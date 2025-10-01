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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-PGJE2B7\\SQLEXPRESS;Initial Catalog=PERSONELVERİTABANI;Integrated Security=True");

        void Temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txtmeslek.Text = "";
            cmbsehir.Text = "";
            maskedTextBox1.Text = "";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            txtad.Focus();
        }


        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'pERSONELVERİTABANIDataSet.tbl_personel' table. You can move, or remove it, as needed.
            // Personel tablosunu doldur
            this.tbl_personelTableAdapter.Fill(this.pERSONELVERİTABANIDataSet.tbl_personel);

            // Türkiye'nin 81 ili ComboBox'a eklendi
            string[] sehirler = {
                "Adana","Adıyaman","Afyonkarahisar","Ağrı","Amasya","Ankara",
                "Antalya","Artvin","Aydın","Balıkesir","Bilecik","Bingöl","Bitlis","Bolu",
                "Burdur","Bursa","Çanakkale","Çankırı","Çorum","Denizli","Diyarbakır",
                "Edirne","Elazığ","Erzincan","Erzurum","Eskişehir","Gaziantep","Giresun",
                "Gümüşhane","Hakkari","Hatay","Isparta","Mersin","İstanbul","İzmir","Kars",
                "Kastamonu","Kayseri","Kırklareli","Kırşehir","Kocaeli","Konya","Kütahya",
                "Malatya","Manisa","Kahramanmaraş","Mardin","Muğla","Muş","Nevşehir","Niğde",
                "Ordu","Rize","Sakarya","Samsun","Siirt","Sinop","Sivas","Tekirdağ","Tokat",
                "Trabzon","Tunceli","Şanlıurfa","Uşak","Van","Yozgat","Zonguldak","Aksaray",
                "Bayburt","Karaman","Kırıkkale","Batman","Şırnak","Bartın","Ardahan","Iğdır",
                "Yalova","Karabük","Kilis","Osmaniye","Düzce"
            };

            cmbsehir.Items.AddRange(sehirler);
        
    }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into tbl_personel(Perad,Persoyad,Persehir,Permaas,Permeslek,Perdurum) values (@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2",txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbsehir.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();    
            baglanti.Close();
            MessageBox.Show("Personel Eklendi");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            this.tbl_personelTableAdapter.Fill(this.pERSONELVERİTABANIDataSet.tbl_personel);
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbsehir.Text= dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text= dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text= dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text= dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "True")
            {
                radioButton1.Checked = true;

            }
            if (label8.Text == "False")
            {
                radioButton2.Checked = true;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("Delete from tbl_personel Where Perid=@k1", baglanti);
            komutsil.Parameters.AddWithValue("@k1",txtid.Text);
            komutsil.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("kayıt silindi");
        }

        private void btngüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update tbl_personel Set Perad=@a1,Persoyad=@a2,Persehir=@a3,Permaas=@a4,Perdurum=@a5,Permeslek=@a6 where Perid=@a", baglanti);
            guncelle.Parameters.AddWithValue("@a", txtid.Text);
            guncelle.Parameters.AddWithValue("@a1",txtad.Text);
            guncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            guncelle.Parameters.AddWithValue("@a3", cmbsehir.Text);
            guncelle.Parameters.AddWithValue("@a4", maskedTextBox1.Text);
            guncelle.Parameters.AddWithValue("@a5", label8.Text);
            guncelle.Parameters.AddWithValue("@a6", txtmeslek.Text);
            
            guncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("Personel bilgi güncellendi");

        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
           istatistik fr =new istatistik();
            fr.Show();
        }

        private void btngrafikler_Click(object sender, EventArgs e)
        {
            grafikler frg =new grafikler();
            frg.Show();
        }

        private void cmbsehir_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] sehirler = { "Adana","Adıyaman","Afyonkarahisar","Ağrı","Amasya","Ankara",
                          "Antalya","Artvin","Aydın","Balıkesir","Bilecik","Bingöl","Bitlis","Bolu",
                          "Burdur","Bursa","Çanakkale","Çankırı","Çorum","Denizli","Diyarbakır",
                          "Edirne","Elazığ","Erzincan","Erzurum","Eskişehir","Gaziantep","Giresun",
                          "Gümüşhane","Hakkari","Hatay","Isparta","Mersin","İstanbul","İzmir","Kars",
                          "Kastamonu","Kayseri","Kırklareli","Kırşehir","Kocaeli","Konya","Kütahya",
                          "Malatya","Manisa","Kahramanmaraş","Mardin","Muğla","Muş","Nevşehir","Niğde",
                          "Ordu","Rize","Sakarya","Samsun","Siirt","Sinop","Sivas","Tekirdağ","Tokat",
                          "Trabzon","Tunceli","Şanlıurfa","Uşak","Van","Yozgat","Zonguldak","Aksaray",
                          "Bayburt","Karaman","Kırıkkale","Batman","Şırnak","Bartın","Ardahan","Iğdır",
                          "Yalova","Karabük","Kilis","Osmaniye","Düzce" };

            cmbsehir.Items.AddRange(sehirler);
        }
    }
}
