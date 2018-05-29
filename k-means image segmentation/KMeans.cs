using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace k_means_image_segmentation
{
    class KMeans : IEditImages
    {
        private Bitmap _bmp;        // image
        private int _height, _width;    // image width & height
        private Random _rand = new Random();
        private Point[] _centroids;         // centroids array

        public KMeans()
        {

        }

        /// <summary>
        /// Load Image
        /// </summary>
        public void Load(PictureBox PicBox)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "Open image";
                dialog.Filter = "Image Files (*.bmp;*.jpg;*.jpeg,*.png)|*.BMP;*.JPG;*.JPEG;*.PNG";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    PicBox.SizeMode = PictureBoxSizeMode.Zoom;
                    PicBox.Image = new Bitmap(dialog.FileName);
                    _bmp = new Bitmap(PicBox.Image, PicBox.Image.Width, PicBox.Image.Height);
                }
            }
            _height = _bmp.Height;
            _width = _bmp.Width;
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
                    _bmp.Save(dialog.FileName);
                }
            }
        }

        /// <summary>
        /// PictureBox clear
        /// </summary>
        public void Clear(Graphics graph, Color BackColor)
        {
            graph.Clear(BackColor);
            _bmp = null;
        }

        /// <summary>
        /// Finding min distance to centroid
        /// </summary>
        /// <param name="distance">Distances array</param>
        /// <param name="k">Just k</param>
        /// <returns></returns>
        private int FindMinDistance(int[] distance, int k)
        {
            int min = distance[0];
            int minIndex = 0;
            for (int i = 0; i < k; i++)
                if (distance[i] < min)
                {
                    min = distance[i];
                    minIndex = i;
                }
            return minIndex;
        }

        /// <summary>
        /// Segmentation himself!
        /// </summary>
        /// <param name="PicBox">PictureBox image</param>
        /// <param name="k">Just k</param>
        public Bitmap GetEditedImage(PictureBox PicBox)
        {
            _centroids = new Point[MainForm.k];
            for (int i = 0; i < MainForm.k; i++)
                _centroids[i] = new Point(_rand.Next(_width), _rand.Next(_height));

            int[] distance = new int[MainForm.k];
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++) 
                {
                    for (int i = 0; i < MainForm.k; i++) 
                    {
                        int r = Math.Abs(_bmp.GetPixel(x, y).R - _bmp.GetPixel(_centroids[i].X, _centroids[i].Y).R);    // sub module RGB count
                        int g = Math.Abs(_bmp.GetPixel(x, y).G - _bmp.GetPixel(_centroids[i].X, _centroids[i].Y).G);
                        int b = Math.Abs(_bmp.GetPixel(x, y).B - _bmp.GetPixel(_centroids[i].X, _centroids[i].Y).B);

                        distance[i] = (int)(Math.Sqrt(r * r + g * g) + Math.Sqrt(g * g + b * b) + Math.Sqrt(r * r + b * b));    // Euclid count distance
                    }
                    int nearest = FindMinDistance(distance, MainForm.k);     // find the nearest color
                    Color clr = _bmp.GetPixel(_centroids[nearest].X, _centroids[nearest].Y);      // take centroid color
                    _bmp.SetPixel(x, y, clr);       // set pixel centroid color
                }
            }         
            return _bmp;
        }
    }
}
