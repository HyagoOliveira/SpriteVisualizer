using System;
using System.IO;
using System.Windows.Forms;

namespace SpriteVisualizer
{
    public partial class SpriteVisualizerForm : Form
    {
        public SpriteVisualizerForm()
        {
            InitializeComponent();
        }

        public void Log(string message)
        {
            EnableLog(true);
            logLabel.Text = message;
        }

        public void SetProgress(int progress)
        {
            EnableProgressBar(true);
            progressBar.Value = progress;
        }

        private void EnableLog(bool enable)
        {
            logLabel.Enabled = enable;
        }

        private void EnableProgressBar(bool enable)
        {
            progressBar.Enabled = enable;
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;

            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    filePath = openFileDialog.FileName;
                    var fileStream = openFileDialog.OpenFile();

                    using (var reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }
                }
            }

            MessageBox.Show(fileContent, "File Content at path: " + filePath, MessageBoxButtons.OK);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
