using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_2
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {

        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillRectangle(Brushes.OrangeRed, Pos.X, Pos.Y, Size.Height, Size.Width);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X > Game.Width)
            {
                Pos.X = Size.Width;
                Pos.Y = new Random().Next(Size.Height, Game.Height);
            }
        }

        internal void Reset()
        {
            this.Pos.X = Game.Width + 1;
            Update();
        }
    }
}
