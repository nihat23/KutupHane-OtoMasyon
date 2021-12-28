using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//kutuphanemız
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_proje
{
    public partial class kitapEkle : UserControl
    {
        public kitapEkle()
        {
            InitializeComponent();
        }

        SqlConnection _baglan = new SqlConnection(@"Data Source=DESKTOP-5QARI7A\SQLEXPRESS;Initial Catalog=KutuphaneDb;Integrated Security=True");

        bool durum = false;

        private void BarkodKontol()
        {
            durum = true;
            _baglan.Open();
            SqlCommand komut1 = new SqlCommand("select * from kitap", _baglan);
            SqlDataReader oku1 = komut1.ExecuteReader();

            while (oku1.Read())
            {
                if (txtBarkod.Text == oku1["barkodno"].ToString() || txtBarkod.Text == "")
                {
                    durum = false;
                }
            }
            _baglan.Close();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            BarkodKontol();

            if (durum == true)
            {
                _baglan.Open();

                SqlCommand komut = new SqlCommand("insert into kitap values(@barkodno,@kitapadi,@yazar,@yayinevi,@sayfasayisi,@turu,@kitapsayisi,@rafno,@aciklama,@tarih )", _baglan);
                komut.Parameters.AddWithValue("@barkodno", txtBarkod.Text);
                komut.Parameters.AddWithValue("@kitapadi", txtK_ad.Text);
                komut.Parameters.AddWithValue("@yazar", txtYazar.Text);
                komut.Parameters.AddWithValue("@yayinevi", txtYayin.Text);
                komut.Parameters.AddWithValue("@sayfasayisi", txtS_Sayi.Text);
                komut.Parameters.AddWithValue("@turu", txtTuru.Text);
                komut.Parameters.AddWithValue("@kitapsayisi", int.Parse(txtStok.Text));
                komut.Parameters.AddWithValue("@rafno", txtRaf.Text);
                komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
                komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToShortDateString());
                komut.ExecuteNonQuery();
                _baglan.Close();
                MessageBox.Show("Kayıt Eklendi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                foreach (Control item in groupBox1.Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
            }
            else
            {
                MessageBox.Show(txtBarkod.Text + " Bu Barkod Kayıt var...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }


        }
    }
}
