using System.Collections.Generic;

namespace _2kL_2023_02_09_AnimDblBfr
{
    public class Painter
    {
        private object locker = new();
        private List<Animator> animators = new();
        private Size containerSize;
        private Thread t;
        private Graphics mainGraphics;
        private BufferedGraphics bg;
        private bool isAlive;
        public List<Circle> List_circles = new();

        private volatile int objectsPainted = 0;
        public Thread PainterThread => t;
        public Graphics MainGraphics
        {
            get => mainGraphics;
            set
            {
                lock (locker)
                {
                    mainGraphics = value;
                    ContainerSize = mainGraphics.VisibleClipBounds.Size.ToSize();
                    bg = BufferedGraphicsManager.Current.Allocate(
                        mainGraphics, new Rectangle(new Point(0, 0), ContainerSize)
                    );
                    objectsPainted = 0;
                }
            }
        }

        public Size ContainerSize
        {
            get => containerSize;
            set
            {
                containerSize = value;
                foreach (var animator in animators)
                {
                    animator.ContainerSize = ContainerSize;
                }
            }
        }

        public Painter(Graphics mainGraphics)
        {
            MainGraphics = mainGraphics;
        }

        public void AddNew(int x, int y, int id, Database db)
        {
            t = new Thread(() =>
            {
               db.add_rect(id);
                var a = new Animator(ContainerSize, x, y, id);
                animators.Add(a);
                a.Start(List_circles, db);
                for (int i = 0; i < 20; i++)
                {
                   
                    
                      var  b = new Animator(ContainerSize, a.r, List_circles);
                    lock (locker)
                    {
                        animators.Add(b);
                    }
                        b.Start(List_circles, db);
                        Thread.Sleep(1500);
                    
                }
            }


        );
            t.Start();

        }

        public void Start()
        {
            isAlive = true;
            t = new Thread(() =>
            {
                try
                {
                    while (isAlive)
                    {
                        
                        lock (locker)
                        {
                            animators.RemoveAll(it => !it.IsAlive);
                            if (PaintOnBuffer())
                            {
                                bg.Render(MainGraphics);
                            }
                        }
                        if (isAlive) Thread.Sleep(30);
                    }
                }
                catch (ArgumentException e) { }
            });
            t.IsBackground = true;
            t.Start();
        }

        public void Stop()
        {
            isAlive = false;
            t.Interrupt();
        }

        private bool PaintOnBuffer()
        {
            objectsPainted = 0;
            var objectsCount = animators.Count;
            bg.Graphics.Clear(Color.White);
            foreach (var animator in animators)
            {
                animator.PaintCircle(bg.Graphics);
                objectsPainted++;
            }

            return objectsPainted == objectsCount;
        }
    }
}
