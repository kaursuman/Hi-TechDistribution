using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hi_TechDistribution.GUI
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserId.Text == "13115" && txtPassword.Text == "Brown")
            {
                this.Hide();
                MISEmpUser myemp = new MISEmpUser();
                myemp.Show();
            }
            else if (txtUserId.Text == "13116" && txtPassword.Text == "Moore")
            {
                this.Hide();
                Customers cus = new Customers();
                cus.Show();
            }
            else
            {
                MessageBox.Show("Enter correct UserName and Password ", "Invalid Entry ",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }

        }
    }
}
