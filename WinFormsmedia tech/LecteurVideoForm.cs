using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LibVLCSharp.Shared;

namespace WinFormsmedia_tech
{
    public partial class LecteurVideoForm : Form
    {
        private LibVLC _libVLC;
        private MediaPlayer _mediaPlayer;
        public LecteurVideoForm()
        {
            InitializeComponent();

            _libVLC = new LibVLC();
            _mediaPlayer = new MediaPlayer(_libVLC);

            videoView1.MediaPlayer = _mediaPlayer;

            this.FormClosed += LecteurVideoForm_FormClosed;
        }

        public void LoadMedia(string mediaPath)
        {
            // Créer un nouvel objet Média
            using (var media = new Media(_libVLC, new Uri(mediaPath)))
            {
                // Démarrer la lecture
                _mediaPlayer.Play(media);
            }
        }

        private void btn_play_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Play();
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Pause();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            _mediaPlayer.Stop();
        }

        private void LecteurVideoForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Arrêter la lecture
            _mediaPlayer.Stop();

            // Libérer le lecteur (MediaPlayer)
            _mediaPlayer.Dispose();

            // Libérer l'instance principale de LibVLC
            _libVLC.Dispose();
        }

    }

}

