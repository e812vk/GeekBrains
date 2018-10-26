using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lesson2_2
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
            // Исключение при превышении заданных или отрицательных размеров в виде диалогового окна перед запуском анимации
            try
            {
                if (form.Width > 1000 || form.Height > 1000 || form.Width < 0 || form.Height < 0) throw new ArgumentOutOfRangeException();
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ширина или высота экрана превышают 1000 px или меньше нуля.");
            }
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

        private static Bullet _bullet;          // Переменная для снаряда
        private static Asteroid[] _asteroids;   // Массив для астероидов
        
        public static void Load()
        {
            try
            {
                _objs = new BaseObject[28];
                _asteroids = new Asteroid[5];
                // Объект класса Random для установки случайных координат создания объектов
                var rnd = new Random();
                // Создание звезд 10 шт
                for (int i = 0; i < 10; i++)
                    _objs[i] = new Star(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(-8, 0), new Size(3, 3));
                // Создание ярких свезд 15 шт
                for (int i = 10; i < 25; i++)
                    _objs[i] = new BigStar(new Point(rnd.Next(0, Width), rnd.Next(0, Height)), new Point(-10, 0), new Size(5, 5));
                // Создание планет 3 шт
                _objs[25] = new Planet1(new Point(rnd.Next(0, Width), Height / 3), new Point(-5, 0), new Size(40, 40));
                _objs[26] = new Planet2(new Point(rnd.Next(0, Width), Height - Height / 3), new Point(-8, 0), new Size(35, 35));
                _objs[27] = new Planet3(new Point(rnd.Next(0, Width), Height - Height / 5), new Point(-10, 0), new Size(50, 50));
                // Создание астероидов 3 шт
                for (int i = 0; i < _asteroids.Length; i++)
                {
                    int r = rnd.Next(0, 50);
                    int y = rnd.Next(10, Height);
                    _asteroids[i] = new Asteroid(new Point(Width, y), new Point(-r - 1, 0), new Size(20, 20));
                }
                // Создание снаряда 1 шт
                _bullet = new Bullet(new Point(0, 500), new Point(51, 0), new Size(10, 40));
                foreach (var item in _objs)
                {
                    if (item.Pos.X < 0 || item.Pos.Y < 0 || item.Dir.X < - 50) throw new GameObjectException();
                }
                foreach (var item in _asteroids)
                {
                    if (item.Pos.X < 0 || item.Pos.Y < 0 || item.Dir.X < -50) throw new GameObjectException();
                }
                if (_bullet.Pos.X < 0 || _bullet.Pos.Y < 0 || _bullet.Dir.X > 50) throw new GameObjectException();
            }
            catch
            {
                
            }
        }

        public static void Draw()
        {
            Buffer.Graphics.Clear(Color.Black);
            foreach (BaseObject obj in _objs)
                obj.Draw();
            foreach (BaseObject obj in _asteroids)
                obj.Draw();
            _bullet.Draw();
            Buffer.Render();
        }
        public static void Update()
        {
            foreach (BaseObject obj in _objs) obj.Update(); // Движение небесных тел
            _bullet.Update();                               // Движение снаряда

            foreach (Asteroid asteroid in _asteroids)       // Движение астероидов
            {
                asteroid.Update();
                if (asteroid.Collision(_bullet))
                {
                    System.Media.SystemSounds.Beep.Play();
                    _bullet.Reset();
                    asteroid.Reset();
                    return;
                }
            }
        }
    }
}
