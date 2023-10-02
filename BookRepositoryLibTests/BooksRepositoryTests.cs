using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookRepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookRepositoryLib.Tests
{
    [TestClass()]
    public class BooksRepositoryTests
    {

        [TestMethod()]
        public void GetTest()
        {
            var b = new BooksRepository();

            List<Book> books = b.Get();

            Assert.IsNotNull(books);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            var b = new BooksRepository();
            Book? foundbook = b.GetById(2);

            Assert.IsNotNull(foundbook);
            Assert.AreEqual(2, foundbook.Id);
        }

        [TestMethod()]
        public void AddTest()
        {
            var b = new BooksRepository();
            Book Book1 = new Book() { Id = 3, Title = "Dagan", Price = 599 };
            Book AddedTeacher = b.Add(Book1);

            Assert.IsNotNull(AddedTeacher);
            Assert.AreNotEqual(2, AddedTeacher.Id);
            Assert.AreEqual("Dagan", AddedTeacher.Title);

        }

        [TestMethod()]
        public void UpdateTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DeleteTest()
        {
            var b = new BooksRepository();
            var bookIdToRemove = 2;
            Book? removedBook = b.Delete(2);
            Assert.IsNotNull(removedBook);
            Assert.AreEqual(bookIdToRemove, removedBook.Id);
        }
    }
}