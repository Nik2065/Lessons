﻿using System;
using System.Drawing;

namespace ConsoleApp2
{
    class Star : BaseObject
    {
        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
            if (Pos.X > Game.Width) Pos.X = 0;

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

    }
}
