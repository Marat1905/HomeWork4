using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Numerics;

namespace HomeWork4.ParallelSum;
internal static class Calculation
{
    private static readonly object _look = new object();

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

    /// <summary>
    /// Расчет суммы коллекции параллельно
    /// </summary>
    /// <typeparam name="T">Тип</typeparam>
    /// <param name="list">Коллекция</param>
    /// <returns>Возврат суммы</returns>
    public static T ParallelSum<T>(ICollection<T> list) where T : struct, INumber<T>
    {
        T sum = default;
        object _lock = new object();

        Parallel.ForEach<T>(list,
            Sum =>
            {
                lock (_lock) { sum += Sum; };
            });
        return sum;
    }

    /// <summary>
    /// Расчет суммы коллекции при помощи PLINQ
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">Коллекция</param>
    /// <returns>Возврат суммы</returns>
    public static int LinqSum(ICollection<int> list)
    {
        return list.AsParallel().Sum();
    }

    /// <summary>
    /// Расчет суммы коллекции при помощи потоков
    /// </summary>
    /// <param name="list">Коллекция</param>
    /// <param name="threadSize">Количество потоков</param>
    /// <returns>Возврат суммы</returns>
    public static int ThreadSum(ICollection<int> list,int threadSize)
    {
        List<Thread> threads = new List<Thread> ();

        var lists= SubList(list,threadSize);

        int sum = 0;

        Action<List<int>> action = (List<int> sublist) =>
        {
            foreach (var item in sublist)
            {
                Interlocked.Add(ref sum, item);
            }
        };

        foreach (var item in lists)
        {
            threads.Add(new Thread(() => action(item)));
        }


        for (int j = 0; j < threads.Count; j++)
            threads[j].Start();

        for (int k = 0; k < threads.Count; k++)
            threads[k].Join();


        return sum;

    }

   
    /// <summary>
    /// Разбиение исходной коллекции на количество потоков
    /// </summary>
    /// <param name="list">исходная коллекция</param>
    /// <param name="threadSize">Количество потоков</param>
    /// <returns>Разбитая коллекция</returns>
    public static List<List<T>> SubList<T>(ICollection<T> list, int threadSize)
    {
        var listRange = list.Count();

        var mod = 0;
        if (listRange % threadSize != 0)
        {
            mod = listRange - threadSize * (listRange / threadSize);
        }
        var listSub = listRange / threadSize;

        List<List<T>> lists = new List<List<T>>();
        for (int i = 0; i < threadSize; i++)
        {
            if (mod != 0)
            {
                lists.Add(Slice<T>(list, i * listSub, listSub * (i + 1)));
                --mod;
            }
            else
                lists.Add(Slice<T>(list, i * listSub, listSub * (i + 1) - 1));

        }
        return lists;
    }


    /// <summary>
    /// Разбиение исходной коллекции
    /// </summary>
    /// <param name="inputList">Коллекция</param>
    /// <param name="startIndex">Начало</param>
    /// <param name="endIndex">Конец</param>
    /// <returns>Часть коллекции</returns>
    public static List<T> Slice<T>(ICollection<T> inputList, int startIndex, int endIndex)
    {
        int elementCount = endIndex - startIndex + 1;
        List<T> list = inputList.Skip(startIndex).Take(elementCount).ToList();
        return list;
    }
}

