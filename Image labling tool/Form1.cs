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
        bool moving = false;
        Pen pen;
        Image original;
        Image lastModified;
        List<Point> points = new List<Point>();
        readonly Color[] COLOR = { Color.Red, Color.Blue, Color.Green, Color.Yellow };
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
        }

        private void PanelMouseDown(object sender, MouseEventArgs e)
        {
            moving = true;
            mouseMove = e.Location;
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
                using (Graphics photo = Graphics.FromImage(bmp))
                {
                    photo.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    Brush aBrush = new SolidBrush(pen.Color);
                    photo.DrawLine(pen, mouseMove, e.Location);
                }
                mouseMove = e.Location;
                canvas.Image.Dispose();
                canvas.Image = new Bitmap(bmp);

            }
        }
        private void PanelMouseClick(object sender, MouseEventArgs e)
        {
            if (!dotMode.Checked|| canvas.Image==null)
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
            canvas.Image.Dispose();
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
            this.points.Clear();
            Bitmap bmp = new Bitmap(photoList.SelectedItem.ToString());
            ProcessImage(bmp,(img,color,i,j)=> 
            {
                if (CheckColor(color))
                {
                    img.SetPixel(i, j, Color.Black);
                }
            });
            this.original= new Bitmap(photoList.SelectedItem.ToString());
            Graphics photo = canvas.CreateGraphics();
            photo.DrawImage(bmp, new Point(0, 0));
            canvas.Image = bmp;
            this.lastModified = new Bitmap(bmp);
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
            canvas.Image.Dispose();
            canvas.Image = new Bitmap(bmp);
            this.points.Clear();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("I am too lazy not available yet.");
        }

        private void saveToFile_Click(object sender, EventArgs e)
        {
            ProcessImage((Bitmap)canvas.Image,(img, color, i, j)=> 
            {
                if (!CheckColor(color))
                {
                    img.SetPixel(i, j, Color.Black);
                }
            });
            string fullPath = photoList.SelectedItem.ToString();
            string outputpath = Path.GetDirectoryName(fullPath);
            string fileName = Path.GetFileName(fullPath);
            outputpath += @"\label";
            if (!Directory.Exists(outputpath)) 
            {
                Directory.CreateDirectory(outputpath);
            }
            canvas.Image.Save(outputpath+ @"\"+fileName);
            //clear resources
            original.Dispose();
            lastModified.Dispose();
            canvas.Image.Dispose();
            canvas.Image = null;
            original = null;
            lastModified = null;
            this.points.Clear();
        }

        private void ProcessImage(Bitmap img,Action<Bitmap,Color,int,int> callback) 
        {
            for (int i = 0; i < img.Width; i++) 
            {
                for (int j = 0; j < img.Height; j++) 
                {
                    Color c=img.GetPixel(i, j);
                    callback(img, c, i, j);
                }
            }
        }
       
        private bool CheckColor(Color c) 
        {
            foreach (var e in COLOR) 
            {
                if (c.R == e.R && c.G == e.G && c.B == e.B) 
                {
                    return true;
                }
            }
            return false;
        
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
