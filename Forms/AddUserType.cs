using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using e_shift.Data;
using e_shift.Factory;
using e_shift.Service;
using e_shift.Util;

namespace e_shift.Forms
{
    public partial class AddUserType : Form
    {
        private UserTypeService userTypeService;
        private List<UserType> userTypes = new List<UserType>();
        private DataGridViewRow row;
        private bool setUpdate = false;
        public AddUserType()
        {
            InitializeComponent();
            userTypeService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER_TYPE);
            FetchUserTypes();
            setTable();
        }

        private void FetchUserTypes() { 
         userTypes = userTypeService.GetAll();
            tblUserTypes.DataSource = userTypes;
            tblUserTypes.Columns["IsDeleted"].Visible = false;
            tblUserTypes.Columns["CreatedAt"].Visible = false;
            tblUserTypes.Columns["ModifiedAt"].Visible = false;
            tblUserTypes.Columns["DeletedAt"].Visible = false;
            tblUserTypes.Columns["Users"].Visible = false;

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
            tblUserTypes.Columns.Insert(3, buttonColumnEdit);
            tblUserTypes.Columns.Insert(4, buttonColumnDelete);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (setUpdate)
            {
                try
                {
                    UserType userType = new UserType();
                    userType.Id = Convert.ToInt32(row.Cells[2].Value);
                    userType.Type = Validator.ValidateField(txtUserType.Text,"User Type");
                    userTypeService.Update(userType);
                    FetchUserTypes();
                    ClearFields();
                    MessageBox.Show("User Type Updated Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
            else {
                try
                {
                    var userType = new UserType();
                    userType.Type = Validator.ValidateField(txtUserType.Text, "User Type");
                    userTypeService.Save(userType);
                    FetchUserTypes();
                    MessageBox.Show("User Type Saved Successfully");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tblUserTypes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = tblUserTypes.Rows[e.RowIndex];
            row.Selected = true;
            if (e.ColumnIndex == 0)
            {
                setUpdate = true;
                txtUserType.Text = row.Cells[3].Value.ToString();
            }
            if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Delete User Type", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        var v = row.Cells[2].Value;
                        userTypeService.Delete(Convert.ToInt32(row.Cells[2].Value));
                        FetchUserTypes();
                        MessageBox.Show("User Type Deleted Successfully");
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

        private void ClearFields() {
            txtUserType.Clear();
            setUpdate = false;
            row.Selected = false;
        }
    }
}
