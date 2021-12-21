using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Photo_Viewer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(string fileName) : this()
        {
            if (fileName == null)
                return;

            if (!File.Exists(fileName))
            {
                MessageBox.Show("Invalid file name.", "Cannot open image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            pictureBox1.Image = new Bitmap(Path.GetFullPath(fileName));
            this.Text = Path.GetFileName(fileName) + " - Photo Viewer";
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.gif)|*.jpg; *.jpeg; *.png; *.bmp; *.gif|All Files (*.*)|*.*", Title = "Select an image file to open" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image = new Bitmap(ofd.FileName);
                        this.Text = Path.GetFileName(ofd.FileName) + " - Photo Viewer";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Cannot open image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
