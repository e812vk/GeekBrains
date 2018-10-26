using System.Drawing;

namespace Lesson1
{
    class Planet2: BaseObject
    {
        public Planet2(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Red, new Rectangle(Pos.X, Pos.Y, Size.Height, Size.Width));
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
