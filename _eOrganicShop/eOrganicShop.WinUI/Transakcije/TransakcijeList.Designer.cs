
namespace eOrganicShop.WinUI.Transakcije
{
    partial class TransakcijeList
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
            this.dgvTransakcije = new System.Windows.Forms.DataGridView();
            this.cbKorisnici = new System.Windows.Forms.ComboBox();
            this.btnUkloni = new System.Windows.Forms.Button();
            this.cbNarudzba = new System.Windows.Forms.ComboBox();
            this.DatumTransakcije = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnickoIme = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransakcijaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojNarudzbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NarudzbaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.KorisnikID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransakcije)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(347, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transakcije";
            // 
            // dgvTransakcije
            // 
            this.dgvTransakcije.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTransakcije.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvTransakcije.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransakcije.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatumTransakcije,
            this.KorisnickoIme,
            this.TransakcijaID,
            this.Cijena,
            this.BrojNarudzbe,
            this.NarudzbaID,
            this.KorisnikID});
            this.dgvTransakcije.Location = new System.Drawing.Point(31, 85);
            this.dgvTransakcije.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTransakcije.Name = "dgvTransakcije";
            this.dgvTransakcije.RowHeadersWidth = 51;
            this.dgvTransakcije.Size = new System.Drawing.Size(892, 330);
            this.dgvTransakcije.TabIndex = 1;
            this.dgvTransakcije.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTransakcije_CellContentClick);
            // 
            // cbKorisnici
            // 
            this.cbKorisnici.FormattingEnabled = true;
            this.cbKorisnici.Location = new System.Drawing.Point(43, 52);
            this.cbKorisnici.Margin = new System.Windows.Forms.Padding(4);
            this.cbKorisnici.Name = "cbKorisnici";
            this.cbKorisnici.Size = new System.Drawing.Size(185, 24);
            this.cbKorisnici.TabIndex = 2;
            this.cbKorisnici.SelectedIndexChanged += new System.EventHandler(this.cbKorisnici_SelectedIndexChanged);
            // 
            // btnUkloni
            // 
            this.btnUkloni.BackColor = System.Drawing.Color.Tomato;
            this.btnUkloni.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUkloni.Location = new System.Drawing.Point(863, 422);
            this.btnUkloni.Margin = new System.Windows.Forms.Padding(4);
            this.btnUkloni.Name = "btnUkloni";
            this.btnUkloni.Size = new System.Drawing.Size(60, 46);
            this.btnUkloni.TabIndex = 10;
            this.btnUkloni.Text = "Ukloni";
            this.btnUkloni.UseVisualStyleBackColor = false;
            this.btnUkloni.Click += new System.EventHandler(this.btnUkloni_Click);
            // 
            // cbNarudzba
            // 
            this.cbNarudzba.FormattingEnabled = true;
            this.cbNarudzba.Location = new System.Drawing.Point(731, 50);
            this.cbNarudzba.Name = "cbNarudzba";
            this.cbNarudzba.Size = new System.Drawing.Size(177, 24);
            this.cbNarudzba.TabIndex = 11;
            this.cbNarudzba.SelectedIndexChanged += new System.EventHandler(this.cbProizvodi_SelectedIndexChanged_1);
            // 
            // DatumTransakcije
            // 
            this.DatumTransakcije.DataPropertyName = "DatumTranskacije";
            this.DatumTransakcije.HeaderText = "Datum Transakcije";
            this.DatumTransakcije.MinimumWidth = 6;
            this.DatumTransakcije.Name = "DatumTransakcije";
            // 
            // KorisnickoIme
            // 
            this.KorisnickoIme.DataPropertyName = "KorisnickoIme";
            this.KorisnickoIme.HeaderText = "Korisnik";
            this.KorisnickoIme.MinimumWidth = 6;
            this.KorisnickoIme.Name = "KorisnickoIme";
            // 
            // TransakcijaID
            // 
            this.TransakcijaID.DataPropertyName = "TransakcijaID";
            this.TransakcijaID.HeaderText = "TransakcijaID";
            this.TransakcijaID.MinimumWidth = 6;
            this.TransakcijaID.Name = "TransakcijaID";
            this.TransakcijaID.Visible = false;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.MinimumWidth = 6;
            this.Cijena.Name = "Cijena";
            // 
            // BrojNarudzbe
            // 
            this.BrojNarudzbe.DataPropertyName = "BrojNarudzbe";
            this.BrojNarudzbe.HeaderText = "Broj Narudzbe";
            this.BrojNarudzbe.MinimumWidth = 6;
            this.BrojNarudzbe.Name = "BrojNarudzbe";
            // 
            // NarudzbaID
            // 
            this.NarudzbaID.DataPropertyName = "NarudzbaID";
            this.NarudzbaID.HeaderText = "NarudzbaID";
            this.NarudzbaID.MinimumWidth = 6;
            this.NarudzbaID.Name = "NarudzbaID";
            this.NarudzbaID.Visible = false;
            // 
            // KorisnikID
            // 
            this.KorisnikID.DataPropertyName = "KorisnikID";
            this.KorisnikID.HeaderText = "KorisnikID";
            this.KorisnikID.MinimumWidth = 6;
            this.KorisnikID.Name = "KorisnikID";
            this.KorisnikID.Visible = false;
            // 
            // TransakcijeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cbNarudzba);
            this.Controls.Add(this.btnUkloni);
            this.Controls.Add(this.cbKorisnici);
            this.Controls.Add(this.dgvTransakcije);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "TransakcijeList";
            this.Size = new System.Drawing.Size(965, 479);
            this.Load += new System.EventHandler(this.TransakcijeList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransakcije)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTransakcije;
        private System.Windows.Forms.ComboBox cbKorisnici;
        private System.Windows.Forms.Button btnUkloni;
        private System.Windows.Forms.ComboBox cbNarudzba;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumTransakcije;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnickoIme;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransakcijaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojNarudzbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn NarudzbaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn KorisnikID;
    }
}
