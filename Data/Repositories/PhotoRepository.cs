using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PhotoRepository : GenericRepository<Photo>
    {
        public PhotoRepository(Context context) : base(context)
        {
        }
    }
}
