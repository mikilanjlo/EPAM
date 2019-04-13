using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary
{
    public static class  BookExtension
    {
        public static string ToString(this Book book,string format, IFormatProvider formatProvider)
        {
            ICustomFormatter formatter = (ICustomFormatter)formatProvider.GetFormat(typeof(ICustomFormatter));
            return formatter.Format(format, book, formatProvider);
        }
    }
}
