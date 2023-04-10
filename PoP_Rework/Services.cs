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
            student.AddToList(student);
        }
        static public void FindStudent()
        {
            Console.Clear();

            Console.Write("First name of the student: ");
            string firstName = Services.ValidateString(Console.ReadLine());
            Console.Write("Last name of the student: ");
            string lastName = Services.ValidateString(Console.ReadLine());

            string fullName = firstName.Trim().Replace(" ", string.Empty) + " " + lastName.Trim().Replace(" ", string.Empty);

            Console.Clear();
            DisplayStudent(fullName);
        }
        static public void DisplayStudent(string name)
        {
            for (int i = 0; i < Student.studentlist.Count; i++)
            {
                if (Student.studentlist[i].FullName.ToLower() == name.ToLower())
                {
                    Console.WriteLine(Student.studentlist[i].ToString());
                    Console.WriteLine($"Student {Student.studentlist[i].FullName}'s scores are: " + Student.studentlist[i].DisplayScore());
                }
            }
        }
        static public void DisplayAllStudents()
        {
            Console.Clear();
            Console.WriteLine("Available students:");
            int counter = 1;
            foreach (Student student in Student.studentlist)
            {
                Console.WriteLine($"{counter}. " + student.FullName + " student number " + student.StudentNumber);
                counter++;
            }
        }
        static public void SaveToFile(Student student, Address address, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(student.FirstName + ";" + student.LastName + ";" + student.StudentNumber + ";" + student.Age 
                                + ";" + student.AverageScore 
                                + ";" + address.ExactAddress + ";" + address.Street + ";" + address.City + ";" + address.Country + ";"
                                + student.ScoreToFile());
            }
        }
        static public string ValidateString(string str)
        {
            while (string.IsNullOrWhiteSpace(str))
            {
                Console.Write("Input data cannot be empty! Enter new data: ");
                str = Console.ReadLine();
            }
            return str.Trim();
        }
        static public int ValidateInt(string val)
        {
            while (string.IsNullOrWhiteSpace(val.Trim()) || int.Parse(val) <= 0)
            {
                if (string.IsNullOrWhiteSpace(val) == true)
                {
                    Console.Write("Input data cannot be empty! Enter new data: ");
                    val = Console.ReadLine();
                }
                else if (int.Parse(val.Trim()) <= 0)
                {
                    Console.Write("Input data cannot be negative or a 0! Enter new data: ");
                    val = Console.ReadLine();
                }
            }
            return int.Parse(val.Trim());
        }
    }
}
