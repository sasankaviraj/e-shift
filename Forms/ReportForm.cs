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
    public partial class ReportForm : Form
    {
        public ReportForm()
        {
            InitializeComponent();
        }

        private void btnIncomeReport_Click(object sender, EventArgs e)
        {
            IncomeReportForm incomeReportForm = new IncomeReportForm();
            incomeReportForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductReportForm productReportForm = new ProductReportForm();
            productReportForm.Show();
        }
    }
}
