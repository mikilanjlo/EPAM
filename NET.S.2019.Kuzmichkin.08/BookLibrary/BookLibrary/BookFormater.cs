using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace BookLibrary
{
    class BookFormater : IFormatProvider, ICustomFormatter
    {

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }


        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if(arg is Book)
            {
                Book book = arg as Book;
                string result = "";
                if (String.IsNullOrEmpty(format)) { }
                    format = "ISBN , AUTHOR, TITLE, PUBLISHER , YEAR ,PAGESCOUNT, PRICE";
                format = format.Replace(" ", "");
                format = format.ToUpperInvariant();
                string[] fields = format.Split(new char[] { ',' });
                //FieldInfo[] fieldInfos= typeof(Book).GetFields();
                foreach(string field in fields)
                {
                    if (result.Length > 0)
                        result += ",";
                    switch (field)
                    {
                        case "ISBN":
                            result += "ISBN 13: " + book.isbn.Substring(0, 3) +"-"+ book.isbn.Substring(3, 1) + "-" + book.isbn.Substring(4, 4) + "-" + book.isbn.Substring(8, 4) + "-" + book.isbn.Substring(12, 1);
                            break;
                        case "AUTHOR":
                            result += book.author;
                            break;
                        case "TITLE":
                            result += book.name;
                            break;
                        case "PUBLISHER":
                            result += "\"" + book.publisher + "\"";
                            break;
                        case "YEAR":
                            result += book.year.ToString();
                            break;
                        case "PAGESCOUNT":
                            result += "P." + book.pagesCount;
                            break;
                        case "PRICE":
                            result += String.Format("0:0.00", book.price);
                            break;

                    }
                    //foreach(FieldInfo fieldInfo in fieldInfos)
                    //{
                    //    string name = fieldInfo.Name.ToUpperInvariant();
                    //    if(name == field)
                    //    {
                    //        result += field + " " + 
                    //    }
                    //}
                }
                if (result.Length < 1)
                    throw new ArgumentException("wrong format");
                result += ".";
                return result;
            }
            else
            {
                throw new ArgumentException("Book Formater only for books");
            }
        }

        
    }
}
