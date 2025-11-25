using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace WinFormsmedia_tech
{
    public partial class InscriptionForm : Form
    {
        public InscriptionForm()
        {
            InitializeComponent();
        }

        private void InscriptionForm_Load(object sender, EventArgs e)
        {

        }

        private void linkLabelConnexion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ConnexionForm Connexion = new ConnexionForm();
            Connexion.Show();
            this.Hide();
        }
    }
}
