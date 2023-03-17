using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoP_Rework
{
    public class Address
    {
        public string ExactAddress { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public override string ToString() //don't remove, otherwise EVERYTHING breaks
        {
            return ExactAddress + " " + Street + ", " + City + ", " + Country;
        }
    }
}
