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
    public partial class ProductReportForm : Form
    {
        public ProductReportForm()
        {
            InitializeComponent();
        }

        private void ProductReportForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'productsDelivered.DataTable2' table. You can move, or remove it, as needed.
            this.dataTable2TableAdapter.Fill(this.productsDelivered.DataTable2);

            this.reportViewer1.RefreshReport();
        }
    }
}
