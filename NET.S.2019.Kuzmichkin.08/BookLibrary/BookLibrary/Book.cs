using System;
using System.Linq;

namespace BookLibrary
{
    public class Book : IComparable<Book>, ICloneable
    {
        public string isbn { get; private set; }

        public string author { get; private set; }

        public string name { get; private set; }

        public string publisher { get; private set; }

        public int year { get; private set; }

        public int pagesCount { get; private set; }

        public int price { get; private set; }

        public Book(string isbn, string author, string name, string publishing, int year, int pagesCount, int price)
        {
            if (isbn == null  || author == null || publishing == null )
            {
                throw new ArgumentNullException("Invalid parametrs given");
            }
            if ( isbn.Length != 13 || !isbn.All(char.IsDigit) || author == "" || publishing == "" || year <= 1000 || year >= DateTime.Now.Year
                || pagesCount <= 0 || price <= 0)
            {
                throw new ArgumentException("Invalid parametrs given");
            }

            this.isbn = isbn;
            this.author = author;
            this.name = name;
            this.publisher = publishing;
            this.year = year;
            this.pagesCount = pagesCount;
            this.price = price;
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            var book = obj as Book;

            if (book.isbn == this.isbn && book.author == this.author && book.name == this.name && book.publisher == this.publisher &&
                book.year == this.year && book.pagesCount == this.pagesCount && book.price == this.price)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            return $"{name}, was writen in {year} by {author} and published by {publisher}. Contains {pagesCount} and costs {price} \n ISBN:{isbn} \n ";
        }

        public override int GetHashCode()
        {
            int hashcode = 13;
            hashcode = (23 * hashcode) + isbn.GetHashCode();
            hashcode = (23 * hashcode) + author.GetHashCode();
            hashcode = (23 * hashcode) + name.GetHashCode();
            hashcode = (23 * hashcode) + publisher.GetHashCode();
            hashcode += price;
            hashcode += pagesCount;
            hashcode += year;

            return hashcode;
        }

        public int CompareTo(Book other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other));
            }

            return isbn.CompareTo(other.isbn);
        }

        public object Clone()
        {
            return new Book(isbn, author, name, publisher, year, pagesCount, price);
        }
    }
}
