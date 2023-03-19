using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoP_Rework
{
    public class Services
    {
        static public string FileName = "D:\\University\\Year1\\PrinciplesOfProgramming\\PoP_Rework\\PoP_Rework\\studentdata.txt";
        static public void AddStudent()
        {
            Student student = new Student();
            Address address = new Address();
            Console.Clear();
            student.AddStudentDetails();
            Console.Clear();
            student.AddStudentScore();
            Console.Clear();
            address.AddAddress();
            student.SetAddress(address);
            SaveToFile(student, address, FileName);
        }
        static public void FindStudent()
        {
            Console.Clear();
            Console.Write("First name of the student: ");
            string firstName = Console.ReadLine();
            Console.Write("Last name of the student: ");
            string lastName = Console.ReadLine();
            string fullName = firstName.Trim() + " " + lastName.Trim();
            DisplayStudent(fullName);
        }
        static public void DisplayStudent(string name)
        {
            using (StreamReader reader = new StreamReader(FileName))
            {
                var line = reader.ReadLine();
                while (line != null && name != line.Split(';')[0] + " " + line.Split(';')[1])
                {
                    line = reader.ReadLine();
                }
                if (line == null)
                {
                    Console.WriteLine($"Student {name} not found");
                    return;
                }
                var temp = line.Split(';');
                Student student = new Student();
                Address address = new Address();
                student.FirstName = temp[0];
                student.LastName = temp[1];
                student.StudentNumber = temp[2];
                student.Age = int.Parse(temp[3]);
                student.AverageScore = double.Parse(temp[4]);

                address.ExactAddress = temp[5];
                address.Street = temp[6];
                address.City = temp[7];
                address.Country = temp[8];
                student.SetAddress(address);
                Console.WriteLine(student.ToString());
            }
        }
        static public void DisplayAllStudents()
        {
            Console.Clear();
            Console.WriteLine("Available students:");
            using (StreamReader reader = new StreamReader(FileName))
            {
                var line = reader.ReadLine();
                int counter = 1;
                while (line != null)
                {
                    Student student = new Student();
                    Address address = new Address();
                    var temp = line.Split(';');

                    student.FirstName = temp[0];
                    student.LastName = temp[1];
                    student.StudentNumber = temp[2];
                    student.Age = int.Parse(temp[3]);
                    student.AverageScore = double.Parse(temp[4]);
                    
                    address.ExactAddress = temp[5];
                    address.Street = temp[6];
                    address.City = temp[7];
                    address.Country = temp[8];

                    student.SetAddress(address);
                    Console.WriteLine($"{counter}. " + student.FullName + " student number " + student.StudentNumber);
                    line = reader.ReadLine();
                    counter++;
                }
            }
        }
        static public void SaveToFile(Student student, Address address, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(student.FirstName + ";" + student.LastName + ";" + student.StudentNumber + ";" + student.Age 
                                + ";" + student.AverageScore 
                                + ";" + address.ExactAddress + ";" + address.Street + ";" + address.City + ";" + address.Country);
            }
        }
    }
}
