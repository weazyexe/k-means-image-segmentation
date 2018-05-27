using System;
using System.Drawing;
using System.Windows.Forms;

namespace k_means_image_segmentation
{
    public partial class MainForm : Form
    {
        Graphics graph; 
        AdvancedImage img = new AdvancedImage();
        int k; 

        public MainForm()
        {
            InitializeComponent();
            graph = PicBox.CreateGraphics();
        }

        /// <summary>
        /// Load button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                img.LoadFile(ref PicBox);
            }
            catch
            {
                MessageBox.Show("Load file error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Save as click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PicBox.Image == null) throw new NullReferenceException();
                img.SaveFile(ref PicBox);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Where an image? Load it.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {

            }
        }

        /// <summary>
        /// Clear button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearButton_Click(object sender, EventArgs e)
        {
            img.ClearImage(ref graph, BackColor);
        }

        /// <summary>
        /// Cluster button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClusterButton_Click(object sender, EventArgs e)
        {
            try
            {
                k = int.Parse(KTextBox.Text);
                if (k <= 0 || k > 30) throw new OverflowException();
                if (PicBox.Image == null) throw new NullReferenceException();
                PicBox.Image = img.ImageSegmentation(ref PicBox, k);
            }
            catch (FormatException)
            {
                MessageBox.Show("Uncorrect k: k is NaN.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Uncorrect k: k is out of range (1-30).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("For segmentation you need an image.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Unknown error.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
