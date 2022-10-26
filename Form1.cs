using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Indiv2
{
    public partial class Form1 : Form
    {
        Graphics g;
        Color color;
        Pen pen;
        public Form1()
        {
            InitializeComponent();

            pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(pictureBox1.Image);
            color = Color.Black;
            pen = new Pen(color);
        }
        //lowest point
        Point p0 = new Point();
        
        //points by user's clicks  
        List<Point> points = new List<Point>();      
        
        int iter = 0; //counter for Graham
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            g.FillEllipse(Brushes.Black, e.X - 2, e.Y - 2, 4, 4); //drawing point
            points.Add(e.Location);  //adding point to list 
            iter++; //increase iteration 
            pictureBox1.Invalidate();

            if (iter >= 3 && checkBox1.Checked) //working only if 3 or more points
            {
                List<Point> S = Graham(points); 
                g.FillPolygon(Brushes.SandyBrown, S.ToArray());
                points.ForEach(p => g.FillEllipse(Brushes.Black, p.X - 2, p.Y - 2, 4, 4)); //drawing points again, to overlay polygon
            }
        }
        /// <summary>
        /// dirrection, clockwise or counterclockwise
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns> 0 if clockwise turn, 1 if counter-otherwise</returns>
        private static bool ccw(Point a, Point b, Point c) 
        {
            return ((b.X - a.X) * (c.Y - a.Y)) > ((b.Y - a.Y) * (c.X - a.X));
        }
        List<Point> Graham(List<Point> Q) //Graham scan
        {
            //p0 is min point by y and max by x
            p0 = Q.OrderByDescending(p => p.Y).ThenByDescending(p => p.X).First(); // min point is max of picture box height abd width                       
            
            //groupby by polar angle relative p0
            List<Point> P = Q.Where(p => p != p0).OrderBy(x => alpha(x)).ToList();

            //failed up with stack ):, doing reverce loop in list instead ¯\_(ツ)_/¯ 
            /*Stack<Point> stack = new Stack<Point>();
            Q.ForEach(p =>
            {
                while (stack.Count > 1 && !ccw(next_to_top(stack), top(stack), p))
                    stack.Pop();
                stack.Push(p);
            });

            return stack.ToList();*/

            List<Point> h = new List<Point>();
            h.Add(p0);
            
            int t = h.Count + 1;
            for (int i = P.Count() - 1; i >= 0; i--)
            {
                Point p = P[i];
                while (h.Count >= t && !ccw(h[h.Count - 2], h[h.Count - 1], p))
                {
                    h.RemoveAt(h.Count - 1);
                }
                h.Add(p);
            }
            return h;
        }

        private Point next_to_top(Stack<Point> stack)
        {
            Point p = stack.Pop();
            Point next = stack.Pop();
            stack.Push(next);
            stack.Push(p);
            return next;
        }

        private Point top(Stack<Point> stack)
        {
            Point p = stack.Pop();
            stack.Push(p);
            return p;
        }

        double alpha(Point t) //polar angle
        { 
            double alph = Math.Atan2(p0.Y - t.Y, t.X - p0.X);
            return !(alph < 0) ? alph : alph + 2 * Math.PI;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (points.Count >= 3) //working only if 3 or more points
            {
                List<Point> S = Graham(points);
                g.FillPolygon(Brushes.SandyBrown, S.ToArray());
                points.ForEach(p => g.FillEllipse(Brushes.Black, p.X - 2, p.Y - 2, 4, 4)); //drawing points again, to overlay polygon
            }
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            points.Clear();
            g.Clear(pictureBox1.BackColor);
            pictureBox1.Invalidate();
            iter = 0;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
