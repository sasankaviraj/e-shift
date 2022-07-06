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
    public partial class LoginForm : Form
    {
        private UserService userService;
        public LoginForm()
        {
            InitializeComponent();
            userService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.USER);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            User user = new User();
            user.UserName = txtUsername.Text;
            user.Password = txtPassword.Text;
            try {
                bool v = userService.Find(user);
                if (v)
                {
                    LoggedUserTemp.LoggedUserTempName = user.UserName;
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else {
                    throw new Exception("Invalid Password");
                }
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
