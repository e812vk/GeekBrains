using System;

namespace Lesson2
{
    class WorkerByHours : Worker, IComparable<Worker>
    {
        public WorkerByHours(double _payment)
        {
            Payment = _payment;
            Delta = GetDelta();
        }

        public override int CompareTo(Worker other)
        {
            return other.Delta > this.Delta ? 1 : -1;
        }

        protected override double GetDelta()
        {
            return this.Payment * 20.8 * 8;         // Расчет средней месячной ставки производится по формуле из методички
        }
    }
}
