using System.Windows.Forms;

// Создаем шаблон приложения, где подключаем модули

namespace Lesson1
{
    class Program
    {
        static void Main(string[] args)
        {
            var form = new Form() {Width = 800, Height = 600};
            Game.Init(form);
            form.Show();
            Game.Draw();
            Application.Run(form);
        }
    }
}