using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

    }
}
