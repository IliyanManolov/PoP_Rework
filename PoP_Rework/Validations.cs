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
            foreach (char c in input)
            {
                if (Char.IsLetter(c) == false)
                    return false;
            }
            return true;
        }

        static public bool ContainsOnlyDigits(string input)
        {
            foreach (char c in input)
            {
                if (Char.IsDigit(c) == false)
                    return false;
            }
            return true;
        }
    }
}
