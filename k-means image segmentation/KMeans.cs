using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace k_means_image_segmentation
{
    class KMeans
    {
        /// <summary>
        /// Segmentation himself!
        /// </summary>
        /// <param name="PicBox">PictureBox image</param>
        /// <param name="k">Just k</param>
        public Bitmap SegmentImage(Bitmap bitmap, int k)
        {
            var rand = new Random();
            var centroids = new Point[k];
            for (int i = 0; i < k; i++)
                centroids[i] = new Point(rand.Next(bitmap.Width), rand.Next(bitmap.Height));

            int[] distance = new int[k];
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++) 
                {
                    for (int i = 0; i < k; i++) 
                    {
                        var r = Math.Abs(bitmap.GetPixel(x, y).R - bitmap.GetPixel(centroids[i].X, centroids[i].Y).R);    // sub module RGB count
                        var g = Math.Abs(bitmap.GetPixel(x, y).G - bitmap.GetPixel(centroids[i].X, centroids[i].Y).G);
                        var b = Math.Abs(bitmap.GetPixel(x, y).B - bitmap.GetPixel(centroids[i].X, centroids[i].Y).B);

                        distance[i] = (int)(Math.Sqrt(r * r + g * g) + Math.Sqrt(g * g + b * b) + Math.Sqrt(r * r + b * b));    // Euclid count distance
                    }
                    var nearest = FindMinDistance(distance, k);     // find the nearest color
                    var clr = bitmap.GetPixel(centroids[nearest].X, centroids[nearest].Y);      // take centroid color
                    bitmap.SetPixel(x, y, clr);       // set pixel centroid color
                }
            }         
            return bitmap;
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
    }
}
