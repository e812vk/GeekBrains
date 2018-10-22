using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lesson1
{
    static class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        // Свойства: ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }


        public static BaseObject[] _objs;
        
        static Game()
        {
        }
        public static void Init(Form form)
        {
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
            // Инициализируем объекты
            Load();

            Timer timer = new Timer { Interval = 100 };
            timer.Start();
            timer.Tick += Timer_Tick;

        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }

        public static void Load()
        {
            _objs = new BaseObject[30];

            // Окружности заменены на изображения звезд
            for (int i = 0; i < _objs.Length / 3; i++)
                _objs[i] = new BaseObject(new Point(600, 100 + i * 20), new Point(-i - 5, -i - 5), new Size(30, 30));

            for (int i = _objs.Length / 3; i < _objs.Length; i++)
                _objs[i] = new Star(new Point(600, 150 + i * 20), new Point(-i, +i), new Size(5, 5));
            
            // Создание ярких свезд
            for (int i = _objs.Length - _objs.Length / 3; i < _objs.Length - 4; i++) // i < _objs.Length - 4 потому что добавляется еще 3 планеты
                _objs[i] = new BigStar(new Point(600, i * 10), new Point(-i - 5, 0), new Size(5, 5));
            // Создание планет
            _objs[_objs.Length - 3] = new Planet1(new Point(600, 10), new Point(-15, 0), new Size(5, 5));
            _objs[_objs.Length - 2] = new Planet2(new Point(600, 150), new Point(-5, 0), new Size(5, 5));
            _objs[_objs.Length - 1] = new Planet3(new Point(600, 400), new Point(-20, 0), new Size(5, 5));
        }

        public static void Draw()
        {
            // Проверяем вывод графики
            //Buffer.Graphics.Clear(Color.Black);
            //Buffer.Graphics.DrawRectangle(Pens.White, new Rectangle(100, 100, 200, 200));
            //Buffer.Graphics.FillEllipse(Brushes.Wheat, new Rectangle(100, 100, 200, 200));
            //Buffer.Render();

            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
    }
}