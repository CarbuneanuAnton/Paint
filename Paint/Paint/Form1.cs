using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Bitmap pic;
        Pen p;
        Graphics g;

        int x1, y1;
        public Form1()
        {
            InitializeComponent();
            pic = new Bitmap(1000,1000);
            x1 = y1 = 0;

            p = new Pen(Color.Black, trackBar1.Value);
            p.StartCap = p.EndCap = System.Drawing.Drawing2D.LineCap.Round;

            g = Graphics.FromImage(pic);
        }


        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "JPEG (*.jpg)|*.jpg";
            saveFileDialog1.ShowDialog();
            if(saveFileDialog1.FileName!="")
                pic.Save(saveFileDialog1.FileName);
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG (*.jpg)|*.jpg";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName !="")
            {
                pic = (Bitmap)Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = pic;
            }
        }

        private void buttonColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            Color color = colorDialog1.Color;
            p.Color = color;
            buttonColor.BackColor = color;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            p.Width = trackBar1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.Color = Color.White;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g.DrawLine(p, x1, y1, e.X, e.Y);
                pictureBox1.Image = pic;
            }
            x1=e.X;
            y1=e.Y;       
        }
    }
}
