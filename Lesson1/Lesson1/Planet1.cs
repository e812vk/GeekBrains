using System.Drawing;

namespace Lesson1
{
    class Planet1: BaseObject
    {
        public Planet1(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.SeaGreen, new Rectangle(Pos.X, Pos.Y, 50, 50));
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
