using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookLibrary
{
    public static class ListExtension
    {
        public static List<T> Clone<T>(this List<T> listToClone) where T : ICloneable
        {
            return listToClone.Select(item => (T)item.Clone()).ToList();
        }

        //public static IList<Book> Clone2<Book>(this IList<Book> listToClone)
        //{
        //    return listToClone.Select(item => (Book)item.Clone()).ToList();
        //}
    }
}
