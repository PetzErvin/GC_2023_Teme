namespace Circle
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
            int n = random.Next(100);

            
            Pen pen = new Pen(Color.Blue, 5);
            Pen pen1 = new Pen(Color.Orange, 5);
            Pen pen2 = new Pen(Color.Red, 10);
            int[] x_coordinates = new int[n];
            int[] y_coordinates = new int[n];
            for (int i = 0; i < n; i++)
            {
                x_coordinates[i] = random.Next(100, 300);
                y_coordinates[i] = random.Next(100, 300);

                e.Graphics.DrawEllipse(pen1, x_coordinates[i], y_coordinates[i], 1, 1);
            }
            double DistMax = 0, dist ;
            double x_mid = 0, y_mid = 0;
            int xmax=0, xmin=0, ymax=0, ymin=0;
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i+1; j < n; j++)
                {
                    dist=Math.Sqrt(Math.Pow((x_coordinates[j]-x_coordinates[i]), 2)
                        +Math.Pow((y_coordinates[j]-y_coordinates[i]), 2));
                    if (dist>DistMax)
                    {
                        DistMax=dist;
                        x_mid=(x_coordinates[j]+x_coordinates[i])/2;
                        y_mid=(y_coordinates[j]+y_coordinates[i])/2;
                        xmax=x_coordinates[j];
                        xmin=x_coordinates[i];
                        ymax=y_coordinates[j];
                        ymin=y_coordinates[i];
                    }
                }
            }
            
            double radius_max;
            for (int i=0; i<n; i++)
            {
                radius_max=Math.Sqrt((Math.Pow((x_coordinates[i]-x_mid), 2)+Math.Pow((y_coordinates[i]-y_mid), 2)));
                if (radius_max>DistMax/2)
                   DistMax=radius_max*2;
                
            }
            int x = (int)x_mid;
            int y = (int)y_mid;
            int radius = (int)DistMax/2;
            e.Graphics.DrawEllipse(pen2, x, y, 1,1);
            e.Graphics.DrawEllipse(pen, x-radius, y-radius, radius*2, radius*2);
            //e.Graphics.DrawLine(pen1, xmax, ymax, xmin, ymin);
            
        }
    }
}