namespace HomeWork4.ParallelSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintInfoPC.PrintSystemInfo();

            List<int> collectionSizes = [100_000, 1_000_000, 10_000_000];

            foreach (int i in collectionSizes) 
            {
                Logger.WriteTitle($"_______________Расчет коллекции с {i.ToString("0,0")} записями_______________");

                var list = Generator.GenerateList(i).ToList();
                TimingControl.MeasureTime(() => Calculation.SequentialSum(list), "Расчет суммы коллекции последовательно");

                TimingControl.MeasureTime(() => Calculation.ParallelSum(list), "Расчет суммы коллекции параллельно");

                TimingControl.MeasureTime(() => Calculation.LinqSum(list), "Расчет суммы коллекции при помощи PLINQ");

                TimingControl.MeasureTime(() => Calculation.ThreadSum(list, 10), "Расчет суммы коллекции при помощи потоков");
            }
        }
    }
}
