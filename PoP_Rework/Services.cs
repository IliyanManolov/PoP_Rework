﻿using System;
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
            Student.AddToList(student);
        }
        static public void FindStudent()
        {
            Console.WriteLine("-----------------------------------------------------------");

            Console.Write("First name of the student: ");
            string firstName = Validations.ValidateString(Console.ReadLine());
            Console.Write("Last name of the student: ");
            string lastName = Validations.ValidateString(Console.ReadLine());

            string fullName = firstName + " " + lastName;

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
                    return;
                }
            }
            Console.WriteLine($"Student {name} not found \n");
            Program.Menu();
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
                                + student.ScoreToFileString());
            }
        }

    }
}
