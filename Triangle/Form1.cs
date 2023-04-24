namespace Triangle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Random random = new Random();
            int n = random.Next(10,60);
            Pen pen = new Pen(Color.Green, 4);
            Pen pen1 = new Pen(Color.Red, 3);
            int[] x_coordinates =new int[n];
            int[] y_coordinates= new int[n];
            for (int i = 0; i < n; i++)
            {
                x_coordinates[i] = random.Next(2, 300);
                y_coordinates[i] = random.Next(2, 300);                
                e.Graphics.DrawEllipse(pen1, x_coordinates[i], y_coordinates[i], 1, 1);
            }
            double Arie_min=int.MaxValue, Arie=0;
            int xmin1 = 0, ymin1=0,xmin2=0,ymin2=0,xmin3=0,ymin3=0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for(int k = 0; k < n; k++)
                    {
                        Arie=(Math.Abs(x_coordinates[i]*y_coordinates[j]+
                            x_coordinates[j]*y_coordinates[k]+
                            x_coordinates[k]*y_coordinates[i]
                            -y_coordinates[j]*x_coordinates[k]
                            -x_coordinates[i]*x_coordinates[k]
                            -y_coordinates[i]*x_coordinates[j]))/2;
                        if (Arie<Arie_min&& Arie!=0)
                        {
                            Arie_min=Arie;
                            xmin1=x_coordinates[i];
                            ymin1=y_coordinates[i];
                            xmin2=x_coordinates[j];
                            ymin2=y_coordinates[j];
                            xmin3=x_coordinates[k];
                            ymin3=y_coordinates[k];
                        }
                    }

                }
            }
            Point[] pnt = new Point[3];
            pnt[0].X=xmin1;
            pnt[0].Y=ymin1;
            pnt[1].X=xmin2;
            pnt[1].Y=ymin2;
            pnt[2].X=xmin3;
            pnt[2].Y=ymin3;
            e.Graphics.DrawPolygon(pen, pnt);

        }

    }
}