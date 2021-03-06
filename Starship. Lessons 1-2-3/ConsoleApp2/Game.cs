﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ConsoleApp2
{
    static class Game
    {
        static readonly Image _backgroungImage = Image.FromFile("space.jpg");
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;
        // Свойства
        // Ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static BaseObject[] _objs;
        private static Bullet _bullet;
        private static Asteroid[] _asteroids;


        public static void Load()
        {
            _objs = new BaseObject[30];
            _bullet = new Bullet(new Point(0, 200), new Point(5, 0), new Size(4, 1));
            _asteroids = new Asteroid[3];
            var rnd = new Random();

            for (var i = 0; i < _objs.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _objs[i] = new Star(new Point(100, rnd.Next(0, Game.Height)), new Point(-r, r), new Size(3, 3));
            }

            for (var i = 0; i < _asteroids.Length; i++)
            {
                int r = rnd.Next(5, 50);
                _asteroids[i] = new Asteroid(new Point(200, rnd.Next(0, Game.Height)), new Point(-r / 5, r), new Size(r, r));
            }


        }

        
        public static void Init(Form form)
        {
           //добавим проверку на размеры формы
            if (form.ClientSize.Width < 0 
                || form.ClientSize.Height<0 
                || form.ClientSize.Width>1000 
                || form.ClientSize.Height>1000)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            
            
            // Графическое устройство для вывода графики            
            Graphics g;
            // Предоставляет доступ к главному буферу графического контекста для текущего приложения
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            // Создаем объект (поверхность рисования) и связываем его с формой
            // Запоминаем размеры формы
            Width = form.ClientSize.Width;
            Height = form.ClientSize.Height;
            // Связываем буфер в памяти с графическим объектом, чтобы рисовать в буфере
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Height));
            
            Load();
            Timer timer = new Timer { Interval = 1000 };
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            Buffer.Graphics.DrawImage(_backgroungImage, new Point(0, 0));

            foreach (BaseObject obj in _objs)
                obj.Draw();

            foreach (Asteroid obj in _asteroids)
                obj.Draw();

            _bullet.Draw();
            Buffer.Render();
        }

        public static void Update()
        {
            foreach (BaseObject obj in _objs)
            {
                obj.Update();
            }

            foreach (Asteroid a in _asteroids)
            {
                a.Update();
                if (a.Collision(_bullet)) { System.Media.SystemSounds.Hand.Play(); }
            }

            _bullet.Update();

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

    }
}
