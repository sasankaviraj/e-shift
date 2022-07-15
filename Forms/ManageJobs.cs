using e_shift.Data;
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
    public partial class ManageJobs : Form
    {
        private DataGridViewRow row;
        private List<JobsTableModel> jobs = new List<JobsTableModel>();
        private List<Transport> transports = new List<Transport>();
        private List<PickupLocation> pickupLocations = new List<PickupLocation>();
        private List<DeliveryLocation> deliveryLocations = new List<DeliveryLocation>();
        private Dictionary<string, int> transportMap = new Dictionary<string, int>();
        private Dictionary<string, int> pickupLocationMap = new Dictionary<string, int>();
        private Dictionary<string, int> deliveryLocationMap = new Dictionary<string, int>();
        private JobService jobService;
        private TransportService transportService;
        private PickupLocationService pickupLocationService;
        private DeliveryLocationService deliveryLocationService;
        private int JobId;
        public ManageJobs()
        {
            InitializeComponent();
            jobService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.JOB);
            transportService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.TRANSPORT);
            pickupLocationService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.PICKUP_LOCATION);
            deliveryLocationService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.DELIVERY_LOCATION);
            FetchAllJobs();
            FetchTransport();
            FetchPickups();
            FetchDeliveries();
            SetTable();
        }

        private void FetchAllJobs()
        {
            try {
                btnApprove.Hide();
                if (LoggedUserTemp.LoggedUser.UserType != null)
                {
                    if (LoggedUserTemp.LoggedUser.UserType.Equals("ADMIN"))
                    {
                        jobs = jobService.GetAll();
                        btnApprove.Show();
                    }
                    if (LoggedUserTemp.LoggedUser.UserType.Equals("CUSTOMER"))
                    {
                        jobs = jobService.GetByUserId(Convert.ToInt32(LoggedUserTemp.LoggedUser.Id));
                        btnApprove.Hide();
                    }
                };
                tblJobs.DataSource = jobs;
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }

            
        }

        private void FetchTransport()
        {
            try
            {
                transports = transportService.GetAll();
                transports.ForEach(value => {
                    transportMap.Add(value.Vehicle, value.Id);
                    cmbTransport.Items.Add(value.Vehicle);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FetchPickups()
        {
            try
            {
                pickupLocations = pickupLocationService.GetAll();
                pickupLocations.ForEach(value => {
                    pickupLocationMap.Add(value.Location, value.Id);
                    cmbPickups.Items.Add(value.Location);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void FetchDeliveries()
        {
            try
            {
                deliveryLocations = deliveryLocationService.GetAll();
                deliveryLocations.ForEach(value => {
                    deliveryLocationMap.Add(value.Location, value.Id);
                    cmbDelivery.Items.Add(value.Location);
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnAddLoad_Click(object sender, EventArgs e)
        {
            try {
                if (!LoggedUserTemp.LoggedUser.Id.Equals(0))
                {
                    Job job = new Job();
                    job.FromAddress = txtFromAddress.Text;
                    job.ToAddress = txtDeliveryAddress.Text;

                    Transport transport = transportService.Get(transportMap[cmbTransport.Text]); ;
                    PickupLocation pickupLocation = pickupLocationService.Get(pickupLocationMap[cmbPickups.Text]);
                    DeliveryLocation deliveryLocation = deliveryLocationService.Get(deliveryLocationMap[cmbDelivery.Text]);

                    job.Transport = transport;
                    job.PickupLocation = pickupLocation;
                    job.DeliveryLocation = deliveryLocation;

                    LoadForm loadForm = new LoadForm(job);
                    loadForm.Show();
                }
                else
                {
                    MessageBox.Show("Login To Place A Job");
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Error Occured");
            }
            
        }

        private void SetTable()
        {
            if (LoggedUserTemp.LoggedUser.UserType != null && LoggedUserTemp.LoggedUser.UserType.Equals("ADMIN"))
            {
                DataGridViewButtonColumn buttonColumnEdit = new DataGridViewButtonColumn
                {
                    Text = "Approve",
                    UseColumnTextForButtonValue = true,
                };
                DataGridViewButtonColumn buttonColumnDelete = new DataGridViewButtonColumn
                {
                    Text = "Delete",
                    UseColumnTextForButtonValue = true,
                };
                tblJobs.Columns.Insert(10, buttonColumnEdit);
                tblJobs.Columns.Insert(11, buttonColumnDelete);
            }

        }

        private void tblJobs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            clearFields();
            row = tblJobs.Rows[e.RowIndex];
            row.Selected = true;
            JobId = Convert.ToInt32(row.Cells[2].Value);
//            if (e.ColumnIndex == 0)
//            {

//;            }
//            if (e.ColumnIndex == 1)
//            {
//                DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Delete User", MessageBoxButtons.YesNo);
//                if (dialogResult == DialogResult.Yes)
//                {
//                    try
//                    {
//                        jobService.Delete(Convert.ToInt32(row.Cells[2].Value));
//                        MessageBox.Show("User Deleted Successfully");
//                    }
//                    catch (Exception ex)
//                    {
//                        MessageBox.Show(ex.Message);
//                    }
//                }


//            }
        }

        private void clearFields() {
            txtDeliveryAddress.Clear();
            txtFromAddress.Clear();
            cmbTransport.ResetText();
            cmbDelivery.ResetText();
            cmbPickups.ResetText();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            try
            {
                if (JobId == 0) {
                    throw new Exception("Error on finding the job");
                }
                jobService.Update(JobId);
                MessageBox.Show("Job Approved Successfully");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
