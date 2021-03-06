﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace k_means_image_segmentation
{
    public partial class MainForm : Form
    {
        Graphics graph; 
        KMeans img = new KMeans();
        public int k;
        DateTime timer = new DateTime();

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
                using (OpenFileDialog dialog = new OpenFileDialog())
                {
                    dialog.Title = "Open image";
                    dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        PicBox.SizeMode = PictureBoxSizeMode.Zoom;
                        PicBox.Image = new Bitmap(dialog.FileName);
                        /*_bmp = new Bitmap(PicBox.Image, PicBox.Image.Width, PicBox.Image.Height);*/
                    }
                }
                TimerLabel.Text = "00:00:00";
                ClusteringStatusLabel.Text = "";
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

                using (SaveFileDialog dialog = new SaveFileDialog())
                {
                    dialog.Title = "Open image";
                    dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        PicBox.Image.Save(dialog.FileName);
                    }
                }
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
            graph.Clear(BackColor);
            PicBox.Image = null;
            TimerLabel.Text = "00:00:00";
            ClusteringStatusLabel.Text = "";
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

                ClusteringProgressBar.Value = 0;
                ClusteringProgressBar.Maximum = 100;
                ClusteringProgressBar.Style = ProgressBarStyle.Marquee;
                ClusteringStatusLabel.Text = "Clustering...";
                tm.Start();
                timer = new DateTime();

                bgw.RunWorkerAsync();
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
            catch (Exception ex)
            {
                MessageBox.Show("Unknown error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            PicBox.Image = img.SegmentImage(new Bitmap(PicBox.Image), k);
        }

        /// <summary>
        /// Then thread code ends
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ClusteringProgressBar.Style = ProgressBarStyle.Blocks;
            ClusteringStatusLabel.Text = "Complete!";
            tm.Stop();
        }

        /// <summary>
        /// Status bar time refresh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tm_Tick(object sender, EventArgs e)
        {
            timer = timer.AddSeconds(1);
            TimerLabel.Text = (timer.Hour >= 10 ? timer.Hour.ToString() : "0" + timer.Hour.ToString()) + ":" + (timer.Minute >= 10 ? timer.Minute.ToString() : "0" + timer.Minute.ToString()) + ":" + (timer.Second >= 10 ? timer.Second.ToString() : "0" + timer.Second.ToString());
        }

        /// <summary>
        /// Load Image
        /// </summary>
        public void Load()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Open image";
                dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PicBox.SizeMode = PictureBoxSizeMode.Zoom;
                    PicBox.Image = new Bitmap(dialog.FileName);
                    /*_bmp = new Bitmap(PicBox.Image, PicBox.Image.Width, PicBox.Image.Height);*/
                }
            }
            //_height = _bmp.Height;
            //_width = _bmp.Width;
        }

        /// <summary>
        /// Save Image
        /// </summary>
        public void Save(PictureBox PicBox)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Open image";
                dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //_bmp.Save(dialog.FileName);
                }
            }
        }
    }
}
