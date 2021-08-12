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
    public partial class FrmSekreterGiris : Form
    {
        public FrmSekreterGiris()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from Sekreterler where SekreterTC=@p1 and SekreterSifre=@p2", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", mskTc.Text);
            command.Parameters.AddWithValue("@p2", txtSifre.Text);

            SqlDataReader dataReader = command.ExecuteReader();
            if (dataReader.Read())
            {
                FrmSekreterDetay sekreterDetay = new FrmSekreterDetay();
                sekreterDetay.TcNumara = mskTc.Text;
                sekreterDetay.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı bilgileri girdiniz.");
            }
            sqlBaglantisi.Connection().Close();
        }
    }
}
