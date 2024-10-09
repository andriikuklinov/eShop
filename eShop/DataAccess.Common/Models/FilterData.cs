using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common.Models
{
    internal class FilterData
    {
        public IEnumerable<FilterModel> Data { get; set; }
    }
    internal class FilterModel
    {
        public string PropertyName { get; set; }
        public string Value { get; set; }
    }
}
