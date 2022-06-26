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

namespace e_shift.Forms
{
    public partial class AddUserType : Form
    {
        private UserTypeService userTypeService;
        public AddUserType()
        {
            InitializeComponent();
            userTypeService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER_TYPE);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var userType = new UserType();
                userType.Type = txtUserType.Text;
                userTypeService.Save(userType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
