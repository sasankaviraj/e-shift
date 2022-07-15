using e_shift.Model;
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
    public partial class JobSearchPopup : Form
    {
        public JobSearchPopup(List<JobsTableModel> jobsTableModels)
        {
            InitializeComponent();
            tblSearch.DataSource = jobsTableModels;

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
