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
    public partial class FrmDoktorDuyurular : Form
    {
        public FrmDoktorDuyurular()
        {
            InitializeComponent();
        }

        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();
        private void FrmDoktorDuyurular_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Duyurular", sqlBaglantisi.Connection());
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            sqlBaglantisi.Connection().Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenMesaj = dataGridView1.SelectedCells[0].RowIndex;
            MessageBox.Show(dataGridView1.Rows[secilenMesaj].Cells[1].Value.ToString(), "Duyuru", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
