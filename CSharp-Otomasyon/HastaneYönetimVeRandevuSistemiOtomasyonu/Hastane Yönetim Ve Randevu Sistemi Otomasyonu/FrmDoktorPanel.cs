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
    public partial class FrmDoktorPanel : Form
    {
        public FrmDoktorPanel()
        {
            InitializeComponent();
        }
        SqlBaglantisi sqlBaglantisi = new SqlBaglantisi();

        private void FrmDoktorPanel_Load(object sender, EventArgs e)
        {
            // doktorları datagride aktarma
            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select * from Doktor", sqlBaglantisi.Connection());
            da2.Fill(dt2);
            dataGridView1.DataSource = dt2;

            //// branşları aktarma
            //DataTable dt1 = new DataTable();
            //SqlDataAdapter da = new SqlDataAdapter("select * from Branslar", sqlBaglantisi.Connection());
            //da.Fill(dt1);
            //dataGridView1.DataSource = dt1;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("insert into Doktor (DoktorAd,DoktorSoyad,DoktorBrans,DoktorTC,DoktorSifre) values (@p1,@p2,@p3,@p4,@p5)", sqlBaglantisi.Connection());
            command.Parameters.AddWithValue("@p1", txtIsim.Text);
            command.Parameters.AddWithValue("@p2", txtSoyisim.Text);
            command.Parameters.AddWithValue("@p3", cmbBrans.Text);
            command.Parameters.AddWithValue("@p4", mskTc.Text);
            command.Parameters.AddWithValue("@p5", txtSifre.Text);

            command.ExecuteNonQuery();
            sqlBaglantisi.Connection().Close();
            MessageBox.Show("Yeni Doktor Kaydı oluşturuldu.");
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            txtIsim.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtSoyisim.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            cmbBrans.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            mskTc.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            txtSifre.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("Kaydı silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("delete from Doktor where DoktorTC = @p1", sqlBaglantisi.Connection());
                command.Parameters.AddWithValue("@p1", mskTc.Text);
                command.ExecuteNonQuery();
                sqlBaglantisi.Connection().Close();
            }
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kaydı güncellemek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                SqlCommand command = new SqlCommand("update Doktorlar set DoktorAd=@p1,DoktorSoyad=@p2,DoktorBrans=@p3,DoktorSifre=@p5 where DoktorTC=@p4", sqlBaglantisi.Connection());
                command.Parameters.AddWithValue("@p1", txtIsim.Text);
                command.Parameters.AddWithValue("@p2", txtSoyisim.Text);
                command.Parameters.AddWithValue("@p3", cmbBrans.Text);
                command.Parameters.AddWithValue("@p4", mskTc.Text);
                command.Parameters.AddWithValue("@p5", txtSifre.Text);
                command.ExecuteNonQuery();
            }
        }

        private void btnGoBack_Click(object sender, EventArgs e)
        {
            FrmSekreterDetay frmSekreterDetay = new FrmSekreterDetay();
            frmSekreterDetay.Show();
            this.Hide();
        }
    }
}
