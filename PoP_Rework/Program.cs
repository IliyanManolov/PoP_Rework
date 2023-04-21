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
            Student.LoadFromFile();
            Menu();
            // submition: github repo(MAKE PUBLIC) or files
        }

        static public void Menu()
        {
            Console.WriteLine("Available options:");
            Console.WriteLine("1. Add a student");
            Console.WriteLine("2. Display information about a student");
            Console.WriteLine("3. Display information about all students");
            Console.Write("Option selected: ");
            int option = Validations.ValidateInt(Console.ReadLine());
            Options(option);

        }
        static public void Options(int chosen)
        {
            switch (chosen)
            {
                case 1:
                    Services.AddStudent();
                    Menu();
                    break;
                case 2:
                    Services.FindStudent();
                    Console.WriteLine("-----------------------------------------------------------");
                    Menu();
                    break;
                case 3:
                    Services.DisplayAllStudents();
                    Console.WriteLine("-----------------------------------------------------------");
                    Menu();
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
