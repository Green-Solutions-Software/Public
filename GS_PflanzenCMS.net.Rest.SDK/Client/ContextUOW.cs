using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GS.PflanzenCMS.Rest.SDK.Interfaces;
using GS.PflanzenCMS.Rest.SDK.Models;

namespace GS.PflanzenCMS.Rest.SDK.Client
{
    public class ContextUOW : IUnitOfWork, IDisposable
    {

        public Context Context { get; set; }

        public Action<string> OnExecuteRequest
        {
            get
            {
                return this.Context.OnExecuteRequest;
            }
            set
            {
                this.Context.OnExecuteRequest = value;
            }
        }

        public int TimeOut
        {
            get
            {
                return Context.TimeOut;
            }
            set
            {
                Context.TimeOut = value;
            }
        }

        public string Endpoint
        {
            get
            {
                return this.Context.Endpoint;
            }
            set
            {
                this.Context.Endpoint = value;
            }
        }

        public string Name
        {
            get
            {
                return this.Context.Name;
            }
        }

        public string Glyph
        {
            get
            {
                return this.Context.Glyph;
            }
            set
            {
                this.Context.Glyph = value;
            }
        }

        public string Image
        {
            get
            {
                return this.Context.Image;
            }
            set
            {
                this.Context.Image = value;
            }
        }

        public string Language
        {
            get
            {
                return this.Context.Language;
            }
            set
            {
                this.Context.Language = value;
            }
        }

        public Type[] Types 
        {
            get
            {
                return this.Context.Types;
            }
        }

        public bool Import { get; set; }

        public bool Cached
        {
            get
            {
                return this.Context.Cached;
            }
            set
            {
                this.Context.Cached = value;
            }
        }

        public string Token
        {
            get
            {
                return this.Context.Token;
            }
            set
            {
                this.Context.Token = value;
            }
        }

        public IOrderTransactionsRepository OrderTransactions
        {
            get
            {
                return new OrderTransactionsRepository(this.Context);
            }
        }

        public ISearchRepository Search
        {
            get
            {
                return new SearchRepository(this.Context);
            }
        }        

        public INewsRepository News
        {
            get
            {
                return new NewsRepository(this.Context);
            }
        }

        public INewsletterMailingRepository NewsletterMailings
        {
            get
            {
                return new NewsletterMailingsRepository(this.Context);
            }
        }

        public ISocialMediaPostsRepository SocialMediaPosts
        {
            get
            {
                return new SocialMediaPostsRepository(this.Context);
            }
        }

        public IMembersRepository Members
        {
            get
            {
                return new MembersRepository(this.Context);
            }
        }

        public IDocumentsRepository Documents
        {
            get
            {
                return new DocumentsRepository(this.Context);
            }
        }

        public IContainersRepository Containers
        {
            get
            {
                return new ContainersRepository(this.Context);
            }
        }

        public ICountriesRepository Countries
        {
            get
            {
                return new CountriesRepository(this.Context);
            }
        }

        public ICurrenciesRepository Currencies
        {
            get
            {
                return new CurrenciesRepository(this.Context);
            }
        }

        public IPagesRepository Pages
        {
            get
            {
                return new PagesRepository(this.Context);
            }
        }

        public IReportsRepository Reports
        {
            get
            {
                return new ReportsRepository(this.Context);
            }
        }

        public IVideosRepository Videos
        {
            get
            {
                return new VideosRepository(this.Context);
            }
        }

        public IArticlesRepository Articles
        {
            get
            {
                return new ArticlesRepository(this.Context);
            }
        }

        public IJobsRepository Jobs
        {
            get
            {
                return new JobsRepository(this.Context);
            }
        }

        public IArticleKeysRepository ArticleKeys
        {
            get
            {
                return new ArticleKeysRepository(this.Context);
            }
        }

        public IVouchersRepository Vouchers
        {
            get
            {
                return new VouchersRepository(this.Context);
            }
        }

        public ITaxRatesRepository TaxRates
        {
            get
            {
                return new TaxRatesRepository(this.Context);
            }
        }

        public IArticleGroupsRepository ArticleGroups
        {
            get
            {
                return new ArticleGroupsRepository(this.Context);
            }
        }

        public ICustomerGroupsRepository CustomerGroups
        {
            get
            {
                return new CustomerGroupsRepository(this.Context);
            }
        }

        public IArticlePropertiesRepository ArticleProperties
        {
            get
            {
                return new ArticlePropertiesRepository(this.Context);
            }
        }

        public ITagsRepository Tags
        {
            get
            {
                return new TagsRepository(this.Context);
            }
        }

        public IPicturesRepository Pictures
        {
            get
            {
                return new PicturesRepository(this.Context);
            }
        }

        public ITimelinesRepository Timelines
        {
            get
            {
                return new TimelinesRepository(this.Context);
            }
        }

        public ILeafletsRepository Leaflets
        {
            get
            {
                return new LeafletsRepository(this.Context);
            }
        }

        public IRightsRepository Rights
        {
            get
            {
                return new RightsRepository(this.Context);
            }
        }

        public IRolesRepository Roles
        {
            get
            {
                return new RolesRepository(this.Context);
            }
        }

        public IMailTemplatesRepository MailTemplates
        {
            get
            {
                return new MailTemplatesRepository(this.Context);
            }
        }

        public IFeaturesRepository Features
        {
            get
            {
                return new FeaturesRepository(this.Context);
            }
        }

        public IFeatureTypesRepository FeatureTypes
        {
            get
            {
                return new FeatureTypesRepository(this.Context);
            }
        }

        public IAccountRepository Account
        {
            get
            {
                return new AccountRepository(this.Context);
            }
        }

        public ILanguagesRepository Languages
        {
            get
            {
                return new LanguagesRepository(this.Context);
            }
        }

        public IOrdersRepository Orders
        {
            get
            {
                return new OrdersRepository(this.Context);
            }
        }

        public IInvoicesRepository Invoices
        {
            get
            {
                return new InvoicesRepository(this.Context);
            }
        }

        public IPaymentMethodsRepository PaymentMethods
        {
            get
            {
                return new PaymentMethodsRepository(this.Context);
            }
        }

        public IShippingMethodsRepository ShippingMethods
        {
            get
            {
                return new ShippingMethodsRepository(this.Context);
            }
        }
        public IShipmentOrdersRepository ShipmentOrders
        {
            get
            {
                return new ShipmentOrdersRepository(this.Context);
            }
        }

        public IMenusRepository Menus
        {
            get
            {
                return new MenusRepository(this.Context);
            }
        }

        public IGalleriesRepository Galleries
        {
            get
            {
                return new GalleriesRepository(this.Context);
            }
        }

        public IPricelistsRepository Pricelists
        {
            get
            {
                return new PricelistsRepository(this.Context);
            }
        }

        public ICategoriesRepository Categories
        {
            get
            {
                return new CategoriesRepository(this.Context);
            }
        }

        public IResultsRepository Results
        {
            get
            {
                return new ResultsRepository(this.Context);
            }
        }

        public IProducersRepository Producers
        {
            get
            {
                return new ProducersRepository(this.Context);
            }
        }

        public IBrandsRepository Brands
        {
            get
            {
                return new BrandsRepository(this.Context);
            }
        }

        public IChannelsRepository Channels
        {
            get
            {
                return new ChannelsRepository(this.Context);
            }
        }

        public ITeasersRepository Teasers
        {
            get
            {
                return new TeasersRepository(this.Context);
            }
        }

        public IChainStoresRepository ChainStores
        {
            get
            {
                return new ChainStoresRepository(this.Context);
            }
        }

        public IStorageRepository Storage
        {
            get
            {
                return new StorageRepository(this.Context);
            }
        }
        public ICacheRepository Cache
        {
            get
            {
                return new CacheRepository(this.Context);
            }
        }

        public ContextUOW(string connectionString, string language = null)
        {
            createContext(connectionString, language);
        }

        public ContextUOW(ContextUOW other, string language = null)
        {
            createContext(other, language);
        }

        protected void createContext(string connectionString, string language)
        {
            this.Context = new Context(connectionString, language);
        }

        protected void createContext(ContextUOW other, string language)
        {
            this.Context = new Context(other.Context, language);
        }

        public T Repository<T>() where T : IRepository
        {
            var formTypes = (from t in typeof(T).Assembly.GetExportedTypes()
                             where t.GetInterfaces().Contains(typeof(T))
                             && !t.IsGenericType && !t.IsInterface
                             orderby t.Name
                             select t).ToList();
            if (formTypes.Count == 0)
                throw new Exception("Repository not found: " + typeof(T).Name);
            if (formTypes.Count > 1)
                throw new Exception("Repository not unique: " + typeof(T).Name);

            return (T)Activator.CreateInstance(formTypes.First(), new object[] { this.Context });
        }

        public string Files(long fileId, int width, int height, StretchMode? stretchMode = StretchMode.ProportionalExact)
        {
            return Context.Files(fileId, width, height, stretchMode);
        }

        public string Files(long fileId)
        {
            return Context.Files(fileId);
        }

        public string EventLog()
        {
            return Context.EventLog();
        }

        public ContextUOW Clone(string language)
        {
            return new ContextUOW(this, language);
        }


        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
          
        }

        #endregion

        // Invalidate
        public virtual T Refresh<T>(Func<IUnitOfWork, T> func)
        {
            try
            {
                this.Context.Refresh = true;
                return func(this);
            }
            finally
            {
                this.Context.Refresh = false;
            }

        }

        public virtual T Invalidate<T>(Func<IUnitOfWork, T> func)
        {
            try
            {
                this.Context.Invalidate = true;
                return func(this);
            }
            finally
            {
                this.Context.Invalidate = false;
            }

        }

        public virtual void Async<T>(Func<IUnitOfWork, T> func, Action<T> resultFunc)
        {
            new System.Threading.Thread(() =>
            {
                T result = default(T);
                Exception e = null;
                try
                {
                    result = func(this);
                }
                catch (Exception ex)
                {
                    //log.Error("Fehler", ex);
                    e = ex;
                }
                resultFunc(result);
            }).Start();
        }

    }
}
