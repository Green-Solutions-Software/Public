using GS.OmniChannelSystem.Rest.SDK.Models;
using System;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IUnitOfWork
    {
        int TimeOut { get; set; }
        string Endpoint { get; set; }
        string Token { get; set; }
        string Name { get; }
        string Glyph { get; }
        string Image { get; }
        bool Import { get; }
        bool Cached { get; set; }
        Type[] Types { get; }
        T Repository<T>() where T : IRepository;

        IOrderTransactionsRepository OrderTransactions {get;}
        ISearchRepository Search {get;}
        INewsRepository News { get; }
        IMembersRepository Members { get; }
        INewsletterMailingRepository NewsletterMailings { get; }
        ISocialMediaPostsRepository SocialMediaPosts { get; }
        IContainersRepository Containers { get; }
        IPagesRepository Pages { get; }
        IPicturesRepository Pictures { get; }
        IReportsRepository Reports { get; }
        IVideosRepository Videos { get; }
        IDocumentsRepository Documents { get; }
        IArticlesRepository Articles { get; }
        IArticleKeysRepository ArticleKeys { get; }
        IJobsRepository Jobs { get; }
        ITaxRatesRepository TaxRates { get; }
        IArticleGroupsRepository ArticleGroups { get; }
        ICustomerGroupsRepository CustomerGroups { get; }
        IArticlePropertiesRepository ArticleProperties { get; }
        ITagsRepository Tags { get; }
        IRightsRepository Rights { get; }
        IRolesRepository Roles { get; }
        IMailTemplatesRepository MailTemplates { get; }
        IFeaturesRepository Features { get; }
        IFeatureTypesRepository FeatureTypes { get; }
        IAccountRepository Account { get; }
        IOrdersRepository Orders { get; }
        IInvoicesRepository Invoices { get; }
        IPaymentMethodsRepository PaymentMethods { get; }
        IShippingMethodsRepository ShippingMethods { get; }
        IShipmentOrdersRepository ShipmentOrders { get; }
        IGalleriesRepository Galleries { get; }
        ILanguagesRepository Languages { get; }
        IStorageRepository Storage { get; }
        ICategoriesRepository Categories { get; }
        IProducersRepository Producers { get; }
        IBrandsRepository Brands { get; }
        IChannelsRepository Channels { get; }
        IResultsRepository Results { get; }
        ITeasersRepository Teasers { get; }
        ICountriesRepository Countries { get; }
        ICurrenciesRepository Currencies { get; }
        ICacheRepository Cache { get; }
        IChainStoresRepository ChainStores { get; }
        IPricelistItemsRepository PricelistItems { get; }

        string Files(long fileId, int width, int height, StretchMode? stretchMode = StretchMode.ProportionalExact);
        string Files(long fileId);

        T Refresh<T>(Func<IUnitOfWork, T> func);
        T Invalidate<T>(Func<IUnitOfWork, T> func);
        void Async<T>(Func<IUnitOfWork, T> func, Action<T> resultFunc);
    }
}
