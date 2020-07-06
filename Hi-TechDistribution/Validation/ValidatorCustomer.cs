using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Hi_TechDistribution.Validation
{
    public class ValidatorCustomer
    {
        public static bool IsValidId(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{5}$"))
            {
                MessageBox.Show("Enter a valid Customer Id", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        public static bool IsValidName(string input)
        {
            string error = "Customer Name must be of characters or Space(s) ";
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
        public static bool IsValidStreet(string input)
        {
            string error = "Street Name must be of characters or Space(s) ";
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
        public static bool IsValidCity(string input)
        {
            string error = "City Name must be of characters or Space(s) ";
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
        public static bool IsValidPostal(string input)
        {
            if (!Regex.IsMatch(input, @"^[A-Z]\d[A-Z] \d[A-Z]\d$"))
            {

                MessageBox.Show("Enter a valid Postal Code", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public static bool IsValidPhone(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{10}$"))
            {

                MessageBox.Show("Enter a valid Phone Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        public static bool IsValidFax(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{10}$"))
            {

                MessageBox.Show("Enter a valid fax Number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
   
        public static bool IsValidCredit(string input)
        {
            if (!Regex.IsMatch(input, @"^\d{4}$"))
            {

                MessageBox.Show("Enter a valid Credit Limit", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    
    }
}
