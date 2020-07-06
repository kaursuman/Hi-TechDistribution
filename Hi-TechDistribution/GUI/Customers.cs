using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Hi_TechDistribution.Business;
using Hi_TechDistribution.DataAccess;
using Hi_TechDistribution.Validation;

namespace Hi_TechDistribution.GUI
{
    public partial class Customers : Form
    {
        SqlDataAdapter da;
        DataSet dsCustomerDB;
        DataTable dtCustomers;
        SqlCommandBuilder sqlBuilder;
        Customer cust = new Customer();

        public Customers()
        {
            InitializeComponent();
        }

        private void ButtonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxOption.SelectedIndex == 1 && txtInput.Text != "")
            {
                DataRow dr = dsCustomerDB.Tables[0].Rows.Find(txtInput.Text.Trim());
                txtCustomerId.Text = Convert.ToString(dr["CustomerId"]);
                txtName.Text = Convert.ToString(dr["Name"]);
                txtStreet.Text = Convert.ToString(dr["Street"]);
                txtCity.Text = Convert.ToString(dr["City"]);
                txtPostal.Text = Convert.ToString(dr["PostalCode"]);
                txtPhoneNumber.Text = Convert.ToString(dr["PhoneNumber"]);
                txtFaxNumber.Text = Convert.ToString(dr["FaxNumber"]);
                txtCredit.Text = Convert.ToString(dr["CreditLimit"]);
            }
            else if(comboBoxOption.SelectedIndex == 2 && txtInput.Text != "")
            {
              
            }
            else
            {
                MessageBox.Show("No Employee data in the database", "No Employee Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void Customers_Load(object sender, EventArgs e)
        {            
            dsCustomerDB = new DataSet("CustomerDB");            
            dtCustomers = new DataTable("Customers");
            
            dtCustomers.Columns.Add("CustomerId", typeof(int));
            dtCustomers.Columns.Add("Name", typeof(string));
            dtCustomers.Columns.Add("Street", typeof(string));
            dtCustomers.Columns.Add("City", typeof(string));
            dtCustomers.Columns.Add("PostalCode", typeof(string));
            dtCustomers.Columns.Add("PhoneNumber", typeof(string));
            dtCustomers.Columns.Add("FaxNumber", typeof(string));
            dtCustomers.Columns.Add("CreditLimit", typeof(int));
            
            dtCustomers.PrimaryKey = new DataColumn[] { dtCustomers.Columns["CustomerId"] };

            dsCustomerDB.Tables.Add(dtCustomers);
            da = new SqlDataAdapter("SELECT * FROM Customers", UtilityDB.ConnectDB());
            da.Fill(dsCustomerDB.Tables["Customers"]);
        }

        private void BtnListStudents_Click(object sender, EventArgs e)
        {
            dataGridViewCustomerDB.DataSource = cust.ListCustomer();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {

            if (!ValidatorCustomer.IsValidId(txtCustomerId.Text))
            {
                txtCustomerId.Clear();
                txtCustomerId.Focus();
                
            }
            else if(!ValidatorCustomer.IsValidName(txtName.Text))
            {
                txtName.Clear();
                txtName.Focus();
            }
            else if (!ValidatorCustomer.IsValidStreet(txtStreet.Text))
            {
                txtStreet.Clear();
                txtStreet.Focus();
            }
            else if(!ValidatorCustomer.IsValidCity(txtCity.Text))
            {
                txtCity.Clear();
                txtCity.Focus();
            }
            else if (!ValidatorCustomer.IsValidPostal(txtPostal.Text))
            {
                txtPostal.Clear();
                txtPostal.Focus();
            }
            else if(!ValidatorCustomer.IsValidPhone(txtPhoneNumber.Text))
            {
                txtPhoneNumber.Clear();
                txtPhoneNumber.Focus();
            }
         
            else if(!ValidatorCustomer.IsValidFax(txtFaxNumber.Text))
            {
                txtFaxNumber.Clear();
                txtFaxNumber.Focus();
            }
            else if (!ValidatorCustomer.IsValidCredit(txtCredit.Text))
            {
                txtCredit.Clear();
                txtCredit.Focus();
            }
            else
            {
                cust.CustomerId = Convert.ToInt32(txtCustomerId.Text.Trim());
                cust.Name = txtName.Text.Trim();
                cust.Street = txtStreet.Text.Trim();
                cust.City = txtCity.Text.Trim();
                cust.PostalCode = txtPostal.Text.Trim();
                cust.PhoneNumber = txtPhoneNumber.Text.Trim();
                cust.FaxNumber = txtFaxNumber.Text.Trim();
                cust.CreditLimit = Convert.ToInt32(txtCredit.Text.Trim());
                dtCustomers.Rows.Add(cust.CustomerId, cust.Name, cust.Street, cust.City, cust.PostalCode, cust.PhoneNumber, cust.FaxNumber, cust.CreditLimit);
                txtCustomerId.Clear();
                txtName.Clear();
                txtStreet.Clear();
                txtCity.Clear();
                txtPostal.Clear();
                txtPhoneNumber.Clear();
                txtFaxNumber.Clear();
                txtCredit.Clear();
            }
                
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            if (!ValidatorCustomer.IsValidId(txtInput.Text))
            {
                txtInput.Clear();
                txtInput.Focus();
            }
            else if (txtInput.Text != null)
            {
                sqlBuilder = new SqlCommandBuilder(da);
                DataRow row = dsCustomerDB.Tables["Customers"].Rows.Find(Convert.ToInt32(txtInput.Text.Trim()));
                row.Delete();
                da.Update(dsCustomerDB, "Customers");
                MessageBox.Show("Record Deleted Successfully","Delete Record",MessageBoxButtons.OK,MessageBoxIcon.Information);
                dataGridViewCustomerDB.DataSource = dsCustomerDB.Tables["Customers"];
                txtInput.Clear();
            }
            else
            {
                MessageBox.Show("Please enter the CustomerId to delete a record", "Deletion Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInput.Focus();
            }
            
           
        }

        private void BtnListFromDB_Click(object sender, EventArgs e)
        {
            dataGridViewCustomerDB.DataSource = cust.ListCustomer();
        }

        private void BtnListFromDS_Click(object sender, EventArgs e)
        {
            dataGridViewCustomerDS.DataSource = dsCustomerDB.Tables["Customers"];
        }

        private void BtnModify_Click(object sender, EventArgs e)
        {
            sqlBuilder = new SqlCommandBuilder(da);
            da.Update(dsCustomerDB.Tables["Customers"]);
            MessageBox.Show("Database has been updated successfully.", "Confirmation");
            dataGridViewCustomerDB.DataSource = cust.ListCustomer();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
            SalesCustomer mypage = new SalesCustomer();
            mypage.Show();
        }

        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            if(!ValidatorCustomer.IsValidId(txtInput.Text))
            {
                txtInput.Clear();
                txtInput.Focus();
            }
            else if(txtInput.Text!=null)
            {
                DataRow dr = dsCustomerDB.Tables[0].Rows.Find(txtCustomerId.Text.Trim());
                dr["CustomerId"] = txtCustomerId.Text.Trim();
                dr["Name"] = txtName.Text.Trim();
                dr["Street"] = txtStreet.Text.Trim();
                dr["City"] = txtCity.Text.Trim();
                dr["PostalCode"] = txtPostal.Text.Trim();
                dr["PhoneNumber"] = txtPhoneNumber.Text.Trim();
                dr["FaxNumber"] = txtFaxNumber.Text.Trim();
                dr["CreditLimit"] = txtCredit.Text.Trim();
                sqlBuilder = new SqlCommandBuilder(da);
                da.Update(dsCustomerDB.Tables["Customers"]);
                MessageBox.Show("Customer has been updated successfully..", "Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridViewCustomerDB.DataSource = dsCustomerDB.Tables[0];
                txtCustomerId.Clear();
                txtName.Clear();
                txtStreet.Clear();
                txtCity.Clear();
                txtPostal.Clear();
                txtPhoneNumber.Clear();
                txtFaxNumber.Clear();
                txtCredit.Clear();

            }
            else
            {
                MessageBox.Show("Please enter the valid data to update a record", "Updation Unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtInput.Focus();
            }

        }

        private void ComboBoxOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexSelected = comboBoxOption.SelectedIndex;
            switch (indexSelected)
            {
                case 0:
                    lblMessage.Text = "Please Select search option";
                    txtInput.Clear();
                    txtInput.Focus();

                    break;
                case 1://Search by CustomerId
                    lblMessage.Text = "Please Enter Customer ID";
                    txtInput.Clear();
                    txtInput.Focus();
                    break;
                case 2://Search by City
                    lblMessage.Text = "Please Enter City";
                    txtInput.Clear();
                    txtInput.Focus();
                    break;
                case 3://Search by PostalCode
                    lblMessage.Text = "Please Enter Postal Code";
                    txtInput.Clear();
                    txtInput.Focus();
                    break;

                default:
                    lblMessage.Text = "Please Select the Search Option";
                    break;
            }
        }

       
    }
}
