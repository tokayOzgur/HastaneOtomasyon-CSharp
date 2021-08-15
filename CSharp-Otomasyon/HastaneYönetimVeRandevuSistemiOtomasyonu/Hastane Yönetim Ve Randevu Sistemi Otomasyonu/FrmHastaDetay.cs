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

            // BranşÇek
            SqlCommand sqlCommand2 = new SqlCommand("select BransAd from Branslar", sqlBaglantisi.Connection());
            SqlDataReader dataReader2 = sqlCommand2.ExecuteReader();
            while (dataReader2.Read())
            {
                cmbBrans.Items.Add(dataReader2[0]); // dataReader2'den gelen değerleri ekle.
            }
            sqlBaglantisi.Connection().Close();
            // /Branş Çek

        }

        private void cmbBrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbDoktor.Items.Clear();
            // Doktor AdSoyad Çek
            SqlCommand sqlCommand = new SqlCommand("select DoktorAd, DoktorSoyad from Doktor where DoktorBrans=@p1", sqlBaglantisi.Connection());
            sqlCommand.Parameters.AddWithValue("@p1", cmbBrans.Text);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {
                cmbDoktor.Items.Add(sqlDataReader[0] + " " + sqlDataReader[1]);
            }
            sqlBaglantisi.Connection().Close();

        }

        private void cmbDoktor_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Randevular where RandevuBrans='" + cmbBrans.Text + "'" + "and RandevuDoktor='" + cmbDoktor.Text + "' and RandevuDurum=0", sqlBaglantisi.Connection());
            sqlDataAdapter.Fill(dataTable);
            dataGridView2.DataSource = dataTable;
        }

        private void lnkBilgiDuzenle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmHastaBilgiDuzenle frmHastaBilgiDuzenle = new FrmHastaBilgiDuzenle();
            frmHastaBilgiDuzenle.tcNo = lblTc.Text; //tcNo ile diğer forma veri taşıdık
            frmHastaBilgiDuzenle.Show();

        }

        private void btnRandevuAl_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("update Randevular set RandevuDurum=1, HastaTc=@p1,RandevuSikayet=@p2 where RandevuId=@p3", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", lblTc.Text);
            command.Parameters.AddWithValue("@p2", rtbSikayet.Text);
            command.Parameters.AddWithValue("@p3", txtRandevuId.Text);
            command.ExecuteNonQuery();
            sqlBaglantisi.Connection().Close();
            MessageBox.Show("Randevu Kaydı Başarılı.");
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView2.SelectedCells[0].RowIndex;
            txtRandevuId.Text = dataGridView2.Rows[secilen].Cells[0].Value.ToString();
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bu hesaptan çıkış yapmak istediğinize emin misiniz?", "Uyarı!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                FrmHastaGiris frmHastaGiris = new FrmHastaGiris();
                frmHastaGiris.Show();
                this.Hide();
            }
        }
    }
}
