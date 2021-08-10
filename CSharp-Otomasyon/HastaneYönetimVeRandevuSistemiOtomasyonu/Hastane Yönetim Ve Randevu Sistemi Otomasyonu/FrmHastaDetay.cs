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
    public partial class FrmHastaDetay : Form
    {
        public FrmHastaDetay()
        {
            InitializeComponent();
        }

        public string tc;

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        private void FrmHastaDetay_Load(object sender, EventArgs e)
        {
            // Kişi Bilgi
            lblTc.Text = tc;

            SqlCommand sqlCommand = new SqlCommand("select HastaAd, HastaSoyad from Hastalar where HastaTC = @p1", sqlBaglantisi.Connection());
            sqlCommand.Parameters.AddWithValue("@p1", tc);
            SqlDataReader dataReader = sqlCommand.ExecuteReader();

            while (dataReader.Read())
            {
                lblAdSoyad.Text = dataReader[0] + " " + dataReader[1];
            }
            sqlBaglantisi.Connection().Close();
            // /Kişi Bilgi


            // Randevu Geçmişi
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Randevular where HastaTC =" + tc, sqlBaglantisi.Connection());
            sqlDataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            // /Randevu Geçmişi

            // Randevu Al
            SqlCommand sqlCommand2 = new SqlCommand("select BransAd from Branslar",sqlBaglantisi.Connection());
            SqlDataReader dataReader2 = sqlCommand2.ExecuteReader();
            while (dataReader2.Read())
            {
                cmbBrans.Items.Add(dataReader2[0]); // dataReader2'den gelen değerleri ekle.
            }
            sqlBaglantisi.Connection().Close();
            // /Randevu Al

        }
    }
}
