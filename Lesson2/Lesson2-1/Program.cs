using System;

namespace Lesson2
{
    static class Program
    {
        static void Main()
        {
            var rnd = new Random();
            var count = 5;
            Worker[] list = new Worker[count];

            for (int i = 0; i < count - 1; i++)
            {
                list[i] = new WorkerByHours(rnd.Next(100, 3500));
                list[i + 1] = new WorkerByMonth(rnd.Next(10000, 50000));
            }

            Draw(list, "Несортированный список\r\n");
            Array.Sort(list); 
            Draw(list, "\r\nCортированный список\r\n");
        }
        public static void Draw(Worker[] list, string comment)
        {
            Console.WriteLine(comment);
            foreach (var item in list)
            {
                Console.WriteLine($"Имя: {item.FirstName} \tФамилия: {item.LastName} \tСтавка: {item.Payment} \tСредняя месячная ЗП: {item.Delta}");
            }
        }
    }
}
