using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hi_TechDistribution.Business;
using Hi_TechDistribution.Validation;

namespace Hi_TechDistribution.GUI

{
    public partial class Users : Form
    {
        public Users()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            if (!ValidatorUser.IsValidId(txtUserId.Text.Trim()))
            {
                txtUserId.Clear();
                txtUserId.Focus();

                
            }
            else if (!ValidatorUser.IsValidPassword(txtPassword.Text.Trim()))
            {
                txtPassword.Clear();
                txtPassword.Focus();
            }
            else
            {
                u1.UserId = Convert.ToInt32(txtUserId.Text.Trim());            
                u1.Password = txtPassword.Text.Trim();
                u1.SaveUser(u1);
                MessageBox.Show("User record has been saved successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserId.Clear();
                txtPassword.Clear();
            }
           
        }

        private void BtnListStudents_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            dataGridViewUser.DataSource = u1.GetUserList();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            User u1 = new User();
            string input = "";
            input = Convert.ToString(txtInput.Text.Trim());
            if (!ValidatorEmp.IsValidId(input))
            {
                txtInput.Clear();
                txtInput.Focus();
            }
            else
            {
                DialogResult ans = MessageBox.Show("Do you really want to delete the data??", "Ask for delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (ans == DialogResult.Yes)
                {
                    MessageBox.Show("You want to delete the data...", "Want to Delete..", MessageBoxButtons.OK, MessageBoxIcon.Question);
                    u1.DeleteUser(Convert.ToInt32(txtInput.Text));
                    MessageBox.Show("User data has been deleted successfully...", "Delete Information..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInput.Text = "";
                }

                else
                {
                    MessageBox.Show("You donot want to delete the data...", "Donot Delete..", MessageBoxButtons.OK, MessageBoxIcon.Question);
                }
            }
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            string input = "";
            User u1 = new User();
            input = txtInput.Text.Trim();
            if (!ValidatorUser.IsValidId(txtUserId.Text.Trim()))
            {
                txtUserId.Clear();
                txtUserId.Focus();


            }
            else if (!ValidatorUser.IsValidPassword(txtPassword.Text.Trim()))
            {
                txtPassword.Clear();
                txtPassword.Focus();
            }
            else
            {
                u1.UserId = Convert.ToInt32(txtInput.Text.Trim());
                //u1.UserId = Convert.ToInt32(txtUserId.Text.Trim());
                u1.Password = txtPassword.Text.Trim();
                u1.UpdateUser(u1);
                MessageBox.Show("User record has been updated successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUserId.Clear();
                txtPassword.Clear();
                txtInput.Clear();
            }
           
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            string input = "";
            User u1 = new User();
            input = txtInput.Text.Trim();

            if (!ValidatorUser.IsValidId(input))
            {
                txtInput.Clear();
                txtInput.Focus();

            }

            else
            {
                if (u1 != null)
                {
                    u1 = u1.SearchUser(Convert.ToInt32(txtInput.Text.Trim()));
                    txtUserId.Text = Convert.ToString(u1.UserId);
                    txtPassword.Text = u1.Password;
                }
                else
                {
                    MessageBox.Show("No User data in the database", "No User Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            MISEmpUser mysign = new MISEmpUser();
            mysign.Show();
            
        }
    }
}
