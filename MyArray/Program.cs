
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

struct MyArray<T>
{
    private int size;
    private T[] arr;

    public int Size
    {
        get { return size; }
        set
        {
            if (value < 0)
                throw new ArgumentException("Розмір масиву не може бути від'ємним.");
            size = value;
            arr = new T[size];
        }
    }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Недопустимий індекс");
            return arr[index];
        }
        set
        {
            if (index < 0 || index >= size)
                throw new IndexOutOfRangeException("Недопустимий індекс");
            arr[index] = value;
        }
    }

    public MyArray(int size)
    {
        this.size = size;
        arr = new T[size];
    }

    public static MyArray<T> operator +(MyArray<T> array1, MyArray<T> array2)
    {
        if (array1.Size != array2.Size)
            throw new ArgumentException("Розміри масивів повинні бути однаковими для додавання.");

        MyArray<T> result = new MyArray<T>(array1.Size);

        for (int i = 0; i < result.Size; i++)
        {
            result[i] = (dynamic)array1[i] + (dynamic)array2[i];
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = UTF8Encoding.UTF8;

        MyArray<int> array1 = new MyArray<int>(3);
        array1[0] = 1;
        array1[1] = 2;
        array1[2] = 3;

        MyArray<int> array2 = new MyArray<int>(3);
        array2[0] = 4;
        array2[1] = 5;
        array2[2] = 6;

        MyArray<int> sumArray = array1 + array2;

        Console.WriteLine("Масив 1:");
        PrintArray(array1);

        Console.WriteLine("\nМасив 2:");
        PrintArray(array2);

        Console.WriteLine("\nСума масивів:");
        PrintArray(sumArray);
    }

    static void PrintArray<T>(MyArray<T> array)
    {
        for (int i = 0; i < array.Size; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
    }
}
