using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace k_means_image_segmentation
{
    // useless code
    class Blur : IEditImages
    {
        private Bitmap _bmp;        // image
        private int _height, _width;    // image width & height

        public void Clear(Graphics graph, Color BackColor)
        {
            graph.Clear(BackColor);
            _bmp = null;
        }

        public Bitmap GetEditedImage(PictureBox PicBox)
        {
            // just for lab.
            return new Bitmap(PicBox.Image);
        }

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
    }
}
