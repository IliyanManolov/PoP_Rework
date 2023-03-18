using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoP_Rework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Address address = new Address();
            //address.ExactAddress = "testExactAddress";
            //address.Street = "testStreet";
            //address.City = "testCity";
            //address.Country = "testCountry";

            //Student student = new Student();
            //student.FirstName = "TestFirstName";
            //student.LastName = "TestLastName";
            //student.Address = address;
            //student.FullAddress = student.SetFullAddress(address);
            //Console.WriteLine("test for full address: " +student.FullAddress);
            //Console.WriteLine("test for address: " + student.Address);
            ////student.FullAddress = "TEST ADDRESS";
            //student.StudentNumber = "TEST NUMBER";
            //int[] test = new int[] { 1, 2, 3 };
            //student.Scores = test;
            //student.Age = 42;
            ////student.DisplayScore();
           // Console.WriteLine(student.ToString());
            //Console.ReadLine();
            Menu();
        }

        static public void Menu()
        {
            Console.WriteLine("Available options:");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Display information about a student");
            Console.WriteLine("3. Display information about all students");
            Console.Write("Option selected: ");
            int option = int.Parse(Console.ReadLine());
            Options(option);

        }
        static public void Options(int chosen)
        {
            switch (chosen)
            {
                case 1:
                    Services.AddStudent();
                    break;
                case 2:
                    Services.FindStudent();
                    Services.DisplayStudent();
                    break;
                case 3:
                    Services.DisplayAllStudents();
                    break;
                default:
                    Console.Clear();
                    Console.WriteLine("Invalid option selected, please select a different one");
                    Menu();
                    break;
            }
        }
    }
}
