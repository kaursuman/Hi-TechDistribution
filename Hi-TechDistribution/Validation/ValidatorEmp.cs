using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Hi_TechDistribution.Validation
{
    public static class ValidatorEmp
    {
        public static bool IsValidId(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{5}$"))
            {

                MessageBox.Show("Enter a valid Employee Id", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;

        }
        
        public static bool IsValidName(string input)
        {
            string error = "Employee Name must be of characters or Space(s) ";
            if (input.Length == 0)
            {
                MessageBox.Show(error, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            for (int i = 0; i < input.Length; i++)
            {
                //MessageBox.Show(input[i].ToString());
                if (!(Char.IsLetter(input[i])) && !(Char.IsWhiteSpace(input[i])))
                {

                    MessageBox.Show(error, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;

        }

        public static bool IsValidJob(string input)
        {
            string error = "Employee Job must be of characters or Space(s) ";
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

