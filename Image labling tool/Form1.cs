using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        Point mouseMove = Point.Empty;
        Point mouseDown = Point.Empty;
        bool moving = false;
        Pen pen;
        Image original;
        Image lastModified;
        List<Point> points = new List<Point>();
        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black, 5);
            pen.StartCap = pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.Color = Color.Red;
        }

        private void ColorClick(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            pen.Color = box.BackColor;
            canvas.Cursor = Cursors.Cross;
            Preprocess((Bitmap)canvas.Image, pen.Color);
        }

        private void PanelMouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            mouseDown = e.Location;
        }

        private void PanelMouseMove(object sender, MouseEventArgs e)
        {
            if (moving) 
            {
                if (!lineMode.Checked) 
                {
                    return;
                }
                Image bmp = lastModified;
                mouseMove = e.Location;
                using (Graphics photo = Graphics.FromImage(bmp))
                {
                    photo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Brush aBrush = new SolidBrush(pen.Color);
                    photo.DrawLine(pen, mouseDown, mouseMove);
                }
                canvas.Image = new Bitmap(bmp);

            }
        }
        private void PanelMouseClick(object sender, MouseEventArgs e)
        {
            if (!dotMode.Checked)
            {
                return;
            }
            Image bmp = new Bitmap(canvas.Image);
            using (Graphics photo = Graphics.FromImage(bmp))
            {
                photo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                Brush aBrush = new SolidBrush(pen.Color);
                photo.FillRectangle(aBrush, e.X, e.Y, 3, 3);
                points.Add(e.Location);
            }
            canvas.Image = bmp;
        }

        private void PanelMouseUp(object sender, MouseEventArgs e)
        {
            moving = false;
            canvas.Cursor = Cursors.Default;
            canvas.Invalidate();
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
            Bitmap bmp = new Bitmap(photoList.SelectedItem.ToString());
            this.original= new Bitmap(photoList.SelectedItem.ToString());
            Graphics photo = canvas.CreateGraphics();
            photo.DrawImage(bmp, new Point(0, 0));
            canvas.Image = bmp;
            this.lastModified = bmp;
        }

        private void fillButton_Click(object sender, EventArgs e)
        {
            Image bmp = lastModified;
            if (bmp == null) 
            {
                return;
            }
            using (Graphics photo = Graphics.FromImage(bmp))
            {
                photo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                Brush aBrush = new SolidBrush(pen.Color);
                photo.FillPolygon(aBrush, points.ToArray());
            }
            canvas.Image = new Bitmap(bmp);
            this.points.Clear();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I am too lazy not available yet.");
        }

        private void saveToFile_Click(object sender, EventArgs e)
        {
            Postprocess((Bitmap)canvas.Image, pen.Color);
            string outputpath = photoList.SelectedItem.ToString();
            string ext = Path.GetExtension(outputpath);
            canvas.Image.Save(outputpath.Replace( ext, "_label_"+ ext));
            original.Dispose();
            lastModified.Dispose();
            canvas.Image.Dispose();
            canvas.Image = null;
            original = null;
            lastModified = null;
        }

        private void Preprocess(Bitmap img, Color selected) 
        {
            for (int i = 0; i < img.Width; i++) 
            {
                for (int j = 0; j < img.Height; j++) 
                {
                    Color c=img.GetPixel(i, j);
                    if (c.R == selected.R && c.G == selected.G && c.B == selected.B) 
                    {
                        img.SetPixel(i, j, Color.White);
                    }
                }
            }
        }
        private void Postprocess(Bitmap img, Color selected)
        {
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    Color c = img.GetPixel(i, j);
                    
                    if (!(c.R==selected.R&&c.G==selected.G&&c.B==selected.B))
                    {
                        img.SetPixel(i, j, Color.Black);
                    }
                }
            }
        }

        private void dotMode_CheckedChanged(object sender, EventArgs e)
        {
            if (dotMode.Checked)
            {
                lineMode.Checked = false;
            }
            else 
            {
                lineMode.Checked = true;
            }
            if (lineMode.Checked)
            {
                dotMode.Checked = false;
            }
            else
            {
                dotMode.Checked = true;
            }

        }

        private void lineMode_CheckedChanged(object sender, EventArgs e)
        {
            if (dotMode.Checked)
            {
                lineMode.Checked = false;
            }
            else
            {
                lineMode.Checked = true;
            }
            if (lineMode.Checked)
            {
                dotMode.Checked = false;
            }
            else
            {
                dotMode.Checked = true;
            }
        }
    }
}
