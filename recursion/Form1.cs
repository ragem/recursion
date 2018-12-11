using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace recursion
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int depth = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            Graphics gr = this.CreateGraphics();
            Pen norm = new Pen(Color.Black);
            depth = int.Parse(textBox1.Text.ToString());
            Point[] p = new Point[4];
            p[0].X = 200;
            p[0].Y = 200;
            p[1].X = 400;
            p[1].Y = 200;
            p[2].X = 400;
            p[2].Y = 400;
            p[3].X = 200;
            p[3].Y = 400;
            draw(gr, norm, depth, p);

        }

        bool lastrect = true;
        private void draw(Graphics gr, Pen pen, int depth, Point[] p)
        {

            
            Point[] poly1 = new Point[4];

            if (lastrect)
            {
                poly1[0].X = p[0].X+ (p[1].X - p[0].X) / 2;
                poly1[0].Y = p[0].Y;

                poly1[1].X = p[1].X;
                poly1[1].Y = p[1].Y+(p[2].Y - p[1].Y) / 2;

                poly1[2].X = p[0].X + (p[2].X - p[3].X) / 2;
                poly1[2].Y = p[2].Y;

                poly1[3].X = p[3].X;
                poly1[3].Y = p[0].Y + (p[2].Y - p[1].Y) / 2;
                lastrect = false;

            }
                else
            {
               
                int x0 =  ((p[3].X - p[0].X) / 2);
                

                poly1[0].X = p[0].X + x0;
                poly1[0].Y = p[0].Y - x0;

                poly1[1].X=  poly1[0].X +(p[1].X - p[2].X);
                poly1[1].Y = poly1[0].Y;

                poly1[2].X = poly1[0].X + (p[1].X - p[2].X);
                poly1[2].Y = poly1[0].Y - (p[1].Y - p[2].Y);

                poly1[3].X = poly1[0].X;
                poly1[3].Y = poly1[0].Y - (p[1].Y - p[2].Y);
                lastrect = true;
            }

            gr.DrawPolygon(pen, p);

           
            if (depth > 1)
            {
                draw(gr,pen,depth-1,poly1);
                
            }
        }

    }
}
