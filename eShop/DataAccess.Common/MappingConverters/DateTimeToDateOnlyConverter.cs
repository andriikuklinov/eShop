using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Common.MappingConverters
{
    public class DateTimeToDateOnlyConverter : IValueConverter<DateTime, DateOnly>
    {
        public DateOnly Convert(DateTime sourceMember, ResolutionContext context)
        {
            return DateOnly.FromDateTime(sourceMember);
        }
    }
}
