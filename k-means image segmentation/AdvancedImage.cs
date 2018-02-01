using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_means_image_segmentation
{
    class AdvancedImage
    {
        private Bitmap _bmp;        // Изображение
        private int _height, _width;    // _height - высота изображения, _width - ширина изображения
        private Random _rand = new Random();
        private Point[] _centroids;         // Массив координат центроидов

        public AdvancedImage()
        {

        }

        /// <summary>
        /// Загрузка изображения
        /// </summary>
        public void LoadFile(ref PictureBox PicBox)
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
        /// Сохранение изображения
        /// </summary>
        public void SaveFile(ref PictureBox PicBox)
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
        /// Очистка пикчербокса и удаление изображения
        /// </summary>
        public void ClearImage(ref Graphics graph, Color BackColor)
        {
            graph.Clear(BackColor);
            _bmp = null;
        }

        /// <summary>
        /// Поиск минимального расстояния
        /// </summary>
        /// <param name="distance">Массив расстояний от пикселя до центроидов</param>
        /// <param name="k">Количество цветов (кластеров)</param>
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
        /// Сегментация изображения на основе алгоритма k-means
        /// </summary>
        /// <param name="PicBox">Изображение</param>
        /// <param name="k">Количество цветов (кластеров)</param>
        public Bitmap ImageSegmentation(ref PictureBox PicBox, int k)
        {
            _centroids = new Point[k];
            for (int i = 0; i < k; i++)
                _centroids[i] = new Point(_rand.Next(_width), _rand.Next(_height));

            int[] distance = new int[k];
            for (int y = 0; y < _height; y++)
            {
                for (int x = 0; x < _width; x++)
                {
                    for (int i = 0; i < k; i++)
                    {
                        int r = Math.Abs(_bmp.GetPixel(x, y).R - _bmp.GetPixel(_centroids[i].X, _centroids[i].Y).R);    // Расчёт модулей разности RGB-каналов
                        int g = Math.Abs(_bmp.GetPixel(x, y).G - _bmp.GetPixel(_centroids[i].X, _centroids[i].Y).G);
                        int b = Math.Abs(_bmp.GetPixel(x, y).B - _bmp.GetPixel(_centroids[i].X, _centroids[i].Y).B);

                        distance[i] = (int)(Math.Sqrt(r * r + g * g) + Math.Sqrt(g * g + b * b) + Math.Sqrt(r * r + b * b));    // Расчёт дистанции по Евклиду
                    }

                    int nearest = FindMinDistance(distance, k);     // Поиск ближайшего цвета
                    Color clr = _bmp.GetPixel(_centroids[nearest].X, _centroids[nearest].Y);      // Взятие цвета центроида
                    _bmp.SetPixel(x, y, clr);       // Замена цвета пикселя
                }
            }
            return _bmp;
        }
    }
}
