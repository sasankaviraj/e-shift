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
    public partial class TransportForm : Form
    {
        private TransportService transportService;
        private List<Transport> transports = new List<Transport>();
        private bool setUpdate = false;
        private DataGridViewRow row;
        public TransportForm()
        {
            InitializeComponent();
            transportService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.TRANSPORT);
            FetchAllTransports();
            SetTable();
        }


        private void FetchAllTransports()
        {
            try
            {
                transports = transportService.GetAll();
                tblTransport.DataSource = transports;
                tblTransport.Columns["IsDeleted"].Visible = false;
                tblTransport.Columns["CreatedAt"].Visible = false;
                tblTransport.Columns["ModifiedAt"].Visible = false;
                tblTransport.Columns["DeletedAt"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void SetTable()
        {
            DataGridViewButtonColumn buttonColumnEdit = new DataGridViewButtonColumn
            {
                Text = "Edit",
                UseColumnTextForButtonValue = true,
            };
            DataGridViewButtonColumn buttonColumnDelete = new DataGridViewButtonColumn
            {
                Text = "Delete",
                UseColumnTextForButtonValue = true,
            };
            tblTransport.Columns.Insert(6, buttonColumnEdit);
            tblTransport.Columns.Insert(7, buttonColumnDelete);
        }

        private void tblTransport_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearFields();
            row = tblTransport.Rows[e.RowIndex];
            row.Selected = true;
            if (e.ColumnIndex == 0)
            {
                setUpdate = true;

                txtVehicle.Text = row.Cells[3].Value.ToString();
                txtRegNo.Text = row.Cells[4].Value.ToString();
                txtDriver.Text = row.Cells[5].Value.ToString();
                txtCharges.Text = row.Cells[6].Value.ToString();
            }
            if (e.ColumnIndex == 1)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Delete Transport", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        transportService.Delete(Convert.ToInt32(row.Cells[2].Value));
                        FetchAllTransports();
                        MessageBox.Show("Transport Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (setUpdate)
                {
                    var transport = new Transport();
                    transport.Vehicle = Validator.ValidateField(txtVehicle.Text, "Vehicle");
                    transport.Driver = Validator.ValidateField(txtDriver.Text, "Driver");
                    transport.Id = Convert.ToInt32(row.Cells[2].Value);
                    transport.RegNo = txtRegNo.Text;
                    transport.ChargesPerKm = Convert.ToDecimal(Validator.ValidateNumbersWithDecimal(txtCharges.Text, "Charges Per Km"));
                    
                    transportService.Update(transport);
                    FetchAllTransports();
                    MessageBox.Show("Transport Details Updated Successfully");
                    clearFields();
                }
                else
                {
                    var transport = new Transport();
                    transport.Vehicle = Validator.ValidateField(txtVehicle.Text, "Vehicle");
                    transport.Driver = Validator.ValidateField(txtDriver.Text, "Driver");
                    transport.RegNo = txtRegNo.Text;
                    transport.ChargesPerKm = Convert.ToDecimal(Validator.ValidateNumbersWithDecimal(txtCharges.Text, "Charges Per Km"));
                    transportService.Save(transport);
                    FetchAllTransports();
                    MessageBox.Show("Transport Details Saved Successfully");
                    clearFields();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed To Save The Transport. " + ex.Message);
            }
        }

        private void clearFields()
        {
            txtCharges.Clear();
            txtDriver.Clear();
            txtRegNo.Clear();
            txtVehicle.Clear();
            setUpdate = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clearFields();
        }
    }
}
