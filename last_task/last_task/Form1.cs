using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace last_task
{
    public partial class Form1 : Form
    {
        Bitmap off;
        float angball = 0;
        int flagd = 0;
        int flagr = 0;
        PolarCircle mycirc = new PolarCircle(0, 0, 100);
        PointF ball = new PointF(0, 0);


        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            this.Load += Form1_Load;
            this.Paint += Form1_Paint;
            Timer t = new Timer();
            t.Start();
            t.Tick += T_Tick;

        }

        private void T_Tick(object sender, EventArgs e)
        {
            ball = mycirc.getnextpoint(angball);

            if (flagd == 0)
            {
                angball += 3;
                if (angball >= 90)
                {
                    flagd = 1;
                }

            }
            if (flagd == 1)
            {
                angball += 3;
                if (angball >= 180)
                {
                    flagd = 2;
                }

            }
            if (flagd == 2)
            {
                angball += 3;
                if (angball >= 270)
                {
                    flagd = 3;
                }

            }
            if (flagd == 3)
            {
                angball += 3;
                if (angball >= 360)
                {
                    flagd = 4;
                }

            }

            if (flagd == 4)
            {
                angball -= 3;
                if (angball <= 270)
                {
                    flagd = 5;
                }
            }
            if (flagd == 5)
            {
                angball -= 3;
                if (angball <= 180)
                {
                    flagd = 6;
                }
            }
            if (flagd == 6)
            {
                angball -= 3;
                if (angball <= 90)
                {
                    flagd = 7;
                }
            }
            if (flagd == 7)
            {
                angball -= 3;
                if (angball <= 0)
                {
                    flagd = 0;
                }
            }
            DrawDubb(this.CreateGraphics());
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            DrawDubb(e.Graphics);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            off = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
        }
        void DrawScene(Graphics g)
        {
            g.Clear(Color.Black);
            mycirc.Drawcirc(g, 1, 0);
            if (flagd == 0)
            {
                g.FillEllipse(Brushes.DarkOrange, ball.X - 15, ball.Y - 15, 30, 30);
            }
            if (flagd == 1)
            {
                g.FillEllipse(Brushes.Blue, ball.X - 15, ball.Y - 15, 30, 30);
            }
            if (flagd == 2)
            {
                g.FillEllipse(Brushes.White, ball.X - 15, ball.Y - 15, 30, 30);
            }
            if (flagd == 3)
            {
                g.FillEllipse(Brushes.Cyan, ball.X - 15, ball.Y - 15, 30, 30);
            }
            if (flagd == 4)
            {
                g.FillEllipse(Brushes.Cyan, ball.X - 15, ball.Y - 15, 30, 30);
            }
            if (flagd == 5)
            {
                g.FillEllipse(Brushes.White, ball.X - 15, ball.Y - 15, 30, 30);
            }
            if (flagd == 6)
            {
                g.FillEllipse(Brushes.Blue, ball.X - 15, ball.Y - 15, 30, 30);
            }
            if (flagd == 7)
            {
                g.FillEllipse(Brushes.DarkOrange, ball.X - 15, ball.Y - 15, 30, 30);
            }





            g.DrawLine(Pens.DarkRed, 550, 355, 850, 355);
            g.DrawLine(Pens.DarkRed, 705, 200, 705, 500);
        }
        void DrawDubb(Graphics g)
        {
            Graphics g2 = Graphics.FromImage(off);
            DrawScene(g2);
            g.DrawImage(off, 0, 0);
        }
    }
}
