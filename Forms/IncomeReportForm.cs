﻿using System;
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
    public partial class IncomeReportForm : Form
    {
        public IncomeReportForm()
        {
            InitializeComponent();
        }

        private void IncomeReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'incomeReport.DataTable1' table. You can move, or remove it, as needed.
            this.dataTable1TableAdapter.Fill(this.incomeReport.DataTable1);
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
