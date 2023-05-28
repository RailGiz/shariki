using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Animator
    {
        private Circle? c;
        Random rnd = new Random();
        public Rect? r;
        private Thread? t = null;
        public bool IsAlive => t == null || t.IsAlive;
        public Size ContainerSize { get; set; }
        private object locker = new();
        public Animator(Size containerSize, int x, int y, int id)
        {
            r = new Rect(75, x, y, id);
            ContainerSize = containerSize;
        }

        public Animator(Size containerSize, Rect r, List<Circle> List_circles)
        {
            c = new Circle(r.Diam, r.X, r.Y, r.id);
            ContainerSize = containerSize;
            lock (locker) {
                List_circles.Add(c);
            }
            
        }

        public void Start(List<Circle> List_circles, Database db)
        {
            t = new Thread(() =>
            {
                if (c != null)
                {
                    int dx = 0;
                    int dy = 0;
                    while (dx == 0 && dy == 0)
                    {
                        dx = rnd.Next(-2, 2);
                        dy = rnd.Next(-2, 2);
                    }
                    while ((c.X + c.Diam < ContainerSize.Width) && (c.Y + c.Diam < ContainerSize.Height))
                    {
                        Thread.Sleep(30);
                        lock (locker)
                        {

                            c.Move(dx, dy);
                        
                            if (compare(c, List_circles, db))

                                break;
                        }
                    }
                    lock (locker)
                    {
                        List_circles.Remove(c);
                    }
                  
                }
                if (r != null)
                {
                    while (true)
                    {
                        Thread.Sleep(30);
                    }
                }
            });
            t.IsBackground = true;
            t.Start();
        }
        public bool compare(Circle c, List<Circle> List_circles,Database db)
        {

                foreach (Circle i in List_circles)
                {

                    if ((leng(c, i) <= c.Diam) && (c.id != i.id))
                    {
                        db = new Database("localhost", "postgres", "ВАШ ПАРОЛЬ", "db_circles", false);
                        db.update_score(i.id);
                        return true;


                    }
                }
            
            return false;
                
        }
        private static double leng(Circle c, Circle i)
        {
            int rad = c.Diam / 2;
            int xc = c.X + rad;
            int yc = c.Y + rad;
            int xi = i.X + rad;
            int yi = i.Y + rad;
            double length = Math.Sqrt(Math.Pow(xi - xc, 2) + Math.Pow(yi - yc, 2));
            return (length);
        }

        public void PaintCircle(Graphics g)
        {
            if (c != null)
            {
                c.Paint(g);
            }
            else if (r != null)
            {
                r.Paint(g);
            }
        }
    }
}
