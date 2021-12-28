using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//kutuphaemız
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_proje
{
    public partial class EmanetKitapVer : UserControl
    {
        public EmanetKitapVer()
        {
            InitializeComponent();
        }

        SqlConnection _baglan = new SqlConnection(@"Data Source=DESKTOP-5QARI7A\SQLEXPRESS;Initial Catalog=KutuphaneDb;Integrated Security=True");


        public void KitapSayisi()
        {
            _baglan.Open();
            string toplam = "select sum(kitapsayisi) from sepet";
            SqlCommand komut = new SqlCommand(toplam, _baglan);
            lblKitap_Sayi.Text = komut.ExecuteScalar().ToString();//topla
            _baglan.Close();
        }

        public void Sepetlisteleme()
        {
            DataSet dataSet = new DataSet();
            dataSet.Clear();

            _baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from sepet", _baglan);
            adtr.Fill(dataSet, "sepet");
            dataGridView1.DataSource = dataSet.Tables["sepet"];
            _baglan.Close();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            _baglan.Open();
            string kayit = "insert into sepet values(@barkodno,@kitapad,@yazar,@yayinevi,@sayfasayisi,@kitapsayisi,@teslimtarih,@iadetarih)";
            SqlCommand komut = new SqlCommand(kayit, _baglan);
            komut.Parameters.AddWithValue("@barkodno", txtBarkod.Text);
            komut.Parameters.AddWithValue("@kitapad", txtK_Ad.Text);
            komut.Parameters.AddWithValue("@yazar", txtYazar.Text);
            komut.Parameters.AddWithValue("@yayinevi", txtYayinE.Text);
            komut.Parameters.AddWithValue("@sayfasayisi", txtS_Sayisi.Text);
            komut.Parameters.AddWithValue("@kitapsayisi", int.Parse(txtK_Sayisi.Text));
            komut.Parameters.AddWithValue("@teslimtarih", dtpTeslim.Text);
            komut.Parameters.AddWithValue("@iadetarih", dtpIade.Text);
            komut.ExecuteNonQuery();
            _baglan.Close();

            MessageBox.Show("Kayıt Başarıyla Eklendi..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Sepetlisteleme();
            lblKayitliKitapSayisi.Text = "";
            KitapSayisi();

            foreach (Control item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            txtK_Sayisi.Text = "1";

        }

        private void Txt_Tc_TextChanged(object sender, EventArgs e)
        {
            _baglan.Open();
            string kayit = "select * from uye where tc  like '" + txt_Tc.Text + "'";
            SqlCommand komut = new SqlCommand(kayit, _baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txtAdSoyad.Text = oku["adsoyad"].ToString();
                txtYas.Text = oku["yas"].ToString();
                txtTel.Text = oku["telefon"].ToString();
            }
            _baglan.Close();


            //KitapSayisi();

            _baglan.Open();

            SqlCommand komut2 = new SqlCommand("select sum(kitapsayisi) from emanet where tc='" + txt_Tc.Text + "'", _baglan);
            lblKayitliKitapSayisi.Text = komut2.ExecuteScalar().ToString();

            _baglan.Close();

            if (txt_Tc.Text == "")
            {
                txtAdSoyad.Clear();
                txtYas.Clear();
                txtTel.Clear();
                lblKayitliKitapSayisi.Text = "";
            }
        }

        private void TxtBarkod_TextChanged(object sender, EventArgs e)
        {
            _baglan.Open();
            string kayit = "select * from kitap where barkodno  like '" + txtBarkod.Text + "'";
            SqlCommand komut = new SqlCommand(kayit, _baglan);
            SqlDataReader oku = komut.ExecuteReader();
            while (oku.Read())
            {
                txtK_Ad.Text = oku["kitapadi"].ToString();
                txtYazar.Text = oku["yazar"].ToString();
                txtYayinE.Text = oku["yayinevi"].ToString();
                txtS_Sayisi.Text = oku["sayfasayisi"].ToString();
            }
            _baglan.Close();

            if (txtBarkod.Text == "")
            {
                foreach (Control item in groupBox2.Controls)
                {
                    if (item is TextBox)
                    {
                        if (item != lblKitap_Sayi)
                        {
                            item.Text = "";
                        }
                    }
                }
            }
            /*
                if (txtBarkod.Text == "")
            {
                txtK_Ad.Clear();
                txtYazar.Clear();
                txtYayinE.Clear();
                txtS_Sayisi.Clear();
            }
            */
            txtK_Sayisi.Text = "1";

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            _baglan.Open();
            SqlCommand komut = new SqlCommand("delete from sepet ", _baglan);
            komut.ExecuteNonQuery();
            _baglan.Close();

            MessageBox.Show("Kayıt Silindi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Sepetlisteleme();
            KitapSayisi();
            lblKitap_Sayi.Text = "";

            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }

        private void BtnTeslim_Et_Click(object sender, EventArgs e)
        {
            if (lblKitap_Sayi.Text != "")
            {
                if (lblKayitliKitapSayisi.Text == "" && int.Parse(lblKitap_Sayi.Text) <= 18 || lblKitap_Sayi.Text != "" && int.Parse(lblKayitliKitapSayisi.Text) + int.Parse(lblKitap_Sayi.Text) <= 18)// 3 çogalıtabılır
                {
                    if (txt_Tc.Text != "" && txtAdSoyad.Text != "" && txtYas.Text != "" && txtTel.Text != "")
                    {
                        for (int i = 0; i < dataGridView1.RowCount; i++)
                        {
                            int say = dataGridView1.RowCount;

                            _baglan.Open();

                            string ekle = "insert into emanet values(@tc,@adsoyad,@yas,@telefon,@barkodno,@kitapad,@yazar,@yayinevi,@sayfasayisi,@kitapsayisi,@teslimtarih,@iadetarih )";
                            SqlCommand komut = new SqlCommand(ekle, _baglan);

                            komut.Parameters.AddWithValue("@tc", txt_Tc.Text);
                            komut.Parameters.AddWithValue("@adsoyad", txtAdSoyad.Text);
                            komut.Parameters.AddWithValue("@yas", txtYas.Text);
                            komut.Parameters.AddWithValue("@telefon", txtTel.Text);
                            komut.Parameters.AddWithValue("@barkodno", dataGridView1.Rows[i].Cells["barkodno"].Value.ToString());
                            komut.Parameters.AddWithValue("@kitapad", dataGridView1.Rows[i].Cells["kitapad"].Value.ToString());
                            komut.Parameters.AddWithValue("@yazar", dataGridView1.Rows[i].Cells["yazar"].Value.ToString());
                            komut.Parameters.AddWithValue("@yayinevi", dataGridView1.Rows[i].Cells["yayinevi"].Value.ToString());
                            komut.Parameters.AddWithValue("@sayfasayisi", dataGridView1.Rows[i].Cells["sayfasayisi"].Value.ToString());
                            komut.Parameters.AddWithValue("@kitapsayisi", int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()));
                            komut.Parameters.AddWithValue("@teslimtarih", dataGridView1.Rows[i].Cells["teslimtarih"].Value.ToString());
                            komut.Parameters.AddWithValue("@iadetarih", dataGridView1.Rows[i].Cells["iadetarih"].Value.ToString());
                            komut.ExecuteNonQuery();

                            SqlCommand komut2 = new SqlCommand("update uye set okukitapsayisi=okukitapsayisi+'" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "' where tc='" + txt_Tc.Text + "'  ", _baglan);
                            komut2.ExecuteNonQuery();

                            SqlCommand komut3 = new SqlCommand("update kitap set stoksayisi = stoksayisi - '" + int.Parse(dataGridView1.Rows[i].Cells["kitapsayisi"].Value.ToString()) + "' where barkodno = '" + dataGridView1.Rows[i].Cells["barkodno"].Value.ToString() + "'", _baglan);
                            komut3.ExecuteNonQuery();

                            SqlCommand komut4 = new SqlCommand("delete from sepet", _baglan);
                            komut4.ExecuteNonQuery();
                            _baglan.Close();

                            MessageBox.Show("Kitaplar emanet edildi..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Sepetlisteleme();
                            lblKitap_Sayi.Text = "";
                            txt_Tc.Clear();
                            lblKayitliKitapSayisi.Text = "";
                            KitapSayisi();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Önce üye isminiz gerekir", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                    }
                }
                else
                {
                    MessageBox.Show("Emanet Kitap Sayısı 3 den fazla olamaz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
            }
            else
            {
                MessageBox.Show("Önce sepete kitap eklenmelidir..", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        private void EmanetKitapVer_Load(object sender, EventArgs e)
        {


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
    }
}
