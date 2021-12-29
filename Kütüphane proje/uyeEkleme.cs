using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;//kutuphanemiz

namespace Kütüphane_proje
{
    public partial class uyeEkleme : UserControl
    {
        public uyeEkleme()
        {
            InitializeComponent();
        }

        SqlConnection _baglan = new SqlConnection(@"Data Source=DESKTOP-5QARI7A\SQLEXPRESS;Initial Catalog=KutuphaneDb;Integrated Security=True");

        bool durum = false;

        private void TcKontrol()
        {
            durum = true;
            _baglan.Open();
            SqlCommand komut1 = new SqlCommand("select * from uye", _baglan);
            SqlDataReader oku1 = komut1.ExecuteReader();

            while (oku1.Read())
            {
                if (txtTc.Text == oku1["tc"].ToString() || txtTc.Text == "")
                {
                    durum = false;
                }
            }
            _baglan.Close();
        }

        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            TcKontrol();

            if (durum == true)
            {
                _baglan.Open();

                SqlCommand komut = new SqlCommand("insert into uye values(@tc,@adsoyad,@yas,@cinsiyet,@telefon,@adres,@mail,@okukitapsayisi)", _baglan);
                komut.Parameters.AddWithValue("@tc", txtTc.Text);
                komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                komut.Parameters.AddWithValue("@yas", txtYas.Text);
                komut.Parameters.AddWithValue("@cinsiyet", cmbCinsiyet.Text);
                komut.Parameters.AddWithValue("@telefon", txtTel.Text);
                komut.Parameters.AddWithValue("@adres", txtAdres.Text);
                komut.Parameters.AddWithValue("@mail", txtMail.Text);
                komut.Parameters.AddWithValue("@okukitapsayisi", int.Parse(txtK_Sayi.Text));
               // komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToShortDateString());
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
                txtK_Sayi.Text = "1";

            }
            else
            {
                MessageBox.Show("Bu Tc Kayıt No var...", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }
    }
}
