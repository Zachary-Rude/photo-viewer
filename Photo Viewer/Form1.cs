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
using System.Drawing.Printing;

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

            pictureBox1.Image = Image.FromFile(Path.GetFullPath(fileName));
            this.Text = Path.GetFileName(fileName) + " - Photo Viewer";
            statusBar2.Text = "Image Size: " + pictureBox1.Image.Height + "x" + pictureBox1.Image.Width;
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.gif; *.wmf)|*.jpg; *.jpeg; *.png; *.bmp; *.gif; *.wmf|All Files (*.*)|*.*", Title = "Select an image file to open", InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                        this.Text = Path.GetFileName(ofd.FileName) + " - Photo Viewer";
                        statusBar2.Text = "Image Size: " + pictureBox1.Image.Height + "x" + pictureBox1.Image.Width;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Cannot open image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem6_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
        }

        private void menuItem7_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void menuItem8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void menuItem10_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            menuItem2.PerformClick();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Show print dialog
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += Doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
                doc.Print();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            //Print image
            Bitmap bm = new Bitmap(pictureBox1.Image.Width, pictureBox1.Image.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Image.Width, pictureBox1.Image.Height));
            e.Graphics.DrawImage(bm, 0, 0);
            bm.Dispose();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            menuItem10.PerformClick();
        }
    }
}
