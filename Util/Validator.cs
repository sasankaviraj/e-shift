using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace e_shift.Util
{
    public class Validator
    {
        public static string ValidateField(string input,string type) {
            bool v = Regex.IsMatch(input, @"^[a-zA-Z]+$");
            if (!v) {
                throw new Exception("Invalid Characters In The "+type);
            }
            return input;
        }

        public static string ValidateContactNumber(string input)
        {
            bool v = Regex.IsMatch(input, @"^([0-9]{10})$");
            if (!v)
            {
                throw new Exception("Invalid Contact Number");
            }
            return input;
        }

        public static string ValidateNIC(string input)
        {
            if (input.Length == 10)
            {
                bool v = Regex.IsMatch(input, @"^([0-9]{9}[x|X|v|V]|[0-9]{12})$");
                if (!v)
                {
                    throw new Exception("Invalid NIC Number");
                }
                return input;
            }
            else if (input.Length == 11)
            {
                bool v = Regex.IsMatch(input, @"^([0-9]{9}[x|X|v|V]|[0-9]{11})$");
                if (!v)
                {
                    throw new Exception("Invalid NIC Number");
                }
                return input;
            }
            else {
                throw new Exception("Invalid NIC Number");
            }

        }
    }
}
