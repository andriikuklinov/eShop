using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common.Extensions
{
    public static class PaginationExtensions
    {
        public static IQueryable<T> Paginate<T>(this IQueryable<T> query, int? page, int? pageSize)
        {
            if (page == null || pageSize == null)
            {
                return query;
            }
            else
            {
                if (pageSize <= 0)
                    throw new ArgumentOutOfRangeException(nameof(pageSize), pageSize, "Invalid pageSize value.");
                if (page != 0)
                    query = query.Skip((int)(page * pageSize));
                return query.Take((int)pageSize);
            }
        }
    }
}
