using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace e_shift.Forms
{
    public partial class Dashboard : Form
    {
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
            loadForm(new CustomerForm());
            panelNav.Height = btnCustomers.Height;
            panelNav.Top = btnCustomers.Top;
            panelNav.Left = btnCustomers.Left;
            btnCustomers.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnJobs_Click(object sender, EventArgs e)
        {
            panelNav.Height = btnJobs.Height;
            panelNav.Top = btnJobs.Top;
            panelNav.Left = btnJobs.Left;
            btnJobs.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            loadForm(new ManageUsers());
            panelNav.Height = btnUsers.Height;
            panelNav.Top = btnUsers.Top;
            panelNav.Left = btnUsers.Left;
            btnUsers.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnLocations_Click(object sender, EventArgs e)
        {
            panelNav.Height = btnLocations.Height;
            panelNav.Top = btnLocations.Top;
            panelNav.Left = btnLocations.Left;
            btnLocations.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnUsertypes_Click(object sender, EventArgs e)
        {
            loadForm(new AddUserType());
            panelNav.Height = btnUsertypes.Height;
            panelNav.Top = btnUsertypes.Top;
            panelNav.Left = btnUsertypes.Left;
            btnUsertypes.BackColor = Color.FromArgb(46, 51, 73);

        }

        private void btnReports_Click(object sender, EventArgs e)
        {
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
            btnCustomers.BackColor = Color.FromArgb(24, 30, 54);
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
            btnUsertypes.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnReports_Leave(object sender, EventArgs e)
        {
            btnReports.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
