using System.Diagnostics;

namespace HomeWork4.ParallelSum
{
    internal static class TimingControl
    {
        public delegate int TimingDelegate();

        public static void MeasureTime(TimingDelegate TimingDelegate, string calculationType)
        {
            Stopwatch sw = Stopwatch.StartNew();

            sw.Start();

            var result = TimingDelegate();

            sw.Stop();

            Console.WriteLine();
            Logger.WriteDescription("Тип расчета" , $"{calculationType}");
            Logger.WriteDescription("Затраченное время", $"{sw.ElapsedMilliseconds} мс");
            Logger.WriteDescription("Сумма", $"{result.ToString("0,0")}");
        }
    }
}
