namespace Otectomie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }
        Graphics g;
        Pen pen = new Pen(Color.Magenta, 3);
        const int raza = 3;
        int n = 0; // nr de varfuri ale poligonului
        List<PointF> P = new List<PointF>(); //lista varfurilor
        bool poligon_inchis = false;
        Tuple<int, int>[] diagonale;
        int nr_diagonale = 0;


        private void Form1_Click(object sender, EventArgs e)
        {
            P.Add(this.PointToClient(new Point(Form1.MousePosition.X, Form1.MousePosition.Y)));
            g.DrawEllipse(pen, P[n].X, P[n].Y, raza, raza);
            g.DrawString((n+1).ToString(), new Font(FontFamily.GenericSansSerif, 10),
            new SolidBrush(Color.Navy), P[n].X + raza, P[n].Y - raza);
            if (n > 0)
                g.DrawLine(pen, P[n - 1], P[n]);
            n++;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (n < 3)
                return;
            g.DrawLine(pen, P[n - 1], P[0]);
            poligon_inchis = true;
        }
        public double Sarrus(PointF p1, PointF p2, PointF p3)
        {
            return p1.X * p2.Y + p2.X * p3.Y + p3.X * p1.Y - p3.X * p2.Y - p2.X * p1.Y - p1.X * p3.Y;
        }
        public bool intoarcere_spre_stanga(int p1, int p2, int p3)
        {
            if (Sarrus(P[p1], P[p2], P[p3]) < 0)
                return true;
            return false;
        }
        public bool intoarcere_spre_dreapta(int p1, int p2, int p3)
        {
            if (Sarrus(P[p1], P[p2], P[p3]) > 0)
                return true;
            return false;
        }
        public bool este_varf_convex(int p)
        {
            int p_ant = (p > 0) ? p - 1 : n - 1;
            int p_urm = (p < n - 1) ? p + 1 : 0;
            return intoarcere_spre_dreapta(p_ant, p, p_urm);
        }
        public bool este_varf_reflex(int p)
        {
            int p_ant = (p > 0) ? p - 1 : n - 1;
            int p_urm = (p < n - 1) ? p + 1 : 0;
            return intoarcere_spre_stanga(p_urm, p, p_ant);
        }
        //verifica daca doua segmente se intersecteaza
        public bool se_intersecteaza(PointF s1, PointF s2, PointF p1, PointF p2)
        {
            if (Sarrus(p2, p1, s1) * Sarrus(p2, p1, s2) <= 0 && Sarrus(s2, s1, p1) * Sarrus(s2, s1, p2) <= 0)
                return true;
            return false;
        }
        //verifica daca segmentul p_i p_j se afla in interiorul poligonului
        public bool se_afla_in_interiorul_poligonului(int pi, int pj)
        {
            int pi_ant = (pi > 0) ? pi - 1 : n - 1;
            int pi_urm = (pi < n - 1) ? pi + 1 : 0;
            if ((este_varf_convex(pi) && intoarcere_spre_stanga(pi, pj, pi_urm) && intoarcere_spre_stanga(pi, pi_ant, pj)) ||
            (este_varf_reflex(pi) && !(intoarcere_spre_dreapta(pi, pj, pi_urm) && intoarcere_spre_dreapta(pi, pi_ant, pj))))
                return true;
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (n <= 3)
                return;
            if (!poligon_inchis)
                button1_Click(sender, e); //inchide poligonul
            Pen pen1 = new Pen(Color.Black);
            Pen pen2=new Pen(Color.LightGray,7);
            float[] dashValues = { 1, 2, 3, 4 };
            pen.DashPattern = dashValues;
            while(n>3)
            {
                for (int i = 0; i < n; i++)
                {
                    if(este_diagonala(i,i+2))
                    {
                        g.DrawLine(pen1, P[i], P[i+2]);
                        Thread.Sleep(150);
                        
                        g.DrawLine(pen2, P[i], P[i+1]);
                        g.DrawLine(pen2, P[i+1], P[i+2]);
                        n--;
                        break;
                        
                    }
                }
            }
        }
        public bool este_diagonala(int i,int j)
        {
            nr_diagonale=0;
            bool intersectie = false;
            diagonale=new Tuple<int, int>[n-3];
            //daca p_i p_j nu intersecteaza nicio latura neincidenta a poligonului
            for (int k = 0; k < n - 1; k++)
                if (i != k && i != (k + 1) && j != k && j != (k + 1) && se_intersecteaza(P[i], P[j], P[k], P[k + 1]))
                {
                    intersectie = true;
                    break;
                }
            //verif si pt ultima latura a poligonului
            if (i != n - 1 && i != 0 && j != n - 1 && j != 0 && se_intersecteaza(P[i], P[j], P[n - 1], P[0]))
            {
                intersectie = true;
            }
            if (!intersectie)
            {
                
                //si daca p_i p_j se afla in interiorul poligonului
                if (se_afla_in_interiorul_poligonului(i, j))
                {
                    //se retine diagonala p_i p_j
                    //Thread.Sleep(100);
                    //g.DrawLine(pen, P[i], P[j]);
                    diagonale[nr_diagonale] = new Tuple<int, int>(i, j);
                    nr_diagonale++;
                    return true;
                }
            }
            return false;
        }
    }
}