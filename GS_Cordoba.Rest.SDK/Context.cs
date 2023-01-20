using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.Cordoba.Rest.SDK.Models;
using GS.Cordoba.Rest.SDK.Interfaces;
using RestSharp;
using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Exceptions;

namespace GS.Cordoba.Rest
{
    public class DummyCache : IBlobCache
    {
        public List<string> GetAllKeys()
        {
            return new List<string>();
        }

        public Task<T> GetOrFetchObject<T>(string key, Func<Task<T>> get, DateTimeOffset absoluteExpiration)
        {
            return get();
        }

        public void Invalidate(string key)
        {
        }

        public void InvalidateAll()
        {
        }
    }

    public class Context : IContext
    {
        public TimeSpan Expiration { get; set; }

        #region protected
        protected string token = null;
        protected string vendor = null;
        protected string endpoint = null;

        protected RestClient client = null;
        protected string clientToken = null;
        protected IBlobCache cache = null;

        protected string getKey(RestRequest request)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(request.Resource + ",");
            foreach (var par in request.Parameters)
            {
                sb.Append(par.Name + "=" + par.Value);
            }

            //System.Diagnostics.Debug.WriteLine(sb.ToString());

            return sb.ToString();
        }

        protected RestClient createClient(params string[] languages)
        {
            if (client != null && this.token == clientToken)
                return client;

            client = new RestClient(this.endpoint);
            if (!string.IsNullOrEmpty(this.token))
                client.AddDefaultParameter("token", this.token, ParameterType.HttpHeader);

            if (!string.IsNullOrEmpty(this.vendor))
                client.AddDefaultParameter("vendor", this.vendor, ParameterType.HttpHeader);

            client.AddDefaultParameter("language", "de-DE");
            clientToken = this.token;


            return client;
        }

        protected async Task<T> executeRequest<T>(RestRequest request, int retryCount = 5) where T : class
        {
            return await cache.GetOrFetchObject<T>(getKey(request),
                async () =>
                {
                    return await new Retry<T>(async () =>
                    {
                        var response = await client.ExecuteAsync<T>(request);
                        if (response.StatusCode != System.Net.HttpStatusCode.OK)
                            throw new Exception("Error while request: " + response.StatusCode + " / " + (response.StatusDescription ?? response.Content));

                        return response.Data;
                    }, retryCount).Execute();
                }, absoluteExpiration: DateTimeOffset.Now + this.Expiration
            );
        }

        protected async Task<T> executeRequestWithoutCache<T>(RestRequest request, int retryCount = 5) where T : class
        {
            return await new Retry<T>(async () =>
            {
                var response = await client.ExecuteAsync<T>(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new Exception("Error while request: " + response.StatusCode + " / " + (response.StatusDescription ?? response.Content));

                return response.Data;
            }, retryCount).Execute();
        }

        protected async Task<string> executeRequestWithoutCache(RestRequest request, int retryCount = 5)
        {
            return await new Retry<string>(async () =>
            {
                var response = await client.ExecuteAsync(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.NoContent)
                    throw new Exception("Error while request: " + response.StatusCode + " / " + (response.StatusDescription ?? response.Content));
                return response.Content;

            }, retryCount).Execute();
        }

        protected async Task executeRequest(RestRequest request)
        {
            await new Retry(async () =>
            {
                var response = await client.ExecuteAsync(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.NoContent)
                    throw new Exception("Error while request: " + response.StatusCode + " / " + (response.StatusDescription ?? response.Content));

            }).Execute();
        }

        protected void executeAndForgetRequest(RestRequest request)
        {
            client.Execute(request);
        }

        protected Task<T> get<T>(string resource, object id) where T : class, new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("id", id.ToString());
            return executeRequest<T>(request);
        }

        protected Task<Paginated<T>> find<T>(string resource, string search, int pageIndex, int pageSize, string orderBy, long[] ids = null) where T : class, new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.GET);
            request.AddParameter("search", search);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("orderBy", orderBy);

            //if (ids != null)
            //    request.AddParameter("ids", VD.Library.Strings.ListStringCombine(ids, m => m.ToString(), ","));

            return executeRequest<Paginated<T>>(request);
        }
        #endregion

        public Action<string> OnExecuteRequest = null;
        public string Token
        {
            get
            {
                return this.token;
            }
            set
            {
                this.token = value;
            }
        }

        public string Endpoint
        {
            get
            {
                return this.endpoint;
            }
            set
            {
                this.endpoint = value;
                this.client = null;
                this.clientToken = null;
            }
        }

        public void InvalidateAll()
        {
            this.cache.InvalidateAll();
        }

        public void Invalidate(string[] keys, int startIndex)
        {
            //if (startIndex < keys.Length)
            //{
            //    this.cache.Invalidate(keys.ElementAt(startIndex))
            //        .Subscribe((d) =>
            //        {
            //            Invalidate(keys, startIndex + 1);
            //        });
            //}
        }

        public void Invalidate(string key)
        {
            Invalidate(this.cache.GetAllKeys().Where(m => m.StartsWith(key)).ToArray(), 0);
        }

        public Context(string connectionString, IBlobCache cache)
        {
            this.cache = cache ?? new DummyCache();
            this.Expiration = TimeSpan.FromMinutes(5);

            foreach (var param in connectionString.Split(','))
            {
                var ss = param.Split('=');
                var paramName = ss[0];
                var paramValue = "";
                foreach (var s in ss.Skip(1))
                {
                    if (!string.IsNullOrEmpty(paramValue))
                        paramValue += "=";
                    paramValue += s;
                }
                switch (paramName)
                {
                    case "endpoint":
                        this.endpoint = paramValue;
                        break;
                    case "token":
                        this.token = paramValue;
                        break;
                    case "vendor":
                        this.vendor = paramValue;
                        break;
                }
            }

            if (string.IsNullOrEmpty(this.endpoint))
                throw new ArgumentNullException("endpint");
            if (string.IsNullOrEmpty(this.token))
                throw new ArgumentNullException("token");
            if (string.IsNullOrEmpty(this.vendor))
                throw new ArgumentNullException("vendor");

        }

        // Languages
        public Task<Paginated<Language.Summary>> FindLanguages(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Language.Summary>("api/languages", search, pageIndex, pageSize, orderBy);
        }

        public Task<Language> GetLanguage(long id)
        {
            return get<Language>("api/languages/{id}", id);
        }

        // Members
        public Task<Paginated<Member.Summary>> FindMembers(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Member.Summary>("api/members", search, pageIndex, pageSize, orderBy);
        }

        public Task<Paginated<Member.Summary>> FindMembersActivated(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return find<Member.Summary>("api/members/activated", search, pageIndex, pageSize, orderBy, ids);
        }

        public Task<Member> GetMember(long id)
        {
            return get<Member>("api/members/{id}", id);
        }

        // Currencies
        public Task<Paginated<Currency.Summary>> FindCurrencies(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Currency.Summary>("api/currencies", search, pageIndex, pageSize, orderBy);
        }

        public Task<Currency> GetCurrency(long id)
        {
            return get<Currency>("api/currencies/{id}", id);
        }

        // Templates
        public Task<Paginated<Template.Summary>> FindTemplates(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Template.Summary>("api/templates", search, pageIndex, pageSize, orderBy);
        }

        public Task<Template> GetTemplate(long id)
        {
            return get<Template>("api/templates/{id}", id);
        }

        // Formats
        public Task<Paginated<Format.Summary>> FindFormats(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Format.Summary>("api/formats", search, pageIndex, pageSize, orderBy);
        }

        public Task<Format> GetFormat(long id)
        {
            return get<Format>("api/formats/{id}", id);
        }

        // Artciles
        public Task<Paginated<Article.Summary>> FindArticles(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Article.Summary>("api/articles", search, pageIndex, pageSize, orderBy);
        }

        public Task<Article> GetArticle(long id)
        {
            return get<Article>("api/articles/{id}", id);
        }

        // Plants
        public Task<Paginated<Article.Summary>> FindPlants(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Article.Summary>("api/files", search, pageIndex, pageSize, orderBy);
        }

        public Task<Plant> GetPlant(long id)
        {
            return get<Plant>("api/plants/{id}", id);
        }

        // Containers
        public Task<Paginated<Container.Summary>> FindContainers(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Container.Summary>("api/containers", search, pageIndex, pageSize, orderBy);
        }

        public Task<Container> GetContainer(long id)
        {
            return get<Container>("api/containers/{id}", id);
        }

        // Galleries
        public Task<Paginated<Gallery.Summary>> FindGalleries(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Gallery.Summary>("api/galleries", search, pageIndex, pageSize, orderBy);
        }

        public Task<Gallery> GetGallery(long id)
        {
            return get<Gallery>("api/galleries/{id}", id);
        }

        public Task<Gallery> GetGalleryByKey(string id)
        {
            return get<Gallery>("api/galleries/key/{id}", id);
        }

        // Folders
        public Task<Paginated<Folder.Summary>> FindFolders(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Folder.Summary>("api/folders", search, pageIndex, pageSize, orderBy);
        }

        public Task<Paginated<Folder.Summary>> FindFolders(long parentFolderID, string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Folder.Summary>("api/folders/hierarchic/" + parentFolderID.ToString(), search, pageIndex, pageSize, orderBy);
        }

        public Task<Folder> GetFolder(long id)
        {
            return get<Folder>("api/folders/{id}", id);
        }

        // News
        public Task<Paginated<News.Summary>> FindNews(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<News.Summary>("api/news", search, pageIndex, pageSize, orderBy);
        }

        public Task<News> GetNews(long id)
        {
            return get<News>("api/news/{id}", id);
        }

        // Signages
        public Task<Paginated<Signage.Summary>> FindSignages(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Signage.Summary>("api/signages", search, pageIndex, pageSize, orderBy);
        }

        public Task<Paginated<Signage.Summary>> FindSignages(long parentFolderID, string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Signage.Summary>("api/signages/hierarchic/" + parentFolderID.ToString(), search, pageIndex, pageSize, orderBy);
        }

        public Task<Signage> GetSignage(long id)
        {
            return get<Signage>("api/signages/{id}", id);
        }

        public Task<BuyOrPrintSignage> BuyOrPrint(long id)
        {
            return get<BuyOrPrintSignage>("api/signages/buyorprint/{id}", id);
        }

        // CalendarItems
        public Task<Paginated<CalendarItem.Summary>> FindCalendarItems(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<CalendarItem.Summary>("api/calendaritems", search, pageIndex, pageSize, orderBy);
        }

        public Task<CalendarItem> GetCalendarItem(long id)
        {
            return get<CalendarItem>("api/calendaritems/{id}", id);
        }

        // PlantPictures
        public Task<Paginated<PlantPicture.Summary>> FindPlantPictures(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<PlantPicture.Summary>("api/plantpictures", search, pageIndex, pageSize, orderBy);
        }

        public Task<PlantPicture> GetPlantPicture(long id)
        {
            return get<PlantPicture>("api/plantpictures/{id}", id);
        }

        // Search
        public Task<PaginatedSearch> Search(string search, int pageIndex, int pageSize, string orderBy, SearchArgs args)
        {
            var client = createClient();
            var request = new RestRequest("api/search", Method.GET);
            request.AddParameter("search", search);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("orderBy", orderBy);

            if (args != null)
            {
                if (args.Types != null)
                {
                    foreach (var type in args.Types)
                    {
                        request.AddParameter("types", type);
                    }
                }
                if (args.Facetts != null)
                {
                    foreach (var facett in args.Facetts)
                    {
                        request.AddParameter("facetts", facett);
                    }
                }

                if (args.SearchFacetts != null)
                {
                    foreach (var facett in args.SearchFacetts)
                    {
                        request.AddParameter("searchfacetts", facett);
                    }
                }

                if (!string.IsNullOrEmpty(args.KeyValue))
                    request.AddParameter("KeyValue", args.KeyValue);
                if (!string.IsNullOrEmpty(args.EAN))
                    request.AddParameter("EAN", args.EAN);
                if (args.ContainerID != null)
                    request.AddParameter("ContainerID", args.ContainerID.Value);
                if (args.MemberID != null)
                    request.AddParameter("MemberID", args.MemberID.Value);
                if (args.DoYouMean)
                    request.AddParameter("DoYouMean", args.DoYouMean);
                if (args.External_COR_ID != null)
                    request.AddParameter("External_COR_ID", args.External_COR_ID.Value);
            }

            return executeRequest<PaginatedSearch>(request);
        }

        // Mailings
        public Task MemberMessage(long id, MemberMessageArgs args)
        {
            var client = createClient();
            var request = new RestRequest("api/mailings/membermessage/{id}", Method.POST);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddUrlSegment("id", id.ToString());
            request.AddJsonBody(args);
            return executeRequest(request);
        }

        // Account
        public Task<string> ValidateAccount(string user, string password, int level = 0)
        {
            var client = createClient();
            var request = new RestRequest("api/account/validate", Method.GET);
            request.AddParameter("user", user);
            request.AddParameter("password", password);
            request.AddParameter("level", level);
            return executeRequestWithoutCache(request, 1);
        }

        public Task<AccountInfo> LoginAccount(string user, string password, int level = 0)
        {
            var client = createClient();
            var request = new RestRequest("api/account/login", Method.GET);
            request.AddParameter("user", user);
            request.AddParameter("password", password);
            request.AddParameter("level", level);
            return executeRequestWithoutCache<AccountInfo>(request, 1);
        }

        public Task<AccountInfo> AccountInfo()
        {
            var client = createClient();
            var request = new RestRequest("api/account/info", Method.GET);
            return executeRequest<AccountInfo>(request);
        }

        // Baskets
        public Task<Paginated<Basket.Summary>> FindBaskets(string search, int pageIndex, int pageSize, string orderBy)
        {
            return find<Basket.Summary>("api/baskets", search, pageIndex, pageSize, orderBy);
        }

        public Task<Paginated<BasketItem>> FindAllPrintList(int pageIndex, int pageSize)
        {
            return find<BasketItem>("api/baskets/printlist", null, pageIndex, pageSize, null);
        }

        public Task<Basket> GetBasket(long id)
        {
            return get<Basket>("api/baskets/{id}", id);
        }

        public Task<Basket.Summary> AddToPrintList(BuyOrPrintSignage model)
        {
            var client = createClient();
            var request = new RestRequest("api/baskets/printlist/add", Method.POST);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddJsonBody(model);
            return executeRequestWithoutCache<Basket.Summary>(request);
        }

        public Task<Basket.Summary> DeleteFromPrintList(long id)
        {
            var client = createClient();
            var request = new RestRequest("api/baskets/printlist/delete/{id}", Method.POST);
            request.AddUrlSegment("id", id.ToString());
            return executeRequestWithoutCache<Basket.Summary>(request);
        }

        public Task<ProgressHub> PrintListPrint(PrintSettings settings)
        {
            var client = createClient();
            var request = new RestRequest("api/baskets/printlist/print", Method.POST);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddJsonBody(settings);
            return executeRequestWithoutCache<ProgressHub>(request);
        }

        public Task<ProgressHub> PrintListPrintTemp(BuyOrPrintSignage model)
        {
            var client = createClient();
            var request = new RestRequest("api/baskets/printlist/temp/print", Method.POST);
            request.AddParameter("Content-Type", "application/json", ParameterType.HttpHeader);
            request.AddJsonBody(model);
            return executeRequestWithoutCache<ProgressHub>(request);
        }

        public Task PrintListClear()
        {
            var client = createClient();
            var request = new RestRequest("api/baskets/printlist/clear", Method.POST);
            return executeRequestWithoutCache(request);
        }

        public string FilesUrl(long id, int width, int height, PictureDisplayMode displayMode = PictureDisplayMode.Cut, ScaleMode scaleMode = ScaleMode.ProportionalBiggest, int revision = 0)
        {
            return new PictureEntityReference(id, this.endpoint + "files/?id=" + id, displayMode, revision).Size(width, height, scaleMode);
        }
    }
}
