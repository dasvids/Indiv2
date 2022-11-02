using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
            g.SmoothingMode = SmoothingMode.AntiAlias;
        }
        //lowest point
        Point p0 = new Point();

        //points by user's clicks  
        List<Point> points = new List<Point>();
        // result list of hull
        List<Point> G = new List<Point>();


        int iter = 0; //counter for Graham
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                g.FillEllipse(Brushes.Red, e.X - 3, e.Y - 3, 6, 6); //drawing point

                points.Add(e.Location);  //adding point to list 
                PointsCount.Text = (int.Parse(PointsCount.Text) + 1).ToString();

                p0 = IsNewMin(e.Location) ? e.Location : p0;

                iter++; //increase iteration 
                pictureBox1.Invalidate();

                if (iter >= 3 && checkBox1.Checked && points.Distinct().Count() != 1 && points.Count < 10000) //working only if 3 or more points
                {
                    G = Graham(points);
                    Draw(G);                   
                }
            }
            
        }

        private bool IsNewMin(Point e) => iter == 0 || (e.Y > p0.Y || (e.Y == p0.Y && e.X > p0.X));
        /*{
            *//*if (iter == 0)
            {
                return true;
            }
            else
            {
                if (e.Y > p0.Y)
                {
                    return true;
                }
                else if (e.Y == p0.Y)
                {
                    return e.X > p0.X ? true : false;
                }
                else return false;
            }*//*
            //return iter == 0 || (e.Y > p0.Y || (e.Y == p0.Y && e.X > p0.X));
        }*/

        //true if clockwise turn or collinear , false if counter-otherwise
        private static bool ccw(Point a, Point b, Point c) => ((b.X - a.X) * (c.Y - a.Y)) >= ((b.Y - a.Y) * (c.X - a.X));

        List<Point> Graham(List<Point> G) //Graham scan
        {
            //p0 is min point by y and max by x
            if (IsMouseDown || checkBox1.Checked || PlaceCountBox.Text != null)
                p0 = G.OrderByDescending(p => p.Y).ThenByDescending(p => p.X).First(); // min point is max of picture box height abd width                       
            //groupby by polar angle relative p0
            //List<Point> P = G.Where(p => p != p0).OrderBy(x => alpha(x)).ToList();

            Stack<Point> stack = new Stack<Point>();

            // adding min point to stack
            stack.Push(p0);



            //loop for sorted points by polar angle
            G.Where(p => p != p0).OrderBy(p => alpha(p)).ToList().ForEach(p =>
            {
                while (stack.Count > 1 && ccw(next_to_top(stack), stack.Peek(), p)) //going back if clockwise or collinear              
                    stack.Pop();
                stack.Push(p);
            });
            HullCount.Text = stack.Count.ToString();
            return stack.ToList();
        }

        private Point next_to_top(Stack<Point> stack)
        {
            Point p = stack.Pop();
            //stack.Pop();
            Point next = stack.Pop();
            //stack.Pop();
            stack.Push(next);
            stack.Push(p);
            return next;
        }


        double alpha(Point p) //polar angle
        {
            double alph = Math.Atan2(p0.Y - p.Y, p.X - p0.X);
            return alph < 0 ? alph + 2 * Math.PI : alph;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (points.Count >= 3 && points.Distinct().Count() != 1) //working only if 3 or more points
            {
                G = Graham(points);
                Draw(G);
            }
        }

        private void Draw(List<Point> G)
        {
            g.Clear(pictureBox1.BackColor);
            if (checkBox2.Checked)
                g.FillPolygon(Brushes.Thistle, G.ToArray());
            else g.DrawPolygon(Pens.Thistle, G.ToArray());
            //points.ForEach(p => g.FillEllipse(Brushes.Red, p.X - 3, p.Y - 3, 6, 6)); //drawing points again, to overlay polygon
            DrawPoints(points);
            pictureBox1.Invalidate();
        }
        private void DrawPoints(List<Point> lp) 
        { 
            lp.ForEach(p => g.FillEllipse(Brushes.Red, p.X - 3, p.Y - 3, 6, 6));
            pictureBox1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            points.Clear();
            G.Clear();
            g.Clear(pictureBox1.BackColor);
            pictureBox1.Invalidate();
            iter = 0;
            HullCount.Text = 0.ToString();
            PointsCount.Text = 0.ToString();
        }

        private bool IsMouseDown = false;
        private int MoveInd;
        private bool AreaSelect = false;
        (Point, Point) RectSelect = (new Point(), new Point());
        private bool DontPutNextPoint = false;
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && points.Count > 0)
            {
                MoveInd = points.FindIndex(p => PointIsNear(p, e.Location));
                IsMouseDown = MoveInd != -1;
            }

            /*if (e.Button == MouseButtons.Left)
            {
                 AreaSelect = true;
                 RectSelect.Item1 = e.Location;
                 DontPutNextPoint = true;
            }*/
        }

        bool PointIsNear(Point p0, Point e) => Math.Abs(p0.X - e.X) < 4 && Math.Abs(p0.Y - e.Y) < 4;
        
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
            AreaSelect = false;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (IsMouseDown)
            {
                int x = e.X > pictureBox1.Width ? pictureBox1.Width-3 : e.X < 0 ? 0 : e.X;
                int y = e.Y > pictureBox1.Height ? pictureBox1.Height-3 : e.Y < 0 ? 0 : e.Y;
                points[MoveInd] = new Point(x, y);
                if (G.Count >2)
                {
                    G = Graham(points);
                    Draw(G);
                }
                else
                {
                    g.Clear(pictureBox1.BackColor);
                    DrawPoints(points);
                }
                

                /*if (AreaSelect)
                {
                    g.Clear(pictureBox1.BackColor);
                    RectSelect.Item2 = e.Location;
                    g.FillRectangle(Brushes.AliceBlue, RectSelect.Item1.X, RectSelect.Item1.Y, -(RectSelect.Item1.X - RectSelect.Item2.X), -(RectSelect.Item1.Y - RectSelect.Item2.Y));
                    pictureBox1.Invalidate();
                }*/
            }
        }
        Random rand = new Random();
        //Random Yrand = new Random();
        private void button3_Click(object sender, EventArgs e)
        {
            //int PlaceCnt = int.Parse(PlaceCountBox.Text);
            if (int.TryParse(PlaceCountBox.Text, out int PlaceCnt))
            {
                //PlaceCnt = PlaceCnt < 0 ? Math.Abs(PlaceCnt) : PlaceCnt;
                PlaceCnt = PlaceCnt > 1000 ? 1000 : Math.Abs(PlaceCnt);
                PlaceCountBox.Text = PlaceCnt.ToString();
                for (int i = 0; i < PlaceCnt; i++)
                {
                    int xrnd = rand.Next(10, pictureBox1.Width - 10);
                    int yrnd = rand.Next(10, pictureBox1.Height - 10);
                    Point rndPoint = new Point(xrnd, yrnd);
                    if (points.Count < pictureBox1.Width * pictureBox1.Height/10) 
                    {
                        points.Add(rndPoint);
                        g.FillEllipse(Brushes.Red, rndPoint.X - 3, rndPoint.Y - 3, 6, 6);
                    }
                    //p0 = IsNewMin(rndPoint) ? rndPoint : p0;
                }

                PointsCount.Text = points.Count.ToString();
                if (checkBox1.Checked && points.Count >= 3)
                {
                    G = Graham(points);
                    Draw(G);
                }
                //pictureBox1.Invalidate();
            }
        }

        private void pictureBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                int DeleteId = points.FindIndex(p => PointIsNear(p, e.Location));
                int DeleteHullId = G.FindIndex(h => PointIsNear(h, e.Location));
                
                if (DeleteHullId != -1)
                {
                    G.RemoveAt(DeleteHullId);                   
                }
                if (DeleteId != -1)
                {
                    points.RemoveAt(DeleteId);
                    PointsCount.Text = points.Count.ToString();
                }

                if (G.Count > 2)
                {
                    G = Graham(points);
                    Draw(G);
                }
                else
                {
                    g.Clear(pictureBox1.BackColor);
                    DrawPoints(points);
                }
            }
        }
    }
}
