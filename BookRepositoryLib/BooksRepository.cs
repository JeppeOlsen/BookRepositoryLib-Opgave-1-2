using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace BookRepositoryLib
{
    public class BooksRepository
    {
        private int nextId = 1;
        private List<Book> books = new List<Book>();
        public BooksRepository()
        {
            books.Add(new Book() { Id = nextId++, Title = "Dagon", Price = 1199 });
            books.Add(new Book() { Id = nextId++, Title = "The Shadow over Innsmouth", Price = 666 });
            books.Add(new Book() { Id = nextId++, Title = "The Call of Cthulhu", Price = 499 });
            books.Add(new Book() { Id = nextId++, Title = "A Game of Thrones", Price = 199 });
            books.Add(new Book() { Id = nextId++, Title = "Warcraft: The Last Guardian", Price = 999 });

        }

        public List<Book> Get(double? minPrice = null, double? maxPrice = null, string title = null)
        {
            if (minPrice == null && maxPrice == null && string.IsNullOrEmpty(title))
            {
                
                return new List<Book>(books);
            }

            
            return books.Where(book =>
            {
                bool includeBook = true;

                if (minPrice != null)
                {
                    includeBook = book.Price >= minPrice;
                }

                if (maxPrice != null)
                {
                    includeBook = includeBook && book.Price <= maxPrice;
                }

                if (!string.IsNullOrEmpty(title))
                {
                    includeBook = includeBook && book.Title.Contains(title, StringComparison.OrdinalIgnoreCase);
                }

                return includeBook;
            }).ToList();
        }

        public Book? GetById(int id)
        {
            return books.FirstOrDefault(t => t.Id == id);
        }

        public Book Add(Book book)
        {
            book.ValidateAll();
            book.Id = nextId++;
            return book;
        }

        
        public  Book? Update(int id, Book books)
        {
            Book? bookToUpdate = GetById(id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Title = books.Title;
                bookToUpdate.Price = books.Price;

            }

            return bookToUpdate;

        }

        public Book Delete(int id)
        {
            Book? book = GetById(id);
            if (book != null)
            {
                books.Remove(book);
            }
            return book;

        }

    }
}
