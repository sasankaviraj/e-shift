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
    public partial class CuistomerDashboard : Form
    {
        private JobService jobService;
        public CuistomerDashboard()
        {
            InitializeComponent();
            lblUserName.Text = (LoggedUserTemp.LoggedUser.UserName == null) ? "Click To Sign In" : LoggedUserTemp.LoggedUser.UserName;
            jobService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.JOB);
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
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
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
            if (LoggedUserTemp.LoggedUser.UserName == null) {
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
                this.Hide();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            loadForm(new ManageJobs());
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<JobsTableModel> jobsTableModels = jobService.Search(txtSearch.Text);
                JobSearchPopup jobSearchPopup = new JobSearchPopup(jobsTableModels);
                jobSearchPopup.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
