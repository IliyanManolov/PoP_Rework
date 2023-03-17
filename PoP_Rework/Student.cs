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
        public double[] Scores { get; set; }
        public double AverageScore { get; set; }
        public string FullAddress { get; set; }
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
                    + "\nStudent " + FullName + " average score is " + AverageScore
                    + "\nStudent " + FullName + " full address is " + Address;
        }
        public string SetFullAddress(Address newAddress)
        {
            return newAddress.ExactAddress + " " + newAddress.Street + " " + newAddress.City + " " + newAddress.Country;
        }
    }
}
