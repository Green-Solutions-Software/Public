using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class ArticleKeysRepository : BaseRepository<ArticleKey, ArticleKey.Summary>, Interfaces.IArticleKeysRepository
    {
        public ArticleKeysRepository(Context context)
            :base(context,"api/articlekeys")
        {
            
        }

    }
}