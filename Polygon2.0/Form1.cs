namespace Polygon2._0
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            var cursorPosition = pictureBox1.PointToClient(Cursor.Position);
            MyCircles.Add(cursorPosition);
            pictureBox1.Refresh();
            
        }
        List<Point> MyCircles = new List<Point>();


        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.Magenta, 5);
            Pen pen = new Pen(Color.HotPink, 3);
            foreach (var item in MyCircles)
            {
                e.Graphics.DrawEllipse(p, item.X, item.Y, 5, 5);
            }
            if (MyCircles.Count>2)
            {
                    
                Point first_point, p1, p2;
                p1=first_point=MyCircles[0];
                for (int i = 1; i < MyCircles.Count; i++)
                {
                    p2=MyCircles[i];
                    e.Graphics.DrawLine(pen, p1, p2);
                    p1=p2;
                    e.Graphics.DrawLine (pen, first_point, p2);
                }
                e.Graphics.DrawLine(pen, MyCircles[0], MyCircles[MyCircles.Count-1]);
                e.Graphics.DrawLine(pen, p1, first_point);
            }
            
        }
    }
}