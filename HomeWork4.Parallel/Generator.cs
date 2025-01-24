namespace HomeWork4.Parallel;
public class Generator
{
    /// <summary>Генератор коллекции с заполнением случайными числами </summary>
    /// <param name="size">размер коллекции</param>
    /// <returns>Заполненная коллекция с заданным размером </returns>
    public static ICollection<int> GenerateList(int size)
    {
        Random random = new();

        ICollection<int> list = [];
        for (int i = 0; i < size; i++)
        {
            int randomNumber = random.Next(1, 101);
            list.Add(randomNumber);
        }
        return list;
    }
}

