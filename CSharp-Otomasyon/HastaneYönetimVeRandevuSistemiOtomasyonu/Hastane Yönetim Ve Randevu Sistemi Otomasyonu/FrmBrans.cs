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
            SqlDataAdapter dataAdapter = new SqlDataAdapter("select * from Branslar", sqlBaglantisi.Connection());
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Branslar (BransAd) values (@p1)", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", txtIsim.Text);
            command.ExecuteNonQuery();
            sqlBaglantisi.Connection().Close();
            MessageBox.Show("Kayıt başarılı.");
            dataGridView1.Update();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("update Branslar set BransAd=@p1 where BransId=@p2", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", txtIsim.Text);
            command.Parameters.AddWithValue("@p2", txtId.Text);
            sqlBaglantisi.Connection().Close();
            MessageBox.Show("Güncelleme işlemi başarılı.");
            dataGridView1.Update();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenDeger = dataGridView1.SelectedCells[0].RowIndex; // seçilen hücrenin 0'ncı satırdaki değerlerini alsın.
            txtId.Text = dataGridView1.Rows[secilenDeger].Cells[0].Value.ToString();
            txtIsim.Text = dataGridView1.Rows[secilenDeger].Cells[1].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kullanıcıyı silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("delete from Branslar where BransId=@p1", sqlBaglantisi.Connection());
                command.Parameters.AddWithValue("@p1", txtId.Text);
                command.ExecuteNonQuery(); // kpmutu çalıştır (Bu fonksiyon; select, insert, update 'de çalışır).
                sqlBaglantisi.Connection().Close();
                dataGridView1.Update();
            }
        }
    }
}
