using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//kütüphanemız
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_proje
{
    public partial class kitapListele : UserControl
    {
        public kitapListele()
        {
            InitializeComponent();
        }


        SqlConnection _baglan = new SqlConnection(@"Data Source=DESKTOP-5QARI7A\SQLEXPRESS;Initial Catalog=KutuphaneDb;Integrated Security=True");

        public void KitapListeleme()
        {
            DataSet dataSet = new DataSet();
            dataSet.Clear();
            _baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kitap", _baglan);
            adtr.Fill(dataSet, "kitap");
            dataGridView1.DataSource = dataSet.Tables["kitap"];

            _baglan.Close();
        }


        private void btnEkle_Click(object sender, EventArgs e)
        {
            _baglan.Open();

            string kayit = "update kitap  set kitapadi=@kitapadi,yazar=@yazar,yayinevi=@yayinevi,sayfasayisi=@sayfasayisi,turu=@turu,stoksayisi=@stoksayisi,rafno=@rafno,aciklama=@aciklama where  barkodno=@barkodno";
            SqlCommand komut = new SqlCommand(kayit, _baglan);
            komut.Parameters.AddWithValue("@barkodno", txtBarkod.Text);
            komut.Parameters.AddWithValue("@kitapadi", txtK_ad.Text);
            komut.Parameters.AddWithValue("@yazar", txtYazar.Text);
            komut.Parameters.AddWithValue("@yayinevi", txtYayin.Text);
            komut.Parameters.AddWithValue("@sayfasayisi", txtS_Sayi.Text);
            komut.Parameters.AddWithValue("@turu", txtTuru.Text);
            komut.Parameters.AddWithValue("@stoksayisi", int.Parse(txtStok.Text));
            komut.Parameters.AddWithValue("@rafno", txtRaf.Text);
            komut.Parameters.AddWithValue("@aciklama", txtAciklama.Text);
            komut.Parameters.AddWithValue("@tarih", DateTime.Now.ToShortDateString());
            komut.ExecuteNonQuery();
            _baglan.Close();
            MessageBox.Show("Güncelleme Başarı ile Yapıldı", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            KitapListeleme();
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void kitapListele_Load(object sender, EventArgs e)
        {

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if (lblSil.Text == "0")
            {
                MessageBox.Show("Silinecek Satır kalmadı..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                _baglan.Open();
                SqlCommand komut = new SqlCommand("delete from kitap where barkodno=@barkodno ", _baglan);
                komut.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
                komut.ExecuteNonQuery();
                _baglan.Close();
                MessageBox.Show("Kayıt Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                KitapListeleme();


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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtBarkod.Text = dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString();
            txtK_ad.Text = dataGridView1.CurrentRow.Cells["kitapadi"].Value.ToString();
            txtYazar.Text = dataGridView1.CurrentRow.Cells["yazar"].Value.ToString();
            txtYayin.Text = dataGridView1.CurrentRow.Cells["yayinevi"].Value.ToString();
            txtS_Sayi.Text = dataGridView1.CurrentRow.Cells["sayfasayisi"].Value.ToString();
            txtTuru.Text = dataGridView1.CurrentRow.Cells["turu"].Value.ToString();
            txtStok.Text = dataGridView1.CurrentRow.Cells["stoksayisi"].Value.ToString();
            txtRaf.Text = dataGridView1.CurrentRow.Cells["rafno"].Value.ToString();
            txtAciklama.Text = dataGridView1.CurrentRow.Cells["aciklama"].Value.ToString();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblSil.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();

        }

        private void txtBarkod_TextChanged(object sender, EventArgs e)
        {
            _baglan.Open();

            string ara = "select * from kitap where barkodno like '" + txtBarkod.Text + "'";
            SqlCommand komut = new SqlCommand(ara,_baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                txtK_ad.Text = oku["kitapadi"].ToString();
                txtYazar.Text = oku["yazar"].ToString();
                txtYayin.Text = oku["yayinevi"].ToString();
                txtS_Sayi.Text = oku["sayfasayisi"].ToString();
                txtTuru.Text = oku["turu"].ToString();
                txtStok.Text = oku["stoksayisi"].ToString();
                txtRaf.Text = oku["rafno"].ToString();
                txtAciklama.Text = oku["aciklama"].ToString();
            }
            _baglan.Close();


        }
    }
}
