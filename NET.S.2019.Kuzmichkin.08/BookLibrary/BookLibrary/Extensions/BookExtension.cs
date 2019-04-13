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

        public static string ToString(this Book book, string format)
        {
            return book.ToString(format, new BookFormater());
        }

        public static string ToString(this Book book)
        {
            return book.ToString("", new BookFormater());
        }
    }
}
