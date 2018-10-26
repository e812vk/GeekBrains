using System.Drawing;

namespace Lesson1
{
    class Planet3: BaseObject
    {
        public Planet3(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.FillEllipse(Brushes.Blue, new Rectangle(Pos.X, Pos.Y, Size.Height, Size.Width));
        }
        public override void Update()
        {
            Pos.X = Pos.X + Dir.X;
            if (Pos.X < 0) Pos.X = Game.Width + Size.Width;
        }
    }
}
