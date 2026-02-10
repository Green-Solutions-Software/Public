using GS.OmniChannelSystem.Rest.SDK.Interfaces;
using GS.OmniChannelSystem.Rest.SDK.Models;

namespace GS.OmniChannelSystem.Rest.SDK.Client
{
    public class PricelistItemsRepository : BaseRepository<PricelistItem, PricelistItem.Summary>, IPricelistItemsRepository
    {
        public PricelistItemsRepository(Context context)
            : base(context, "api/pricelistitems")
        {

        }

        /// <summary>
        /// Adds a single item to a pricelist without removing existing items.
        ///
        /// How it works:
        ///   A POST request is sent to api/pricelistitems with the PricelistItem payload.
        ///   The Pricelist property is set as an EntityReference to the target pricelist,
        ///   so the server assigns the new item to that pricelist.
        ///   Existing items on the pricelist remain untouched.
        ///
        /// API endpoint: POST api/pricelistitems
        /// Request body: { "Pricelist": { "ID": pricelistId }, "Article": ..., "Keys": [...] }
        ///
        /// Reference: PricelistItemsController.Post + Api.Models.PricelistItem
        /// </summary>
        /// <param name="pricelistId">The ID of the target pricelist.</param>
        /// <param name="item">The PricelistItem to add (including Keys and Prices).</param>
        /// <returns>The created PricelistItem as returned by the server.</returns>
        public PricelistItem AddItem(long pricelistId, PricelistItem item)
        {
            item.Pricelist = new EntityReference { ID = pricelistId };
            return this.Create(item);
        }

        /// <summary>
        /// Adds a single item to a pricelist (identified by External_Key) without removing existing items.
        ///
        /// How it works:
        ///   Same as AddItem(long, PricelistItem), but the pricelist is resolved server-side
        ///   via External_Key instead of ID (using GetByEntityReference).
        ///
        /// API endpoint: POST api/pricelistitems
        /// Request body: { "Pricelist": { "External_Key": externalKey }, "Article": ..., "Keys": [...] }
        ///
        /// Reference: PricelistItemsController.Post + GetByEntityReference(ID, External_Key)
        /// </summary>
        /// <param name="externalKey">The External_Key of the target pricelist.</param>
        /// <param name="item">The PricelistItem to add (including Keys and Prices).</param>
        /// <returns>The created PricelistItem as returned by the server.</returns>
        public PricelistItem AddItem(string externalKey, PricelistItem item)
        {
            item.Pricelist = new EntityReference { External_Key = externalKey };
            return this.Create(item);
        }

        /// <summary>
        /// Retrieves all items of a specific pricelist (paginated).
        ///
        /// How it works:
        ///   A GET request is sent to api/pricelistitems with the filter parameter "pricelistid".
        ///   The server filters items by the given pricelist ID.
        ///
        /// API endpoint: GET api/pricelistitems?search=...&amp;pageIndex=...&amp;pageSize=...&amp;orderBy=...&amp;filter=pricelistid%3D{pricelistId}
        ///
        /// Reference: PricelistItemsController.toFilteredQuery (filter key: "pricelistid")
        /// </summary>
        /// <param name="pricelistId">The ID of the pricelist to query items for.</param>
        /// <param name="search">Optional search term.</param>
        /// <param name="pageIndex">Zero-based page index.</param>
        /// <param name="pageSize">Number of items per page.</param>
        /// <param name="orderBy">Sort expression.</param>
        /// <returns>A paginated list of PricelistItem summaries.</returns>
        public Paginated<PricelistItem.Summary> FindByPricelist(long pricelistId, string search, int pageIndex, int pageSize, string orderBy)
        {
            return this.FindAll(search, pageIndex, pageSize, orderBy, "pricelistid=" + pricelistId);
        }
    }
}
