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
        private Dictionary<string, int> userTypeMap = new Dictionary<string, int>();
        public ManageUsers()
        {
            InitializeComponent();
            userTypeService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER_TYPE);
            userService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER);
            FetchUserTypes();
        }

        void FetchUserTypes() {
            userTypes = userTypeService.GetAll();
            userTypes.ForEach(value => {
                userTypeMap.Add(value.Type, value.Id);
                cmbUserTypes.Items.Add(value.Type);
            });
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var user = new User();
                user.UserName = txtUsername.Text;
                var encryptedPassword = EncryptDecryptPassword.EncryptPlainTextToCipherText(txtPassword.Text);
                user.Password = txtPassword.Text;
                user.Address = txtAddress.Text;
                user.ContactNumber = txtContactNo.Text;
                UserType userType = userTypeService.Get(userTypeMap[cmbUserTypes.Text]);
                user.UserType = userType;
                userService.Save(user);
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }


    }
}
