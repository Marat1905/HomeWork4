using System.Numerics;

namespace HomeWork4.Parallel;
internal class Calculation
{
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

