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
    public partial class FrmHastaBilgiDuzenle : Form
    {
        public FrmHastaBilgiDuzenle()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        public string tcNo;
        private void FrmHastaBilgiDuzenle_Load(object sender, EventArgs e)
        {
            mskTc.Text = tcNo;

            //Veriler çekme işlemi
            SqlCommand sqlCommand = new SqlCommand("select * from Hastalar where HastaTC=@p1", sqlBaglantisi.Connection());
            sqlCommand.Parameters.AddWithValue("@p1", tcNo);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                txtIsim.Text = dataReader[1].ToString();
                txtSoyisim.Text = dataReader[2].ToString();
                mskTelefon.Text = dataReader[4].ToString();
                txtSifre.Text = dataReader[5].ToString();
                cmbCinsiyet.Text = dataReader[6].ToString();
            }

            sqlBaglantisi.Connection().Close();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand sqlCommand = new SqlCommand("Update Hastalar set HastaAd=@p1,HastaSoyad=@p2,HastaTelefon=@p3,HastaSifre=@p4,HastaCinsiyet=@p5 where  HastaTC=@p6", sqlBaglantisi.Connection());
            sqlCommand.Parameters.AddWithValue("@p1", txtIsim.Text);
            sqlCommand.Parameters.AddWithValue("@p2", txtSoyisim.Text);
            sqlCommand.Parameters.AddWithValue("@p3", mskTelefon.Text);
            sqlCommand.Parameters.AddWithValue("@p4", txtSifre.Text);
            sqlCommand.Parameters.AddWithValue("@p5", cmbCinsiyet.Text);
            sqlCommand.Parameters.AddWithValue("@p6", tcNo);

            sqlCommand.ExecuteNonQuery(); //kayıt işlemi
            sqlBaglantisi.Connection().Close();
            MessageBox.Show("Bilgileriniz Başarılı Bir Şekilde Güncellendi.", "Bilgilendirme!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            FrmHastaDetay frmHastaDetay = new FrmHastaDetay();
            frmHastaDetay.Show();
            this.Hide();
        }
    }
}
