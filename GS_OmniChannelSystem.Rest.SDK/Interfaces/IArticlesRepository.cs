using GS.OmniChannelSystem.Rest.SDK.Models;
using GS.PflanzenCMS.Rest.SDK.Args;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IArticlesRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Article, GS.OmniChannelSystem.Rest.SDK.Models.Article.Summary>
    {
        Dialog Dialog(long id);
        Article.Summary Create(Article entity, bool importExternal, bool compareNameSecondary = false);
        FoundLinkTarget LinkTarget(string extkey, string info = null);
        Job CreatePatches(ArticleKey.Patch[] value, string external_key, string mode = "available", bool dontRemove = true);
        Job CreateAvailabilities(long? id, Availability[] value, bool complete, bool finished = false);
        Job CreateAvailabilities(Availability[] value, bool complete, bool finished = false);
        bool Transactions(ArticleTransactionArgs[] transactions, bool immediateIndex = true);
    }
}
