using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookLibrary
{
    public class BookListStorage
    {
        private List<Book> m_listbooks = new List<Book>();

        public BookListStorage()
        {
            
        }

        public BookListStorage(List<Book> localbooks)
        {
            
            if (localbooks == null)
            {
                throw new ArgumentNullException("Parametr can't be null");
            }
            m_listbooks = localbooks;
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
                    throw new ArgumentNullException("Value can't be null");
                }
                else
                {
                    m_listbooks = value.Clone();
                }
            }
        }

        public void UpdateListBooks(List<Book> list)
        {
            m_listbooks = list;
        }

        public void SaveBooks(string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                foreach (Book b in m_listbooks)
                {
                    writer.Write(b.isbn);
                    writer.Write(b.name);
                    writer.Write(b.author);
                    writer.Write(b.publisher);
                    writer.Write(b.year);
                    writer.Write(b.pagesCount);
                    writer.Write(b.price);
                }
            }
        }

        public void LoadBooks(string filename)
        {
            if (File.Exists(filename))
            {
                using (BinaryReader reader = new BinaryReader(File.OpenRead(filename)))
                {
                    List<Book> result = new List<Book>();

                    while (reader.PeekChar() > -1)
                    {
                        string isbn = reader.ReadString();
                        string author = reader.ReadString();
                        string name = reader.ReadString();
                        string publisher = reader.ReadString();
                        int year = reader.ReadInt32();
                        int pages = reader.ReadInt32();
                        int price = reader.ReadInt32();

                        result.Add(new Book(isbn, author, name, publisher, year, pages, price));
                    }

                    m_listbooks = result;
                }
            }
        }
    }
}
