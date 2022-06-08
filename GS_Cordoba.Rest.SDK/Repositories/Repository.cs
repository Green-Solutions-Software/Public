using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GS.Cordoba.Rest.SDK.Repositories
{
    public class Repository
    {
        protected Context context = null;

        public Repository(Context context)
        {
            this.context = context;
        }
    }

    public class Repository<T> : Repository
    {
        public Repository(Context context)
            :base(context)
        {

        }
    }
}
