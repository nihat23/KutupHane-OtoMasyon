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
    public partial class EmanetKitapListeleme : UserControl
    {
        public EmanetKitapListeleme()
        {
            InitializeComponent();
        }


        SqlConnection _baglan = new SqlConnection(@"Data Source=DESKTOP-5QARI7A\SQLEXPRESS;Initial Catalog=KutuphaneDb;Integrated Security=True");

        DataSet dataSet = new DataSet();

        public void EmanetKitapListele()
        {
            dataSet.Clear();
            _baglan.Open(); 
            SqlDataAdapter adtr = new SqlDataAdapter("select * from emanet", _baglan);
            adtr.Fill(dataSet, "emanet");
            dataGridView1.DataSource = dataSet.Tables["emanet"];
            _baglan.Close();
        }

        private void EmanetKitapListeleme_Load(object sender, EventArgs e)
        {
            EmanetKitapListele();
            cmbFiltrele.SelectedIndex = 0;

        }

        private void cmbFiltrele_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSet.Clear();

            if (cmbFiltrele.SelectedIndex == 0)
            {
                EmanetKitapListele();

            }
            else if (cmbFiltrele.SelectedIndex == 1)
            {
                _baglan.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select * from emanet where '" + DateTime.Now.ToShortDateString() + "'>iadetarih ", _baglan);
                adtr.Fill(dataSet, "emanet");
                dataGridView1.DataSource = dataSet.Tables["emanet"];
                _baglan.Close();

            }
            else if (cmbFiltrele.SelectedIndex == 2)
            {
                _baglan.Open();
                SqlDataAdapter adtr = new SqlDataAdapter("select * from emanet where '" + DateTime.Now.ToShortDateString() + "'<=iadetarih ", _baglan);
                adtr.Fill(dataSet, "emanet");
                dataGridView1.DataSource = dataSet.Tables["emanet"];
                _baglan.Close();

            }

        }
    }
}
