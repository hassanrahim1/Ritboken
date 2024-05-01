using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ritboken
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Width = 1000;
            this.Height = 800;
            bm = new Bitmap(bild.Width,bild.Height);
            g = Graphics.FromImage(bm);
            g.Clear(Color.White);
            bild.Image = bm;

        }


        private float penSize1 = 1;
        private float penSize2 = 10;
        private float currentPenSize = 1;


        Bitmap bm;
        Graphics g;
        bool paint = false;
        Point px, py;
        Pen p = new Pen(Color.Black,1);
        Pen sudda = new Pen(Color.White,10);
        int index;
        int x, y, sX, sY, cX, cY;

        ColorDialog cd = new ColorDialog();
        Color farg2;

        private void button7_Click(object sender, EventArgs e)
        {
            index = 4;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            index = 5;
        }

        private void bild_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            if(paint)
            {
                if (index == 3)
                {
                    g.DrawEllipse(p, cX, cY, sX, sY);
                }
                if (index == 4)
                {
                    g.DrawRectangle(p, cX, cY, sX, sY);
                }
                if (index == 5)
                {
                    g.DrawLine(p, cX, cY, x, y);
                }
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            g.Clear(Color.White);
            bild.Image = bm;
            index = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            farg2 = cd.Color;
            bild.BackColor = cd.Color;
            p.Color = cd.Color;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (currentPenSize == penSize1)
            {
                currentPenSize = penSize2;
            }
            else
            {
                currentPenSize = penSize1;
            }
            p.Width = currentPenSize;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            index = 3;
        }

        private void bild_MouseMove(object sender, MouseEventArgs e)
        {
            if(paint)
            {
                if(index==1)
                {
                    px = e.Location;
                    g.DrawLine(p,px,py);
                    py = px;

                }
                if (index == 2)
                {
                    px = e.Location;
                    g.DrawLine(sudda, px, py);
                    py = px;

                }
            }
            bild.Refresh();

            x = e.X;
            y = e.Y;
            sX = cX - cX;
            sY = e.Y - cY;
        }

        private void bild_MouseUp(object sender, MouseEventArgs e)
        {
            paint = false;

            sX = x - cX;
            sY = y - cY;

            if(index==3)
            {
                g.DrawEllipse(p, cX, cY, sX, sY);
            }
            if (index == 4)
            {
                g.DrawRectangle(p, cX, cY, sX, sY);
            }
            if (index == 5)
            {
                g.DrawLine(p, cX, cY, x, y);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            index = 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            index = 2;
        }

        private void bild_MouseDown(object sender, MouseEventArgs e)
        {
            paint = true;
            py = e.Location;
           
            cX = e.X;
            cY = e.Y;
        }
        
    
    }
}
