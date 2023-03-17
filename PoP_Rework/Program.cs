using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoP_Rework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Address address = new Address();
            address.ExactAddress = "testExactAddress";
            address.Street = "testStreet";
            address.City = "testCity";
            address.Country = "testCountry";

            Student student = new Student();
            student.FirstName = "TestFirstName";
            student.LastName = "TestLastName";
            student.FullAddress = student.SetFullAddress(address);
            //student.FullAddress = "TEST ADDRESS";
            student.StudentNumber = "TEST NUMBER";
            int[] test = new int[] { 1, 2, 3 };
            student.Scores = test;
            student.Age = 42;
            //student.DisplayScore();
            Console.WriteLine(student.ToString());
            Console.ReadLine();
        }
    }
}
