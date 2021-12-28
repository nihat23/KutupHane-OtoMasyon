using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//kutuphanemiz
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Kütüphane_proje
{
    public partial class uyeListele : UserControl
    {
        public uyeListele()
        {
            InitializeComponent();
        }


        SqlConnection _baglan = new SqlConnection(@"Data Source=DESKTOP-5QARI7A\SQLEXPRESS;Initial Catalog=KutuphaneDb;Integrated Security=True");

        public void UyeListeleme()
        {
            DataSet dataSet = new DataSet();
            dataSet.Clear();
            _baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from uye", _baglan);
            adtr.Fill(dataSet, "uye");
            dataGridView1.DataSource = dataSet.Tables["uye"];

            _baglan.Close();
        }


        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            _baglan.Open();
            string kayit = "update uye  set adsoyad=@adsoyad,yas=@yas,cinsiyet=@cinsiyet,telefon=@telefon,adres=@adres,mail=@mail,okukitapsayisi=@okukitapsayisi where tc=@tc";
            SqlCommand komut = new SqlCommand(kayit, _baglan);
            komut.Parameters.AddWithValue("@tc", txtTc.Text);
            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
            komut.Parameters.AddWithValue("@yas", txtYas.Text);
            komut.Parameters.AddWithValue("@cinsiyet", cmbCinsiyet.Text);
            komut.Parameters.AddWithValue("@telefon", txtTel.Text);
            komut.Parameters.AddWithValue("@adres", txtAdres.Text);
            komut.Parameters.AddWithValue("@mail", txtMail.Text);
            komut.Parameters.AddWithValue("@okukitapsayisi", int.Parse(txtK_Sayi.Text));
            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToShortDateString());
            komut.ExecuteNonQuery();
            _baglan.Close();
            MessageBox.Show("Güncelleme Başarı ile Yapıldı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UyeListeleme();


            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            txtK_Sayi.Text = "1";
        }


        private void uyeListele_Load(object sender, EventArgs e)
        {
          
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtTc.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            txtAdSoyad.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            txtYas.Text = dataGridView1.CurrentRow.Cells["yas"].Value.ToString();
            cmbCinsiyet.Text = dataGridView1.CurrentRow.Cells["cinsiyet"].Value.ToString();
            txtTel.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            txtAdres.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            txtMail.Text = dataGridView1.CurrentRow.Cells["mail"].Value.ToString();
            txtK_Sayi.Text = dataGridView1.CurrentRow.Cells["okukitapsayisi"].Value.ToString();
            
        }

        private void txtTc_TextChanged(object sender, EventArgs e)
        {
            _baglan.Open();
            SqlCommand komut = new SqlCommand("select * from uye where tc like '" + txtTc.Text + "'", _baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txtTc.Text = oku["tc"].ToString();
                txtAdSoyad.Text = oku["adsoyad"].ToString();
                txtYas.Text = oku["yas"].ToString();
                cmbCinsiyet.Text = oku["cinsiyet"].ToString();
                txtTel.Text = oku["telefon"].ToString();
                txtAdres.Text = oku["adres"].ToString();
                txtMail.Text = oku["mail"].ToString();
                txtK_Sayi.Text = oku["okukitapsayisi"].ToString();
                
            }
            _baglan.Close();

            if (txtTc.Text == "")
            {
                txtAdSoyad.Clear();
                txtYas.Clear();
                txtTel.Clear();
                txtAdres.Clear();
                txtK_Sayi.Text = "1";
            }


        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (lblSil.Text == "0")
            {
                MessageBox.Show("Silinecek Satır kalmadı..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _baglan.Open();
                SqlCommand komut = new SqlCommand("delete from uye where tc=@tc ", _baglan);
                komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
                komut.ExecuteNonQuery();
                _baglan.Close();
                MessageBox.Show("Kayıt Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UyeListeleme();

                foreach (Control item in Controls)
                {
                    if (item is TextBox)
                    {
                        item.Text = "";
                    }
                }
                lblSil.Text = "0";
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblSil.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();

        }
    }
}
