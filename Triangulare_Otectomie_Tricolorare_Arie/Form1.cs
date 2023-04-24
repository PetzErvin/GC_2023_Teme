using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangulareOctectomie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        #region DrawPolygon

        Graphics g;
        List<Point> points = new List<Point>();
        List<Tuple<int, int, int>> triangles = new List<Tuple<int, int, int>>();
        int contor = 1;


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            Graphics g = panel1.CreateGraphics();

            Pen pen = new Pen(Color.Coral, 3);
            Point aux = new Point(e.X, e.Y);
            Pen pinkPen = new Pen(Color.Violet, 2);
            g.DrawString(contor.ToString(), new Font(FontFamily.GenericSansSerif, 10), new SolidBrush(Color.Black), aux.X - 20, aux.Y - 20);
            contor++;
            g.DrawEllipse(pen, aux.X - 2, aux.Y - 2, 4, 4);
            if (points.Count != 0)
            {
                g.DrawLine(pinkPen, aux, points[points.Count - 1]);
            }
            points.Add(aux);

        }
        private void buttonFinishUp_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen pinkPen = new Pen(Color.Violet, 2);
            g.DrawLine(pinkPen, points[0], points[points.Count - 1]);
        }
        #endregion
        private void buttonTriang_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen blackPen = new Pen(Color.RoyalBlue, 2);
            List<Point> puncteTriangulare = new List<Point>(points); //clona listei points
            int n = puncteTriangulare.Count;
            int newLabelY = label1.Location.Y + 20;
            while (n > 3)
            {
                for (int i = 0; i < n - 2; i++)
                {
                    if (EsteDiagonala(puncteTriangulare, i, i + 2))
                    {
                        Thread.Sleep(100);
                        IdentificareTriunghi(newLabelY, puncteTriangulare, i); //scrie in label triunghiul
                        newLabelY += 20;
                        g.DrawLine(blackPen, puncteTriangulare[i], puncteTriangulare[i + 2]); //deseneaza diagonala
                        puncteTriangulare.RemoveAt(i + 1); //sterge varful urechii
                        n--;
                        break;
                    }
                }
            }
            IdentificareTriunghi(newLabelY, puncteTriangulare, 0); //scrie ultimul triunghi
        }
        private bool EsteDiagonala(List<Point> puncte, int i, int j)
        {
            bool intersectie = false;

            for (int k = 0; k < puncte.Count - 1; k++)
            {
                if (i != k && i != (k + 1) && j != k && j != (k + 1) && se_intersecteaza(puncte[i], puncte[j], puncte[k], puncte[k + 1]))
                {
                    intersectie = true;
                    break;
                }
            }
            if (i != puncte.Count - 1 && i != 0 && j != puncte.Count - 1 && j != 0 && se_intersecteaza(puncte[i], puncte[j], puncte[puncte.Count - 1], puncte[0]))
            {
                intersectie = true;
            }
            if (!intersectie && se_afla_in_interiorul_poligonului(puncte, i, j))
            {
                return true;
            }
            return false;
        }

        private void IdentificareTriunghi(int labelY, List<Point> puncteTriangulare, int i)
        {
            Label labelTriangle = new Label();
            labelTriangle.Parent = panel1;
            labelTriangle.Location = new Point(label1.Location.X, labelY);
            labelTriangle.Text = "";
            labelTriangle.AutoSize = true;
            this.Controls.Add(labelTriangle);
            int A = 0, B = 0, C = 0;
            for (int j = 0; j < points.Count; j++)
            {
                if (points[j].X == puncteTriangulare[i].X && points[j].Y == puncteTriangulare[i].Y)
                {
                    A = j;
                    break;
                }
            }
            for (int j = 0; j < points.Count; j++)
            {
                if (points[j].X == puncteTriangulare[i + 1].X && points[j].Y == puncteTriangulare[i + 1].Y)
                {
                    B = j;
                    break;
                }
            }
            for (int j = 0; j < points.Count; j++)
            {
                if (points[j].X == puncteTriangulare[i + 2].X && points[j].Y == puncteTriangulare[i + 2].Y)
                {
                    C = j;
                    break;
                }
            }
            triangles.Add(new Tuple<int, int, int>(A, B, C));

        }


        private int ValoareDeterminant(Point a, Point b, Point c)
        {
            return a.X * b.Y + b.X * c.Y + c.X * a.Y - c.X * b.Y - a.X * c.Y - b.X * a.Y;
        }

        private bool se_afla_in_interiorul_poligonului(List<Point> puncte, int pi, int pj)
        {
            int pi_ant = (pi > 0) ? pi - 1 : puncte.Count - 1;
            int pi_urm = (pi < puncte.Count - 1) ? pi + 1 : 0;
            if ((este_varf_convex(puncte, pi) && intoarcere_spre_stanga(puncte, pi, pj, pi_urm) && intoarcere_spre_stanga(puncte, pi, pi_ant, pj)) || (este_varf_reflex(puncte, pi) && !(intoarcere_spre_dreapta(puncte, pi, pj, pi_urm) && intoarcere_spre_dreapta(puncte, pi, pi_ant, pj))))
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_dreapta(List<Point> puncte, int p1, int p2, int p3)
        {
            if (ValoareDeterminant(puncte[p1], puncte[p2], puncte[p3]) > 0)
            {
                return true;
            }
            return false;
        }

        private bool intoarcere_spre_stanga(List<Point> puncte, int p1, int p2, int p3)
        {
            if (ValoareDeterminant(puncte[p1], puncte[p2], puncte[p3]) < 0)
            {
                return true;
            }
            return false;
        }

        private bool este_varf_reflex(List<Point> puncte, int p)
        {
            int p_ant = (p > 0) ? p - 1 : puncte.Count - 1;
            int p_urm = (p < puncte.Count - 1) ? p + 1 : 0;
            return intoarcere_spre_stanga(puncte, p_ant, p, p_urm);
        }

        private bool este_varf_convex(List<Point> puncte, int p)
        {
            int p_ant = (p > 0) ? p - 1 : puncte.Count - 1;
            int p_urm = (p < puncte.Count - 1) ? p + 1 : 0;
            return intoarcere_spre_dreapta(puncte, p_ant, p, p_urm);
        }

        private bool se_intersecteaza(Point s1, Point s2, Point p1, Point p2)
        {
            if (ValoareDeterminant(p2, p1, s1) * ValoareDeterminant(p2, p1, s2) <= 0 && ValoareDeterminant(s2, s1, p1) * ValoareDeterminant(s2, s1, p2) <= 0)
            {
                return true;
            }
            return false;
        }



        private void buttonThreeColor_Click(object sender, EventArgs e)
        {
            Graphics g = panel1.CreateGraphics();
            Pen[] pens = new Pen[] { new Pen(Color.Blue, 3), new Pen(Color.Green, 3), new Pen(Color.Red, 3) };
            List<Tuple<int, int>> varfuriMarcate = new List<Tuple<int, int>>();
            for (int i = triangles.Count - 1; i >= 0; i--)
            {
                int colored1 = EsteMarcat(triangles[i].Item1, varfuriMarcate);
                int colored2 = EsteMarcat(triangles[i].Item2, varfuriMarcate);
                int colored3 = EsteMarcat(triangles[i].Item3, varfuriMarcate);
                if (colored1 == -1 && colored2 == -1 && colored3 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item1, 0));
                    g.DrawRectangle(pens[0], points[triangles[i].Item1].X - 8, points[triangles[i].Item1].Y - 8, 16, 16);
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item2, 1));
                    g.DrawRectangle(pens[1], points[triangles[i].Item2].X - 8, points[triangles[i].Item2].Y - 8, 16, 16);
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item3, 2));
                    g.DrawRectangle(pens[2], points[triangles[i].Item3].X - 8, points[triangles[i].Item3].Y - 8, 16, 16);
                }
                else if (colored1 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item1, NextColor(colored2, colored3)));
                    g.DrawRectangle(pens[NextColor(colored2, colored3)], points[triangles[i].Item1].X - 8, points[triangles[i].Item1].Y - 8, 16, 16);
                }
                else if (colored2 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item2, NextColor(colored1, colored3)));
                    g.DrawRectangle(pens[NextColor(colored1, colored3)], points[triangles[i].Item2].X - 8, points[triangles[i].Item2].Y - 8, 16, 16);
                }
                else if (colored3 == -1)
                {
                    varfuriMarcate.Add(new Tuple<int, int>(triangles[i].Item3, NextColor(colored1, colored2)));
                    g.DrawRectangle(pens[NextColor(colored1, colored2)], points[triangles[i].Item3].X - 8, points[triangles[i].Item3].Y - 8, 16, 16);
                }
            }
        }

        private int EsteMarcat(int punct, List<Tuple<int, int>> varfuriMarcate) //verifica daca e marcat si returneaza culoarea
        {
            for (int i = 0; i < varfuriMarcate.Count; i++)
            {
                if (varfuriMarcate[i].Item1 == punct)
                {
                    return varfuriMarcate[i].Item2;
                }
            }
            return -1;
        }

        private int NextColor(int a, int b) //returneaza a treia culoare
        {
            if ((a == 0 && b == 1) || (a == 1 && b == 0))
            {
                return 2;
            }
            if ((a == 0 && b == 2) || (a == 2 && b == 0))
            {
                return 1;
            }
            if ((a == 1 && b == 2) || (a == 2 && b == 1))
            {
                return 0;
            }
            return -1;
        }




        private void buttonArie_Click(object sender, EventArgs e)
        {
            double arieTotala = 0;
            for (int i = 0; i < triangles.Count; i++)
            {
                arieTotala += ArieTriunghi(points[triangles[i].Item1].X, points[triangles[i].Item1].Y, points[triangles[i].Item2].X, points[triangles[i].Item2].Y, points[triangles[i].Item3].X, points[triangles[i].Item3].Y);
            }
            labelArie.Text = arieTotala.ToString();
        }

        private double ArieTriunghi(int x1, int y1, int x2, int y2, int x3, int y3)
        {
            return 0.5 * Math.Abs(x1 * y2 + x2 * y3 + x3 * y1 - x3 * y2 - x1 * y3 - x2 * y1);
        }

    }
}