using GS.Cordoba.Rest.SDK.Classes;
using GS.Cordoba.Rest.SDK.Interfaces;
using GS.Cordoba.Rest.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class CORCalendarItemsRepository : Repository<CalendarItem>, ICalendarItemsRepository
    {
        public CORCalendarItemsRepository(Context context) : base(context)
        {
        }

        public async Task<Paginated<CalendarItem.Summary>> FindAll(string search, int pageIndex, int pageSize, string orderBy, long[] ids = null)
        {
            return await this.context.FindCalendarItems(search, pageIndex, pageSize, orderBy);
        }

        public async Task<CalendarItem> Get(long id)
        {
            return await this.context.GetCalendarItem(id);
        }
    }
}
