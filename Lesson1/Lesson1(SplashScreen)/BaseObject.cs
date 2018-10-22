using System;
using System.Drawing;

namespace Lesson1_SplashScreen_
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public virtual void Draw()
        {
            SplashScreen.Buffer.Graphics.DrawImage(Image.FromFile("images/star.png"), Pos.X, Pos.Y, Size.Height, Size.Width); // Отрисовка снежинки
        }
        public void Update()
        {
            Pos.Y = Pos.Y + Dir.Y;                  // Алгоритм перемещения снежинки (сверху вниз)
            if (Pos.Y > SplashScreen.Height)
            {
                Pos.Y = 0;                          // Базовая позиция по оси Y для каждой снежинки
                Pos.X = new Random().Next(0, 800);  // случайный выбор координаты по оси Х
                Dir.Y = new Random().Next(1, 10);   // случайный выбор скорости падения снежинок
            }
        }
    }
}
