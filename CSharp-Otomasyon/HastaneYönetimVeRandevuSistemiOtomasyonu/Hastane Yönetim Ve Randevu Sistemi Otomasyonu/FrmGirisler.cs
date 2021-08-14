using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hastane_Yönetim_Ve_Randevu_Sistemi_Otomasyonu
{
    public partial class FrmGirisler : Form
    {
        public FrmGirisler()
        {
            InitializeComponent();
        }

        private void btnHastaGiris_Click(object sender, EventArgs e)
        {
            FrmHastaGiris frmHastaGiris = new FrmHastaGiris();

            frmHastaGiris.Show();
            this.Hide();
        }

        private void btnDoktorGiris_Click(object sender, EventArgs e)
        {
            FrmDoktorGiris frmDoktorGiris = new FrmDoktorGiris();
            frmDoktorGiris.Show();
            this.Hide();
        }

        private void btnSekreterGiris_Click(object sender, EventArgs e)
        {
            FrmSekreterGiris frmSekreterGiris = new FrmSekreterGiris();

            frmSekreterGiris.Show();
            this.Hide();
        }
    }
}
