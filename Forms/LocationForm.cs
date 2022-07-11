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
    public partial class LocationForm : Form
    {
        private PickupLocationService pickupLocationService;
        private List<PickupLocation> pickupLocations = new List<PickupLocation>();
        private DeliveryLocationService deliveryLocationService;
        private List<DeliveryLocation> deliveryLocations = new List<DeliveryLocation>();
        private DataGridViewRow rowTblPk;
        private DataGridViewRow rowTblDl;
        public LocationForm()
        {
            InitializeComponent();
            pickupLocationService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.PICKUP_LOCATION);
            deliveryLocationService = ServiceFactory.getInstance().getFactory(ServiceFactory.Instance.DELIVERY_LOCATION);
            FetchAllPickups();
            FetchAllDeliveries();
            SetTablePk();
            SetTableDl();
        }

        private void btnSavePickup_Click(object sender, EventArgs e)
        {
            try {
                var pickupLocation = new PickupLocation();
                pickupLocation.Location = Validator.ValidateField(txtPickup.Text, "Pickup Location");
                pickupLocation.UnitsFromColombo = Convert.ToInt32(Validator.ValidateNumbersOnly(txtUnitsPk.Text,"Units"));
                pickupLocationService.Save(pickupLocation);
                FetchAllPickups();
                MessageBox.Show("Pickup Location Saved Successfully");
                txtPickup.Clear();
            } catch (Exception ex) {
                Console.WriteLine(ex);
                MessageBox.Show("Failed To Save The Pickup Location. " + ex.Message);
            }
        }

        private void FetchAllPickups()
        {
            pickupLocations = pickupLocationService.GetAll();
            tblPickupLocations.DataSource = pickupLocations;
            tblPickupLocations.Columns["IsDeleted"].Visible = false;
            tblPickupLocations.Columns["CreatedAt"].Visible = false;
            tblPickupLocations.Columns["ModifiedAt"].Visible = false;
            tblPickupLocations.Columns["DeletedAt"].Visible = false;
        }
        private void FetchAllDeliveries()
        {
            deliveryLocations = deliveryLocationService.GetAll();
            tblDeliveryLocations.DataSource = deliveryLocations;
            tblDeliveryLocations.Columns["IsDeleted"].Visible = false;
            tblDeliveryLocations.Columns["CreatedAt"].Visible = false;
            tblDeliveryLocations.Columns["ModifiedAt"].Visible = false;
            tblDeliveryLocations.Columns["DeletedAt"].Visible = false;
        }

        private void SetTablePk()
        {
            DataGridViewButtonColumn buttonColumnDelete = new DataGridViewButtonColumn
            {
                Text = "Delete",
                UseColumnTextForButtonValue = true,
            };
            tblPickupLocations.Columns.Insert(3, buttonColumnDelete);
        }
        private void SetTableDl()
        {
            DataGridViewButtonColumn buttonColumnDelete = new DataGridViewButtonColumn
            {
                Text = "Delete",
                UseColumnTextForButtonValue = true,
            };
            tblDeliveryLocations.Columns.Insert(3, buttonColumnDelete);
        }

        private void btnSaveDelivery_Click(object sender, EventArgs e)
        {
            try
            {
                var deliveryLocation = new DeliveryLocation();
                deliveryLocation.Location = Validator.ValidateField(txtDelivery.Text, "Delivery Location");
                deliveryLocation.UnitsFromColombo = Convert.ToInt32(Validator.ValidateNumbersOnly(txtUnitsDl.Text, "Units"));
                deliveryLocationService.Save(deliveryLocation);
                FetchAllDeliveries();
                MessageBox.Show("Delivery Location Saved Successfully");
                txtDelivery.Clear();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                MessageBox.Show("Failed To Save The Delivery Location. " + ex.Message);
            }
        }

        private void tblPickupLocations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowTblPk = tblPickupLocations.Rows[e.RowIndex];
            rowTblPk.Selected = true;
            if (e.ColumnIndex == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Delete Pickup Location", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        pickupLocationService.Delete(Convert.ToInt32(rowTblPk.Cells[1].Value));
                        FetchAllPickups();
                        MessageBox.Show("Pickup Location Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void tblDeliveryLocations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            rowTblDl = tblDeliveryLocations.Rows[e.RowIndex];
            rowTblDl.Selected = true;
            if (e.ColumnIndex == 0)
            {
                DialogResult dialogResult = MessageBox.Show("Are You Sure?", "Delete Delivery Location", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        deliveryLocationService.Delete(Convert.ToInt32(rowTblDl.Cells[1].Value));
                        FetchAllDeliveries();
                        MessageBox.Show("Delivery Location Deleted Successfully");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
