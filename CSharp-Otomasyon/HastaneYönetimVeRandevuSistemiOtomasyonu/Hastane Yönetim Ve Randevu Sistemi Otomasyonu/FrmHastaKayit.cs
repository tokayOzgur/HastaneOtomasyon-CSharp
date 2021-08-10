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
    public partial class FrmHastaKayit : Form
    {
        public FrmHastaKayit()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("insert into Hastalar (HastaAd, HastaSoyad, HastaTC, HastaTelefon, HastaSifre, HastaCinsiyet) values (@p1,@p2,@p3,@p4,@p5,@p6)", sqlBaglantisi.Connection());

            sqlCommand.Parameters.AddWithValue("@p1", txtIsim.Text);
            sqlCommand.Parameters.AddWithValue("@p1", txtSoyisim.Text);
            sqlCommand.Parameters.AddWithValue("@p1", mskTc.Text);
            sqlCommand.Parameters.AddWithValue("@p1", mskTelefon.Text);
            sqlCommand.Parameters.AddWithValue("@p1", txtSifre.Text);
            sqlCommand.Parameters.AddWithValue("@p1", cmbCinsiyet.Text);


            sqlBaglantisi.Connection().Close();
            MessageBox.Show("Kayıt işlemi başarılı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
