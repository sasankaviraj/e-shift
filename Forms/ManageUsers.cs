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
        private UserTypeService userTypeService;
        private UserService userService;
        private List<UserType> userTypes = new List<UserType>();
        private List<UserTableModel> users = new List<UserTableModel>();
        private Dictionary<string, int> userTypeMap;
        private bool setUpdate = false;
        private DataGridViewRow row;
        public ManageUsers()
        {
            InitializeComponent();
            userTypeMap = new Dictionary<string, int>();
            userTypeService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER_TYPE);
            userService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER);
            FetchUserTypes();
            FetchAllUsers();
            setTable();
        }

        private void FetchUserTypes() {
            userTypes = userTypeService.GetAll();
            userTypes.ForEach(value => {
                userTypeMap.Add(value.Type, value.Id);
                cmbUserTypes.Items.Add(value.Type);
            });
        }

        private void FetchAllUsers() {
            users = userService.GetAll();
            tblUsers.DataSource = users;
        }

        private void setTable() {
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
                    user.Name = Validator.ValidateName(txtName.Text);
                    user.Id = Convert.ToInt32(row.Cells[2].Value);
                    user.Address = txtAddress.Text;
                    user.ContactNumber = Validator.ValidateContactNumber(txtContactNo.Text);
                    UserType userType = userTypeService.Get(userTypeMap[cmbUserTypes.Text]);
                    user.UserType = userType;
                    userService.Update(user);
                    FetchAllUsers();
                    MessageBox.Show("User Details Updated Successfully");
                    clearFields();
                }
                else
                {
                    var user = new User();
                    user.Name = Validator.ValidateName(txtName.Text);
                    user.UserName = txtUsername.Text;
                    var encryptedPassword = EncryptDecryptPassword.EncryptPlainTextToCipherText(txtPassword.Text);
                    user.Password = encryptedPassword;
                    user.Address = txtAddress.Text;
                    user.ContactNumber = Validator.ValidateContactNumber(txtContactNo.Text);
                    UserType userType = userTypeService.Get(userTypeMap[cmbUserTypes.Text]);
                    user.UserType = userType;
                    userService.Save(user);
                    FetchAllUsers();
                    MessageBox.Show("User Saved Successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed To Save The user. " + ex.Message);
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

                txtName.Text = row.Cells[3].Value.ToString();
                txtAddress.Text = row.Cells[4].Value.ToString();
                txtContactNo.Text = row.Cells[5].Value.ToString();
                cmbUserTypes.Text = row.Cells[6].Value.ToString();
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
            cmbUserTypes.ResetText();
            txtName.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtAddress.Clear();
            txtContactNo.Clear();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
