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
    public partial class ManageUsers : Form
    {
        private UserTypeService userTypeService;
        private UserService userService;
        private List<UserType> userTypes = new List<UserType>();
        private List<User> users = new List<User>();
        private Dictionary<string, int> userTypeMap;
        public ManageUsers()
        {
            InitializeComponent();
            userTypeMap = new Dictionary<string, int>();
            userTypeService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER_TYPE);
            userService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER);
            FetchUserTypes();
            FetchAllUsers();
        }

        void FetchUserTypes() {
            userTypes = userTypeService.GetAll();
            userTypes.ForEach(value => {
                userTypeMap.Add(value.Type, value.Id);
                cmbUserTypes.Items.Add(value.Type);
            });
        }

        void FetchAllUsers() {
            users.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("Name");
            dt.Columns.Add("Address");
            dt.Columns.Add("Contact Number");
            users = userService.GetAll();

            users.ForEach(value => {
                DataRow row = dt.NewRow();
                row["Name"] = value.Name;
                row["Address"] = value.Address;
                row["Contact Number"] = value.ContactNumber;
                dt.Rows.Add(row);
            });

            foreach (DataRow dataRow in dt.Rows) {
                int v = tblUsers.Rows.Add();
                tblUsers.Rows[v].Cells[0].Value = dataRow["Name"].ToString();
                tblUsers.Rows[v].Cells[1].Value = dataRow["Address"].ToString();
                tblUsers.Rows[v].Cells[2].Value = dataRow["Contact Number"].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User();
                user.Name = txtName.Text;
                user.UserName = txtUsername.Text;
                var encryptedPassword = EncryptDecryptPassword.EncryptPlainTextToCipherText(txtPassword.Text);
                user.Password = txtPassword.Text;
                user.Address = txtAddress.Text;
                user.ContactNumber = txtContactNo.Text;
                UserType userType = userTypeService.Get(userTypeMap[cmbUserTypes.Text]);
                user.UserType = userType;
                userService.Save(user);
                FetchAllUsers();
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }
    }
}
