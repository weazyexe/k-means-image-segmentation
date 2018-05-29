using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace k_means_image_segmentation
{
    public interface IEditImages
    {
        void Save(PictureBox PicBox);
        void Load(PictureBox PicBox);
        void Clear(Graphics graph, Color BackColor);
        Bitmap GetEditedImage(PictureBox PicBox);
    }
}
