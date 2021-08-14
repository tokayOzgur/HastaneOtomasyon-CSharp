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
    public partial class FrmDoktorDetay : Form
    {
        public FrmDoktorDetay()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        public string Tc;
        private void FrmDoktorDetay_Load(object sender, EventArgs e)
        {
            lblTc.Text = Tc;

            //Doktor AdSoyad çekme işlemi
            SqlCommand command = new SqlCommand("select DoktorAd, DoktorSoyad from Doktor where DoktorTc =" + Tc, sqlBaglantisi.Connection());
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                lblAdSoyad.Text = reader[0] + " " + reader[1];
            }
            sqlBaglantisi.Connection().Close();

            //Randevule
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Randevular where RandevuDoktor='" + lblAdSoyad.Text+"'", sqlBaglantisi.Connection());
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            FrmDoktorBilgiDuzenle frmDoktorBilgiDuzenle = new FrmDoktorBilgiDuzenle();
            frmDoktorBilgiDuzenle.TcNo = lblTc.Text;
            frmDoktorBilgiDuzenle.Show();
        }

        private void btnDuyurular_Click(object sender, EventArgs e)
        {
            FrmDoktorDuyurular frmDoktorDuyurular = new FrmDoktorDuyurular();
            frmDoktorDuyurular.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            FrmGirisler frmGirisler = new FrmGirisler();
            frmGirisler.Show();
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rtbHastaSikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
