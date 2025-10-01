using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace son
{
    public partial class grafikler : Form
    {
        public grafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PGJE2B7\\SQLEXPRESS;Initial Catalog=PERSONELVERİTABANI;Integrated Security=True");
        private void chart1_Click(object sender, EventArgs e)
        {
            //grafik1
            baglanti.Open();
            SqlCommand komutg1 = new SqlCommand("Select Persehir,Count(*) from tbl_personel Group By Persehir",baglanti);
            SqlDataReader dr1 = komutg1.ExecuteReader();    
            while (dr1.Read())
            {
                chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
            }
            baglanti.Close();
            //grafik2
            baglanti.Open();
            SqlCommand komutg2 = new SqlCommand("Select Permeslek,Avg(Permaas) from tbl_personel Group By Permeslek", baglanti);
            SqlDataReader dr2 = komutg2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }
            baglanti.Close();

        }
    }
}
