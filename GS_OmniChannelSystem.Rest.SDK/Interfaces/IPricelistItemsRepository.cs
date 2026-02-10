using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Interfaces
{
    public interface IPricelistItemsRepository : IRepository<PricelistItem, PricelistItem.Summary>
    {
        /// <summary>
        /// Adds a single item to a pricelist without removing existing items.
        /// The item is created via POST api/pricelistitems with the Pricelist reference set.
        /// </summary>
        /// <param name="pricelistId">The ID of the target pricelist.</param>
        /// <param name="item">The PricelistItem to add (including Keys and Prices).</param>
        /// <returns>The created PricelistItem as returned by the server.</returns>
        PricelistItem AddItem(long pricelistId, PricelistItem item);

        /// <summary>
        /// Adds a single item to a pricelist (identified by External_Key) without removing existing items.
        /// The item is created via POST api/pricelistitems with the Pricelist reference set by External_Key.
        /// </summary>
        /// <param name="externalKey">The External_Key of the target pricelist.</param>
        /// <param name="item">The PricelistItem to add (including Keys and Prices).</param>
        /// <returns>The created PricelistItem as returned by the server.</returns>
        PricelistItem AddItem(string externalKey, PricelistItem item);

        /// <summary>
        /// Retrieves all items of a specific pricelist (paginated).
        /// Uses the server-side filter "pricelistid" on GET api/pricelistitems.
        /// </summary>
        /// <param name="pricelistId">The ID of the pricelist to query items for.</param>
        /// <param name="search">Optional search term.</param>
        /// <param name="pageIndex">Zero-based page index.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <param name="orderBy">Sort expression.</param>
        /// <returns>A paginated list of PricelistItem summaries.</returns>
        Paginated<PricelistItem.Summary> FindByPricelist(long pricelistId, string search, int pageIndex, int pageSize, string orderBy);
    }
}
