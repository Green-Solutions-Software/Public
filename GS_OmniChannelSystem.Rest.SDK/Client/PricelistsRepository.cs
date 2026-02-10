using GS.OmniChannelSystem.Rest.SDK.Interfaces;
using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class PricelistsRepository : BaseRepository<GS.OmniChannelSystem.Rest.SDK.Models.Pricelist, GS.OmniChannelSystem.Rest.SDK.Models.Pricelist.Summary>, IPricelistsRepository
    {
        public PricelistsRepository(Context context)
            :base(context, "api/pricelists")
        {

        }

        /// <summary>
        /// Resets all items of a pricelist by sending Items as null.
        ///
        /// How it works:
        ///   A PUT request is sent to the pricelist with the "Items" property explicitly set to null.
        ///   The server interprets this as an instruction to remove all existing PricelistItems
        ///   (including subordinate PricelistKeys and PricelistPrices).
        ///
        /// API endpoint: PUT api/pricelists/{id}?properties=Items
        /// Request body: { "Items": null }
        ///
        /// Reference: PricelistsController (BaseRepositoryApiController) + Api.Models.Pricelist.Items
        /// </summary>
        /// <param name="id">The ID of the pricelist whose items should be reset.</param>
        /// <returns>The updated pricelist after the reset.</returns>
        public Pricelist ResetItems(long id)
        {
            var entity = new Pricelist { Items = null };
            return this.Update(id, entity, new[] { "Items" });
        }
    }
}