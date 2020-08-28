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
