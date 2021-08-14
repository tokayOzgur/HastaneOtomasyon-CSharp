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
    public partial class FrmDoktorGiris : Form
    {
        public FrmDoktorGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        private void FrmDoktorGiris_Load(object sender, EventArgs e)
        {

        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from Doktor where DoktorTc=@p1 and DoktorSifre=@p2", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", mskTc.Text);
            command.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                FrmDoktorDetay frmDoktorDetay = new FrmDoktorDetay();
                frmDoktorDetay.Tc = mskTc.Text;
                frmDoktorDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı giriş bilgileri girdiniz.");
            }
            sqlBaglantisi.Connection().Close();
        }
    }
}
