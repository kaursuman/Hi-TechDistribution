using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Hi_TechDistribution.Validation
{
    public static class ValidatorUser
    {
        public static bool IsValidId(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{5}$"))
            {

                MessageBox.Show("Invalid User Id", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }
        public static bool IsValidPassword(string input)
        {
            string error = "User password must be of characters or Space(s) ";
            if (input.Length == 0)
            {
                MessageBox.Show(error, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                
                if (!(Char.IsLetter(input[i])) && !(Char.IsWhiteSpace(input[i])))
                {

                    MessageBox.Show(error, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;

        }

    }
}
