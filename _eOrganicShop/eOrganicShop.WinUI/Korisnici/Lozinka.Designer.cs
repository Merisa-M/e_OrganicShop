
namespace eOrganicShop.WinUI.Korisnici
{
    partial class Lozinka
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLozinkaStara = new System.Windows.Forms.TextBox();
            this.txtNovaLozinka = new System.Windows.Forms.TextBox();
            this.txtPotvrdiLozinku = new System.Windows.Forms.TextBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnNazad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(136, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trenutna lozinka";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(136, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nova lozinka";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(136, 182);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Potvrdi lozinku";
            // 
            // txtLozinkaStara
            // 
            this.txtLozinkaStara.Location = new System.Drawing.Point(143, 100);
            this.txtLozinkaStara.Name = "txtLozinkaStara";
            this.txtLozinkaStara.PasswordChar = '*';
            this.txtLozinkaStara.Size = new System.Drawing.Size(208, 20);
            this.txtLozinkaStara.TabIndex = 3;
            this.txtLozinkaStara.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // txtNovaLozinka
            // 
            this.txtNovaLozinka.Location = new System.Drawing.Point(139, 148);
            this.txtNovaLozinka.Name = "txtNovaLozinka";
            this.txtNovaLozinka.PasswordChar = '*';
            this.txtNovaLozinka.Size = new System.Drawing.Size(208, 20);
            this.txtNovaLozinka.TabIndex = 4;
            // 
            // txtPotvrdiLozinku
            // 
            this.txtPotvrdiLozinku.Location = new System.Drawing.Point(139, 210);
            this.txtPotvrdiLozinku.Name = "txtPotvrdiLozinku";
            this.txtPotvrdiLozinku.PasswordChar = '*';
            this.txtPotvrdiLozinku.Size = new System.Drawing.Size(208, 20);
            this.txtPotvrdiLozinku.TabIndex = 5;
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(269, 260);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(81, 29);
            this.btnSacuvaj.TabIndex = 6;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnNazad
            // 
            this.btnNazad.Location = new System.Drawing.Point(182, 260);
            this.btnNazad.Name = "btnNazad";
            this.btnNazad.Size = new System.Drawing.Size(81, 29);
            this.btnNazad.TabIndex = 7;
            this.btnNazad.Text = "Nazad";
            this.btnNazad.UseVisualStyleBackColor = true;
            this.btnNazad.Click += new System.EventHandler(this.btnNazad_Click);
            // 
            // Lozinka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnNazad);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.txtPotvrdiLozinku);
            this.Controls.Add(this.txtNovaLozinka);
            this.Controls.Add(this.txtLozinkaStara);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Lozinka";
            this.Size = new System.Drawing.Size(725, 465);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLozinkaStara;
        private System.Windows.Forms.TextBox txtNovaLozinka;
        private System.Windows.Forms.TextBox txtPotvrdiLozinku;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnNazad;
    }
}
