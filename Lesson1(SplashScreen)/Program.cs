using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lesson1_SplashScreen_
{
    static class Program
    {
        static void Main()
        {
            var form = new Form() { Width = 800, Height = 600 };
            SplashScreen.Init(form);
            form.Show();
            SplashScreen.Draw();
            Application.Run(form);
        }
    }
}
