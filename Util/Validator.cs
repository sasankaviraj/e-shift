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
        public static string ValidateName(string input) {
            bool v = Regex.IsMatch(input, @"^[a-zA-Z]+$");
            if (!v) {
                throw new Exception("Invalid Characters In The Name");
            }
            return input;
        }

        public static string ValidateContactNumber(string input)
        {
            bool v = Regex.IsMatch(input, @"^([0-9]{10,12})$");
            if (!v)
            {
                throw new Exception("Invalid Contact Number");
            }
            return input;
        }
    }
}
