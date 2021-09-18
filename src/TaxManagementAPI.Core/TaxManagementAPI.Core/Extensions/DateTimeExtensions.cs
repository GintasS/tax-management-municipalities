using System;

namespace TaxManagementAPI.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static bool IsBetweenDate(this DateTime date, DateTime fromDate, DateTime? toDate = null)
        {
            if (toDate.HasValue == false)
            {
                return fromDate >= date;
            }

            return fromDate >= date && date <= toDate;
        }
    }
}
