using System;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Drawing;

namespace Animation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IAnimationManager _manager;

        private void Form1_Load(object sender, EventArgs e)
        {
            //in a real app will be injected
            _manager = new AnimationManager(numberOfParticles: 2, numberOfIterations: 20, roomWidth: ClientSize.Width, roomHeight: ClientSize.Height);            

            // Use double buffering to reduce flicker.
            SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer,
                true);
            UpdateStyles();
        }

        private void AnimationTimerTick(object sender, EventArgs e)
        {
            if (!_manager.AnimationEnded())
            {
                //move particles
                _manager.MoveParticles();
                Refresh();
            }
            else
            {
                _animationTimer.Stop();
            }
        }        

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(BackColor);
            _manager.DrawOn(e.Graphics);
        }

        private void OptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var options = new Options();

            _animationTimer.Stop();
            if(options.ShowDialog() == DialogResult.OK)
            {
                var configuration = options.GetConfiguration();
                _manager = new AnimationManager2(configuration);

                ClientSize = new Size(configuration.RoomWidthMeters * AnimationManager.Scale, configuration.RoomHeightMeters * AnimationManager.Scale);
                _animationTimer.Interval = configuration.FramesIntervalInMiliseconds;
            }
            _animationTimer.Start();
        }
    }
}
