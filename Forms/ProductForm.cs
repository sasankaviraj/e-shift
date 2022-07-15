using e_shift.Data;
using e_shift.Factory;
using e_shift.Service;
using e_shift.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_shift.Forms
{
    public partial class ProductForm : Form
    {
        private ProductService productService;
        private List<Product> products = new List<Product>();
        private DataGridViewRow row;
        private bool setUpdate = false;
        public ProductForm()
        {
            InitializeComponent();
            InitializeComponent();
            productService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.PRODUCT);
            FetchProducts();
            setTable();
        }
        private void FetchProducts()
        {
            
            try
            {
                products = productService.GetAll();
                tblProducts.DataSource = products;
                tblProducts.Columns["IsDeleted"].Visible = false;
                tblProducts.Columns["CreatedAt"].Visible = false;
                tblProducts.Columns["ModifiedAt"].Visible = false;
                tblProducts.Columns["DeletedAt"].Visible = false;
                tblProducts.Columns["Users"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void setTable()
        {
            DataGridViewButtonColumn buttonColumnEdit = new DataGridViewButtonColumn
            {
                Text = "Edit",
                UseColumnTextForButtonValue = true,
            };
            DataGridViewButtonColumn buttonColumnDelete = new DataGridViewButtonColumn
            {
                Text = "Delete",
                UseColumnTextForButtonValue = true,
            };
            tblProducts.Columns.Insert(3, buttonColumnEdit);
            tblProducts.Columns.Insert(4, buttonColumnDelete);
        }

        private void ClearFields()
        {
            txtProductType.Clear();
            txtCharges.Clear();
            setUpdate = false;
            row.Selected = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (setUpdate)
            {
                try
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(row.Cells[2].Value);
                    product.Type = Validator.ValidateField(txtProductType.Text, "Product Type");
                    product.Charges = Convert.ToInt32(Validator.ValidateNumbersWithDecimal(txtCharges.Text, "Charges"));
                    productService.Update(product);
                    FetchProducts();
                    ClearFields();
                    MessageBox.Show("Product Type Updated Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                try
                {
                    string text = txtProductType.Text;
                    string text1 = txtCharges.Text;
                    Console.WriteLine();
                    Product product = new Product();
                    product.Charges = Convert.ToInt32(Validator.ValidateNumbersWithDecimal(txtCharges.Text, "Charges"));
                    product.Type = Validator.ValidateField(txtProductType.Text, "Product Type");
                    productService.Save(product);
                    FetchProducts();
                    MessageBox.Show("Product Saved Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tblProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = tblProducts.Rows[e.RowIndex];
            row.Selected = true;
            if (e.ColumnIndex == 0)
            {
                setUpdate = true;
                txtProductType.Text = row.Cells[3].Value.ToString();
                txtCharges.Text = row.Cells[4].Value.ToString();
            }
            if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Delete Product Type", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var v = row.Cells[2].Value;
                        productService.Delete(Convert.ToInt32(row.Cells[2].Value));
                        FetchProducts();
                        MessageBox.Show("Product Type Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
    }
}
