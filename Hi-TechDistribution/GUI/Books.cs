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

namespace Hi_TechDistribution.GUI
{
    public partial class Books : Form
    {
        public Books()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            
            Book book1 = new Book();
            book1.Isbn = Convert.ToInt32(txtISBN.Text.Trim());
            book1.Title = txtTitle.Text.Trim();
            book1.UnitPrice = Convert.ToInt32(txtUnitPrice.Text.Trim());
            book1.QuantityOnHand= Convert.ToInt32(txtQuantity.Text.Trim());
            book1.CategoryId = Convert.ToInt32(cmbBookCategory.SelectedItem);
            book1.PublisherId = Convert.ToInt32(cmbPublisher.SelectedItem);
            book1.SaveBook(book1);
            MessageBox.Show("Book record has been saved successfully", "Data Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            txtISBN.Clear();
            txtTitle.Clear();
            txtUnitPrice.Clear();
            txtQuantity.Clear();

        }

        private void cmbBookCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
