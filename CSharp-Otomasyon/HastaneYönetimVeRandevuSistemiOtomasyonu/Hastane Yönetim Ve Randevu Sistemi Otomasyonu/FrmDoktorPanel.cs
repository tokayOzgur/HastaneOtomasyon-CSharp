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

        }
    }
}
