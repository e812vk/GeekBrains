using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson2_2
{
    class Asteroid : BaseObject
    {
        public int Power { get; set; }
        public Asteroid (Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
        }
        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y, Size.Height, Size.Width);
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0)
            {
                Pos.X = Game.Width + Size.Width;
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
