using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Partitionarea_in_poligoane_monotone
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen p1;
        const int raza = 2;
        int n = 0;
        List<Point> p = new List<Point>();
        bool closed = false;
        int contor = 1;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            p1 = new Pen(Color.BlueViolet, 3);
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            p.Add(PointToClient(new Point(MousePosition.X, MousePosition.Y)));
            if (!closed)
            {
                g.DrawEllipse(p1, p[n].X, p[n].Y, raza, raza);
                g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), p[n].X - 20, p[n].Y - 20);
                contor++;
                if (n > 0)
                    g.DrawLine(p1, p[n - 1], p[n]);
                n++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p1 = new Pen(Color.Red, 3);

            if (n >= 3)
            {
                for (int i = 0; i < n; i++)
                {
                    if (reflex(i))
                    {
                        if (i == 0)
                        {
                            if (p[n - 1].Y > p[i].Y && p[i + 1].Y > p[i].Y)
                            {
                                int j;
                                if (First_Over(i) != -1)
                                {
                                    j = First_Over(i);
                                    g.DrawLine(p1, p[i], p[j]);
                                }
                            }
                            if (p[n - 1].Y < p[i].Y && p[i + 1].Y < p[i].Y)
                            {
                                int j;
                                if (First_Under(i) != -1)
                                {
                                    j = First_Under(i);
                                    g.DrawLine(p1, p[i], p[j]);
                                }
                            }
                        }
                        else if (i == n - 1)
                        {
                            if (p[i - 1].Y > p[i].Y && p[0].Y > p[i].Y)
                            {
                                int j;
                                if (First_Over(i) != -1)
                                {
                                    j = First_Over(i);
                                    g.DrawLine(p1, p[i], p[j]);
                                }
                            }
                            if (p[i - 1].Y < p[i].Y && p[0].Y < p[i].Y)
                            {
                                int j;
                                if (First_Under(i) != -1)
                                {
                                    j = First_Under(i);
                                    g.DrawLine(p1, p[i], p[j]);
                                }
                            }
                        }
                        else
                        {
                            if (p[i - 1].Y > p[i].Y && p[i + 1].Y > p[i].Y)
                            {
                                int j;
                                if (First_Over(i) != -1)
                                {
                                    j = First_Over(i);
                                    g.DrawLine(p1, p[i], p[j]);
                                }
                            }
                            else if (p[i - 1].Y < p[i].Y && p[i + 1].Y < p[i].Y)
                            {
                                int j;
                                if (First_Under(i) != -1)
                                {
                                    j = First_Under(i);
                                    g.DrawLine(p1, p[i], p[j]);
                                }
                            }
                        }
                    }
                }
            }
        }

        private int First_Under(int i)
        {
            for (int k = p[i].Y + 1; k < Height; k++)
                for (int h = 0; h < n; h++)
                    if (p[h].Y == k && isdiagonala(i, h))
                        return h;
            return -1;
        }

        private int First_Over(int i)
        {
            for (int k = p[i].Y - 1; k >= 0; k--)
                for (int h = 0; h < n; h++)
                    if (p[h].Y == k && isdiagonala(i, h))
                        return h;
            return -1;
        }

        private bool isdiagonala(int i, int j)
        {
            int nr_diagonale = 0;
            Tuple<int, int>[] diagonale = new Tuple<int, int>[n - 3];
            bool intersectie = false;
            for (int k = 0; k < n - 1; k++)
                if (i != k && i != (k + 1) && j != k && j != (k + 1) && intersecteaza(p[i], p[j], p[k], p[k + 1]))
                {
                    intersectie = true;
                    break;
                }
            if (i != n - 1 && i != 0 && j != n - 1 && j != 0 && intersecteaza(p[i], p[j], p[n - 1], p[0]))
                intersectie = true;
            if (!intersectie)
            {
                if (Interior(i, j))
                {
                    diagonale[nr_diagonale] = new Tuple<int, int>(i, j);
                    nr_diagonale++;
                    return true;
                }
            }
            return false;
        }

        private bool intersecteaza(Point s1, Point s2, Point p1, Point p2)
        {
            if (Sarrus(p2, p1, s1) * Sarrus(p2, p1, s2) <= 0 && Sarrus(s2, s1, p1) * Sarrus(s2, s1, p2) <= 0)
                return true;
            return false;
        }

        private double Sarrus(Point p1, Point p2, Point p3)
        {
            return p1.X * p2.Y + p2.X * p3.Y + p3.X * p1.Y - p3.X * p2.Y - p2.X * p1.Y - p1.X * p3.Y;
        }

        private bool Interior(int pi, int pj)
        {
            int pi_ant = (pi > 0) ? pi - 1 : n - 1;
            int pi_urm = (pi < n - 1) ? pi + 1 : 0;
            if ((convex(pi) && intoarcere_spre_stanga(pi, pj, pi_urm) && intoarcere_spre_stanga(pi, pi_ant, pj)) ||
            (reflex(pi) && !(intoarcere_spre_dreapta(pi, pj, pi_urm) && intoarcere_spre_dreapta(pi, pi_ant, pj))))
                return true;
            return false;
        }

        private bool convex(int p)
        {
            int p_ant = (p > 0) ? p - 1 : n - 1;
            int p_urm = (p < n - 1) ? p + 1 : 0;
            return intoarcere_spre_dreapta(p_ant, p, p_urm);
        }

        private bool reflex(int p)
        {
            int p_ant = (p > 0) ? p - 1 : n - 1;
            int p_urm = (p < n - 1) ? p + 1 : 0;
            return intoarcere_spre_stanga(p_ant, p, p_urm);
        }
        private bool intoarcere_spre_stanga(int p1, int p2, int p3)
        {
            if (Sarrus(p[p1], p[p2], p[p3]) < 0)
                return true;
            return false;
        }

        private bool intoarcere_spre_dreapta(int p1, int p2, int p3)
        {
            if (Sarrus(p[p1], p[p2], p[p3]) > 0)
                return true;
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n < 3)
                return;

            if (!closed)
            {
                if (n < 3)
                    return;
                g.DrawLine(p1, p[n - 1], p[0]);
                closed = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}