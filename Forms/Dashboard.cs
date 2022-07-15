﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using e_shift.Util;
using e_shift.Factory;
using e_shift.Service;
using e_shift.Model;

namespace e_shift.Forms
{
    public partial class Dashboard : Form
    {
        private JobService jobService;
        [DllImport("Gdi32.dll",EntryPoint = "CreateRoundRectRgn")]

        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );
        public Dashboard()
        {
            InitializeComponent();
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0,0,Width,Height,25,25));
            panelNav.Height = btnDashboard.Height;
            panelNav.Top = btnDashboard.Top;
            panelNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46, 51, 73);
            lblUserName.Text = LoggedUserTemp.LoggedUser.UserName;
            jobService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.JOB);
        }

        public void loadForm(object Form) {
            if (this.pnlDashBoard.Controls.Count>0) {
                this.pnlDashBoard.Controls.RemoveAt(0);
            }

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.pnlDashBoard.Controls.Add(f);
            this.pnlDashBoard.Tag = f;
            f.Show();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            loadForm(new DashboardForm());
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            loadForm(new DashboardForm());
            panelNav.Height = btnDashboard.Height;
            panelNav.Top = btnDashboard.Top;
            panelNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(46,51,73);
        }

        private void btnCustomers_Click(object sender, EventArgs e)
        {
            loadForm(new TransportForm());
            panelNav.Height = btnTransport.Height;
            panelNav.Top = btnTransport.Top;
            panelNav.Left = btnTransport.Left;
            btnTransport.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            loadForm(new ManageJobs());
            panelNav.Height = btnJobs.Height;
            panelNav.Top = btnJobs.Top;
            panelNav.Left = btnJobs.Left;
            btnJobs.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            loadForm(new ManageUsers(false));
            panelNav.Height = btnUsers.Height;
            panelNav.Top = btnUsers.Top;
            panelNav.Left = btnUsers.Left;
            btnUsers.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnLocations_Click(object sender, EventArgs e)
        {
            loadForm(new LocationForm());
            panelNav.Height = btnLocations.Height;
            panelNav.Top = btnLocations.Top;
            panelNav.Left = btnLocations.Left;
            btnLocations.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnUsertypes_Click(object sender, EventArgs e)
        {
            loadForm(new ProductForm());
            panelNav.Height = btnProducttypes.Height;
            panelNav.Top = btnProducttypes.Top;
            panelNav.Left = btnProducttypes.Left;
            btnProducttypes.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            loadForm(new ReportForm());
            panelNav.Height = btnReports.Height;
            panelNav.Top = btnReports.Top;
            panelNav.Left = btnReports.Left;
            btnReports.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnCustomers_Leave(object sender, EventArgs e)
        {
            btnTransport.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnJobs_Leave(object sender, EventArgs e)
        {
            btnJobs.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnUsers_Leave(object sender, EventArgs e)
        {
            btnUsers.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnLocations_Leave(object sender, EventArgs e)
        {
            btnLocations.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnUsertypes_Leave(object sender, EventArgs e)
        {
            btnProducttypes.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnReports_Leave(object sender, EventArgs e)
        {
            btnReports.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSignOut_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try {
                List<JobsTableModel> jobsTableModels = jobService.Search(txtSearch.Text);
                JobSearchPopup jobSearchPopup = new JobSearchPopup(jobsTableModels);
                jobSearchPopup.Show();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
