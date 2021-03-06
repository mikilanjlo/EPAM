﻿using System;
using System.Collections.Generic;
using NLog;
using System.Text;

namespace BookLibrary
{
    public class BookListService
    {
        private List<Book> m_listbooks = new List<Book>();
        private BookListStorage m_bookListStorage;
        private Logger m_logger;

        public BookListService(BookListStorage bookListStorage, Logger logger)
        {
            m_bookListStorage = bookListStorage;
            m_listbooks = m_bookListStorage.ListBooks;
            m_logger = logger;
        }

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
                    m_logger.Error("Not Found list books");
                        throw new ArgumentNullException("Value can't be null");
                }
                else
                {
                    m_logger.Info("Set new list books");
                    m_listbooks = value.Clone();
                }
            }
        }

        public void AddBook(Book book)
        {
            if (!BookExist(book))
            {
                m_listbooks.Add(book);
                m_logger.Info("Book " + book.ToString("TITLE") + " was add");
            }
            else
            {
                m_logger.Warn("Book already exist");
                throw new Exception("Book already exist");
            }
        }

        public void RemoveBook(Book book)
        {

            if (BookExist(book))
            {
                m_listbooks.Remove(book);
                m_logger.Info("Book " + book.ToString("TITLE") + " was remove");
            }
            else
            {
                m_logger.Warn("Book not exist");
                throw new Exception("Book not exist");
            }
        }

        public Book FindBookByTag(string value, Crit crit)
        {
            m_logger.Info("Search by " + crit.ToString("g")+", value = "+ value);
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
                    m_logger.Info("Book is not find");
                    return null;
            }
        }

        private bool BookExist(Book book)
        {

            if (book == null)
            {
                m_logger.Error("Book can't be null");
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

        public void SaveInStoroge(string filename)
        {
            m_logger.Trace("Start save in storage");
            m_bookListStorage.UpdateListBooks(m_listbooks);
            m_bookListStorage.SaveBooks(filename);
            m_logger.Trace("End save in storage");
            m_logger.Info("Boks Save in storage");
        }
        
    }
}
