﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoP_Rework
{
    public class Student:Person
    {
        public string StudentNumber { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
            set{}
        }
        public int[] Scores { get; set; }
        public double AverageScore { get; set; }
        public string FullAddress
        {
            get
            {
                return Address.ExactAddress + " " + Address.Street + ", " + Address.City + ", " + Address.Country;
            }
            set{}
        }

        static public List<Student> studentlist = new List<Student>();
        public override string ToString()
        {
            return "Student " + FullName + " age is " + Age
                    + "\nStudent " + FullName + " student number is " + StudentNumber
                    + "\nStudent " + FullName + " average score is " + AverageScore
                    + "\nStudent " + FullName + " lives in " + Address.City + ", " + Address.Country
                    + "\nStudent " + FullName + " full address is " + Address
                    + "\nStudent " + FullName + $" has {Scores.Length} scores";
        }        
        public string DisplayScore(Student student)
        {
            string result = string.Empty;

            result = student.Scores[0].ToString();
            for (int i = 1; i < student.Scores.Length; i++)
            {
                result = result + "," + student.Scores[i];
            }
            return result;
        }
        public void AddStudentDetails()
        {
            Console.Write("Student First name: ");
            FirstName = Services.ValidateString(Console.ReadLine());

            Console.Write("Student Last name: ");
            LastName = Services.ValidateString(Console.ReadLine());

            Console.Write("Student Age: ");
            Age = Services.ValidateInt(Console.ReadLine());

            Console.Write("Student number: ");
            StudentNumber = Services.ValidateString(Console.ReadLine());

        }
        public void AddStudentScore()
        {
            Console.Write("Number of student scores: ");
            int scoreNumber = Services.ValidateInt(Console.ReadLine());
            Scores = new int[scoreNumber];
            for (int i = 0; i < scoreNumber; i++)
            {
                Console.Write($"Score {i + 1}: ");
                Scores[i] = ValidateScore(Console.ReadLine());
            }

            double result = 0;
            for (int i = 0; i < scoreNumber; i++)
            {
                result = result + Scores[i];
            }

            AverageScore = (double) result / (double) scoreNumber;
        }
        public void SetAddress(Address newAddress)
        {
            Address = newAddress;
        }
        public string ScoreToFile()
        {
            string[] result = new string[Scores.Length];
            int counter = 0;
            foreach (int score in Scores)
            {
                result[counter] = Scores[counter].ToString();
                counter++;
            }
            string finalresult = string.Join(",", result);
            return finalresult;
        }
        public void ScoreFromFile(string input)
        {
            Scores = new int[input.Split(',').Length];
            int i = 0;
            foreach (string number in input.Split(','))
            {
                Scores[i] = int.Parse(number);
                i++;
            }
        }
        public int ValidateScore(string score) 
        {
            //TODO: add TryParse to avoid exceptions
            while (string.IsNullOrWhiteSpace(score) == true || int.Parse(score) < 0)
            {
                if(string.IsNullOrWhiteSpace(score) == true)
                {
                    Console.Write("Input data cannot be empty! Input new data: ");
                    score = Console.ReadLine();
                }
                else if(int.Parse(score) < 0)
                {
                    Console.Write("Input data cannot be negative! Input new data: ");
                    score = Console.ReadLine();
                }
            }
            return int.Parse(score.Trim());
        }
        public void AddToList(Student newstudent)
        {
            studentlist.Add(newstudent);
        }
        static public void AddFromFile()
        {
            using (StreamReader reader = new StreamReader(Services.FileName))
            {
                var line = reader.ReadLine();
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
                    student.ScoreFromFile(temp[9]);

                    address.ExactAddress = temp[5];
                    address.Street = temp[6];
                    address.City = temp[7];
                    address.Country = temp[8];

                    student.SetAddress(address);
                    studentlist.Add(student);
                    line = reader.ReadLine();
                }
            }

        }
        public string DisplayScore()
        {
            string result = string.Empty;
            result = Scores[0].ToString();
            if (Scores.Length == 1)
            {
                return result;
            }
            else
            {
                for (int i = 1; i < Scores.Length; i++)
                {
                    result += ", " + Scores[i].ToString();
                }
            }
            return result;
        }
    }
}
