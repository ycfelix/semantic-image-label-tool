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
        public Form1()
        {
            InitializeComponent();
            photo = panel1.CreateGraphics();
        }

        private void ColorClick(object sender, EventArgs e)
        {
            PictureBox box = (PictureBox)sender;
            box.
        }
    }
}
