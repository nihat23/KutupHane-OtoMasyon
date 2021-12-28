using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;//Kutuphanemiz
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_proje
{
    public partial class kitapSiralama : Form
    {
        public kitapSiralama()
        {
            InitializeComponent();
        }

        SqlConnection _baglan = new SqlConnection(@"Data Source=DESKTOP-5QARI7A\SQLEXPRESS;Initial Catalog=KutuphaneDb;Integrated Security=True");

        DataSet dataSet = new DataSet();

        public void KitapSiralama()
        {
            dataSet.Clear();
            _baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from uye order by okukitapsayisi desc", _baglan);
            adtr.Fill(dataSet, "uye");
            dataGridView1.DataSource = dataSet.Tables["uye"];
            _baglan.Close();
        }

        private void kitapSiralama_Load(object sender, EventArgs e)
        {
            KitapSiralama();

            lblEnCok.Text = dataSet.Tables["uye"].Rows[0]["adsoyad"].ToString() + " : ";
            lblEnCok.Text += dataSet.Tables["uye"].Rows[0]["okukitapsayisi"].ToString();

          lblEnAz.Text = dataSet.Tables["uye"].Rows[dataGridView1.RowCount-1]["adsoyad"].ToString() + " : ";
          lblEnAz.Text += dataSet.Tables["uye"].Rows[dataGridView1.RowCount-1]["okukitapsayisi"].ToString();


        }
    }
}
