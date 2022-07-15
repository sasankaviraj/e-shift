using e_shift.Data;
using e_shift.Factory;
using e_shift.Model;
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
    public partial class ManageUsers : Form
    {
        private UserService userService;
        private List<UserType> userTypes = new List<UserType>();
        private List<UserTableModel> users = new List<UserTableModel>();
        private Dictionary<string, int> userTypeMap;
        private bool setUpdate = false;
        private DataGridViewRow row;
        private bool isCustomerReg;
        public ManageUsers(bool isCustomerReg)
        {
            this.isCustomerReg = isCustomerReg;
            InitializeComponent();
            userTypeMap = new Dictionary<string, int>();
            userService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER);
            btnExit.Show();
            if (!(LoggedUserTemp.LoggedUser.UserName == null))
            {
                FetchAllUsers();
                SetTable();
                btnExit.Hide();
            }

        }


        private void FetchAllUsers() {
  
            users = userService.GetAll();
            tblUsers.DataSource = users;
            btnExit.Show();
            
        }

        private void SetTable() {
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
            tblUsers.Columns.Insert(5, buttonColumnEdit);
            tblUsers.Columns.Insert(6, buttonColumnDelete);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (setUpdate)
                {
                    var user = new User();
                    user.FirstName = Validator.ValidateField(txtFirstName.Text,"First Name");
                    user.LastName = Validator.ValidateField(txtLastName.Text, "Last Name");
                    user.NIC = Validator.ValidateNIC(txtNIC.Text);
                    user.Id = Convert.ToInt32(row.Cells[2].Value);
                    user.Address = txtAddress.Text;
                    user.ContactNumber = Validator.ValidateContactNumber(txtContactNo.Text);
                    user.UserType = "ADMIN";
                    userService.Update(user);
                    FetchAllUsers();
                    MessageBox.Show("User Details Updated Successfully");
                    clearFields();
                }
                else
                {
                    var user = new User();
                    user.FirstName = Validator.ValidateField(txtFirstName.Text, "First Name");
                    user.LastName = Validator.ValidateField(txtLastName.Text, "Last Name");
                    user.NIC = Validator.ValidateNIC(txtNIC.Text);
                    user.UserName = txtUsername.Text;
                    var encryptedPassword = EncryptDecryptPassword.EncryptPlainTextToCipherText(txtPassword.Text);
                    user.Password = encryptedPassword;
                    user.Address = txtAddress.Text;
                    user.ContactNumber = Validator.ValidateContactNumber(txtContactNo.Text);
                    user.UserType = isCustomerReg ? "CUSTOMER":"ADMIN";
                    userService.Save(user);
                    if (isCustomerReg) {
                        this.Hide();
                        LoginForm loginForm = new LoginForm();
                        loginForm.Show();
                    }
                    FetchAllUsers();
                    MessageBox.Show("User Saved Successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed To Save The User. " + ex.Message);
            }
        }

        private void tblUsers_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearFields();
            row = tblUsers.Rows[e.RowIndex];
            row.Selected = true;
            if (e.ColumnIndex == 0) {
                setUpdate = true;
                txtUsername.Enabled = false;
                txtPassword.Enabled = false;

                txtFirstName.Text = row.Cells[3].Value.ToString();
                txtLastName.Text = row.Cells[4].Value.ToString();
                txtNIC.Text = row.Cells[5].Value.ToString();
                txtAddress.Text = row.Cells[6].Value.ToString();
                txtContactNo.Text = row.Cells[7].Value.ToString();
            }
            if (e.ColumnIndex == 1) {
                DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Delete User", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try {
                        userService.Delete(Convert.ToInt32(row.Cells[2].Value));
                        FetchAllUsers();
                        MessageBox.Show("User Deleted Successfully");
                    }
                    catch (Exception ex) {
                        MessageBox.Show(ex.Message);
                    }
                }
                
                
            }
            
        }

        private void clearFields() {
            txtUsername.Enabled = true;
            txtPassword.Enabled = true;
            txtFirstName.Clear();
            txtLastName.Clear();
            txtNIC.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtAddress.Clear();
            txtContactNo.Clear();
            setUpdate = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
