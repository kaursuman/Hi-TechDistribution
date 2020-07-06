using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hi_TechDistribution.DataAccess;
using Hi_TechDistribution.Business;
using Hi_TechDistribution.Validation;


namespace Hi_TechDistribution.GUI
{
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string input = "";
            Employee emp = new Employee();
            
            input = txtFirstName.Text.Trim();
            if (!ValidatorEmp.IsValidName(input))
            {
                txtFirstName.Clear();
                txtFirstName.Focus();
                return;
            }

            input = txtLastName.Text.Trim();
            if (!ValidatorEmp.IsValidName(input))
            {
                txtLastName.Clear();
                txtLastName.Focus();
                return;
            }
            input = txtJobTitle.Text.Trim();
            if (!ValidatorEmp.IsValidJob(input))
            {
                txtJobTitle.Clear();
                txtJobTitle.Focus();
                return;
            }            
            //emp.EmployeeId = Convert.ToInt32(txtEmpId.Text.Trim());
            emp.FirstName = txtFirstName.Text.Trim();
            emp.LastName = txtLastName.Text.Trim();
            emp.JobTitle = txtJobTitle.Text.Trim();
            emp.SaveEmployee(emp);
            MessageBox.Show("Employee record has been saved successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtFirstName.Clear();
            txtLastName.Clear();
            txtJobTitle.Clear();
        }

        private void BtnListStudents_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            dataGridViewEmployee.DataSource = emp.GetEmployeeList();
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Employee emp = new Employee();
            string input = "";
            input = Convert.ToString(txtInput.Text.Trim());
            if(!ValidatorEmp.IsValidId(input))
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
                    emp.DeleteEmployee(Convert.ToInt32(txtInput.Text));
                    MessageBox.Show("Employee data has been deleted successfully...", "Delete Information..", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtInput.Text = "";
                }
                else
                {
                    MessageBox.Show("You donot want to delete the data...", "No deletion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            txtInput.Clear();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            MISEmpUser mysign = new MISEmpUser();
            mysign.Show();
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            string input = "";
            Employee emp = new Employee();
            //input = txtInput.Text.Trim();   

            input = txtFirstName.Text.Trim();
            if (!ValidatorEmp.IsValidName(input))
            {
                txtFirstName.Clear();
                txtFirstName.Focus();
                return;
            }

            input = txtLastName.Text.Trim();
            if (!ValidatorEmp.IsValidName(input))
            {
                txtLastName.Clear();
                txtLastName.Focus();
                return;
            }
            input = txtJobTitle.Text.Trim();
            if (!ValidatorEmp.IsValidName(input))
            {
                txtJobTitle.Clear();
                txtJobTitle.Focus();
                return;
            }
            emp.EmployeeId = Convert.ToInt32(txtInput.Text.Trim());
            emp.FirstName = txtFirstName.Text.Trim();
            emp.LastName = txtLastName.Text.Trim();
            emp.JobTitle = txtJobTitle.Text.Trim();
            emp.UpdateEmployee(emp);
            MessageBox.Show("Employee record has been updated successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtFirstName.Clear();
            txtLastName.Clear();
            txtJobTitle.Clear();
            txtInput.Clear();
        }     

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxOption.SelectedIndex == 1 && txtInput.Text != "")
            {
                string input = "";
                Employee emp = new Employee();
                input = txtInput.Text.Trim();
                if(!ValidatorEmp.IsValidId(input))
                {
                    txtInput.Clear();
                    txtInput.Focus();
                }
                else
                {
                    emp = emp.SearchEmployee(Convert.ToInt32(txtInput.Text.Trim()));
                    if (emp != null)
                    {
                        txtFirstName.Text = emp.FirstName;
                        txtLastName.Text = emp.LastName;
                        txtJobTitle.Text = emp.JobTitle;
                    }
                    else
                    {
                        MessageBox.Show("No Employee data in the database", "No Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                
                
            }
            else
            {
                string name = "";
                name = txtInput.Text.Trim();
                Employee emp = new Employee();
                List<Employee> listEmp = emp.SearchEmployee(name);

                if (listEmp != null)
                {
                    foreach (Employee empItem in listEmp.ToList())
                    {
                        ListViewItem item = new ListViewItem(Convert.ToString(empItem.EmployeeId));
                        item.SubItems.Add(empItem.FirstName);
                        item.SubItems.Add(empItem.LastName);
                        item.SubItems.Add(empItem.JobTitle);
                        listEmp.Add(empItem);
                    }
                    dataGridViewEmployee.DataSource = listEmp;
                    
                }
                else
                {
                    MessageBox.Show("No Employee data in the database", "No Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                }
            }
        }

        private void ComboBoxOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = comboBoxOption.SelectedIndex;
            switch (indexSelected)
            {
                case 0:
                    labelMessage.Text = "Please Select search option";
                    txtInput.Clear();
                    txtInput.Focus();

                    break;
                case 1://Search by EmployeeId
                    labelMessage.Text = "Please Enter Employee ID";
                    txtInput.Clear();
                    txtInput.Focus();
                    break;
                case 2://Search by FirstName
                    labelMessage.Text = "Please Enter First Name";
                    txtInput.Clear();
                    txtInput.Focus();
                    break;
                case 3://Search by LastName
                    labelMessage.Text = "Please Enter Last Name";
                    txtInput.Clear();
                    txtInput.Focus();
                    break;

                default:
                    labelMessage.Text = "Please Select the Search Option";
                    break;
            }
        }

        
    }
}
