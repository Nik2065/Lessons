using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ConsoleApp2
{
    class FlickeringStar:BaseObject
    {
        public FlickeringStar(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        private Size _lastSize;
        private int Max = 10;
        private int Min = 4;
        //private 

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X, Pos.Y, Pos.X + Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.White, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            var img = Image.FromFile("fStar.png");
            img = resizeImage(img, Size);

            Game.Buffer.Graphics.DrawImage(img, Pos);
        }


        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
            }
            //меняем размер

        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

    }
}
