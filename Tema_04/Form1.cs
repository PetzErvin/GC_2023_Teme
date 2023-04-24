namespace Tema_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
                Graphics g = e.Graphics;
                Pen pen = new Pen(Color.Red, 4);
                Pen pen1 = new Pen(Color.Green, 5);

                Random random = new Random();
                int n = 100;

                PointF[] L1 = new PointF[n];

                for (int i = 0; i < n; i++)
                {
                    L1[i].X = random.Next(0, 818);
                    L1[i].Y = random.Next(0, 497);
                    g.DrawEllipse(pen1, L1[i].X, L1[i].Y, 1, 1);
                }

                int p, q, r;
                bool ok;

                for (p = 0; p < n; p++)
                {
                    for (q = 0; q < n; q++)
                    {
                        ok = true;
                        for (r = 0; r < n; r++)
                        {
                            if (determinant(L1[p].X, L1[p].Y, L1[q].X, L1[q].Y, L1[r].X, L1[r].Y) > 0)
                                ok = false;
                        }
                        if (ok)
                        {
                            g.DrawLine(pen, L1[p].X, L1[p].Y, L1[q].X, L1[q].Y);
                            
                        }
                    }
                }
        }
            private float determinant(float xp, float yp, float xq, float yq, float xr, float yr)
            {
                float dist = xp * (yq - yr) + xq * (yr - yp) + xr * (yp - yq);
                return dist;
            }
    }
}
