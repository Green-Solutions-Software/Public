using GS.OmniChannelSystem.Rest.SDK.Interfaces;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class FieldsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Field, GS.OmniChannelSystem.Rest.SDK.Models.Field.Summary>, IFieldsRepository
    {
        public FieldsRepository(Context context)
            :base(context, "api/fields")
        {
            
        }
    }
}