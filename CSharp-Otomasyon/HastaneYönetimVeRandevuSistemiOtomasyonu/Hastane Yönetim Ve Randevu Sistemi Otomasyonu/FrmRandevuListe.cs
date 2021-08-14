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
    public partial class FrmRandevuListe : Form
    {
        public FrmRandevuListe()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        private void FrmRandevuListe_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Randevular", sqlBaglantisi.Connection());
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlBaglantisi.Connection().Close();
        }

        public int secilen;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            secilen = dataGridView1.SelectedCells[0].RowIndex;
        }
    }
}
