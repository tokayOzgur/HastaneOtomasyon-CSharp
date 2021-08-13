using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hastane_Yönetim_Ve_Randevu_Sistemi_Otomasyonu
{
    public partial class FrmSekreterDetay : Form
    {
        public FrmSekreterDetay()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        public string TcNumara;
        private void FrmSekreterDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = TcNumara;

            //ad soyad
            SqlCommand command = new SqlCommand("select SekreterAdSoyad from Sekreterler where SekreterTC=@p1", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", TcNumara);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                lblAdSoyad.Text = dataReader[0].ToString();
            }
            sqlBaglantisi.Connection().Close();

            // Branşları datagride Aktartma
            DataTable dt1 = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from Branslar", sqlBaglantisi.Connection());
            da.Fill(dt1);
            dataGridView1.DataSource = dt1;

            // doktorları datagride aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select (DoktorAd+' '+DoktorSoyad )as 'Doktorlar' ,DoktorBrans from Doktor", sqlBaglantisi.Connection());
            da2.Fill(dt2);
            dataGridView2.DataSource = dt2;

            // Branşı combobox'a çekme
            SqlCommand command1 = new SqlCommand("select BransAd from Branslar", sqlBaglantisi.Connection());
            SqlDataReader dataReader1 = command1.ExecuteReader();
            while (dataReader1.Read())
            {
                cmbBrans.Items.Add(dataReader1[0]);
            }
            sqlBaglantisi.Connection().Close();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Randevular (RandevuTarih, RandevuSaat,RandevuBrans,Randevudoktor)" +
                "values (@p1,@p2,@p3,@p4)", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", mskTarih.Text);
            command.Parameters.AddWithValue("@p2", mskSaat.Text);
            command.Parameters.AddWithValue("@p3", cmbBrans.Text);
            command.Parameters.AddWithValue("@p4", cmbDoktor.Text);
            command.ExecuteNonQuery();
            sqlBaglantisi.Connection().Close();
            MessageBox.Show("Randevu Oluşturuldu.");
        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Seçilen branş'a göre doktor getirtme 
            cmbDoktor.Items.Clear();

            SqlCommand command = new SqlCommand("Select DoktorAd , DoktorSoyad  from Doktor where DoktorBrans = @p1", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                cmbDoktor.Items.Add(dataReader[0] + " " + dataReader[1]);
            }
            sqlBaglantisi.Connection().Close();
        }

        private void btnDuyuruYayinla_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Duyurular (Duyuru) values (@p1)", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", rtbDuyuru.Text);
            command.ExecuteNonQuery();
            sqlBaglantisi.Connection().Close();
            MessageBox.Show("Duyuru yayına alındı.");
        }

        private void btnDoktorPanel_Click(object sender, EventArgs e)
        {
            FrmDoktorPanel frmDoktorPanel = new FrmDoktorPanel();
            frmDoktorPanel.Show();
            
        }

        private void btnBransPanel_Click(object sender, EventArgs e)
        {
            FrmBrans frmBrans = new FrmBrans();
            frmBrans.Show();
        }
    }
}   
