using System;
using System.Drawing;
using System.Windows.Forms;

namespace Lesson1_SplashScreen_
{
    static class SplashScreen
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        // Свойства: ширина и высота игрового поля
        public static int Width { get; set; }
        public static int Height { get; set; }

        public static BaseObject[] _objs;
        public static Button[] _btns;
        
        static SplashScreen()
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

            Timer timer = new Timer { Interval = 50 };
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
            _objs = new BaseObject[20];
            _btns = new Button[3];
            // Создаем объект класса Random для генерации случайной координаты Х для снежинок
            Random rnd = new Random();
            // Заполняем массив снежинок для заставки (начальная координата Х и скорость падения снежинки выбираются случайно
            for (int i = 0; i < _objs.Length; i++)
                _objs[i] = new BaseObject(new Point(rnd.Next(30, Width - 30), 0), new Point(0, rnd.Next(1, 10)), new Size(30, 30));
            // Заполняем массив кнопок с различными текстами и координатами
            int btn_heigth = 40;
            int btn_width = 150;
            int btn_pos_x = 30;
            int btn_pos_y = 490;
            _btns[0] = new Button(new Point(btn_pos_x, btn_pos_y), new Size(btn_heigth, btn_width), "Начало игры");
            _btns[1] = new Button(new Point(btn_pos_x + btn_width + 10, btn_pos_y), new Size(btn_heigth, btn_width), "Рекорды");
            _btns[2] = new Button(new Point(btn_pos_x + (btn_width + 10) * 2, btn_pos_y), new Size(btn_heigth, btn_width), "Выход");
        }
        
        public static void Draw()
        {
            // Устанавливаем серый цвет фона
            Buffer.Graphics.Clear(Color.Gray);
            // Отрисовываем каждую снежинку в массиве
            foreach (BaseObject obj in _objs)
                obj.Draw();
            // Рисуем кнопки
            foreach (Button btn in _btns)
                btn.Draw(new Rectangle(btn.X + btn.D, btn.Y, btn.H, btn.W));
            // Добавляем подпись студента
            SplashScreen.Buffer.Graphics.DrawString("ст. Альберт Арсланов", new Font("Arial", 12), Brushes.Black, Width - 200, Height - 60);
            // Создаем изображение
            Buffer.Render();
        }
        public static void Update()
        {
            // Обновляем координаты снежинок
            foreach (BaseObject obj in _objs)
                obj.Update();
        }
    }
}