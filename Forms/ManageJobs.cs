using e_shift.Data;
using e_shift.Factory;
using e_shift.Service;
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
        private List<Job> jobs = new List<Job>();
        private List<Customer> customers = new List<Customer>();
        private List<PickupLocation> pickupLocations = new List<PickupLocation>();
        private List<DeliveryLocation> deliveryLocations = new List<DeliveryLocation>();
        private Dictionary<string, int> customerMap = new Dictionary<string, int>();
        private Dictionary<string, int> pickupLocationMap = new Dictionary<string, int>();
        private Dictionary<string, int> deliveryLocationMap = new Dictionary<string, int>();
        private JobService jobService;
        private CustomerService customerService;
        private PickupLocationService pickupLocationService;
        private DeliveryLocationService deliveryLocationService;
        public ManageJobs()
        {
            InitializeComponent();
            jobService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.JOB);
            customerService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.CUSTOMER);
            pickupLocationService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.PICKUP_LOCATION);
            deliveryLocationService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.DELIVERY_LOCATION);
            FetchCustomers();
            FetchPickups();
            FetchDeliveries();
        }

        private void FetchCustomers()
        {
            customers = customerService.GetAll();
            customers.ForEach(value => {
                customerMap.Add(value.FirstName, value.Id);
                cmbCustomers.Items.Add(value.FirstName);
            });
        }

        private void FetchPickups()
        {
            pickupLocations = pickupLocationService.GetAll();
            pickupLocations.ForEach(value => {
                pickupLocationMap.Add(value.Location, value.Id);
                cmbPickups.Items.Add(value.Location);
            });
        }

        private void FetchDeliveries()
        {
            deliveryLocations = deliveryLocationService.GetAll();
            deliveryLocations.ForEach(value => {
                deliveryLocationMap.Add(value.Location, value.Id);
                cmbDelivery.Items.Add(value.Location);
            });
        }

        private void btnAddLoad_Click(object sender, EventArgs e)
        {
            Job job = new Job();
            job.FromAddress = txtFromAddress.Text;
            job.ToAddress = txtDeliveryAddress.Text;
            Customer customer = customerService.Get(customerMap[cmbCustomers.Text]); ;
            PickupLocation pickupLocation = pickupLocationService.Get(pickupLocationMap[cmbPickups.Text]);
            DeliveryLocation deliveryLocation = deliveryLocationService.Get(deliveryLocationMap[cmbDelivery.Text]);

            job.Customer = customer;
            job.PickupLocation = pickupLocation;
            job.DeliveryLocation = deliveryLocation;

            LoadForm loadForm = new LoadForm(job);
            loadForm.Show();
        }
    }
}
