using GS.OmniChannelSystem.Rest.SDK.Models;
using System.Collections.Generic;
using System.Linq;
using GS.OmniChannelSystem.Rest.SDK.Interfaces;
using GS.PflanzenCMS.Rest.SDK.Args;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ArticlesRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Article, GS.OmniChannelSystem.Rest.SDK.Models.Article.Summary>, IArticlesRepository
    {
        public ArticlesRepository(Context context)
            :base(context,"api/articles")
        {
            
        }

        public Dialog Dialog(long id)
        {
            return this.context.GetArticleDialog(id);
        }

        public Article.Summary Create(Article entity, bool importExternal, bool compareNameSecondary = false)
        {
            var dict = new Dictionary<string, object>();
            dict.Add("importExternal", importExternal);
            dict.Add("compareNameSecondary", compareNameSecondary);
            return this.context.Post<Article, Article.Summary>(this.resource+"/create", entity, null, dict);
        }

        public FoundLinkTarget LinkTarget(string extkey, string info = null)
        {
            var dict = new Dictionary<string, object>();
            dict["extkey"] = extkey;
            dict["info"] = info;
            return this.context.Post<FoundLinkTarget>(this.resource + "/create/linktarget", dict);
        }

        public bool Transactions(ArticleTransactionArgs[] transactions, bool immediateIndex = true)
        {
            this.context.Post<List<ArticleTransactionArgs>, object>(this.resource + "/transaction", transactions.ToList());
            return true;
        }

        public Job CreatePatches(ArticleKey.Patch[] value, string external_key, string mode = "available", bool dontRemove = true)
        {
            return this.context.CreateArticleKeyPatches(value, external_key, mode, dontRemove);
        }

        public Job CreateAvailabilities(long? id, Availability[] value, bool complete, bool finished = false)
        {
            return this.context.CreateAvailabilities(id, value, complete, finished);
        }

        public Job CreateAvailabilities(Availability[] value, bool complete, bool finished = false)
        {
            return CreateAvailabilities(null, value, complete, finished);
        }

    }
}