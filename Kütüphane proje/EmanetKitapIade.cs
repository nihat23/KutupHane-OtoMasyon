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
    public partial class EmanetKitapIade : UserControl
    {
        public EmanetKitapIade()
        {
            InitializeComponent();
        }

        SqlConnection _baglan = new SqlConnection(@"Data Source=DESKTOP-5QARI7A\SQLEXPRESS;Initial Catalog=KutuphaneDb;Integrated Security=True");

        DataSet dataSet = new DataSet();

        public void EmanetKitapIadee()
        {
            dataSet.Clear();
            _baglan.Open();
            SqlDataAdapter adtr = new SqlDataAdapter("select * from emanet", _baglan);
            adtr.Fill(dataSet, "emanet");
            dataGridView1.DataSource = dataSet.Tables["emanet"];
            _baglan.Close();
        }


        private void btnTeslimAl_Click(object sender, EventArgs e)
        { 
            _baglan.Open();
            SqlCommand komut = new SqlCommand("delete from emanet  where tc=@tc  and barkodno=@barkodno", _baglan);
            komut.Parameters.AddWithValue("@tc", dataGridView1.CurrentRow.Cells["tc"].Value.ToString());
            komut.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut.ExecuteNonQuery();

            SqlCommand komut2 = new SqlCommand("update kitap set stoksayisi=stoksayisi+'" + dataGridView1.CurrentRow.Cells["kitapsayisi"].Value.ToString() + "' where barkodno=@barkodno", _baglan);
            komut2.Parameters.AddWithValue("@barkodno", dataGridView1.CurrentRow.Cells["barkodno"].Value.ToString());
            komut2.ExecuteNonQuery();
            _baglan.Close();

            MessageBox.Show("Kitap iade edildi..", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataSet.Clear();
            EmanetKitapIadee();
        }

        private void txtTcAra_TextChanged(object sender, EventArgs e)
        {
            dataSet.Clear();

            _baglan.Open();

            SqlDataAdapter adtr = new SqlDataAdapter("select * from emanet where  tc like '%" + txtTcAra.Text + "%'", _baglan);
            adtr.Fill(dataSet, "emanet");
            dataGridView1.DataSource = dataSet.Tables["emanet"];
            _baglan.Close();

            if (txtTcAra.Text == "")
            {
                EmanetKitapIadee();

            }
        }

        private void EmanetKitapIade_Load(object sender, EventArgs e)
        {
            EmanetKitapIadee();

        }
    }
}
