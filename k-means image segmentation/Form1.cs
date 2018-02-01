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
    public partial class MainForm : Form
    {
        Graphics graph;     // Инициализация графики для работы с изображением
        AdvancedImage img = new AdvancedImage();    // Изображение
        int k;      // Количество кластеров

        public MainForm()
        {
            InitializeComponent();
            graph = PicBox.CreateGraphics();
        }

        // Обзор. . .
        private void ImportButton_Click(object sender, EventArgs e)
        {
            try
            {
                img.LoadFile(ref PicBox);
            }
            catch
            {

            }
        }

        // Сохранить как. . .
        private void SaveFileButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (PicBox.Image == null) throw new NullReferenceException();
                img.SaveFile(ref PicBox);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Нет изображения для сохранения.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {

            }
        }

        // Очистить
        private void ClearButton_Click(object sender, EventArgs e)
        {
            img.ClearImage(ref graph, BackColor);
        }

        // Кластеризировать
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
                MessageBox.Show("Некорректный ввод значения k: k не является числом.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (OverflowException)
            {
                MessageBox.Show("Некорректный ввод значения k: k выходит за границы заданного диапазона (1-30)", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Для сегментации требуется изображение.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            {
                MessageBox.Show("Неизвестная ошибка.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
