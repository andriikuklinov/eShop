using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common.Models
{
    internal class FilterData<TFilterValue>
    {
        public IEnumerable<FilterModel<TFilterValue>> Data { get; set; }
    }
    internal class FilterModel<T>
    {
        public string PropertyName { get; set; }
        public T Value { get; set; }
    }
}
