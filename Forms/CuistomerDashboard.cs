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
    public partial class CuistomerDashboard : Form
    {
        public CuistomerDashboard()
        {
            InitializeComponent();
            lblUserName.Text = (LoggedUserTemp.LoggedUserTempName.Equals("")) ? "Click To Sign In" : LoggedUserTemp.LoggedUserTempName;
        }

        public void loadForm(object Form)
        {
            if (this.pnlDashBoard.Controls.Count > 0)
            {
                this.pnlDashBoard.Controls.RemoveAt(0);
            }

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.pnlDashBoard.Controls.Add(f);
            this.pnlDashBoard.Tag = f;
            f.Show();
        }
        private void btnSignOut_Click(object sender, EventArgs e)
        {

        }

        private void CuistomerDashboard_Load(object sender, EventArgs e)
        {
            loadForm(new ManageJobs());
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lblUserName_Click(object sender, EventArgs e)
        {
            if (LoggedUserTemp.LoggedUserId.Equals("")) {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }
    }
}
