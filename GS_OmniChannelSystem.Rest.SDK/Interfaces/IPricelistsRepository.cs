namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IPricelistsRepository : IRepository<GS.OmniChannelSystem.Rest.SDK.Models.Pricelist, GS.OmniChannelSystem.Rest.SDK.Models.Pricelist.Summary>
    {
        /// <summary>
        /// Resets all items of a pricelist by sending Items as null.
        /// All existing PricelistItems (including PricelistKeys and PricelistPrices) are removed server-side.
        /// </summary>
        /// <param name="id">The ID of the pricelist whose items should be reset.</param>
        /// <returns>The updated pricelist without items.</returns>
        GS.OmniChannelSystem.Rest.SDK.Models.Pricelist ResetItems(long id);
    }
}
