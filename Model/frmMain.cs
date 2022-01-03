using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Model
{
    public partial class frmMain : Form
    {
        //
        //
        //
        //
        //
        //MODEL ORIGIN
        //
        //
        //
        //
        //
        public frmMain()
        {
            InitializeComponent();
        }

        const double Vk = 0.000207, LkI1 = 0.000165, LkI2 = 0.000036;
        double LT = 0, V = 1, T = 3.98, w = 500, h = 250, z = 500, k = 0, wm = 20, hm = 10, zm = 20;
        int pp1 = 0, pp2 = 0, pp3 = 0;

        double dh;

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        double hI0 = 274.774577;


        double w0, z0;

       private void timer2_Tick(object sender, EventArgs e)
        {

            double TT = 0;

            if (jov == 0)
            {
                h = 300;
                w = 300;
                z = Math.Sqrt(200);
                zm = 300 / 25;

                if (LT >= (-20))
                {
                    LT += 0.02;
                    LT1 = LT;

                    while (TT > LT)
                    {
                        h = h - (LkI1 * 0.02 * h);
                        w = w - (LkI1 * 0.02 * w);
                        z = z - (LkI1 * 0.02 * z);
                        zm = zm - (LkI1 * 0.02 * zm);
                        TT -= 0.02;
                    }

                    hm = h / 25;
                    wm = w / 25;

                    V1 = hm * wm * zm;

                    lblV.Text = "V = " + V1 + " l";
                    lblT.Text = "T = " + Math.Round(LT,2) + " C";
                }
                else
                {
                    if (LT < (-40))
                    {
                        LT += 0.02;
                        LT1 = LT;

                        while (TT > LT)
                        {
                            if (TT > -20)
                            {
                                h = h - (LkI1 * 0.02 * h);
                                w = w - (LkI1 * 0.02 * w);
                                z = z - (LkI1 * 0.02 * z);
                                zm = zm - (LkI1 * 0.02 * zm);
                            }
                            else
                            {
                                if (TT >= (-40))
                                {
                                    h = h - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * h);
                                    w = w - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * w);
                                    z = z - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * z);
                                    zm = zm - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * zm);
                                }
                                else
                                {
                                    h = h - (LkI2 * 0.02 * h);
                                    w = w - (LkI2 * 0.02 * w);
                                    z = z - (LkI2 * 0.02 * z);
                                    zm = zm - (LkI2 * 0.02 * zm);
                                }
                            }
                            TT -= 0.02;
                        }

                        hm = h / 25;
                        wm = w / 25;

                        V1 = hm * wm * zm;

                        lblV.Text = "V = " + V1 + " l";
                        lblT.Text = "T = " + Math.Round(LT, 2) + " C";
                    }
                    else
                    {
                        if (LT >= (-40))
                        {
                            LT += 0.02;
                            LT1 = LT;
                            while (TT > LT)
                            {
                                if (TT > -20)
                                {
                                    h = h - (LkI1 * 0.02 * h);
                                    w = w - (LkI1 * 0.02 * w);
                                    z = z - (LkI1 * 0.02 * z);
                                    zm = zm - (LkI1 * 0.02 * zm);
                                }
                                else
                                {
                                    h = h - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * h);
                                    w = w - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * w);
                                    z = z - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * z);
                                    zm = zm - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * zm);
                                }
                                TT -= 0.02;
                            }

                            hm = h / 25;
                            wm = w / 25;

                            V1 = hm * wm * zm;

                            lblV.Text = "V = " + V1 + " l";
                            lblT.Text = "T = " + Math.Round(LT, 2) + " C";

                            h0 = h;
                            w0 = w;
                            z0 = z;
                        }
                    }
                }
                jov = 1;
            }
            else
            {
                if ((Math.Round(h, 0) != (Math.Round(h0, 0)))||((Math.Round(w, 0) != (Math.Round(w0, 0)))))
                {
                    gr.Clear(Color.Ivory);
                    gr.FillRectangle(Brushes.LightBlue, 100, 200, (int)w, (int)h);
                    GraphicsPath graphPath = new GraphicsPath();
                    graphPath.AddLine(100, 200, (float)(100 + (z * z / 2)), (float)(200 - (z * z / 2)));
                    graphPath.AddLine((float)(100 + (z * z / 2)), (float)(200 - (z * z / 2)), (float)(100 + w + (z*z/2)), (float)(200 - (z * z / 2)));
                    graphPath.AddLine((float)(100 + w + (z * z / 2)), (float)(200 - (z * z / 2)), (float)(100 + w), 200);
                    graphPath.AddLine((float)(100 + w), 200, 100, 200);
                    gr.FillPath(Brushes.LightCyan, graphPath);

                    GraphicsPath graphPath1 = new GraphicsPath();
                    graphPath1.AddLine((float)(100 + w + (z * z / 2)), (float)(200 - (z * z / 2)), (float)(100 + w), 200);
                    graphPath1.AddLine((float)(100 + w), 200, (float)(100 + w), (float)(200 + h));
                    graphPath1.AddLine((float)(100 + w), (float)(200 + h), (float)(100 + w + (z * z / 2)), (float)(200 - (z * z / 2) + h));
                    graphPath1.AddLine((float)(100 + w + (z * z / 2)), (float)(200 - (z * z / 2) + h), (float)(100 + w + (z * z / 2)), (float)(200 - (z * z / 2)));
                    gr.FillPath(Brushes.Blue, graphPath1);
                    h0 = h;
                    w0 = w;
                    z0 = z;
                }

                h = 300;
                w = 300;
                z = Math.Sqrt(200);
                zm = 300 / 25;

                if (LT >= (-20))
                {
                    LT += 0.02;
                    LT1 = LT;

                    while (TT > LT)
                    {
                        h = h - (LkI1 * 0.02 * h);
                        w = w - (LkI1 * 0.02 * w);
                        z = z - (LkI1 * 0.02 * z);
                        zm = zm - (LkI1 * 0.02 * zm);
                        TT -= 0.02;
                    }

                    hm = h / 25;
                    wm = w / 25;

                    V1 = hm * wm * zm;

                    lblV.Text = "V = " + V1 + " l";
                    lblT.Text = "T = " + Math.Round(LT, 2) + " C";
                }
                else
                {
                    if (LT < (-40))
                    {
                        LT += 0.02;
                        LT1 = LT;

                        while (TT > LT)
                        {
                            if (TT > -20)
                            {
                                h = h - (LkI1 * 0.02 * h);
                                w = w - (LkI1 * 0.02 * w);
                                z = z - (LkI1 * 0.02 * z);
                                zm = zm - (LkI1 * 0.02 * zm);
                            }
                            else
                            {
                                if (TT >= (-40))
                                {
                                    h = h - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * h);
                                    w = w - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * w);
                                    z = z - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * z);
                                    zm = zm - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * zm);
                                }
                                else
                                {
                                    h = h - (LkI2 * 0.02 * h);
                                    w = w - (LkI2 * 0.02 * w);
                                    z = z - (LkI2 * 0.02 * z);
                                    zm = zm - (LkI2 * 0.02 * zm);
                                }
                            }
                            TT -= 0.02;
                        }

                        hm = h / 25;
                        wm = w / 25;

                        V1 = hm * wm * zm;

                        lblV.Text = "V = " + V1 + " l";
                        lblT.Text = "T = " + Math.Round(LT, 2) + " C";
                    }
                    else
                    {
                        if (LT >= (-40))
                        {
                            LT += 0.02;
                            LT1 = LT;
                            while (TT > LT)
                            {
                                if (TT > -20)
                                {
                                    h = h - (LkI1 * 0.02 * h);
                                    w = w - (LkI1 * 0.02 * w);
                                    z = z - (LkI1 * 0.02 * z);
                                    zm = zm - (LkI1 * 0.02 * zm);
                                }
                                else
                                {
                                    h = h - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * h);
                                    w = w - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * w);
                                    z = z - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * z);
                                    zm = zm - ((((TT - (-40)) / (-20 + 40)) * (LkI1 - LkI2) + LkI2) * 0.02 * zm);
                                }
                                TT -= 0.02;
                            }

                            hm = h / 25;
                            wm = w / 25;

                            V1 = hm * wm * zm;

                            lblV.Text = "V = " + V1 + " l";
                            lblT.Text = "T = " + Math.Round(LT, 2) + " C";
                        }
                    }
                }
            }
        }

        Graphics gr, grx;

        double lx0, ly0, lx1, ly1;

        private void frmMain_Load(object sender, EventArgs e)
        {
        }

        private void btLaucnh_Click(object sender, EventArgs e)
        {
            LT = 0; V = 1; T = 3.98; w = 500; h = 250; z = 500; k = 0;
            wm = w / 25;
            hm = h / 25;
            zm = z / 25;
            V = hm * wm * zm;
            LT = double.Parse(txtTemp.Text);

            gr = pbAnim.CreateGraphics();
            gr.Clear(Color.Ivory);
            Pen p = new Pen(Brushes.Black, 3);
            gr.DrawLine(p, 70, 70, 70, 570);
            gr.DrawLine(p, 70, 570, 570, 570);
            gr.DrawLine(p, 570, 570, 570, 70);

            grx = pbZoom.CreateGraphics();
            grx.Clear(Color.Ivory);
            grx.DrawLine(p, 20, 20, 20, 360);
            grx.DrawLine(p, 250, 20, 250, 360);
            grx.DrawLine(p, 20, 360, 250, 360);

            pp1 = 95;
            while (pp1<570)
            {
                gr.DrawLine(p, pp1, 570, pp1, 600);
                pp1 += 25;
            }
            pp2 = 95;
            while (pp2 < 570)
            {
                gr.DrawLine(p, 40, pp2, 70, pp2);
                pp2 += 25;
            }
            pp3 = 95;
            while (pp3 < 570)
            {
                gr.DrawLine(p, 570, pp3, 600, pp3);
                pp3 += 25;
            }

            gr.FillRectangle(Brushes.Blue, 70, 320, (int)w, (int)h);
            lblV.Text = "V = " + V + " l";

            jov = 0;

            if (LT >= 0)
            {
                timer1.Start();
                timer1.Interval = 10;
            }
            else
            {
                h = 300;
                w = 300;
                z = Math.Sqrt(200);
                zm = 300 / 25;

                gr.Clear(Color.Ivory);
                grx.Clear(Color.Ivory);

                timer2.Start();
                timer2.Interval = 10;
            }
        }

        // Vk = V/T  T = V/Vk  V = Vk*T
            double LT1;
            double dV;
            double V1;
            double h0;

            double h02;
            Pen pl;
        int jov = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            double TT = 3.98, V1 = V;

            if (jov == 0) { 
            Pen p = new Pen(Brushes.Black, 3);
                if (LT > T)
                {
                    LT -= 0.02;
                    LT1 = LT;

                    while (TT < LT)
                    {
                        V1 = V1 + (Vk * 0.02 * V1);
                        TT += 0.02;
                    }

                    hm = V1 / wm / zm;

                    h = hm * 25;
                    w = wm * 25;
                    z = zm * 25;

                    lblV.Text = "V = " + V1 + " l";
                    lblT.Text = "T = " + Math.Round(LT, 2) + " C";
                }
                else
                {
                    if (LT > 0)
                    {
                        LT -= 0.02;
                        LT1 += 0.02;

                        while (TT < LT1)
                        {
                            V1 = V1 + (Vk * 0.02 * V1);
                            TT += 0.02;
                        }

                        hm = V1 / wm / zm;

                        h = hm * 25;
                        w = wm * 25;
                        z = zm * 25;


                        lblV.Text = "V = " + V1 + " l";
                        lblT.Text = "T = " + Math.Round(LT, 2) + " C";
                    }
                    else
                    {
                        V1 *= 1.1;
                        hm = V1 / wm / zm;

                        h = hm * 25;
                        w = wm * 25;
                        z = zm * 25;

                        lblV.Text = "V = " + V1 + " l";
                        lblT.Text = "T = " + Math.Round(LT, 2) + " C";
                        gr.Clear(Color.Ivory);
                        gr.DrawLine(p, 70, 70, 70, 570);
                        gr.DrawLine(p, 70, 570, 570, 570);
                        gr.DrawLine(p, 570, 570, 570, 70);

                        pp1 = 95;
                        while (pp1 < 570)
                        {
                            gr.DrawLine(p, pp1, 570, pp1, 600);
                            pp1 += 25;
                        }
                        pp2 = 95;
                        while (pp2 < 570)
                        {
                            gr.DrawLine(p, 40, pp2, 70, pp2);
                            pp2 += 25;
                        }
                        pp3 = 95;
                        while (pp3 < 570)
                        {
                            gr.DrawLine(p, 570, pp3, 600, pp3);
                            pp3 += 25;
                        }

                        gr.FillRectangle(Brushes.Blue, 70, (float)(570 - h), (float)w, (float)h);
                        grx.FillRectangle(Brushes.Blue, 20, (float)(((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20), 230, (float)(360 - (((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20)));

                       
                        timer1.Stop();
                    }
                }
                h0 = h;
                h02 = (360 - (((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20));

                gr.Clear(Color.Ivory);
                gr.DrawLine(p, 70, 70, 70, 570);
                gr.DrawLine(p, 70, 570, 570, 570);
                gr.DrawLine(p, 570, 570, 570, 70);

                pp1 = 95;
                while (pp1 < 570)
                {
                    gr.DrawLine(p, pp1, 570, pp1, 600);
                    pp1 += 25;
                }
                pp2 = 95;
                while (pp2 < 570)
                {
                    gr.DrawLine(p, 40, pp2, 70, pp2);
                    pp2 += 25;
                }
                pp3 = 95;
                while (pp3 < 570)
                {
                    gr.DrawLine(p, 570, pp3, 600, pp3);
                    pp3 += 25;
                }

                gr.FillRectangle(Brushes.Blue, 70, (float)(570-h), (float)w, (float)h);

                
                grx.FillRectangle(Brushes.Blue, 20, (float)(((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20), 230, (float)(360 - (((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20)));
                jov = 1;


            }
            else
            {
                Pen p = new Pen(Brushes.Black, 3);
                if (Math.Round(h,0)!=(Math.Round(h0,0))) {
                    gr.Clear(Color.Ivory);
                    gr.DrawLine(p, 70, 70, 70, 570);
                    gr.DrawLine(p, 70, 570, 570, 570);
                    gr.DrawLine(p, 570, 570, 570, 70);

                    pp1 = 95;
                    while (pp1 < 570)
                    {
                        gr.DrawLine(p, pp1, 570, pp1, 600);
                        pp1 += 25;
                    }
                    pp2 = 95;
                    while (pp2 < 570)
                    {
                        gr.DrawLine(p, 40, pp2, 70, pp2);
                        pp2 += 25;
                    }
                    pp3 = 95;
                    while (pp3 < 570)
                    {
                        gr.DrawLine(p, 570, pp3, 600, pp3);
                        pp3 += 25;
                    }

                    gr.FillRectangle(Brushes.Blue, 70, (float)(570 - h), (float)w, (float)h);
                    h0 = h;
                }
                if ((Math.Round((360 - (((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20)),0)!= (Math.Round(h02, 0))))
                {
                    grx.Clear(Color.Ivory);
                    grx.DrawLine(p, 20, 20, 20, 360);
                    grx.DrawLine(p, 20, 360, 250, 360);
                    grx.DrawLine(p, 250, 20, 250, 360);
                    
                    grx.FillRectangle(Brushes.Blue, 20, (float)(((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20), 230, (float)(360 - (((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20)));
                    h02 = (360 - (((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20));
                   
                }
                if (LT > T)
                {
                    LT -= 0.02;
                    LT1 = LT;

                    while (TT < LT1)
                    {
                        V1 = V1 + (Vk * 0.02 * V1);
                        TT += 0.02;
                    }
                    hm = V1 / wm / zm;

                    h = hm * 25;
                    w = wm * 25;
                    z = zm * 25;

                    lblV.Text = "V = " + V1 + " l";
                    lblT.Text = "T = " + Math.Round(LT, 2) + " C";
                }
                else
                {
                    
                    if (LT > 0)
                    {
                        LT -= 0.02;
                        LT1 += 0.02;
                        while (TT < LT1)
                        {
                            V1 = V1 + (Vk * 0.02 * V1);
                            TT += 0.02;
                        }
                        hm = V1 / wm / zm;

                        h = hm * 25;
                        w = wm * 25;
                        z = zm * 25;


                        lblV.Text = "V = " + V1 + " l";
                        lblT.Text = "T = " + Math.Round(LT, 2) + " C";
                    }
                    else
                    {
                        V1 *= 1.1;
                        hm = V1 / wm / zm;

                        h = hm * 25;
                        w = wm * 25;
                        z = zm * 25;

                        lblV.Text = "V = " + V1 + " l";
                        lblT.Text = "T = " + Math.Round(LT, 2) + " C";
                        gr.Clear(Color.Ivory);
                        gr.DrawLine(p, 70, 70, 70, 570);
                        gr.DrawLine(p, 70, 570, 570, 570);
                        gr.DrawLine(p, 570, 570, 570, 70);

                        pp1 = 95;
                        while (pp1 < 570)
                        {
                            gr.DrawLine(p, pp1, 570, pp1, 600);
                            pp1 += 25;
                        }
                        pp2 = 95;
                        while (pp2 < 570)
                        {
                            gr.DrawLine(p, 40, pp2, 70, pp2);
                            pp2 += 25;
                        }
                        pp3 = 95;
                        while (pp3 < 570)
                        {
                            gr.DrawLine(p, 570, pp3, 600, pp3);
                            pp3 += 25;
                        }

                        gr.FillRectangle(Brushes.Blue, 70, (float)(570 - h), (float)w, (float)h);
                        grx.FillRectangle(Brushes.Blue, 20, (float)(((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20), 230, (float)(360 - (((570 - h) - (570 - 275)) / ((570 - 250 - 570 + 275)) * (360 - 20) + 20)));
                        
                        timer1.Stop();
                    }
                }
            }
        }
    }
}
