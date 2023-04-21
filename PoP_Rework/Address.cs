using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoP_Rework
{
    public class Address
    {
        public string ExactAddress { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public void AddAddress()
        {
            Console.Write("Student house number: ");
            ExactAddress = Validations.ValidateStringWithDigits(Console.ReadLine());
            
            Console.Write("Student street: ");
            Street = Validations.ValidateStringWithDigits(Console.ReadLine());

            Console.Write("Student city: ");
            City = Validations.ValidateStringWithDigits(Console.ReadLine());

            Console.Write("Student country: ");
            Country = Validations.ValidateStringWithDigits(Console.ReadLine());
        }
    }
}
