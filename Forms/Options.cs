
using System.Windows.Forms;

namespace Animation
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
        }

        private Configuration _configuration;

        private void _cancelButton_Click(object sender, System.EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void _okButton_Click(object sender, System.EventArgs e)
        {
            _configuration = new Configuration {
                                    FramesIntervalInMiliseconds = (int)_framesInterval.Value,
                                    NumberOfParticles = (int)_numberOfParticles.Value,
                                    RoomHeightMeters = _roomHeight.Value,
                                    RoomWidthMeters = _roomWidth.Value
                            };

            DialogResult = DialogResult.OK;
            Close();

        }

        public Configuration GetConfiguration()
        {
            return _configuration;
        }
    }
}
