using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Allocine.ExtensionMethods
{
    public static class Extensions
    {
        public static DateTime toDate(this string allocineDateTimeString)
        {
            var result = new DateTime();

            if (allocineDateTimeString != null)
            {
                int dateStringLenght = allocineDateTimeString.Length;
                string dateFormat = null;
                string dateTimeString = null;

                //AlloCine Dates are either this 2013-03-30T23:42:00Z or this 2013-03-30
                if (dateStringLenght == 10)
                {
                    dateTimeString = allocineDateTimeString;
                    dateFormat = "yyyy-MM-dd";
                }
                else if (dateStringLenght > 10)
                {
                    dateTimeString = allocineDateTimeString.Substring(0, 19);
                    dateFormat = "yyyy-MM-ddTHH:mm:ss";
                }
                const DateTimeStyles style = DateTimeStyles.AllowWhiteSpaces;
               
                DateTime dt;
                if (DateTime.TryParseExact(dateTimeString, dateFormat, CultureInfo.InvariantCulture, style, out dt)) result = dt;
            }
            return result;
        }
    }  
}
