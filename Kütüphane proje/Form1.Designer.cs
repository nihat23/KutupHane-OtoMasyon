
namespace Kütüphane_proje
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnUyeEkle = new System.Windows.Forms.Button();
            this.btnUyeListele = new System.Windows.Forms.Button();
            this.btnKitapListele = new System.Windows.Forms.Button();
            this.btnKitapEkle = new System.Windows.Forms.Button();
            this.EmanetKitapListele = new System.Windows.Forms.Button();
            this.btnEmanetKitapVer = new System.Windows.Forms.Button();
            this.brnSirala = new System.Windows.Forms.Button();
            this.btnKitapIade = new System.Windows.Forms.Button();
            this.btnGrafik = new System.Windows.Forms.Button();
            this.emanetKitapIade1 = new Kütüphane_proje.EmanetKitapIade();
            this.emanetKitapListeleme1 = new Kütüphane_proje.EmanetKitapListeleme();
            this.emanetKitapVer1 = new Kütüphane_proje.EmanetKitapVer();
            this.uyeEkleme1 = new Kütüphane_proje.uyeEkleme();
            this.kitapListele1 = new Kütüphane_proje.kitapListele();
            this.kitapEkle1 = new Kütüphane_proje.kitapEkle();
            this.uyeListele1 = new Kütüphane_proje.uyeListele();
            this.SuspendLayout();
            // 
            // btnUyeEkle
            // 
            this.btnUyeEkle.BackColor = System.Drawing.Color.Orange;
            this.btnUyeEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUyeEkle.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUyeEkle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnUyeEkle.Location = new System.Drawing.Point(23, 603);
            this.btnUyeEkle.Name = "btnUyeEkle";
            this.btnUyeEkle.Size = new System.Drawing.Size(110, 47);
            this.btnUyeEkle.TabIndex = 0;
            this.btnUyeEkle.Text = "Üye Ekle";
            this.btnUyeEkle.UseVisualStyleBackColor = false;
            this.btnUyeEkle.Click += new System.EventHandler(this.btnUyeEkle_Click);
            // 
            // btnUyeListele
            // 
            this.btnUyeListele.BackColor = System.Drawing.Color.DarkGreen;
            this.btnUyeListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUyeListele.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnUyeListele.ForeColor = System.Drawing.SystemColors.Control;
            this.btnUyeListele.Location = new System.Drawing.Point(147, 603);
            this.btnUyeListele.Name = "btnUyeListele";
            this.btnUyeListele.Size = new System.Drawing.Size(135, 47);
            this.btnUyeListele.TabIndex = 1;
            this.btnUyeListele.Text = "Üye Listele";
            this.btnUyeListele.UseVisualStyleBackColor = false;
            this.btnUyeListele.Click += new System.EventHandler(this.btnUyeListele_Click);
            // 
            // btnKitapListele
            // 
            this.btnKitapListele.BackColor = System.Drawing.Color.DarkGreen;
            this.btnKitapListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitapListele.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKitapListele.ForeColor = System.Drawing.SystemColors.Control;
            this.btnKitapListele.Location = new System.Drawing.Point(444, 603);
            this.btnKitapListele.Name = "btnKitapListele";
            this.btnKitapListele.Size = new System.Drawing.Size(134, 47);
            this.btnKitapListele.TabIndex = 3;
            this.btnKitapListele.Text = "Kitap Listele";
            this.btnKitapListele.UseVisualStyleBackColor = false;
            this.btnKitapListele.Click += new System.EventHandler(this.btnKitapListele_Click);
            // 
            // btnKitapEkle
            // 
            this.btnKitapEkle.BackColor = System.Drawing.Color.Orange;
            this.btnKitapEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitapEkle.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKitapEkle.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnKitapEkle.Location = new System.Drawing.Point(296, 603);
            this.btnKitapEkle.Name = "btnKitapEkle";
            this.btnKitapEkle.Size = new System.Drawing.Size(134, 47);
            this.btnKitapEkle.TabIndex = 2;
            this.btnKitapEkle.Text = "Kitap Ekle";
            this.btnKitapEkle.UseVisualStyleBackColor = false;
            this.btnKitapEkle.Click += new System.EventHandler(this.btnKitapEkle_Click);
            // 
            // EmanetKitapListele
            // 
            this.EmanetKitapListele.BackColor = System.Drawing.Color.DarkGreen;
            this.EmanetKitapListele.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EmanetKitapListele.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.EmanetKitapListele.ForeColor = System.Drawing.SystemColors.Control;
            this.EmanetKitapListele.Location = new System.Drawing.Point(734, 603);
            this.EmanetKitapListele.Name = "EmanetKitapListele";
            this.EmanetKitapListele.Size = new System.Drawing.Size(114, 47);
            this.EmanetKitapListele.TabIndex = 5;
            this.EmanetKitapListele.Text = "Emanet Kitap Listele";
            this.EmanetKitapListele.UseVisualStyleBackColor = false;
            this.EmanetKitapListele.Click += new System.EventHandler(this.EmanetKitapListele_Click);
            // 
            // btnEmanetKitapVer
            // 
            this.btnEmanetKitapVer.BackColor = System.Drawing.Color.Red;
            this.btnEmanetKitapVer.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnEmanetKitapVer.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEmanetKitapVer.Location = new System.Drawing.Point(862, 597);
            this.btnEmanetKitapVer.Name = "btnEmanetKitapVer";
            this.btnEmanetKitapVer.Size = new System.Drawing.Size(108, 53);
            this.btnEmanetKitapVer.TabIndex = 4;
            this.btnEmanetKitapVer.Text = "Emanet Kitap Ver";
            this.btnEmanetKitapVer.UseVisualStyleBackColor = false;
            this.btnEmanetKitapVer.Click += new System.EventHandler(this.btnEmanetKitapVer_Click);
            // 
            // brnSirala
            // 
            this.brnSirala.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.brnSirala.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.brnSirala.ForeColor = System.Drawing.SystemColors.Control;
            this.brnSirala.Location = new System.Drawing.Point(984, 603);
            this.brnSirala.Name = "brnSirala";
            this.brnSirala.Size = new System.Drawing.Size(99, 47);
            this.brnSirala.TabIndex = 7;
            this.brnSirala.Text = "Sıralama ";
            this.brnSirala.UseVisualStyleBackColor = true;
            this.brnSirala.Click += new System.EventHandler(this.brnSirala_Click);
            // 
            // btnKitapIade
            // 
            this.btnKitapIade.BackColor = System.Drawing.Color.Crimson;
            this.btnKitapIade.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKitapIade.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKitapIade.ForeColor = System.Drawing.SystemColors.Control;
            this.btnKitapIade.Location = new System.Drawing.Point(592, 603);
            this.btnKitapIade.Name = "btnKitapIade";
            this.btnKitapIade.Size = new System.Drawing.Size(128, 47);
            this.btnKitapIade.TabIndex = 6;
            this.btnKitapIade.Text = "Emanet Kitap İade";
            this.btnKitapIade.UseVisualStyleBackColor = false;
            this.btnKitapIade.Click += new System.EventHandler(this.btnKitapIade_Click);
            // 
            // btnGrafik
            // 
            this.btnGrafik.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGrafik.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnGrafik.ForeColor = System.Drawing.SystemColors.Control;
            this.btnGrafik.Location = new System.Drawing.Point(1097, 603);
            this.btnGrafik.Name = "btnGrafik";
            this.btnGrafik.Size = new System.Drawing.Size(99, 47);
            this.btnGrafik.TabIndex = 16;
            this.btnGrafik.Text = "Grafik";
            this.btnGrafik.UseVisualStyleBackColor = true;
            this.btnGrafik.Click += new System.EventHandler(this.btnGrafik_Click);
            // 
            // emanetKitapIade1
            // 
            this.emanetKitapIade1.BackColor = System.Drawing.Color.Teal;
            this.emanetKitapIade1.Location = new System.Drawing.Point(12, 17);
            this.emanetKitapIade1.Name = "emanetKitapIade1";
            this.emanetKitapIade1.Size = new System.Drawing.Size(1192, 574);
            this.emanetKitapIade1.TabIndex = 15;
            // 
            // emanetKitapListeleme1
            // 
            this.emanetKitapListeleme1.BackColor = System.Drawing.Color.Teal;
            this.emanetKitapListeleme1.Location = new System.Drawing.Point(-2, 5);
            this.emanetKitapListeleme1.Name = "emanetKitapListeleme1";
            this.emanetKitapListeleme1.Size = new System.Drawing.Size(1206, 567);
            this.emanetKitapListeleme1.TabIndex = 14;
            // 
            // emanetKitapVer1
            // 
            this.emanetKitapVer1.BackColor = System.Drawing.Color.Teal;
            this.emanetKitapVer1.Location = new System.Drawing.Point(12, 5);
            this.emanetKitapVer1.Name = "emanetKitapVer1";
            this.emanetKitapVer1.Size = new System.Drawing.Size(1207, 586);
            this.emanetKitapVer1.TabIndex = 13;
            // 
            // uyeEkleme1
            // 
            this.uyeEkleme1.BackColor = System.Drawing.Color.Teal;
            this.uyeEkleme1.Location = new System.Drawing.Point(237, -10);
            this.uyeEkleme1.Name = "uyeEkleme1";
            this.uyeEkleme1.Size = new System.Drawing.Size(878, 559);
            this.uyeEkleme1.TabIndex = 12;
            // 
            // kitapListele1
            // 
            this.kitapListele1.BackColor = System.Drawing.Color.Teal;
            this.kitapListele1.Location = new System.Drawing.Point(12, 12);
            this.kitapListele1.Name = "kitapListele1";
            this.kitapListele1.Size = new System.Drawing.Size(1163, 509);
            this.kitapListele1.TabIndex = 11;
            this.kitapListele1.Load += new System.EventHandler(this.kitapListele1_Load);
            // 
            // kitapEkle1
            // 
            this.kitapEkle1.BackColor = System.Drawing.Color.Teal;
            this.kitapEkle1.Location = new System.Drawing.Point(382, 12);
            this.kitapEkle1.Name = "kitapEkle1";
            this.kitapEkle1.Size = new System.Drawing.Size(733, 511);
            this.kitapEkle1.TabIndex = 10;
            // 
            // uyeListele1
            // 
            this.uyeListele1.BackColor = System.Drawing.Color.Teal;
            this.uyeListele1.Location = new System.Drawing.Point(27, -10);
            this.uyeListele1.Name = "uyeListele1";
            this.uyeListele1.Size = new System.Drawing.Size(1207, 572);
            this.uyeListele1.TabIndex = 9;
            this.uyeListele1.Load += new System.EventHandler(this.uyeListele1_Load);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(1231, 662);
            this.Controls.Add(this.btnGrafik);
            this.Controls.Add(this.emanetKitapIade1);
            this.Controls.Add(this.emanetKitapListeleme1);
            this.Controls.Add(this.emanetKitapVer1);
            this.Controls.Add(this.uyeEkleme1);
            this.Controls.Add(this.kitapListele1);
            this.Controls.Add(this.kitapEkle1);
            this.Controls.Add(this.uyeListele1);
            this.Controls.Add(this.brnSirala);
            this.Controls.Add(this.btnKitapIade);
            this.Controls.Add(this.EmanetKitapListele);
            this.Controls.Add(this.btnEmanetKitapVer);
            this.Controls.Add(this.btnKitapListele);
            this.Controls.Add(this.btnKitapEkle);
            this.Controls.Add(this.btnUyeListele);
            this.Controls.Add(this.btnUyeEkle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Kütüphane işlemleri";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUyeEkle;
        private System.Windows.Forms.Button btnUyeListele;
        private System.Windows.Forms.Button btnKitapListele;
        private System.Windows.Forms.Button btnKitapEkle;
        private System.Windows.Forms.Button EmanetKitapListele;
        private System.Windows.Forms.Button btnEmanetKitapVer;
        private System.Windows.Forms.Button brnSirala;
        private System.Windows.Forms.Button btnKitapIade;
        public uyeListele uyeListele1;
        private kitapEkle kitapEkle1;
        private kitapListele kitapListele1;
        private uyeEkleme uyeEkleme1;
        private EmanetKitapVer emanetKitapVer1;
        private EmanetKitapListeleme emanetKitapListeleme1;
        private EmanetKitapIade emanetKitapIade1;
        private System.Windows.Forms.Button btnGrafik;
    }
}

