using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Image_labling_tool
{
    public partial class Form1 : Form
    {
        Graphics photo;
        int x = -1;
        int y = -1;
        bool moving = false;
        Pen pen;
        public Form1()
        {
            InitializeComponent();
            photo = canvas.CreateGraphics();
            pen = new Pen(Color.Black, 5);
            photo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;

        }

        private void ColorClick(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            pen.Color = box.BackColor;
            canvas.Cursor = Cursors.Cross;
        }

        private void PanelMouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            x = e.X;
            y = e.Y;
        }

        private void PanelMouseMove(object sender, MouseEventArgs e)
        {
            if (moving && x != -1 && y != -1) 
            {
                photo.DrawLine(pen, x, y, e.X, e.Y);
                x = e.X;
                y = e.Y;
            }
        }

        private void PanelMouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            x = -1;
            y = -1;
            canvas.Cursor = Cursors.Default;
        }

        private void LoadDirectory(object sender, EventArgs e)
        {
            photoList.SizeChanged += (_sender, args) =>
            {
                if (photoList.Items.Count == 0) 
                {
                    return;
                }
                var CurrentItemWidth = (int)this.CreateGraphics().MeasureString(photoList.Items[photoList.Items.Count - 1].ToString(), photoList.Font, TextRenderer.MeasureText(photoList.Items[photoList.Items.Count - 1].ToString(), new Font("Arial", 12.0F))).Width;
                if (CurrentItemWidth > photoList.Width)
                    photoList.Width = CurrentItemWidth;
            };
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    string[] files = Directory.GetFiles(fbd.SelectedPath);
                    files.ToList().ForEach(f => photoList.Items.Add(f));
                }
            }
        }

        private void LoadPhoto(object sender, EventArgs e)
        {
            MessageBox.Show(photoList.SelectedItem.ToString());
            Image img = Image.FromFile(photoList.SelectedItem.ToString());
            this.MaximumSize = new Size(img.Width, img.Height);
            this.Size = new Size(img.Width, img.Height);
            panel1.MaximumSize = new Size(img.Width, img.Height);
            panel1.Size = new Size(img.Width, img.Height);
            canvas.MaximumSize = new Size(img.Width, img.Height);
            canvas.Size = new Size(img.Width, img.Height);
            photo = canvas.CreateGraphics();
            this.photo.DrawImage(img, 0, 0);
        }
    }
}
