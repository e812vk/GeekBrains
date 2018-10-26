using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson2_2
{
    class GameObjectException : Exception
    {
        public GameObjectException ()
        {
            MessageBox.Show("Обнаружена ошибка при создании объекта. Игра завершается.");
            Application.Exit();
        }
    }
}
