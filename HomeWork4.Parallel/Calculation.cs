using System.Numerics;

namespace HomeWork4.Parallel;
internal class Calculation
{

    /// <summary>Расчет суммы коллекции последовательно</summary>
    /// <typeparam name="T">Тип</typeparam>
    /// <param name="list">Коллекция</param>
    /// <returns>Возврат суммы</returns>
    public static T SequentialSum<T>(ICollection<T> list) where T : struct, INumber<T>
    {
        T sum = default;
        foreach (T item in list)
        {
            checked { sum += item; }
        }
        return sum;
    }
}

