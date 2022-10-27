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
        //lowest point (max coorinates point of picturebox)
        Point p0 = new Point();
        
        //points by user's clicks
        List<Point> points = new List<Point>();      
        
        //iteration
        int iter = 0; 
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            //Draw point
            g.FillEllipse(Brushes.Red, e.X - 3, e.Y - 3, 6, 6);
            //adding point to list 
            points.Add(e.Location);
            //increase iteration 
            iter++; 
            //updationg changes 
            pictureBox1.Invalidate();
            //if points 3 or more doing graham scan
            if (iter >= 3 && checkBox1.Checked) 
            {
                //result of Graham Scan
                List<Point> S = Graham(points); 
                //drawing polygon by points, selected by graham scan
                g.FillPolygon(Brushes.Thistle, S.ToArray());
                //drawing points again, to overlay polygon
                points.ForEach(p => g.FillEllipse(Brushes.Red, p.X - 3, p.Y - 3, 6, 6)); 
            }
        }
        // 0 if clockwise turn, 1 if counter-otherwise
        private static bool ccw(Point a, Point b, Point c) 
        {
            //return ((b.X - a.X) * (c.Y - a.Y)) > ((b.Y - a.Y) * (c.X - a.X));
            return ((b.X - a.X) * (c.Y - a.Y)) > ((b.Y - a.Y) * (c.X - a.X));
        }
        List<Point> Graham(List<Point> G) //Graham scan
        {
            //p0 is min point by y and max by x
            p0 = G.OrderByDescending(p => p.Y).ThenByDescending(p => p.X).First(); // min point is max of picture box height abd width          
            //groupby by polar angle relative p0 (sorting)
            List<Point> P = G.Where(p => p != p0).OrderBy(x => alpha(x)).ToList();
            // stack of final points 
            Stack<Point> stack = new Stack<Point>();
            //inserting min point
            stack.Push(p0);
            P.ForEach(p =>
            {
                while (stack.Count > 1 && ccw(next_to_top(stack), top(stack), p))
                {
                    stack.Pop();
                }
                stack.Push(p);
            });
            return stack.ToList();
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
                g.FillPolygon(Brushes.Thistle, S.ToArray());
                points.ForEach(p => g.FillEllipse(Brushes.Red, p.X - 3, p.Y - 3, 6, 6)); //drawing points again, to overlay polygon
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
