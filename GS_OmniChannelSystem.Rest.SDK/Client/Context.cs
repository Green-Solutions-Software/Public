using GS.OmniChannelSystem.Rest.SDK.Api.Args;
using GS.OmniChannelSystem.Rest.SDK.Classes;
using GS.OmniChannelSystem.Rest.SDK.Exceptions;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;
using GS.OmniChannelSystem.Rest.SDK.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class Context 
    {
        #region protected

        protected string token = null;
        protected string name = "CMS";
        protected string vendor = null;
        protected string glyph = "Context";
        protected string image = null;
        protected string endpoint = null;
        protected string language = System.Threading.Thread.CurrentThread.CurrentCulture.Name;
        protected string appKey = null;
        protected long? channelId = null;
        protected Dictionary<string, object> cache = new Dictionary<string, object>();
        protected RestClient client = null;

        public int TimeOut { get; set; }
        public string Endpoint
        {
            get
            {
                return this.endpoint;
            }
            set
            {
                this.endpoint = value;
                client = null;
            }
        }

        public string Token
        {
            get
            {
                return this.token;
            }
            set
            {
                this.token = value;
                client = null;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }


        public Action<string> OnExecuteRequest = null;

        protected RestClient createClient(bool needToken = true)
        {
            if (client != null)
                return client;

            if (string.IsNullOrEmpty(this.endpoint))
                throw new ArgumentNullException("endpoint");
            if (string.IsNullOrEmpty(this.token) && needToken)
                throw new ArgumentNullException("token");

            client = new RestClient(this.endpoint);
            if (!string.IsNullOrEmpty(this.token))
                client.AddDefaultHeader("token", this.token);

            if (!string.IsNullOrEmpty(this.vendor))
                client.AddDefaultHeader("vendor", this.vendor);

            client.AddDefaultHeader("language", this.language);
            return client;
        }

        protected string getKey(RestRequest request)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(request.Resource);
            foreach (var par in request.Parameters)
            {
                sb.Append(par.ToString());
            }

            return sb.ToString();
        }

        protected T executeRequest<T>(RestRequest request, bool nullAllowed = false) where T : class,new()
        {
            var isJson = request.RequestFormat == DataFormat.Json;

            var key = getKey(request);
            if (this.Cached && !isJson && this.cache.ContainsKey(key) && request.Method==Method.GET && !this.Refresh)
                return this.cache[key] as T;

            if (this.Invalidate)
            {
                this.cache.Remove(key);
                return default(T);
            }

            client.Timeout = TimeOut;

            return new Retry<T>(() =>
            {
                if (OnExecuteRequest != null)
                    OnExecuteRequest(request.Resource);

                var response = client.Execute<T>(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new RequestException(client, request, response, response.StatusCode, response.ErrorMessage, response.Content);

                if (response.Data == null)
                {
                    if (nullAllowed)
                        return null;
                    throw new RequestException(client, request, response, response.StatusCode, response.ErrorMessage, response.Content);
                }

                if (this.Cached && !isJson)
                    this.cache[key] = response.Data;

                return response.Data;
            }).Execute();


        }

        protected string executeRequestContent(RestRequest request)
        {

            client.Timeout = TimeOut;

            return new Retry<string>(() =>
            {
                if (OnExecuteRequest != null)
                    OnExecuteRequest(request.Resource);

                var response = client.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK)
                    throw new RequestException(client, request, response, response.StatusCode, response.ErrorMessage, response.Content);

                return response.Content;
            }).Execute();
        }

        protected void executeRequest(RestRequest request)
        {
            new Retry(() =>
            {
                if (OnExecuteRequest != null)
                    OnExecuteRequest(request.Resource);

                var response = client.Execute(request);
                if (response.StatusCode != System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.NoContent)
                    throw new RequestException(client, request, response, response.StatusCode, response.ErrorMessage, response.Content);

            }).Execute();
        }

        protected void executeAndForgetRequest(RestRequest request)
        {
            client.ExecuteAsync(request, (response) =>
            {
                //if (response.StatusCode != System.Net.HttpStatusCode.OK)
                //    throw new Exception("Error while request: " + response.StatusCode + " / " + (response.ErrorMessage ?? response.Content));
            });
        }

        protected Paginated<T> find<T>(string resource, string search, int pageIndex, int pageSize, string orderBy, string filter = null, string ids = null, Dictionary<string,object> parameters = null) where T : class,new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.GET);
            request.AddParameter("search", search);
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            request.AddParameter("orderBy", orderBy);
            if(filter != null)
                request.AddParameter("filter", filter);
            if (ids != null)
                request.AddParameter("ids", ids);
            if (parameters!=null)
            {
                foreach(var parameter in parameters)
                    request.AddParameter(parameter.Key, parameter.Value);
            }
            
            return executeRequest<Paginated<T>>(request);
        }

        protected T get<T>(string resource, object id, Dictionary<string, object> parameters = null, bool nullAllowed = false) where T : class,new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("id", id.ToString());
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    request.AddParameter(parameter.Key, parameter.Value);
            }


            return executeRequest<T>(request, nullAllowed);
        }

        protected T get<T>(string resource, Dictionary<string, object> parameters = null, bool nullAllowed = false) where T : class, new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.GET);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    request.AddParameter(parameter.Key, parameter.Value);
            }


            return executeRequest<T>(request, nullAllowed);
        }

        protected T getByKey<T>(string resource, string key, Dictionary<string, object> parameters = null, bool nullAllowed = false) where T : class, new()
        {
            var client = createClient();
            var request = new RestRequest(resource+"/key", Method.GET);
            request.AddUrlSegment("key", key);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    request.AddParameter(parameter.Key, parameter.Value);
            }


            return executeRequest<T>(request, nullAllowed);
        }

        protected T put<T>(string resource, object id, T entity, Dictionary<string, object> parameters = null) where T : class, new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.PUT);
            request.AddUrlSegment("id", id.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(entity);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    request.AddParameter(parameter.Key, parameter.Value, ParameterType.QueryString);
            }
            return executeRequest<T>(request);
        }

        protected S post<T,S>(string resource, T entity, Dictionary<string, object> parameters = null) 
            where T : class, new()
            where S : class, new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(entity);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    request.AddParameter(parameter.Key, parameter.Value);
            }

            return executeRequest<S>(request);
        }

        protected S post<S>(string resource, Dictionary<string, object> parameters = null)
            where S : class, new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.POST);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    request.AddParameter(parameter.Key, parameter.Value, ParameterType.QueryString);
            }

            return executeRequest<S>(request);
        }

        protected U post<T, S, U>(string resource, T entity, Dictionary<string, object> parameters = null)
            where T : class, new()
            where S : class, new()
            where U : class, new()
        {
            var client = createClient();
            client.AddDefaultHeader("type", typeof(U).Name);

            var request = new RestRequest(resource, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(entity);
            if (parameters != null)
            {
                foreach (var parameter in parameters)
                    request.AddParameter(parameter.Key, parameter.Value);
            }

            return executeRequest<U>(request);
        }

        protected T get<T>(string resource, object id, int pageIndex, int pageSize) where T : class,new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.GET);
            request.AddUrlSegment("id", id.ToString());
            request.AddParameter("pageIndex", pageIndex);
            request.AddParameter("pageSize", pageSize);
            return executeRequest<T>(request);
        }

        protected T getForKey<T>(string resource, string key) where T : class,new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.POST);
            request.Timeout = 480000;
            request.AddQueryParameter("key", key);
            return executeRequest<T>(request);
        }
        #endregion

        public string Glyph
        {
            get
            {
                return this.glyph;
            }
            set
            {
                this.glyph = value;
            }
        }

        public long? ChannelID
        {
            get
            {
                return this.channelId;
            }
            set
            {
                this.channelId = value;
            }
        }

        public string Image
        {
            get
            {
                return this.image;
            }
            set
            {
                this.image = value;
            }
        }

        public string Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;
            }
        }
        
        public bool Cached { get; set; }

        public bool Refresh { get; set; }
        public bool Invalidate { get; set; }

        public Type[] Types { get; internal set; }


        public Context(string connectionString, string language)
            :base()
        {
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
                    case "name":
                        this.name = paramValue;
                        break;
                    case "glyph":
                        this.glyph = paramValue;
                        break;
                    case "channel":
                        this.channelId = Convert.ToInt64(channelId);
                        break;
                    case "image":
                        this.image = paramValue;
                        break;
                }
            }

            //if (string.IsNullOrEmpty(this.endpoint))
            //    throw new ArgumentNullException("endpoint");
            //if (string.IsNullOrEmpty(this.token))
            //    throw new ArgumentNullException("token");

            if (language != null)
                this.language = language;

        }

        public Context(Context other)
            : base()
        {
            this.endpoint = other.endpoint;
            this.token = other.token;
            this.vendor = other.vendor;
            this.name = other.name;
            this.glyph = other.glyph;
            this.channelId = other.channelId;
            this.image = other.image;
            this.language = other.language;
        }

        public Context(Context other, string language)
            :this(other)
        {
            this.language = language;
        }

        public Order UpdateOrderTransactionStatus(long id, OrderTransactionArgs args)
        {
            var client = createClient();
            var request = new RestRequest("api/orders/transactions/status/{id}", Method.POST);
            request.AddUrlSegment("id", id.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(args);
            return executeRequest<Order>(request);
        }

        public Job UpdateOrderTransactionStatusAsync(long id, OrderTransactionArgs args)
        {
            var client = createClient();
            var request = new RestRequest("api/orders/transactions/status/async/{id}", Method.POST);
            request.AddUrlSegment("id", id.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(args);
            return executeRequest<Job>(request);
        }

        public T UpdateOrderTransactionStatusAsync<T>(long id, OrderTransactionArgs args) where T : Job,new()
        {
            var client = createClient();
            var request = new RestRequest("api/orders/transactions/status/async/{id}", Method.POST);
            request.AddUrlSegment("id", id.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(args);
            return executeRequest<T>(request);
        }

        public OrderUpdates[] UpdateOrderTransactionPositionStatus(long id, OrderTransactionPositions positions)
        {
            var client = createClient();
            var request = new RestRequest("api/orders/transactions/status/positions/{id}", Method.POST);
            request.AddUrlSegment("id", id.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(positions);
            return executeRequest<List<OrderUpdates>>(request).ToArray();
        }

        // Cache
        public void ClearCache()
        {
            var client = createClient();
            var request = new RestRequest("api/cache/clear", Method.POST);
            if (executeRequestContent(request) != "\"OK\"")
                throw new Exception("Error clear cache");
        }

        // Suche
        public Paginated<Item> Search(string search, int pageIndex, int pageSize, string orderBy, SearchArgs args)
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
                if (!string.IsNullOrEmpty(args.KeyValue))
                    request.AddParameter("KeyValue", args.KeyValue);
                if (!string.IsNullOrEmpty(args.EAN))
                    request.AddParameter("EAN", args.EAN);
                if (args.AvailableForDropShipping!=null)
                    request.AddParameter("AvailableForDropShipping", args.AvailableForDropShipping);
                if (args.ContainerID!=null)
                    request.AddParameter("ContainerID", args.ContainerID.Value);
                request.AddParameter("WithPhoto", args.WithPhoto);
                if (args.External_COR_ID != null)
                    request.AddParameter("External_COR_ID", args.External_COR_ID.Value);
            }

            return executeRequest<Paginated<Item>>(request);
        }

        public Paginated<T> FindAll<T>(string resource, string search, int pageIndex, int pageSize, string orderBy, string filter = null, string ids = null) where T:class,new()
        {
            return find<T>(resource, search, pageIndex, pageSize, orderBy, filter, ids);
        }

        public T Get<T>(string resource, long id, string[] properties = null) where T : class, new()
        {
            Dictionary<string, object> dict = null;
            if(properties!=null)
            {
                dict = new Dictionary<string, object>();
                dict.Add("properties", toString(properties));
            }

            return get<T>(resource, id, dict, true);
        }

        public T Get<T>(string resource, string[] properties = null) where T : class, new()
        {
            Dictionary<string, object> dict = null;
            if (properties != null)
            {
                dict = new Dictionary<string, object>();
                dict.Add("properties", toString(properties));
            }
        
            return get<T>(resource, dict, true);
        }

        public T Get<T>(string resource, long[] ids, string[] properties = null) where T : class, new()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            dict.Add("ids", GS.OmniChannelSystem.Rest.SDK.Classes.Strings.ListStringCombine(ids, m => m.ToString(), ","));
            if (properties != null)
                dict.Add("properties", toString(properties));

            return get<T>(resource, 0, dict, true);
        }

        public T GetByKey<T>(string resource, string key, string[] properties = null) where T : class, new()
        {
            Dictionary<string, object> dict = null;
            if (properties != null)
            {
                dict = new Dictionary<string, object>();
                dict.Add("properties", toString(properties));
            }

            return getByKey<T>(resource, key, dict, true);
        }

        public T Put<T>(string resource, long id, T entity, string[] properties = null) where T : class, new()
        {
            Dictionary<string, object> dict = null;
            if (properties != null)
            {
                dict = new Dictionary<string, object>();
                dict.Add("properties", toString(properties));
            }

            return put<T>(resource, id, entity, dict);
        }

        public S Post<T,S>(string resource, T entity, string[] properties = null, Dictionary<string, object> dict = null) 
            where T : class, new()
            where S : class, new()
        {
            if (properties != null)
            {
                if(dict == null)
                    dict = new Dictionary<string, object>();
                dict.Add("properties", toString(properties));
            }

            return post<T,S>(resource, entity, dict);
        }

        public S Post<S>(string resource, Dictionary<string, object> dict = null)
            where S : class, new()
        {
            return post<S>(resource, dict);
        }

        public U Post<T, S, U>(string resource, T entity, string[] properties = null, Dictionary<string, object> dict = null)
            where T : class, new()
            where S : class, new()
            where U : class, new()
        {
            if (properties != null)
            {
                if (dict == null)
                    dict = new Dictionary<string, object>();
                dict.Add("properties", toString(properties));
            }

            return post<T, S, U>(resource, entity, dict);
        }


        private static string toString(string[] properties)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var property in properties)
            {
                if (sb.Length > 0)
                    sb.Append(",");
                sb.Append(property);
            }

            return sb.ToString();
        }

        public void Delete<T>(string resource, long id, bool permanent = false) where T : class, new()
        {
            var client = createClient();
            var request = new RestRequest(resource, Method.DELETE);
            request.AddUrlSegment("id", id.ToString());
            if (permanent)
                request.AddParameter("permanent", permanent);
            executeRequest(request);
        }

        // Storage
        public UrlResult GetStorageUrl(long id, int width, int height)
        {
            return get<UrlResult>("api/storage/url/{id}?width="+width+"&height="+height, id);
        }

        // Orders
        public CreateOrderArgs.Result CreateOrder(CreateOrderArgs order)
        {
            var client = createClient();
            var request = new RestRequest("api/orders/create", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(order);
            return executeRequest<CreateOrderArgs.Result>(request);
        }

        public CreateCashdeskArgs.Result CreateCashDesk(CreateCashdeskArgs order)
        {
            var client = createClient();
            var request = new RestRequest("api/orders/create/cashdesk", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(order);
            return executeRequest<CreateCashdeskArgs.Result>(request);
        }

        public Paginated<Order.Summary> FindAllOrdersForShop(string search, int pageIndex, int pageSize, string orderBy, string filter = null)
        {
            return find<Order.Summary>("api/orders/all", search, pageIndex, pageSize, orderBy, filter);
        }

        public GS.OmniChannelSystem.Rest.SDK.Models.Dialog GetOrdersDialog()
        {
            var client = createClient();
            var request = new RestRequest("api/orders/dialog", Method.POST);
            return executeRequest<GS.OmniChannelSystem.Rest.SDK.Models.Dialog>(request);
        }

        public ShipmentOrder.Summary CreateShipmentOrderFastForOrder(long id, long transactionId, CreateShipmentOrderArgs args)
        {
            var client = createClient();
            var request = new RestRequest("api/shipmentorders/order/create/fast/{id}/{transactionId}", Method.POST);
            request.AddUrlSegment("id", id.ToString());
            request.AddUrlSegment("transactionId", transactionId.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(args);

            return executeRequest<ShipmentOrder.Summary>(request);
        }

        public string GetShipmentOrderLabel(long id, ShipmentLabelType type = ShipmentLabelType.Shipment)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("vendor", this.vendor);
            webClient.Headers.Add("token", this.token);
            var file = System.IO.Path.GetTempFileName() + ".pdf";
            webClient.DownloadFile(Web.Combine(this.endpoint, "api/shipmentorders/items/label/" + id + "?type=" + type), file);
            return file;
        }

        // Channels
        public Channel GetMonitor(Channel value)
        {
            var dict = new Dictionary<string, object>();
            return this.Post<Channel, Channel>("api/channels/monitor", value, null, dict);
        }

        public Paginated<GallerySlide> FindMonitorSlides(long id, int pageIndex = 0, int pageSize = 100, string search = null, string orderBy = null, string filter = null)
        {
            return find<GS.OmniChannelSystem.Rest.SDK.Models.GallerySlide>("api/channels/monitor/slides/" + id, search, pageIndex, pageSize, orderBy, filter);
        }

        public GS.OmniChannelSystem.Rest.SDK.Models.Dialog GetMonitorPlayer(long id)
        {
            var client = createClient();
            var request = new RestRequest("api/channels/monitor/player/{id}", Method.POST);
            request.AddUrlSegment("id", id.ToString());
            return executeRequest<GS.OmniChannelSystem.Rest.SDK.Models.Dialog>(request);
        }

        // Categories

        public GS.OmniChannelSystem.Rest.SDK.Models.Category GetCategoryByKey(string key)
        {
            throw new NotImplementedException();
        }

        // Countries
        public GS.OmniChannelSystem.Rest.SDK.Models.Country GetCountry(string key)
        {
            throw new NotImplementedException();
        }

        // Producers

        public GS.OmniChannelSystem.Rest.SDK.Models.Producer GetProducerByKey(string key)
        {
            throw new NotImplementedException();
        }


        // Article Groups

        public GS.OmniChannelSystem.Rest.SDK.Models.ArticleGroup GetArticleGroupByKey(string key)
        {
            throw new NotImplementedException();
        }

        // Articles
        public GS.OmniChannelSystem.Rest.SDK.Models.Dialog GetArticleDialog(long id)
        {
            var client = createClient();
            var request = new RestRequest("api/articles/dialog/{id}", Method.POST);
            request.AddUrlSegment("id", id.ToString());
            return executeRequest<GS.OmniChannelSystem.Rest.SDK.Models.Dialog>(request);
        }

        public Job CreateArticleKeyPatches(ArticleKey.Patch[] patches, string external_key, string mode, bool dontRemove)
        {
            var client = createClient();
            var request = new RestRequest("api/articles/keys/patches", Method.POST);
            request.AddQueryParameter("external_key", external_key);
            request.AddQueryParameter("mode", mode);
            request.AddQueryParameter("dontRemove", dontRemove.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(patches);
            return executeRequest<Job>(request);
        }

        public Job CreateAvailabilities(long? id, Availability[] value, bool complete, bool finished = false)
        {
            var client = createClient();
            var request = new RestRequest("api/articles/availabilities", Method.POST);
            if(id != null)
                request.AddQueryParameter("id", id.ToString());
            request.AddQueryParameter("complete", complete.ToString());
            request.AddQueryParameter("finished", finished.ToString());
            request.RequestFormat = DataFormat.Json;
            request.AddBody(value);
            return executeRequest<Job>(request);
        }

        // Pictures
        public Picture UploadPicture(UploadArgs args)
        {
            var client = createClient();
            var request = new RestRequest("api/pictures/upload", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(args);
            return executeRequest<Picture>(request);
        }

        // Pages

        public Paginated<GS.OmniChannelSystem.Rest.SDK.Models.Page.Summary> FindPages(long? parentId, string search, int pageIndex, int pageSize, string orderBy, string filter = null)
        {
            return find<GS.OmniChannelSystem.Rest.SDK.Models.Page.Summary>("api/pages/childs/" + (parentId!=null ? parentId.Value : 0), search, pageIndex, pageSize, orderBy, filter);
        }

        // Containers
        public GS.OmniChannelSystem.Rest.SDK.Models.Container GetContainerByKey(string key)
        {
            return get<GS.OmniChannelSystem.Rest.SDK.Models.Container>("api/containers/key/{id}", key);
        }

        // Galleries

        public GS.OmniChannelSystem.Rest.SDK.Models.Gallery GetGalleryByKey(string key)
        {
            return get<GS.OmniChannelSystem.Rest.SDK.Models.Gallery>("api/galleries/key/{id}", key);
        }

        // Bilder
        public string Files(long fileId, int width, int height, StretchMode? stretchMode = StretchMode.ProportionalSmallest)
        {
            return string.Format("{0}/Files?id={1}&width={2}&height={3}&stretchMode={4}", this.endpoint, fileId, width, height, stretchMode);
        }

        public string Files(long fileId)
        {
            return string.Format("{0}/Files?id={1}", this.endpoint, fileId);
        }

        // Account
        public AccountInfo AccountInfo()
        {
            var client = createClient();
            var request = new RestRequest("api/account/info", Method.GET);
            return executeRequest<AccountInfo>(request);
        }

        // EventLogs
        public string EventLog()
        {
            var client = createClient();
            var request = new RestRequest("api/system/eventlog", Method.GET);
            return executeRequestContent(request);
        }

        public string ValidateAccount(string user, string password)
        {
            var client = createClient();
            var request = new RestRequest("api/account/validate", Method.POST);
            request.AddParameter("user", user, ParameterType.QueryString);
            request.AddParameter("password", password, ParameterType.QueryString);
            var token = executeRequestContent(request);
            return token.Substring(1,token.Length-2);
        }
        public AccountInfo LoginAccount(string user, string password, int level = 0, bool automaticPasswordException = true)
        {
            var client = createClient(false);
            var request = new RestRequest("api/account/login", Method.GET);
            request.AddParameter("user", user, ParameterType.QueryString);
            request.AddParameter("password", password, ParameterType.QueryString);
            request.AddParameter("level", level, ParameterType.QueryString);
            request.AddParameter("automaticPasswordException", automaticPasswordException, ParameterType.QueryString);
            return executeRequest<AccountInfo>(request);
        }

        // Documents
        public string GetDocumentForOrder(long orderId, DocumentationType type)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("vendor", this.vendor);
            webClient.Headers.Add("token", this.token);
            var file = System.IO.Path.GetTempFileName() + ".pdf";
            webClient.DownloadFile(Web.Combine(this.endpoint, "/api/documents/order/" + orderId + "/" + type), file);
            return file;
        }

        public string GetDocumentForOrders(long[] orderId, DocumentationType type)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("vendor", this.vendor);
            webClient.Headers.Add("token", this.token);
            var file = System.IO.Path.GetTempFileName() + ".pdf";
            var url = Web.Combine(this.endpoint, "api/public/documents/orders/?id=" + GS.OmniChannelSystem.Rest.SDK.Classes.Strings.ListStringCombine(orderId, m => m.ToString(), ",") + "&type=" + type+"&guid="+Guid.NewGuid().ToString());
            webClient.DownloadFile(url, file);
            return file;
        }

        public string GetDocumentForOrder(long orderId, long transactionId, DocumentationType type)
        {
            var webClient = new WebClient();
            webClient.Headers.Add("vendor", this.vendor);
            webClient.Headers.Add("token", this.token);
            var file = System.IO.Path.GetTempFileName() + ".pdf";
            webClient.DownloadFile(Web.Combine(this.endpoint, "/api/documents/order/" + orderId + "/" + type + "/" + transactionId), file);
            return file;
        }

        // Messages
        public Message SubmitMessage(Message message)
        {
            var client = createClient();
            var request = new RestRequest("api/messages/create", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(message);
            return executeRequest<Message>(request);
        }

        public Message ExecuteMessageWorkflow(long messageId, Workflow workflow)
        {
            var client = createClient();
            var request = new RestRequest("api/messages/"+messageId+"/workflow/execute", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(workflow);
            return executeRequest<Message>(request);
        }

        // Messages
        public List<Workflow> GetMessageWorkflow(long messageId)
        {
            var client = createClient();
            var request = new RestRequest("api/messages/"+ messageId + "/workflow", Method.GET);
            request.RequestFormat = DataFormat.Json;
            return executeRequest<List<Workflow>>(request);
        }

        public void ClearLocalCache()
        {
            this.cache.Clear();
        }

    }
}
