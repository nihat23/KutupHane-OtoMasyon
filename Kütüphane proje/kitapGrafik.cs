using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//Kutuphanemız
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_proje
{
    public partial class kitapGrafik : Form
    {
        public kitapGrafik()
        {
            InitializeComponent();
        }


        SqlConnection _baglan = new SqlConnection(@"Data Source=DESKTOP-5QARI7A\SQLEXPRESS;Initial Catalog=KutuphaneDb;Integrated Security=True");

        DataSet dataSet = new DataSet();

        private void kitapGrafik_Load(object sender, EventArgs e)
        {
            _baglan.Open();
            SqlCommand komut = new SqlCommand("select adsoyad,okukitapsayisi from uye",_baglan);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                chart1.Series["Okunan Kitap Sayısı"].Points.AddXY(oku["adsoyad"].ToString(), oku["okukitapsayisi"]);
            }
            _baglan.Close();

            chart1.Series["Okunan Kitap Sayısı"].Color = Color.Coral;

        }
    }
}
