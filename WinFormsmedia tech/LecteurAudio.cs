using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace WinFormsmedia_tech
{
    public partial class LecteurAudio : Form
    {
        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;

        public LecteurAudio()
        {
            InitializeComponent();
            InitializeAudio();
        }

        private void InitializeAudio()
        {
            var flowPanel = new FlowLayoutPanel();
            flowPanel.FlowDirection = FlowDirection.LeftToRight;
            flowPanel.Margin = new Padding(10);

            var buttonPlay = new Button();
            buttonPlay.Text = "Play";
            buttonPlay.Click += BtnPlay_Click;
            flowPanel.Controls.Add(buttonPlay);

            var buttonStop = new Button();
            buttonStop.Text = "Stop";
            buttonStop.Click += BtnStop_Click;
            flowPanel.Controls.Add(buttonStop);

            this.Controls.Add(FondPanel);

            this.FormClosing += BtnStop_Click;
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
           //     outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(@"D:\example.mp3");
                outputDevice.Init(audioFile);
            }
            outputDevice.Play();
        }

        private void BtnStop_Click(object sender, EventArgs e)
        {

        }
    }
}