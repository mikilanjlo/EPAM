using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BookLibrary
{
    public class BookListStorage
    {
        private BookListService listbooksService = new BookListService();
        public BookListStorage(List<Book> localbooks)
        {
            
            if (localbooks == null)
            {
                throw new ArgumentNullException("Parametr can't be null");
            }
            listbooksService.ListBooks = localbooks;
        }

        public void UpdateListBooks(List<Book> list)
        {
            listbooksService.ListBooks = list;
        }

        public void SaveBooks(string filename)
        {
            using (BinaryWriter writer = new BinaryWriter(File.Open(filename, FileMode.Create)))
            {
                foreach (Book b in listbooksService.ListBooks)
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

                    listbooksService.ListBooks = result;
                }
            }
        }
    }
}
