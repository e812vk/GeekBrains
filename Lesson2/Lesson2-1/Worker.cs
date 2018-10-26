using System;
using System.IO;

namespace Lesson2
{
    abstract class Worker : IComparable<Worker>
    {
        public string FirstName { get; }     // Имя
        public string LastName { get; }         // Фамилия
        public double Payment { get; set; }     // Ставка в час или в месяц
        public double Delta { get; set; }            // Средняя месячная ЗП рассчитывается методом GetDelta

        protected Worker()
        {
            FirstName = Path.GetRandomFileName().Replace(".", "");
            LastName = Path.GetRandomFileName().Replace(".", "");
        }

        abstract protected double GetDelta();
        abstract public int CompareTo(Worker other);
    }
}

