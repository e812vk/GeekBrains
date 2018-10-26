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
            _objs = new BaseObject[28];
            var rnd = new Random();
            // Создание звезд 10 шт
            for (int i = 0; i < 10; i++)
                _objs[i] = new Star(new Point(rnd.Next(0,800), rnd.Next(0, 600)), new Point(-3, 0), new Size(3, 3));
            // Создание ярких свезд 15 шт
            for (int i = 10; i < 25; i++)
                _objs[i] = new BigStar(new Point(rnd.Next(0, 800), rnd.Next(0, 600)), new Point(- 10, 0), new Size(5, 5));
            // Создание планет
            _objs[25] = new Planet1(new Point(rnd.Next(0, 800), 150), new Point(-5, 0), new Size(40, 40));
            _objs[26] = new Planet2(new Point(rnd.Next(0, 800), 100), new Point(-8, 0), new Size(35, 35));
            _objs[27] = new Planet3(new Point(rnd.Next(0, 800), 400), new Point(-10, 0), new Size(50, 50));
        }

        public static void Draw()
        {
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