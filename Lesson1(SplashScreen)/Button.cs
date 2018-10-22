using System;
using System.Drawing;

namespace Lesson1_SplashScreen_
{
    class Button : BaseObject
    {
        private string text; // Переменная для подписи кнопок
        public int X
        {
            get { return Pos.X; }
        }
        public int Y
        {
            get { return Pos.Y; }
        }
        public int H
        {
            get { return Size.Height; }
        }
        public int W
        {
            get { return Size.Width; }
        }
        public int D
        {
            get { return Dir.X; }
        }
        public Button(Point pos, Point dir, Size size, String _text) : base (pos, dir, size)
        {
            text = _text; // Определяем дополнительную переменную text для объекта Button, остальные переменные наследуются из базового класса
        }
        public Button(Point pos, Size size, String _text) : this(pos, Point.Empty, size, _text)
        {           
        }
        public void Draw(Rectangle rect)
        {
            SplashScreen.Buffer.Graphics.FillRectangle(Brushes.Black, rect); // Рисуем кнопки
            SplashScreen.Buffer.Graphics.DrawString(text, new Font("Arial", 14), Brushes.White, rect.X + 15, rect.Y+7); // Рисуем текст на кнопках
        }

    }
}
