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
    public partial class FrmBrans : Form
    {
        public FrmBrans()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        private void FrmBrans_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Branslar",sqlBaglantisi.Connection());
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Branslar (BransAd) values (@p1)", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1",txtIsim.Text);
            command.ExecuteNonQuery();
            sqlBaglantisi.Connection().Close();
            MessageBox.Show("Kayıt başarılı.");
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {

        }
    }
}
