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
    public partial class FrmHastaGiris : Form
    {
        public FrmHastaGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        private void lblUyeOl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaKayit frmHastaKayit = new FrmHastaKayit();

            frmHastaKayit.Show();

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("SELECT * from Hastalar where HastaTC=@p1 and HastaSifre = @p2", sqlBaglantisi.Connection());

            command.Parameters.AddWithValue("@p1", mskTc.Text);
            command.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dataReader = command.ExecuteReader();

            if (dataReader.Read())
            {
                FrmHastaDetay frmHastaDetay = new FrmHastaDetay();

                frmHastaDetay.tc = mskTc.Text;//Bu veriyi hasta detay penceresine taşıdık

                frmHastaDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Giriş Bilgileri Girdiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sqlBaglantisi.Connection().Close();
        }

        private void FrmHastaGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            FrmGirisler frmGirisler = new FrmGirisler();
            frmGirisler.Show();
            this.Close();
        }
    }
}
