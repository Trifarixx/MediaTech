using MySqlX.XDevAPI;
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
        private MediaTechRepository repo;
     

        public ProfilForm()
        {
            InitializeComponent();
            repo = new MediaTechRepository();
           


        }

        private void ProfilForm_Load(object sender, EventArgs e)
        {
            // Charger les informations du membre
                 

        }

        private void btnMonProfil(object sender, EventArgs e)
        {

        }

        private void MonHistorique_Click(object sender, EventArgs e)
        {
            HistoriqueForm historique = new HistoriqueForm();
            historique.Show();
        }

        private void favoris_Click(object sender, EventArgs e)
        {
            FavorisForm favoris = new FavorisForm();
            favoris.Show();
        }

   

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        
    }



}
