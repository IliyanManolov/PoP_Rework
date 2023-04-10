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
                    Console.WriteLine(Student.studentlist[i].Sc);
                }
            }
            //using (StreamReader reader = new StreamReader(FileName))
            //{
            //    var line = reader.ReadLine();
            //    while (line != null && name.ToLower() != line.Split(';')[0].ToLower() + " " + line.Split(';')[1].ToLower())
            //    {
            //        line = reader.ReadLine();
            //    }
            //    if (line == null)
            //    {
            //        Console.WriteLine($"Student {name} not found");
            //        return;
            //    }

            //    var temp = line.Split(';');
            //    Student student = new Student();
            //    Address address = new Address();

            //    student.FirstName = temp[0];
            //    student.LastName = temp[1];
            //    student.StudentNumber = temp[2];
            //    student.Age = int.Parse(temp[3]);
            //    student.AverageScore = double.Parse(temp[4]);
            //    student.ScoreFromFile(temp[9]);

            //    address.ExactAddress = temp[5];
            //    address.Street = temp[6];
            //    address.City = temp[7];
            //    address.Country = temp[8];
            //    student.SetAddress(address);
            //    Console.WriteLine(student.ToString());
            //    Console.WriteLine($"Student {student.FullName} scores are: {student.DisplayScore(student)}");
            //}
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
