namespace Lesson2
{
    class WorkerByMonth : Worker
    {
        public WorkerByMonth(double _payment)
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
            return this.Payment;
        }
    }
}
