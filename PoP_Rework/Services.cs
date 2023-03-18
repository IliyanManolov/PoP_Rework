using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoP_Rework
{
    public class Services
    {
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
        }
        static public void FindStudent()
        {
            Console.WriteLine("First name of the student: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("Last name of the student: ");
            string lastName = Console.ReadLine();
            string fullName = firstName + " " + lastName;
        }
        static public void DisplayStudent()
        {

        }
        static public void DisplayAllStudents()
        {

        }
        static public void SaveToFile(Student student, Address address, string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(student.FirstName + ";" + student.LastName + ";" + student.StudentNumber + ";" + student.Age 
                                + ";" + student.Scores + ";" + student.AverageScore
                                + ";" + address.ExactAddress + ";" + address.Street + ";" + address.City + ";" + address.Country);
            }
        }
        //static public void AddStudentScore(Student student)
        //{
        //    Console.WriteLine("Number of student scores: ");
        //    int scoreNumber = int.Parse(Console.ReadLine());
        //    student.Scores = new double[scoreNumber];
        //    for (int i = 0; i < scoreNumber; i++)
        //    {
        //        Console.Write($"Score {i+1}: ");
        //        student.Scores[i] = int.Parse(Console.ReadLine());
        //    }

        //    double result = 0;
        //    for (int i = 0; i < scoreNumber;i++)
        //    {
        //        result = result + student.Scores[i];
        //    }

        //    student.AverageScore = (result / scoreNumber);
        //}
    }
}
