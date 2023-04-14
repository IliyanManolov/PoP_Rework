using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoP_Rework
{
    public class Validations
    {
        static public bool ContainsOnlyLetters(string input)
        {
            foreach (char c in input.Trim())
            {
                if (Char.IsLetter(c) == false)
                    return false;
            }
            return true;
        }

        static public bool ContainsOnlyDigits(string input)
        {
            foreach (char c in input.Trim())
            {
                if (Char.IsDigit(c) == false)
                    return false;
            }
            return true;
        }
        static bool ContainsLettersAndDigits(string input)
        {
            foreach (char c in input.Trim())
            {
                if (Char.IsLetterOrDigit(c) == false)
                    return false;
            }
            return true;
        }
        static public string ValidateString(string str) //only letters
        {
            bool isValid = false;
            while (!isValid)
            {
                isValid = true;
                if (string.IsNullOrWhiteSpace(str))
                {
                    Console.Write("Input data cannot be empty! Enter new data: ");
                    str = Console.ReadLine();
                    isValid = false;
                }
                else if (ContainsOnlyLetters(str) == false)
                {
                    Console.Write("Input data cannot contain digits! Enter new data: ");
                    str = Console.ReadLine();
                    isValid = false;
                }
            }
            return str.Trim();
        }
        static public string ValidateStringWithDigits(string str) //letters + digits
        {
            bool isValid = false;
            while (!isValid)
            {
                isValid = true;
                if (string.IsNullOrWhiteSpace(str))
                {
                    Console.Write("Input data cannot be empty! Enter new data: ");
                    str = Console.ReadLine();
                    isValid = false;
                }
                else if (ContainsLettersAndDigits(str) == false)
                {
                    Console.Write("Input data cannot have forbidden symbols! Enter new data: ");
                    str = Console.ReadLine();
                    isValid = false;
                }
            }
            return str.Trim();
        }
        static public int ValidateInt(string val) //only digits
        {
            bool isValid = false;
            while (!isValid)
            {
                isValid = true;
                if (string.IsNullOrWhiteSpace(val))
                {
                    Console.Write("Input data cannot be empty! Enter new data: ");
                    val = Console.ReadLine();
                    isValid = false;
                }
                else if (ContainsOnlyDigits(val) == false)
                {
                    Console.Write("Input data must be a number! Input new data: ");
                    val = Console.ReadLine();
                    isValid = false;
                }
                else if (int.TryParse(val.Trim(), out _) && int.Parse(val.Trim()) <= 0)
                {
                    Console.Write("Input data cannot be negative or a 0! Enter new data: ");
                    val = Console.ReadLine();
                    isValid = false;
                }
            }
            return int.Parse(val.Trim());
        }
    }
}
