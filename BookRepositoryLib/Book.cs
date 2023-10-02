using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;
using System.Xml.Linq;

namespace BookRepositoryLib
{
    public class Book 
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public int Price { get; set; }

            

        public override string ToString()
        {
            return $"Id/{Id} - Title/{Title} - Price/{Price}";
        }


        //public void ValidateId()
        //{
            
        //}

        //Validating the title
        public void ValidateTitle()
        {

            if (Title == null)
            {
                throw new ArgumentNullException("Title cannot be NULL");
            }

            if (Title == " ")
            {
                throw new ArgumentException("Title cannot be empty");
            }

            if (Title.Length < 3)
            {
                throw new FormatException("Title needs to be atleast three characters or longer");
            }

        }

        //Validating the price
        public void ValidatePrice()
        {
            if(Price <= 0)
            {
                throw new ValidationException("Price cannot be 0 or less");
            }

            if(Price >= 1200)
            {
                throw new ValidationException("Price cannot be higher than 1200");
            }

        }

        public void ValidateAll()
        {
            ValidatePrice();
            ValidateTitle();
        }

       
    }
}