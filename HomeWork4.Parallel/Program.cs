namespace HomeWork4.Parallel
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

               var sum = Calculation.SequentialSum<int>(list);
            }
        }
    }
}
