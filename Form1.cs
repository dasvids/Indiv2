﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        }
        //lowest point
        Point p0 = new Point();
        
        //points by user's clicks  
        List<Point> points = new List<Point>();

        List<Point> G = new List<Point>();


        int iter = 0; //counter for Graham
        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            g.FillEllipse(Brushes.Red, e.X - 3, e.Y - 3, 6, 6); //drawing point
            points.Add(e.Location);  //adding point to list 

            //
            //p0 = (e.Location.X >= p0.X && e.Location.X >= p0.Y) || iter == 0 ? e.Location : p0;
            /*if (iter == 0)
            {
                p0 = e.Location;
            }
            else if (e.Location.X > p0.X && e.Location.X > p0.Y)
            {
                p0 = e.Location;
            }*/
           

            iter++; //increase iteration 
            pictureBox1.Invalidate();

            if (iter >= 3 && checkBox1.Checked /*&& points.Distinct().Skip(1).Any()*/) //working only if 3 or more points
            {
                G = Graham(points);
                if (checkBox2.Checked)
                {
                    g.Clear(pictureBox1.BackColor);
                    g.FillPolygon(Brushes.Thistle, G.ToArray());
                }
                else
                {
                    g.Clear(pictureBox1.BackColor);
                    g.DrawPolygon(Pens.Thistle, G.ToArray()); 
                }
                points.ForEach(p => g.FillEllipse(Brushes.Red, p.X - 3, p.Y - 3, 6, 6)); //drawing points again, to overlay polygon
            }
        }

        //true if clockwise turn or collinear , false if counter-otherwise
        private static bool ccw(Point a, Point b, Point c) 
        {
            //return ((b.X - a.X) * (c.Y - a.Y)) > ((b.Y - a.Y) * (c.X - a.X));
            return ((b.X - a.X) * (c.Y - a.Y)) >= ((b.Y - a.Y) * (c.X - a.X));
        }

        List<Point> Graham(List<Point> G) //Graham scan
        {
            //p0 is min point by y and max by x
            p0 = G.OrderByDescending(p => p.Y).ThenByDescending(p => p.X).First(); // min point is max of picture box height abd width                       
            //groupby by polar angle relative p0
            //List<Point> P = G.Where(p => p != p0).OrderBy(x => alpha(x)).ToList();

            Stack<Point> stack = new Stack<Point>();
            
            // adding min point to stack
            stack.Push(p0);

            //loop for sorted points by polar angle
            G.Where(p => p != p0).OrderBy(x => alpha(x)).ToList().ForEach(p =>
            {
                while (stack.Count > 1 && ccw(next_to_top(stack), top(stack), p)) //going back if clockwise or collinear
                    stack.Pop();
                stack.Push(p);
            });

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
            if (points.Count >= 3 /*&& points.Distinct().Skip(1).Any()*/) //working only if 3 or more points
            {
                G = Graham(points);
                //g.FillPolygon(Brushes.Thistle, S.ToArray());
                g.Clear(pictureBox1.BackColor);
                if (checkBox2.Checked)
                    g.FillPolygon(Brushes.Thistle, G.ToArray());
                else g.DrawPolygon(Pens.Thistle, G.ToArray());
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
    }
}
