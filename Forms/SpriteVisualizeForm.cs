using System;
using System.Drawing;
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
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files(*.PNG;*.JPG)|*.PNG;*.JPG|txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var filePath = openFileDialog.FileName;
                    OpenSpriteFile(filePath);

                    /*var fileStream = openFileDialog.OpenFile();
                    using (var reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                    }*/
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenSpriteFile(string path)
        {
            var name = Path.GetFileNameWithoutExtension(path);
            var image = new Bitmap(path);
            var viewport = CreateViweport(name, image);
            var tab = new TabPage(name)
            {
                Padding = new Padding(10)
            };

            tab.Controls.Add(viewport);
            tabControl.TabPages.Add(tab);
        }

        private Panel CreateViweport(string name, Image image)
        {
            var panel = new Panel()
            {
                Dock = DockStyle.Fill,
                AutoScroll = true
            };
            var pictureBox = new PictureBox()
            {
                BorderStyle = BorderStyle.FixedSingle,
                BackgroundImageLayout = ImageLayout.Center,
                Location = new Point(3, 3),
                Name = name,
                Size = new Size(576, 372),
                TabIndex = 0,
                TabStop = false,
                Image = image,
                SizeMode = PictureBoxSizeMode.AutoSize
            };

            panel.Controls.Add(pictureBox);
            return panel;
        }
    }
}
