using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _2D_Maximum
{
    class Point : IComparable<Point>
    {
        private int x, y;
        public int X
        {
            get { return x; }
     
        }
        public int Y
        {
            get { return y; }
        }

        public Point(int x,int y)
        {
            this.x = x;
            this.y = y;
        }
        
        public static Point[] getRandomPoints(int numberOfPoints)
        {
            Point[] points=new Point [numberOfPoints];
            var rand = new Random();
            for (int i = 0; i < numberOfPoints; i++)
            {
               
                points[i] = new _2D_Maximum.Point(rand.Next(), rand.Next());
                
            }
            return points;
        }

        public bool dominatesOver(Point p)
        {
            return x >= p.X && y >= p.Y;
        }

        public override string ToString()
        {
            return "X: " + x + " Y:" + y;
        }

        public int CompareTo(Point p)
        {
            if (x > p.X) return -1;
            else if (x == p.X) return 0;
            return 1;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            var points = Point.getRandomPoints(1000000);
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            printMaximumPoints(points);
            stopwatch.Stop();
            Console.WriteLine("It took  to find maximums"+stopwatch.Elapsed);
            stopwatch.Reset();
            stopwatch.Start();
            printMaximumPointsv2(points);
            stopwatch.Stop();
            Console.WriteLine("It took  to find maximums" + stopwatch.Elapsed);
            Console.ReadKey();
        }

        public static void printMaximumPoints(Point[] points)
        {
            for(int i = 0; i < points.Length; i++)
            {
                bool max = true;
                for(int j= 0; j < points.Length; j++)
                {
                    
                    if (points[i]!=points[j] && points[j].dominatesOver(points[i]))
                    {
                        max = false;
                        break;
                    }
                }
                if (max)
                {
                    Console.WriteLine("I've found maximum:"+points[i]);
                }
            }
        }

        public static void printMaximumPointsv2(Point[] points)
        {
            Array.Sort(points);
            var s = new Stack<Point>();
            for(int i = 0; i < points.Length; i++)
            {
                while(s.Count>0 && s.Peek().Y < points[i].Y)
                {
                    s.Pop();
                }
                s.Push(points[i]);
            }
            for(int i = 0; i < s.Count; i++) {
                Console.WriteLine(s.Pop());
            }
        }
    }
}
