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
    public partial class FrmDoktorBilgiDuzenle : Form
    {
        public FrmDoktorBilgiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        public string TcNo;
        private void FrmDoktorBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTc.Text = TcNo;
            SqlCommand command = new SqlCommand("select * from Doktor where DoktorTc='" + TcNo + "'", sqlBaglantisi.Connection());
            SqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                txtIsim.Text = dataReader[1].ToString();
                txtSoyisim.Text = dataReader[2].ToString();
                cmbBrans.Text = dataReader[3].ToString();
                txtSifre.Text = dataReader[5].ToString();
            }
            sqlBaglantisi.Connection().Close();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("update Doktor set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p4 where DoktorTc=@p5", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", txtIsim.Text);
            command.Parameters.AddWithValue("@p2", txtSoyisim.Text);
            command.Parameters.AddWithValue("@p3", cmbBrans.Text);
            command.Parameters.AddWithValue("@p4", txtSifre.Text);
            command.Parameters.AddWithValue("@p5", mskTc.Text);
            command.ExecuteNonQuery();
            sqlBaglantisi.Connection().Close();
            MessageBox.Show("Kayıt güncellendi.");
        }
    }
}
