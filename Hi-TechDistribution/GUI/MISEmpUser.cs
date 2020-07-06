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
    public partial class MISEmpUser : Form
    {
        public MISEmpUser()
        {
            InitializeComponent();
        }

        private void BtnUser_Click(object sender, EventArgs e)
        {
            this.Hide();
            Users myuser = new Users();
            myuser.Show();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Employees mypage = new Employees();
            mypage.Show();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            SignUp mysign = new SignUp();
            mysign.Show();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }
    }
}
