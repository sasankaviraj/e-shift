using e_shift.Data;
using e_shift.Factory;
using e_shift.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace e_shift.Forms
{
    public partial class LoadForm : Form
    {
        private Job job;
        private List<Load> loads;
        private LoadService loadService;
        private DataGridViewRow row;
        BindingList<Load> list;
        private Dictionary<string, int> productTypesMap = new Dictionary<string, int>();
        private ProductService productService;
        public LoadForm(Job job)
        {
            this.job = job;
            InitializeComponent();
            loads = new List<Load>();
            loadService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.LOAD);
            productService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.PRODUCT);
            FetchProductTypes();
        }

        void FetchProductTypes() {
            List<Product> products = productService.GetAll();
            products.ForEach(value =>
            {
                productTypesMap.Add(value.Type, value.Id);
                cmbProducts.Items.Add(value.Type);
            });
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Load load = new Load();
            load.Job = job;
            load.Product = txtProduct.Text;
            load.Weight = Convert.ToDecimal(txtWeight.Text);
            Product product = productService.Get(productTypesMap[cmbProducts.Text]); ;
            load.ProductType = product;
            loads.Add(load);
            SetTable();
        }

        private void SetTable() {
            list = new BindingList<Load>(loads);
            tblLoads.DataSource = list;
            tblLoads.AllowUserToAddRows = false;
            tblLoads.Columns["IsDeleted"].Visible = false;
            tblLoads.Columns["CreatedAt"].Visible = false;
            tblLoads.Columns["ModifiedAt"].Visible = false;
            tblLoads.Columns["DeletedAt"].Visible = false;
            tblLoads.Columns["Id"].Visible = false;
            tblLoads.Columns["Job"].Visible = false;
            DataGridViewButtonColumn buttonColumnDelete = new DataGridViewButtonColumn
            {
                Text = "Delete",
                Name = "Delete",
                UseColumnTextForButtonValue = true,
            };
            if (!tblLoads.Columns.Contains("Delete")) {
                tblLoads.Columns.Insert(3, buttonColumnDelete);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try {
                loadService.Save(loads, job);
                MessageBox.Show("Saved Successfully");
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void tblLoads_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            row = tblLoads.Rows[e.RowIndex];
            row.Selected = true;
            
            if (e.ColumnIndex == 0)
            {
                list.RemoveAt(e.RowIndex);
                SetTable();
            }
            
        }
    }
}
