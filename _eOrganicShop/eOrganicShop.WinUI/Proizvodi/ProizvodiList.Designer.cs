
namespace eOrganicShop.WinUI.Proizvodi
{
    partial class ProizvodiList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvProizvodi = new System.Windows.Forms.DataGridView();
            this.ProizvodID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NazivProizvoda = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Sifra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cijena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Opis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPretragaProizvoda = new System.Windows.Forms.TextBox();
            this.btnPretragaProizvoda = new System.Windows.Forms.Button();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.btnUredi = new System.Windows.Forms.Button();
            this.btnUkloni = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(399, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Proizvodi";
            // 
            // dgvProizvodi
            // 
            this.dgvProizvodi.AllowUserToAddRows = false;
            this.dgvProizvodi.AllowUserToDeleteRows = false;
            this.dgvProizvodi.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProizvodi.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvProizvodi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProizvodi.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProizvodID,
            this.NazivProizvoda,
            this.Sifra,
            this.Cijena,
            this.Opis});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvProizvodi.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvProizvodi.GridColor = System.Drawing.SystemColors.ControlDarkDark;
            this.dgvProizvodi.Location = new System.Drawing.Point(81, 81);
            this.dgvProizvodi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvProizvodi.Name = "dgvProizvodi";
            this.dgvProizvodi.ReadOnly = true;
            this.dgvProizvodi.RowHeadersWidth = 51;
            this.dgvProizvodi.Size = new System.Drawing.Size(809, 321);
            this.dgvProizvodi.TabIndex = 1;
            this.dgvProizvodi.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProizvodi_CellContentClick);
            // 
            // ProizvodID
            // 
            this.ProizvodID.DataPropertyName = "ProizvodID";
            this.ProizvodID.HeaderText = "ProizvodID";
            this.ProizvodID.MinimumWidth = 6;
            this.ProizvodID.Name = "ProizvodID";
            this.ProizvodID.ReadOnly = true;
            this.ProizvodID.Visible = false;
            // 
            // NazivProizvoda
            // 
            this.NazivProizvoda.DataPropertyName = "NazivProizvoda";
            this.NazivProizvoda.HeaderText = "NazivProizvoda";
            this.NazivProizvoda.MinimumWidth = 6;
            this.NazivProizvoda.Name = "NazivProizvoda";
            this.NazivProizvoda.ReadOnly = true;
            // 
            // Sifra
            // 
            this.Sifra.DataPropertyName = "Sifra";
            this.Sifra.HeaderText = "Sifra";
            this.Sifra.MinimumWidth = 6;
            this.Sifra.Name = "Sifra";
            this.Sifra.ReadOnly = true;
            // 
            // Cijena
            // 
            this.Cijena.DataPropertyName = "Cijena";
            this.Cijena.HeaderText = "Cijena";
            this.Cijena.MinimumWidth = 6;
            this.Cijena.Name = "Cijena";
            this.Cijena.ReadOnly = true;
            // 
            // Opis
            // 
            this.Opis.DataPropertyName = "Opis";
            this.Opis.HeaderText = "Opis";
            this.Opis.MinimumWidth = 6;
            this.Opis.Name = "Opis";
            this.Opis.ReadOnly = true;
            // 
            // txtPretragaProizvoda
            // 
            this.txtPretragaProizvoda.Location = new System.Drawing.Point(81, 49);
            this.txtPretragaProizvoda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPretragaProizvoda.Name = "txtPretragaProizvoda";
            this.txtPretragaProizvoda.Size = new System.Drawing.Size(164, 22);
            this.txtPretragaProizvoda.TabIndex = 2;
            this.txtPretragaProizvoda.Enter += new System.EventHandler(this.txtPretragaProizvoda_Enter);
            this.txtPretragaProizvoda.Leave += new System.EventHandler(this.txtPretragaProizvoda_Leave);
            // 
            // btnPretragaProizvoda
            // 
            this.btnPretragaProizvoda.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnPretragaProizvoda.Location = new System.Drawing.Point(255, 49);
            this.btnPretragaProizvoda.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnPretragaProizvoda.Name = "btnPretragaProizvoda";
            this.btnPretragaProizvoda.Size = new System.Drawing.Size(97, 25);
            this.btnPretragaProizvoda.TabIndex = 3;
            this.btnPretragaProizvoda.Text = "Traži";
            this.btnPretragaProizvoda.UseVisualStyleBackColor = true;
            this.btnPretragaProizvoda.Click += new System.EventHandler(this.btnPretragaProizvoda_Click);
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnDodaj.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnDodaj.Location = new System.Drawing.Point(689, 410);
            this.btnDodaj.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(59, 46);
            this.btnDodaj.TabIndex = 7;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // btnUredi
            // 
            this.btnUredi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnUredi.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUredi.Location = new System.Drawing.Point(756, 410);
            this.btnUredi.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUredi.Name = "btnUredi";
            this.btnUredi.Size = new System.Drawing.Size(60, 46);
            this.btnUredi.TabIndex = 8;
            this.btnUredi.Text = "Uredi";
            this.btnUredi.UseVisualStyleBackColor = false;
            this.btnUredi.Click += new System.EventHandler(this.btnUredi_Click);
            // 
            // btnUkloni
            // 
            this.btnUkloni.BackColor = System.Drawing.Color.Tomato;
            this.btnUkloni.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnUkloni.Location = new System.Drawing.Point(824, 410);
            this.btnUkloni.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUkloni.Name = "btnUkloni";
            this.btnUkloni.Size = new System.Drawing.Size(60, 46);
            this.btnUkloni.TabIndex = 9;
            this.btnUkloni.Text = "Ukloni";
            this.btnUkloni.UseVisualStyleBackColor = false;
            this.btnUkloni.Click += new System.EventHandler(this.btnUkloni_Click);
            // 
            // ProizvodiList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.btnUkloni);
            this.Controls.Add(this.btnUredi);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.btnPretragaProizvoda);
            this.Controls.Add(this.txtPretragaProizvoda);
            this.Controls.Add(this.dgvProizvodi);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "ProizvodiList";
            this.Size = new System.Drawing.Size(957, 503);
            this.Load += new System.EventHandler(this.ProizvodiList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProizvodi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvProizvodi;
        private System.Windows.Forms.TextBox txtPretragaProizvoda;
        private System.Windows.Forms.Button btnPretragaProizvoda;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.Button btnUredi;
        private System.Windows.Forms.Button btnUkloni;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProizvodID;
        private System.Windows.Forms.DataGridViewTextBoxColumn NazivProizvoda;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sifra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cijena;
        private System.Windows.Forms.DataGridViewTextBoxColumn Opis;
    }
}
