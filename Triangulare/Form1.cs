namespace Triangulare
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void pictureBox1_Click(object sender, EventArgs e)
        {
            var cursorPosition = pictureBox1.PointToClient(Cursor.Position);
            MyPoints.Add(cursorPosition);
            pictureBox1.Refresh();
        }

        List<Point> MyPoints = new List<Point>();

        public void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen p1 = new Pen(Color.Magenta, 5);
            foreach (var item in MyPoints)
            {
                e.Graphics.DrawEllipse(p1, item.X, item.Y, 5, 5);
            }
        }

        public void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
            pictureBox1.Refresh();
        }

        public void pictureBox1_Paint_1(object sender, PaintEventArgs e)
        {
            Pen pen = new Pen(Color.HotPink, 3);
            if (MyPoints.Count>2)
            {

                Point first_point, p1, p2;
                p1=first_point=MyPoints[0];
                for (int i = 1; i < MyPoints.Count; i++)
                {
                    p2=MyPoints[i];
                    e.Graphics.DrawLine(pen, p1, p2);
                    p1=p2;
                    e.Graphics.DrawLine(pen, first_point, p2);
                }
                e.Graphics.DrawLine(pen, MyPoints[0], MyPoints[MyPoints.Count-1]);
                e.Graphics.DrawLine(pen, p1, first_point);
            }
        }
    }
}