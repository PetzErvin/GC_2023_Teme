namespace Complex_ConvexHull
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
            Pen pen = new Pen(Color.LightBlue, 6);
            Pen pen2 = new Pen(Color.Orange, 5);

            Random random = new Random();
            int n = random.Next(100);

            PointF[] points = new PointF[n];
            float ymax = float.MinValue;
            float xmin = float.MaxValue;
            float x = 0, y = 0;

            for (int i = 0; i < n; i++)
            {
                points[i].X = random.Next(10, 818);
                points[i].Y = random.Next(10, 497);
                g.DrawEllipse(pen2, points[i].X, points[i].Y, 1, 1);
                if (points[i].Y > ymax)
                {
                    ymax = points[i].Y;
                    x = points[i].X;
                    y = points[i].Y;
                }
                else if (points[i].Y == ymax)
                {
                    if (points[i].X < xmin)
                    {
                        xmin = points[i].X;
                        x = points[i].X;
                        y = points[i].Y;
                    }
                }
            }

            int k = 0;
            bool ok = true;
            float xx = x;
            float yy = y;

            while (ok)
            {
                float xp = points[k].X;
                float yp = points[k].Y;

                for (int i = 0; i < n; i++)
                {
                    if (deter(xx, yy, xp, yp, points[i].X, points[i].Y) > 0)
                    {
                        xp = points[i].X;
                        yp = points[i].Y;
                    }
                }
                if (xp != x && yp != y)
                {
                    g.DrawLine(pen, xx, yy, xp, yp);
                    k++;
                    xx = xp;
                    yy = yp;
                }
                else
                {
                    g.DrawLine(pen, xx, yy, xp, yp);
                    ok = false;
                }
            }
        }
        private float deter(float xp, float yp, float xq, float yq, float xr, float yr)
        {
            float d = xp * (yq - yr) + xq * (yr - yp) + xr * (yp - yq);
            return d;
        }
    }
}