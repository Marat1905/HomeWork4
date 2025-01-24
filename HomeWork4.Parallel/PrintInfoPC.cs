namespace HomeWork4.ParallelSum
{
    public static class PrintInfoPC
    {
        public static void PrintSystemInfo()
        {
            var gcMemoryInfo = GC.GetGCMemoryInfo();
            long installedMemory = gcMemoryInfo.TotalAvailableMemoryBytes;
            // it will give the size of memory in GB
            var physicalMemory = ((double)installedMemory / 1024) / 1024 / 1024;

            Logger.WriteTitle("_______________Информация о системе_______________");
            Console.WriteLine();
            Logger.WriteDescription($"Количество оперативной памяти", $"{Math.Round(physicalMemory, 2)} GB");

            Logger.WriteDescription("Количество логических процессоров", Environment.ProcessorCount.ToString());

            Logger.WriteDescription($"Операционная система", System.Runtime.InteropServices.RuntimeInformation.OSDescription);

            Logger.WriteTitle("__________________________________________________");
           
        }
    }
}
