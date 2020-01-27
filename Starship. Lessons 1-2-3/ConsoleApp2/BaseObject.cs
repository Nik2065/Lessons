using System;
using System.Drawing;

namespace ConsoleApp2
{
    abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        //public virtual void Draw()
        //{
        //    Game.Buffer.Graphics.DrawEllipse(Pens.White, Pos.X, Pos.Y, Size.Width, Size.Height);
        //}

        public virtual void Update()
        {
            //Pos.X = Pos.X + 2;
            //Pos.Y = 0;

            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;

            var canShow = "";
            if (Pos.X > 0 && Pos.X < Game.Width && Pos.Y > 0 && Pos.Y < Game.Height)
            {
                canShow = "Отображается";
            }
            else
            {
                canShow = "Не отображается";
            }

            Console.WriteLine($"X={Pos.X}| Y={Pos.Y} {canShow}");
        }


        // Так как переданный объект тоже должен будет реализовывать интерфейс ICollision, мы 
        // можем использовать его свойство Rect и метод IntersectsWith для обнаружения пересечения с
        // нашим объектом (а можно наоборот)
        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);

        public Rectangle Rect => new Rectangle(Pos, Size);

    }

}

