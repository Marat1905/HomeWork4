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
                var list = Generator.GenerateList(i).ToList();

               var sequentialSum = Calculation.SequentialSum<int>(list);
                var parallelSum = Calculation.ParallelSum<int>(list);
                var linqSum = Calculation.LinqSum(list);
            }
        }
    }
}
