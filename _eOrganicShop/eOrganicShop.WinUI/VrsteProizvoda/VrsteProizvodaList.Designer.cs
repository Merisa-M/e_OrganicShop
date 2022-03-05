
namespace eOrganicShop.WinUI.VrsteProizvoda
{
    partial class VrsteProizvodaList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVrsteProizvoda = new System.Windows.Forms.DataGridView();
            this.VrsteProizvodaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Naziv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnUredi = new System.Windows.Forms.Button();
            this.btnUkloni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVrsteProizvoda)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(174, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Vrste proizvoda";
            // 
            // dgvVrsteProizvoda
            // 
            this.dgvVrsteProizvoda.AllowUserToAddRows = false;
            this.dgvVrsteProizvoda.AllowUserToDeleteRows = false;
            this.dgvVrsteProizvoda.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvVrsteProizvoda.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvVrsteProizvoda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVrsteProizvoda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.VrsteProizvodaID,
            this.Naziv});
            this.dgvVrsteProizvoda.GridColor = System.Drawing.SystemColors.Control;
            this.dgvVrsteProizvoda.Location = new System.Drawing.Point(127, 76);
            this.dgvVrsteProizvoda.Name = "dgvVrsteProizvoda";
            this.dgvVrsteProizvoda.ReadOnly = true;
            this.dgvVrsteProizvoda.Size = new System.Drawing.Size(252, 235);
            this.dgvVrsteProizvoda.TabIndex = 1;
            this.dgvVrsteProizvoda.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvVrsteProizvoda_CellContentClick);
            // 
            // VrsteProizvodaID
            // 
            this.VrsteProizvodaID.DataPropertyName = "VrsteProizvodaID";
            this.VrsteProizvodaID.HeaderText = "VrsteProizvodaID";
            this.VrsteProizvodaID.Name = "VrsteProizvodaID";
            this.VrsteProizvodaID.ReadOnly = true;
            this.VrsteProizvodaID.Visible = false;
            // 
            // Naziv
            // 
            this.Naziv.DataPropertyName = "Naziv";
            this.Naziv.HeaderText = "Naziv";
            this.Naziv.Name = "Naziv";
            this.Naziv.ReadOnly = true;
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDodaj.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDodaj.Location = new System.Drawing.Point(251, 314);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(44, 37);
            this.btnDodaj.TabIndex = 6;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnUredi
            // 
            this.btnUredi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUredi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUredi.Location = new System.Drawing.Point(292, 314);
            this.btnUredi.Name = "btnUredi";
            this.btnUredi.Size = new System.Drawing.Size(45, 37);
            this.btnUredi.TabIndex = 7;
            this.btnUredi.Text = "Uredi";
            this.btnUredi.UseVisualStyleBackColor = false;
            this.btnUredi.Click += new System.EventHandler(this.btnUredi_Click);
            // 
            // btnUkloni
            // 
            this.btnUkloni.BackColor = System.Drawing.Color.Tomato;
            this.btnUkloni.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUkloni.Location = new System.Drawing.Point(334, 314);
            this.btnUkloni.Name = "btnUkloni";
            this.btnUkloni.Size = new System.Drawing.Size(45, 37);
            this.btnUkloni.TabIndex = 8;
            this.btnUkloni.Text = "Ukloni";
            this.btnUkloni.UseVisualStyleBackColor = false;
            this.btnUkloni.Click += new System.EventHandler(this.btnUkloni_Click);
            // 
            // VrsteProizvodaList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.Controls.Add(this.btnUkloni);
            this.Controls.Add(this.btnUredi);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dgvVrsteProizvoda);
            this.Controls.Add(this.label1);
            this.Name = "VrsteProizvodaList";
            this.Size = new System.Drawing.Size(481, 354);
            this.Load += new System.EventHandler(this.VrsteProizvodaList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvVrsteProizvoda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvVrsteProizvoda;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnUredi;
        private System.Windows.Forms.Button btnUkloni;
        private System.Windows.Forms.DataGridViewTextBoxColumn VrsteProizvodaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Naziv;
    }
}
