using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MODEL
{
    public partial class Form2 : Form
    {
       
        public Form2()
        {
            InitializeComponent();
  
        }
        bool isclisc = false;
        bool is2 = false;
        bool is212 = false;
        int X = 0;
        int Y = 0;
        int dud = 0;
        int dud2 = 0;
        int X1 = 0;
        int Y1 = 0;
        int X2 = 250;
        int kukl = 0;
        int Y2 = 250;
        Graphics g;
        
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {if (dud == 0)
            {
                listBox1.Items.Clear();
                isclisc = true;
                X = e.X;
                Y = e.Y;
                dud = 1;
listBox1.Items.Add("Перша точка лінії  X " + (X-250) + "  Y " + (-(Y-250)) + "  "  );
            }
        else
            {
                if (((Convert.ToInt32(e.X) - X) < 10) & ((Convert.ToInt32(e.X) - X) > -10) & ((Convert.ToInt32(e.Y) - Y) < 10) & ((Convert.ToInt32(e.Y) - Y) > -10))
                {
                    listBox1.Items.Add("Перша точка лінії  X " );
                    is2 = true;
                }
            else
                if (((Convert.ToInt32(e.X) - X1) < 10) & ((Convert.ToInt32(e.X) - X1) > -10) & ((Convert.ToInt32(e.Y) - Y1) < 10) & ((Convert.ToInt32(e.Y) - Y1) > -10)) {
                    listBox1.Items.Add("Перша точка лінії  X " );
                    is212 = true;
                }             
                else
                { 
                X2 = e.X;
                Y2 = e.Y;
                dud = 3;
                dud2 = 1;
                listBox1.Items.Clear();
                isclisc = false;
             
                pictureBox1.Invalidate();

}

            }
        

        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isclisc)
            {
                listBox1.Items.Clear();
                listBox1.Items.Add("Перша точка лінії  X " + (X - 250) + "  Y " + (-(Y - 250)) + "  ");
                listBox1.Items.Add("Друга точка лінії X " + (X1 - 250) + "  Y " + (-(Y1 - 250)) + "  " );
}
            isclisc = false;

            is2 = false;
            is212 = false;

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
           
                if (isclisc)
                {
                    X1 = e.X;
                    Y1 = e.Y;
                    pictureBox1.Invalidate();
                }
            if (is2)
            {
                X = e.X;
                Y = e.Y;
                pictureBox1.Invalidate();
            }
            if (is212)
            {
                X1 = e.X;
                Y1 = e.Y;
                pictureBox1.Invalidate();


            }

            }

            private void Form2_Paint(object sender, PaintEventArgs e)
        {
        } 
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            dima = X1 - X;
            dima = Math.Abs(dima);
            ort = Y1 - Y;
            ort = Math.Abs(ort);
        
            dima = dima / 2;
            ort = ort / 2;
            listBox1.Items.Clear();
            Pen pen = new Pen(Color.Black,3);
        
            e.Graphics.DrawLine(pen, new Point(X, Y), new Point(X1, Y1));
            if (dud != 0)
            {
                listBox1.Items.Add("Перша точка лінії  X " + (X - 250) + "  Y " + (-(Y - 250)) + "  ");
                listBox1.Items.Add("Друга точка лінії X " + (X1 - 250) + "  Y " + (-(Y1 - 250)) + "  ");
            }
            if (dud == 3)
            {
                
                listBox1.Items.Add("Точка X " + (X2 - 250) + "  Y " + (-(Y2 - 250)) + "  ");
                e.Graphics.DrawRectangle(pen, X2, Y2, 5, 5);
            }
            if(kukl==1)
            {
                if ((Y < Y1) & (X < X1))
                    e.Graphics.DrawLine(pen, new Point(X2 + dima, Y2 + ort), new Point(X2 - dima, Y2 - ort));
                if ((Y > Y1) & (X < X1))
                    e.Graphics.DrawLine(pen, new Point(X2 + dima, Y2 - ort), new Point(X2 - dima, Y2 + ort));
                if ((Y < Y1) & (X > X1))
                    e.Graphics.DrawLine(pen, new Point(X2 - dima, Y2 + ort), new Point(X2 + dima, Y2 - ort));
                if ((Y > Y1) & (X > X1))
                    e.Graphics.DrawLine(pen, new Point(X2 + dima, Y2 + ort), new Point(X2 - dima, Y2 - ort));

            }
            if (da == 1)
            {
                Pen pen3 = new Pen(Color.Black, 3);
                e.Graphics.DrawLine(pen3, new Point(0, ord), new Point(500, ord));
                e.Graphics.DrawLine(pen3, new Point(ord, 0), new Point(ord, 500));
                for (int i = 0; i < (290 / corr); i++)
                {
                    e.Graphics.DrawLine(pen3, new Point(250 + i * corr, ord - 4), new Point(250 + i * corr, ord + 4));
                    e.Graphics.DrawLine(pen3, new Point(ord - 4, 250 + i * corr), new Point(ord + 4, 250 + i * corr));
                    e.Graphics.DrawLine(pen3, new Point(250 - i * corr, ord - 4), new Point(250 - i * corr, ord + 4));
                    e.Graphics.DrawLine(pen3, new Point(ord - 4, 250 - i * corr), new Point(ord + 4, 250 - i * corr));
                }
                Pen pen1 = new Pen(Color.Gray);
                for (int i = 0; i < (290 / corr); i++)
                {
                    e.Graphics.DrawLine(pen1, new Point(250 + i * corr, 0), new Point(250 + i * corr, 500));
                    e.Graphics.DrawLine(pen1, new Point(0, 250 + i * corr), new Point(500, 250 + i * corr));
                    e.Graphics.DrawLine(pen1, new Point(250 - i * corr, 0), new Point(250 - i * corr, 500));
                    e.Graphics.DrawLine(pen1, new Point(0, 250 - i * corr), new Point(500, 250 - i * corr));

                }

            }
            }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
            listBox1.Items.Clear();
            X = 0;
            Y = 0;
            dud = 0;
            X1 = 0;
             Y1 = 0;
             X2 = 250;
             Y2 = 250;
            dud = 0;
            dud2 = 0;
            kukl = 0;
            is2 = false;
           is212 = false;
        }
        int dima;
        int ort;
        private void button2_Click(object sender, EventArgs e)
        {
            kukl = 1;
            dima = X1 - X;
            dima = Math.Abs(dima);
            ort = Y1 - Y;
            ort = Math.Abs(ort);

            dima = dima / 2;
            ort= ort / 2;
            
            Pen pen = new Pen(Color.Black,3);
            if((Y<Y1)&(X<X1))
            g.DrawLine(pen, new Point(X2+dima, Y2+ort), new Point(X2-dima, Y2-ort));
            if ((Y > Y1) & (X < X1))
                g.DrawLine(pen, new Point(X2 + dima, Y2 - ort), new Point(X2 - dima, Y2 + ort));
            if ((Y < Y1) & (X > X1))
                g.DrawLine(pen, new Point(X2 - dima, Y2 + ort), new Point(X2 + dima, Y2 - ort));
            if ((Y > Y1) & (X > X1))
              g.DrawLine(pen, new Point(X2 + dima, Y2 + ort), new Point(X2 - dima, Y2 - ort));

  



        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
            g = pictureBox1.CreateGraphics();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {

        }
        int corr = 50;
        int ord = 250;
        int da = 0;
        private void button3_Click(object sender, EventArgs e)
        {





            da = 1;
            Pen pen = new Pen(Color.Black,3);
            g.DrawLine(pen, new Point(0,ord), new Point(500,ord));
            g.DrawLine(pen, new Point(ord, 0), new Point(ord, 500));
            for(int i =0;i< (290 / corr);i++)
            {
                g.DrawLine(pen, new Point(250+i*corr, ord-4), new Point(250+i * corr, ord+4));
                g.DrawLine(pen, new Point(ord-4,250+i * corr), new Point(ord+4,250+i * corr ));
                g.DrawLine(pen, new Point(250 - i * corr, ord - 4), new Point(250 - i * corr, ord + 4));
                g.DrawLine(pen, new Point(ord - 4,250 -  i * corr), new Point( ord + 4,250 - i * corr));
            }
            Pen pen1 = new Pen(Color.Gray);
            for (int i = 0; i < (290 / corr); i++)
            {
                g.DrawLine(pen1, new Point(250 + i * corr, 0), new Point(250 + i * corr,500));
                g.DrawLine(pen1, new Point(0, 250 + i * corr), new Point(500, 250 + i * corr));
                g.DrawLine(pen1, new Point(250 - i * corr, 0), new Point(250 - i * corr, 500));
                g.DrawLine(pen1, new Point(0, 250 - i * corr), new Point(500, 250 - i * corr));

            }

            if(dud!=0)
            {

              g.DrawLine(pen, new Point(X, Y), new Point(X1, Y1));
                if(dud2==1)
                    g.DrawRectangle(pen, X2, Y2, 5, 5);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {if (da == 1)
            {
                Pen pen2 = new Pen(Color.White, 3);
                g.DrawLine(pen2, new Point(0, ord), new Point(500, ord));
                g.DrawLine(pen2, new Point(ord, 0), new Point(ord, 500));
                for (int i = 0; i < (290 / corr); i++)
                {
                    g.DrawLine(pen2, new Point(250 + i * corr, ord - 4), new Point(250 + i * corr, ord + 4));
                    g.DrawLine(pen2, new Point(ord - 4, 250 + i * corr), new Point(ord + 4, 250 + i * corr));
                    g.DrawLine(pen2, new Point(250 - i * corr, ord - 4), new Point(250 - i * corr, ord + 4));
                    g.DrawLine(pen2, new Point(ord - 4, 250 - i * corr), new Point(ord + 4, 250 - i * corr));
                }
                Pen pen12 = new Pen(Color.White);
                for (int i = 0; i < (290 / corr); i++)
                {
                    g.DrawLine(pen12, new Point(250 + i * corr, 0), new Point(250 + i * corr, 500));
                    g.DrawLine(pen12, new Point(0, 250 + i * corr), new Point(500, 250 + i * corr));
                    g.DrawLine(pen12, new Point(250 - i * corr, 0), new Point(250 - i * corr, 500));
                    g.DrawLine(pen12, new Point(0, 250 - i * corr), new Point(500, 250 - i * corr));

                }
                corr = corr - 6;

                Pen pen = new Pen(Color.Black, 3);
                g.DrawLine(pen, new Point(0, ord), new Point(500, ord));
                g.DrawLine(pen, new Point(ord, 0), new Point(ord, 500));
                for (int i = 0; i < (290 / corr); i++)
                {
                    g.DrawLine(pen, new Point(250 + i * corr, ord - 4), new Point(250 + i * corr, ord + 4));
                    g.DrawLine(pen, new Point(ord - 4, 250 + i * corr), new Point(ord + 4, 250 + i * corr));
                    g.DrawLine(pen, new Point(250 - i * corr, ord - 4), new Point(250 - i * corr, ord + 4));
                    g.DrawLine(pen, new Point(ord - 4, 250 - i * corr), new Point(ord + 4, 250 - i * corr));
                }
                Pen pen1 = new Pen(Color.Gray);
                for (int i = 0; i < (290 / corr); i++)
                {
                    g.DrawLine(pen1, new Point(250 + i * corr, 0), new Point(250 + i * corr, 500));
                    g.DrawLine(pen1, new Point(0, 250 + i * corr), new Point(500, 250 + i * corr));
                    g.DrawLine(pen1, new Point(250 - i * corr, 0), new Point(250 - i * corr, 500));
                    g.DrawLine(pen1, new Point(0, 250 - i * corr), new Point(500, 250 - i * corr));

                }
                if (dud != 0)
                {

                    g.DrawLine(pen, new Point(X, Y), new Point(X1, Y1));
                    if (dud2 == 1)
                        g.DrawRectangle(pen, X2, Y2, 5, 5);
                    if(kukl==1)
                    {
                        if ((Y < Y1) & (X < X1))
                            g.DrawLine(pen, new Point(X2 + dima, Y2 + ort), new Point(X2 - dima, Y2 - ort));
                        if ((Y > Y1) & (X < X1))
                            g.DrawLine(pen, new Point(X2 + dima, Y2 - ort), new Point(X2 - dima, Y2 + ort));
                        if ((Y < Y1) & (X > X1))
                            g.DrawLine(pen, new Point(X2 - dima, Y2 + ort), new Point(X2 + dima, Y2 - ort));
                        if ((Y > Y1) & (X > X1))
                            g.DrawLine(pen, new Point(X2 + dima, Y2 + ort), new Point(X2 - dima, Y2 - ort));

                    }
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (da == 1)
            {
                Pen pen2 = new Pen(Color.White, 3);
                g.DrawLine(pen2, new Point(0, ord), new Point(500, ord));
                g.DrawLine(pen2, new Point(ord, 0), new Point(ord, 500));
                for (int i = 0; i < (290 / corr); i++)
                {
                    g.DrawLine(pen2, new Point(250 + i * corr, ord - 4), new Point(250 + i * corr, ord + 4));
                    g.DrawLine(pen2, new Point(ord - 4, 250 + i * corr), new Point(ord + 4, 250 + i * corr));
                    g.DrawLine(pen2, new Point(250 - i * corr, ord - 4), new Point(250 - i * corr, ord + 4));
                    g.DrawLine(pen2, new Point(ord - 4, 250 - i * corr), new Point(ord + 4, 250 - i * corr));
                }
                Pen pen12 = new Pen(Color.White);
                for (int i = 0; i < (290 / corr); i++)
                {
                    g.DrawLine(pen12, new Point(250 + i * corr, 0), new Point(250 + i * corr, 500));
                    g.DrawLine(pen12, new Point(0, 250 + i * corr), new Point(500, 250 + i * corr));
                    g.DrawLine(pen12, new Point(250 - i * corr, 0), new Point(250 - i * corr, 500));
                    g.DrawLine(pen12, new Point(0, 250 - i * corr), new Point(500, 250 - i * corr));

                }
                corr = corr + 6;

                Pen pen = new Pen(Color.Black, 3);
                g.DrawLine(pen, new Point(0, ord), new Point(500, ord));
                g.DrawLine(pen, new Point(ord, 0), new Point(ord, 500));
                for (int i = 0; i < (290 / corr); i++)
                {
                    g.DrawLine(pen, new Point(250 + i * corr, ord - 4), new Point(250 + i * corr, ord + 4));
                    g.DrawLine(pen, new Point(ord - 4, 250 + i * corr), new Point(ord + 4, 250 + i * corr));
                    g.DrawLine(pen, new Point(250 - i * corr, ord - 4), new Point(250 - i * corr, ord + 4));
                    g.DrawLine(pen, new Point(ord - 4, 250 - i * corr), new Point(ord + 4, 250 - i * corr));
                }
                Pen pen1 = new Pen(Color.Gray);
                for (int i = 0; i < (290 / corr); i++)
                {
                    g.DrawLine(pen1, new Point(250 + i * corr, 0), new Point(250 + i * corr, 500));
                    g.DrawLine(pen1, new Point(0, 250 + i * corr), new Point(500, 250 + i * corr));
                    g.DrawLine(pen1, new Point(250 - i * corr, 0), new Point(250 - i * corr, 500));
                    g.DrawLine(pen1, new Point(0, 250 - i * corr), new Point(500, 250 - i * corr));

                }
                if (dud != 0)
                {

                    g.DrawLine(pen, new Point(X, Y), new Point(X1, Y1));
                    if (dud2 == 1)
                        g.DrawRectangle(pen, X2, Y2, 5, 5);
                    if (kukl == 1)
                    {
                        if ((Y < Y1) & (X < X1))
                            g.DrawLine(pen, new Point(X2 + dima, Y2 + ort), new Point(X2 - dima, Y2 - ort));
                        if ((Y > Y1) & (X < X1))
                            g.DrawLine(pen, new Point(X2 + dima, Y2 - ort), new Point(X2 - dima, Y2 + ort));
                        if ((Y < Y1) & (X > X1))
                            g.DrawLine(pen, new Point(X2 - dima, Y2 + ort), new Point(X2 + dima, Y2 - ort));
                        if ((Y > Y1) & (X > X1))
                            g.DrawLine(pen, new Point(X2 + dima, Y2 + ort), new Point(X2 - dima, Y2 - ort));

                    }
                }
            }
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MODEL.Form3 Form1 = new MODEL.Form3();
            Form1.Show();
            this.Hide();

        }
    }
}
