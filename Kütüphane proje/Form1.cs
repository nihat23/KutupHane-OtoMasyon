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
    public partial class Form1 : Form
    {
        public Form1()
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
            uyeListele1.dataGridView1.DataSource = dataSet.Tables["uye"];

            _baglan.Close();
        }

        public void KitapSayisi()//önemli toplam yedek
        {
            _baglan.Open();
            string Kitap_sayi_Topla = "select sum(kitapsayisi) from sepet";
            SqlCommand komut = new SqlCommand(Kitap_sayi_Topla, _baglan);
            emanetKitapVer1.lblKayitliKitapSayisi.Text = komut.ExecuteScalar().ToString();
            _baglan.Close();
        }


        public void KitapListeleme()
        {
            DataSet dataSetl = new DataSet();
            dataSetl.Clear();
            _baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from kitap", _baglan);
            adtr.Fill(dataSetl, "kitap");
            kitapListele1.dataGridView1.DataSource = dataSetl.Tables["kitap"];
            _baglan.Close();
        }

        public void SepetListeleme()
        {
            DataSet dataSetl = new DataSet();
            dataSetl.Clear();
            _baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from sepet", _baglan);
            adtr.Fill(dataSetl, "sepet");
            emanetKitapVer1.dataGridView1.DataSource = dataSetl.Tables["sepet"];


            _baglan.Close();
        }


        private void btnUyeEkle_Click(object sender, EventArgs e)
        {
            uyeEkleme1.Show();
            uyeListele1.Hide();
            kitapEkle1.Hide();
            emanetKitapVer1.Hide();
            emanetKitapListeleme1.Hide();
            emanetKitapIade1.Hide();

            SepetListeleme();
            KitapListeleme();
            UyeListeleme();
            emanetKitapVer1.KitapSayisi();
            emanetKitapListeleme1.EmanetKitapListele();
            emanetKitapIade1.EmanetKitapIadee();



        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UyeListeleme();//çagır
            emanetKitapVer1.KitapSayisi();

            // KitapSayisi();

            uyeListele1.Show();
            uyeEkleme1.Hide();
            kitapEkle1.Hide();
            kitapListele1.Hide();
            emanetKitapVer1.Hide();
            emanetKitapListeleme1.Hide();
            emanetKitapIade1.Hide();

            SepetListeleme();
            KitapListeleme();
            UyeListeleme();
            emanetKitapVer1.KitapSayisi();
            emanetKitapListeleme1.EmanetKitapListele();
            emanetKitapIade1.EmanetKitapIadee();


        }

        private void btnUyeListele_Click(object sender, EventArgs e)
        {
            UyeListeleme();

            uyeListele1.Show();

            uyeEkleme1.Hide();
            kitapEkle1.Hide();
            kitapListele1.Hide();
            emanetKitapVer1.Hide();
            emanetKitapListeleme1.Hide();
            emanetKitapIade1.Hide();


            SepetListeleme();
            KitapListeleme();
            UyeListeleme();
            emanetKitapVer1.KitapSayisi();
            emanetKitapListeleme1.EmanetKitapListele();
            emanetKitapIade1.EmanetKitapIadee();
        }

        private void uyeListele1_Load(object sender, EventArgs e)
        {

        }

        private void btnKitapEkle_Click(object sender, EventArgs e)
        {
            kitapEkle1.Show();

            uyeEkleme1.Hide();
            uyeListele1.Hide();
            kitapListele1.Hide();
            emanetKitapVer1.Hide();
            emanetKitapListeleme1.Hide();
            emanetKitapIade1.Hide();

            SepetListeleme();
            KitapListeleme();
            UyeListeleme();
            emanetKitapVer1.KitapSayisi();
            emanetKitapListeleme1.EmanetKitapListele();
            emanetKitapIade1.EmanetKitapIadee();
        }

        private void btnKitapListele_Click(object sender, EventArgs e)
        {

            kitapListele1.Show();

            uyeListele1.Hide();
            uyeEkleme1.Hide();
            kitapEkle1.Hide();
            emanetKitapVer1.Hide();
            emanetKitapListeleme1.Hide();
            emanetKitapIade1.Hide();


            SepetListeleme();
            KitapListeleme();
            UyeListeleme();
            emanetKitapVer1.KitapSayisi();
            emanetKitapListeleme1.EmanetKitapListele();
            emanetKitapIade1.EmanetKitapIadee();
        }

        private void kitapListele1_Load(object sender, EventArgs e)
        {

        }

        private void btnEmanetKitapVer_Click(object sender, EventArgs e)
        {
            emanetKitapVer1.Show();

            uyeListele1.Hide();
            uyeEkleme1.Hide();
            kitapEkle1.Hide();
            kitapListele1.Hide();
            emanetKitapListeleme1.Hide();
            emanetKitapIade1.Hide();


            SepetListeleme();
            KitapListeleme();
            UyeListeleme();

            emanetKitapVer1.KitapSayisi();
            emanetKitapListeleme1.EmanetKitapListele();
            emanetKitapIade1.EmanetKitapIadee();

        }

        private void EmanetKitapListele_Click(object sender, EventArgs e)
        {
            emanetKitapListeleme1.Show();

            uyeEkleme1.Hide();
            uyeListele1.Hide();
            kitapEkle1.Hide();
            emanetKitapVer1.Hide();
            emanetKitapIade1.Hide();

            SepetListeleme();
            KitapListeleme();
            UyeListeleme();

            emanetKitapVer1.KitapSayisi();
            emanetKitapListeleme1.EmanetKitapListele();
            emanetKitapIade1.EmanetKitapIadee();
        }

        private void btnKitapIade_Click(object sender, EventArgs e)
        {
            emanetKitapIade1.Show();

            emanetKitapVer1.Hide();
            uyeListele1.Hide();
            uyeEkleme1.Hide();
            kitapEkle1.Hide();
            kitapListele1.Hide();
            emanetKitapListeleme1.Hide();

            SepetListeleme();
            KitapListeleme();
            UyeListeleme();
            emanetKitapVer1.KitapSayisi();
            emanetKitapListeleme1.EmanetKitapListele();
            emanetKitapIade1.EmanetKitapIadee();

        }

        private void brnSirala_Click(object sender, EventArgs e)
        {
            kitapSiralama kitapSiralama = new kitapSiralama();
            kitapSiralama.Show();


            SepetListeleme();
            KitapListeleme();
            UyeListeleme();
            emanetKitapVer1.KitapSayisi();
            emanetKitapListeleme1.EmanetKitapListele();
            emanetKitapIade1.EmanetKitapIadee();

        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            kitapGrafik kitapGrafik = new kitapGrafik();
            kitapGrafik.ShowDialog();

            SepetListeleme();
            KitapListeleme();
            UyeListeleme();

            emanetKitapVer1.KitapSayisi();
            emanetKitapListeleme1.EmanetKitapListele();
            emanetKitapIade1.EmanetKitapIadee();

        }
    }
}
