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
    public partial class CustomerForm : Form
    {
        private CustomerService customerService;
        private List<Customer> customers = new List<Customer>();
        private bool setUpdate = false;
        private DataGridViewRow row;
        public CustomerForm()
        {
            InitializeComponent();
            customerService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.CUSTOMER);
            FetchAllCustomers();
            SetTable();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void clearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtNIC.Clear();
            txtAddress.Clear();
            txtContactNumber.Clear();
            setUpdate = false;
        }

        private void FetchAllCustomers()
        {
            customers = customerService.GetAll();
            tblCustomers.DataSource = customers;
            tblCustomers.Columns["IsDeleted"].Visible = false;
            tblCustomers.Columns["CreatedAt"].Visible = false;
            tblCustomers.Columns["ModifiedAt"].Visible = false;
            tblCustomers.Columns["DeletedAt"].Visible = false;
        }

        private void SetTable()
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
            tblCustomers.Columns.Insert(7, buttonColumnEdit);
            tblCustomers.Columns.Insert(8, buttonColumnDelete);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (setUpdate)
                {
                    var customer = new Customer();
                    customer.FirstName = Validator.ValidateField(txtFirstName.Text, "First Name");
                    customer.LastName = Validator.ValidateField(txtLastName.Text, "Last Name");
                    customer.Id = Convert.ToInt32(row.Cells[2].Value);
                    customer.Address = txtAddress.Text;
                    customer.NIC = Validator.ValidateNIC(txtNIC.Text);
                    customer.ContactNumber = Validator.ValidateContactNumber(txtContactNumber.Text);
                    customerService.Update(customer);
                    FetchAllCustomers();
                    MessageBox.Show("Customer Details Updated Successfully");
                    clearFields();
                }
                else
                {
                    var customer = new Customer();
                    customer.FirstName = Validator.ValidateField(txtFirstName.Text, "First Name");
                    customer.LastName = Validator.ValidateField(txtLastName.Text, "Last Name");
                    customer.Address = txtAddress.Text;
                    customer.NIC = Validator.ValidateNIC(txtNIC.Text);
                    customer.ContactNumber = Validator.ValidateContactNumber(txtContactNumber.Text);
                    customerService.Save(customer);
                    FetchAllCustomers();
                    MessageBox.Show("Customer Details Saved Successfully");
                    clearFields();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
                MessageBox.Show("Failed To Save The Customer. " + ex.Message);
            }
        }

        private void tblCustomers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearFields();
            row = tblCustomers.Rows[e.RowIndex];
            row.Selected = true;
            if (e.ColumnIndex == 0)
            {
                setUpdate = true;

                txtFirstName.Text = row.Cells[3].Value.ToString();
                txtLastName.Text = row.Cells[4].Value.ToString();
                txtNIC.Text = row.Cells[5].Value.ToString();
                txtAddress.Text = row.Cells[6].Value.ToString();
                txtContactNumber.Text = row.Cells[7].Value.ToString();
            }
            if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Delete Customer", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        customerService.Delete(Convert.ToInt32(row.Cells[2].Value));
                        FetchAllCustomers();
                        MessageBox.Show("Customer Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }


            }
        }
    }
}
