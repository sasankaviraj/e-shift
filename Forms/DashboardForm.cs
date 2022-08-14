using e_shift.Factory;
using e_shift.Model;
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
using System.Windows.Forms.DataVisualization.Charting;

namespace e_shift.Forms
{
    public partial class DashboardForm : Form
    {
        private JobService jobService;
        List<JobsTableModel> jobsTableModels;
        public DashboardForm()
        {
            InitializeComponent();
            jobService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.JOB);
            FindJobs();
            SetChart();
            SetCards();
        }

        void FindJobs() {
             jobsTableModels = jobService.GetAll();
        }

        void SetCards() {
            decimal total = 0;
            jobsTableModels.ForEach(model => {
                total = total + model.DeliveryCharges;
            });
            txtearnings.Text = "Rs." +total.ToString();
            txtJobsCount.Text = jobsTableModels.Count().ToString();
        }

        void SetChart() {
            DataPoint Dp = new DataPoint();
            chart1.Series.Clear();
            chart1.Series.Add("Jobs Data");

            jobsTableModels.ForEach(model => {
                chart1.Series[0].Points.Add(Double.Parse(model.DeliveryCharges.ToString()), model.Id);
            });
        }
    }
}
