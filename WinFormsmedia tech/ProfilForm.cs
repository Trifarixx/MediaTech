using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsmedia_tech
{
    public partial class ProfilForm : Form
    {
        public ProfilForm()
        {
            InitializeComponent();

        }

        private void ProfilForm_Load(object sender, EventArgs e)
        {

        }

        private void btnMonProfil(object sender, EventArgs e)
        {

        }

        private void MonHistorique_Click(object sender, EventArgs e)
        {
            HistoriqueForm historique = new HistoriqueForm();
            historique.Show();
        }

        private void Favoris_Click(object sender, EventArgs e)
        {
            FavorisForm favoris = new FavorisForm();
            favoris.Show();
        }

        private void Param_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
