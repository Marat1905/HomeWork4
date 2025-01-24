namespace HomeWork4.Parallel;
public static class Logger
{
    /// <summary>Запись в консоль красным цветом заголовок</summary>
    /// <param name="titleText">текст</param>
    public static void WriteTitle(string titleText)
    {
        var consoleColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(titleText);
        Console.ForegroundColor = consoleColor;
    }

    /// <summary>
    /// Запись в консоль с выделением
    /// </summary>
    /// <param name="statement">Смысловое выражение</param>
    /// <param name="addition">Дополнение</param>
    public static void WriteDescription(string statement, string addition)
    {
        var consoleColor = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.White;
        Console.Write($"{statement}:  ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write($"{addition}  \n");
        Console.ForegroundColor = consoleColor;
    }
}

