using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookRepositoryLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookRepositoryLib.Tests
{
    [TestClass()]
    public class BookTests
    {
       
        [TestMethod()]
        public void ValidateTitleTest()
        {
            Book Book1 = new Book() {Id = 1, Title = null, Price = 599};
            Assert.ThrowsException<ArgumentNullException>(() => Book1.ValidateTitle());

            Book Book2 = new Book() { Id = 2, Title = " ", Price = 599 };
            Assert.ThrowsException<ArgumentException>(() => Book2.ValidateTitle());

            Book Book3 = new Book() { Id = 3, Title = "Øe", Price = 599 };
            Assert.ThrowsException<FormatException>(() => Book3.ValidateTitle());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            Book Book1 = new Book() { Id = 1, Title = "The Call of Cthulhu", Price = 0 };
            Assert.ThrowsException<ValidationException>(() => Book1.ValidatePrice());

            Book Book2 = new Book() { Id = 1, Title = "Dagon", Price = 1201 };
            Assert.ThrowsException<ValidationException>(() => Book2.ValidatePrice());

        }
    }
}