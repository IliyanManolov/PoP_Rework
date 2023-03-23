using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoP_Rework
{
    public class Student:Person
    {
        public string StudentNumber { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; } //can't assign Address.ExactAddress, etc. so just gonna use a different object and set it
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
        public void DisplayScore(Student student)
        {
            foreach (int score in student.Scores)
            {
                Console.Write(score + ",");
            }
        }
        public override string ToString()
        {
            return    "Student " + FullName + " age is " + Age
                    + "\nStudent " + FullName + " student number is " + StudentNumber
                    + "\nStudent " + FullName + " average score is " + AverageScore
                    + "\nStudent " + FullName + " lives in " + Address.City + ", " + Address.Country 
                    + "\nStudent " + FullName + " full address is " + Address
                    + "\nStudent " + FullName + $" has {Scores.Length} scores";
        }
        public void AddStudentDetails()
        {
            Console.WriteLine("Student First name: ");
            FirstName = Services.ValidateIfEmpty(Console.ReadLine());

            Console.WriteLine("Student Last name: ");
            LastName = Services.ValidateIfEmpty(Console.ReadLine());

            Console.WriteLine("Student Age: ");
            Age = int.Parse(Console.ReadLine());

            Console.WriteLine("Student number: ");
            StudentNumber = Services.ValidateIfEmpty(Console.ReadLine());

        }
        public void AddStudentScore()
        {
            Console.Write("Number of student scores: ");
            int scoreNumber = int.Parse(Console.ReadLine());
            Scores = new int[scoreNumber];
            for (int i = 0; i < scoreNumber; i++)
            {
                Console.Write($"Score {i + 1}: ");
                Scores[i] = int.Parse(Console.ReadLine());
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
    }
}
