using System;
using System.Collections.Generic;
using System.ComponentModel;
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


        }
        static public void AddStudentScore(Student student)
        {
            Console.WriteLine("Number of student scores: ");
            int scoreNumber = int.Parse(Console.ReadLine());
            student.Scores = new double[scoreNumber];
            for (int i = 0; i < scoreNumber; i++)
            {
                Console.Write($"Score {i+1}: ");
                student.Scores[i] = int.Parse(Console.ReadLine());
            }

            double result = 0;
            for (int i = 0; i < scoreNumber;i++)
            {
                result = result + student.Scores[i];
            }

            student.AverageScore = (result / scoreNumber);
        }
    }
}
