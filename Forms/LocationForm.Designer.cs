namespace e_shift.Forms
{
    partial class LocationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.tblDeliveryLocations = new System.Windows.Forms.DataGridView();
            this.btnSaveDelivery = new System.Windows.Forms.Button();
            this.txtDelivery = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSavePickup = new System.Windows.Forms.Button();
            this.tblPickupLocations = new System.Windows.Forms.DataGridView();
            this.txtPickup = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.txtUnitsPk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUnitsDl = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeliveryLocations)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblPickupLocations)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtUnitsDl);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.tblDeliveryLocations);
            this.panel1.Controls.Add(this.btnSaveDelivery);
            this.panel1.Controls.Add(this.txtDelivery);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(402, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 537);
            this.panel1.TabIndex = 0;
            // 
            // tblDeliveryLocations
            // 
            this.tblDeliveryLocations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblDeliveryLocations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tblDeliveryLocations.Location = new System.Drawing.Point(12, 156);
            this.tblDeliveryLocations.Name = "tblDeliveryLocations";
            this.tblDeliveryLocations.Size = new System.Drawing.Size(348, 370);
            this.tblDeliveryLocations.TabIndex = 20;
            this.tblDeliveryLocations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblDeliveryLocations_CellContentClick);
            // 
            // btnSaveDelivery
            // 
            this.btnSaveDelivery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnSaveDelivery.FlatAppearance.BorderSize = 0;
            this.btnSaveDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveDelivery.ForeColor = System.Drawing.Color.White;
            this.btnSaveDelivery.Location = new System.Drawing.Point(270, 130);
            this.btnSaveDelivery.Name = "btnSaveDelivery";
            this.btnSaveDelivery.Size = new System.Drawing.Size(75, 20);
            this.btnSaveDelivery.TabIndex = 29;
            this.btnSaveDelivery.Text = "Save";
            this.btnSaveDelivery.UseVisualStyleBackColor = false;
            this.btnSaveDelivery.Click += new System.EventHandler(this.btnSaveDelivery_Click);
            // 
            // txtDelivery
            // 
            this.txtDelivery.Location = new System.Drawing.Point(109, 66);
            this.txtDelivery.Name = "txtDelivery";
            this.txtDelivery.Size = new System.Drawing.Size(236, 20);
            this.txtDelivery.TabIndex = 20;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(19, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 19;
            this.label3.Text = "District";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 32);
            this.label1.TabIndex = 17;
            this.label1.Text = "Delivery Location";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txtUnitsPk);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnSavePickup);
            this.panel2.Controls.Add(this.tblPickupLocations);
            this.panel2.Controls.Add(this.txtPickup);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lblFirstName);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(370, 537);
            this.panel2.TabIndex = 1;
            // 
            // btnSavePickup
            // 
            this.btnSavePickup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnSavePickup.FlatAppearance.BorderSize = 0;
            this.btnSavePickup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSavePickup.ForeColor = System.Drawing.Color.White;
            this.btnSavePickup.Location = new System.Drawing.Point(270, 130);
            this.btnSavePickup.Name = "btnSavePickup";
            this.btnSavePickup.Size = new System.Drawing.Size(75, 20);
            this.btnSavePickup.TabIndex = 27;
            this.btnSavePickup.Text = "Save";
            this.btnSavePickup.UseVisualStyleBackColor = false;
            this.btnSavePickup.Click += new System.EventHandler(this.btnSavePickup_Click);
            // 
            // tblPickupLocations
            // 
            this.tblPickupLocations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tblPickupLocations.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.tblPickupLocations.Location = new System.Drawing.Point(9, 156);
            this.tblPickupLocations.Name = "tblPickupLocations";
            this.tblPickupLocations.Size = new System.Drawing.Size(348, 370);
            this.tblPickupLocations.TabIndex = 19;
            this.tblPickupLocations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.tblPickupLocations_CellContentClick);
            // 
            // txtPickup
            // 
            this.txtPickup.Location = new System.Drawing.Point(109, 66);
            this.txtPickup.Name = "txtPickup";
            this.txtPickup.Size = new System.Drawing.Size(236, 20);
            this.txtPickup.TabIndex = 18;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(19, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "District";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Microsoft Sans Serif", 21F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.Color.White;
            this.lblFirstName.Location = new System.Drawing.Point(3, 10);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(231, 32);
            this.lblFirstName.TabIndex = 16;
            this.lblFirstName.Text = "Pickup Location";
            // 
            // txtUnitsPk
            // 
            this.txtUnitsPk.Location = new System.Drawing.Point(109, 95);
            this.txtUnitsPk.Name = "txtUnitsPk";
            this.txtUnitsPk.Size = new System.Drawing.Size(236, 20);
            this.txtUnitsPk.TabIndex = 29;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(19, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Units From CMB";
            // 
            // txtUnitsDl
            // 
            this.txtUnitsDl.Location = new System.Drawing.Point(109, 95);
            this.txtUnitsDl.Name = "txtUnitsDl";
            this.txtUnitsDl.Size = new System.Drawing.Size(236, 20);
            this.txtUnitsDl.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(19, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(83, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Units From CMB";
            // 
            // LocationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LocationForm";
            this.Text = "LocationForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblDeliveryLocations)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblPickupLocations)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtDelivery;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPickup;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView tblDeliveryLocations;
        private System.Windows.Forms.DataGridView tblPickupLocations;
        private System.Windows.Forms.Button btnSaveDelivery;
        private System.Windows.Forms.Button btnSavePickup;
        private System.Windows.Forms.TextBox txtUnitsDl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUnitsPk;
        private System.Windows.Forms.Label label4;
    }
}