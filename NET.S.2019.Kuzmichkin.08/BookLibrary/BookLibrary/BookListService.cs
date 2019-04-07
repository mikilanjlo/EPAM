using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary
{
    public class BookListService
    {
        private List<Book> m_listbooks = new List<Book>();

        public List<Book> ListBooks
        {
            get
            {                
                return m_listbooks.Clone();
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Value can't be null");
                }
                else
                {
                    m_listbooks = value.Clone();
                }
            }
        }

        public void AddBook(Book book)
        {
            if (!BookExist(book))
            {
                m_listbooks.Add(book);
            }
            else
            {
                throw new Exception("Book already exist");
            }
        }

        public void RemoveBook(Book book)
        {

            if (BookExist(book))
            {
                m_listbooks.Remove(book);
            }
            else
            {
                throw new Exception("Book not exist");
            }
        }

        public Book FindBookByTag(string value, Crit crit)
        {
            switch (crit)
            {
                case Crit.isbn:
                    return m_listbooks.Find(book => book.isbn == value);
                case Crit.author:
                    return m_listbooks.Find(book => book.author == value);
                case Crit.name:
                    return m_listbooks.Find(book => book.name == value);
                case Crit.publisher:
                    return m_listbooks.Find(book => book.publisher == value);
                case Crit.year:
                    return m_listbooks.Find(book => book.year == int.Parse(value));
                case Crit.price:
                    return m_listbooks.Find(book => book.price == int.Parse(value));
                case Crit.pages:
                    return m_listbooks.Find(book => book.pagesCount == int.Parse(value));
                default:
                    return null;
            }
        }

        private bool BookExist(Book book)
        {

            if (book == null)
            {
                throw new ArgumentNullException("Book can't be null");
            }

            foreach (Book b in m_listbooks)
            {
                if (b.Equals(book))
                {
                    return true;
                }
            }
            return false;
        }

        public void SortBooksByTag()
        {
            m_listbooks.Sort();
        }

        public string PrintBooks()
        {
            string result = string.Empty;

            foreach (Book b in m_listbooks)
            {
                result += b.ToString();
            }

            return result;
        }
    }
}
