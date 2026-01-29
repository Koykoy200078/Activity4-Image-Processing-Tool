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
        private Bitmap originalImage;
        private Bitmap processedImage;

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
                originalImage = new Bitmap(ofd.FileName);
                pictureBoxOriginal.Image = originalImage;
                pictureBoxProcessed.Image = null;
                processedImage = null;
            }
        }

        private async void btnGrayscale_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            
            this.Cursor = Cursors.WaitCursor;
            btnGrayscale.Enabled = false;
            
            try
            {
                processedImage = await Task.Run(() =>
                {
                    Grayscale grayFilter = new Grayscale(0.2125, 0.7154, 0.0721);
                    return grayFilter.Apply(originalImage);
                });
                
                pictureBoxProcessed.Image = processedImage;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnGrayscale.Enabled = true;
            }
        }

        private async void btnInvert_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            
            this.Cursor = Cursors.WaitCursor;
            btnInvert.Enabled = false;
            
            try
            {
                processedImage = await Task.Run(() =>
                {
                    Invert invertFilter = new Invert();
                    return invertFilter.Apply(originalImage);
                });
                
                pictureBoxProcessed.Image = processedImage;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnInvert.Enabled = true;
            }
        }

        private async void btnBlur_Click(object sender, EventArgs e)
        {
            if (originalImage == null) return;
            
            this.Cursor = Cursors.WaitCursor;
            btnBlur.Enabled = false;
            
            try
            {
                processedImage = await Task.Run(() =>
                {
                    GaussianBlur blurFilter = new GaussianBlur(4, 11);
                    return blurFilter.Apply(originalImage);
                });
                
                pictureBoxProcessed.Image = processedImage;
            }
            finally
            {
                this.Cursor = Cursors.Default;
                btnBlur.Enabled = true;
            }
        }
    }
}
