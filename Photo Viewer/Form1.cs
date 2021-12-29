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
            statusBar2.Text = "No image file open";
            pictureBox1.BackColor = Properties.Settings.Default.BackgroundColor;
            panel1.BackColor = Properties.Settings.Default.BackgroundColor;
            txtSlideDelay.Text = ((double)Properties.Settings.Default.SlideshowDelay / 1000).ToString();
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
            statusBarPanel2.Text = "Dimensions: " + pictureBox1.Image.Height + "x" + pictureBox1.Image.Width;
            statusBarPanel1.Text = "File Name: " + Path.GetFileName(fileName);
            statusBar2.Text = "";
            statusBar2.ShowPanels = true;
            toolStripButton2.Enabled = true;
            toolStripButton4.Enabled = true;
            toolStripButton5.Enabled = true;
            toolStripButton6.Enabled = true;
            menuItem13.Enabled = true;
            this.Text = Path.GetFileName(fileName) + " - Photo Viewer";
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.gif; *.wmf; *.ico)|*.jpg; *.jpeg; *.png; *.bmp; *.gif; *.wmf; *.ico|All Files (*.*)|*.*", InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        pictureBox1.Image = Image.FromFile(ofd.FileName);
                        this.Text = Path.GetFileName(ofd.FileName) + " - Photo Viewer";
                        statusBarPanel2.Text = "Dimensions: " + pictureBox1.Image.Height + "x" + pictureBox1.Image.Width;
                        statusBarPanel1.Text = "File Name: " + Path.GetFileName(ofd.FileName);
                        statusBar2.Text = "";
                        statusBar2.ShowPanels = true;
                        toolStripButton2.Enabled = true;
                        toolStripButton4.Enabled = true;
                        toolStripButton5.Enabled = true;
                        toolStripButton6.Enabled = true;
                        menuItem13.Enabled = true;
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

        private void menuItem13_Click(object sender, EventArgs e)
        {
            toolStripButton2.PerformClick();
        }

        private void menuItem14_Click(object sender, EventArgs e)
        {
            using (ColorDialog cd = new ColorDialog() { Color = Properties.Settings.Default.BackgroundColor })
            {
                if (cd.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.BackgroundColor = cd.Color;
                    Properties.Settings.Default.Save();
                    pictureBox1.BackColor = Properties.Settings.Default.BackgroundColor;
                    panel1.BackColor = Properties.Settings.Default.BackgroundColor;
                }
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            InfoForm infoForm = new InfoForm();
            infoForm.label1.Text = infoForm.label1.Text + this.Text.Replace(" - Photo Viewer", "");
            infoForm.label2.Text = infoForm.label2.Text + statusBarPanel2.Text.Replace("Dimensions: ", "");
            infoForm.ShowDialog();
        }

        private async void toolStripButton7_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files (*.jpg; *.jpeg; *.png; *.bmp; *.gif; *.wmf; *.ico)|*.jpg; *.jpeg; *.png; *.bmp; *.gif; *.wmf; *.ico|All Files (*.*)|*.*", InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), Multiselect = true, Title = "Select images for the slideshow" })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    foreach (string file in ofd.FileNames)
                    {
                        try
                        {
                            pictureBox1.Image = Image.FromFile(file);
                            this.Text = Path.GetFileName(file) + " - Photo Viewer";
                            statusBarPanel2.Text = "Dimensions: " + pictureBox1.Image.Height + "x" + pictureBox1.Image.Width;
                            statusBarPanel1.Text = "File Name: " + Path.GetFileName(file);
                            statusBar2.Text = "";
                            statusBar2.ShowPanels = true;
                            toolStripButton2.Enabled = true;
                            toolStripButton4.Enabled = true;
                            toolStripButton5.Enabled = true;
                            toolStripButton6.Enabled = true;
                            menuItem13.Enabled = true;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Cannot open image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        await Task.Delay(Properties.Settings.Default.SlideshowDelay);
                    }
                }
            }
        }

        private void txtSlideDelay_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                float secSlideDelay = float.Parse(txtSlideDelay.Text);
                int slideDelay = (int)(secSlideDelay * 1000);
                Properties.Settings.Default.SlideshowDelay = slideDelay;
                Properties.Settings.Default.Save();
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = (int)(pictureBox1.Top - (pictureBox1.Height * 0.025));
            pictureBox1.Left = (int)(pictureBox1.Left - (pictureBox1.Width * 0.025));
            pictureBox1.Height = (int)(pictureBox1.Height + (pictureBox1.Height * 0.05));
            pictureBox1.Width = (int)(pictureBox1.Width + (pictureBox1.Width * 0.05));
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            pictureBox1.Top = (int)(pictureBox1.Top + (pictureBox1.Height * 0.025));
            pictureBox1.Left = (int)(pictureBox1.Left + (pictureBox1.Width * 0.025));
            pictureBox1.Height = (int)(pictureBox1.Height - (pictureBox1.Height * 0.05));
            pictureBox1.Width = (int)(pictureBox1.Width - (pictureBox1.Width * 0.05));
        }

        private void menuItem15_Click(object sender, EventArgs e)
        {
            toolStripButton7.PerformClick();
        }
    }
}
