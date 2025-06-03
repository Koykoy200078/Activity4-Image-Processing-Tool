using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Imaging.Filters;

namespace ImageProcessingApp
{
    public partial class Form1 : Form
    {
        private Bitmap loadedImage;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                loadedImage = new Bitmap(ofd.FileName);
                pictureBox.Image = loadedImage;
            }
        }

        private void btnGrayscale_Click(object sender, EventArgs e)
        {
            if (loadedImage == null) return;
            Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            pictureBox.Image = grayFilter.Apply(loadedImage);
        }

        private void btnInvert_Click(object sender, EventArgs e)
        {
            if (loadedImage == null) return;
            Invert invertFilter = new Invert();
            pictureBox.Image = invertFilter.Apply(loadedImage);
        }

        private void btnBlur_Click(object sender, EventArgs e)
        {
            if (loadedImage == null) return;
            GaussianBlur blurFilter = new GaussianBlur(4, 11);
            pictureBox.Image = blurFilter.Apply(loadedImage);
        }
    }
}
