static class Program
{
static void Main(string[] args)
    {
        Console.Clear();

        int m = EnterPositiveNumber("Введите число строк массива:");

        int n = EnterPositiveNumber("Введите число столбцов массива:");

        // Задача 47: Задайте двумерный массив размером m×n,
        // заполненный случайными вещественными числами.
        // m = 3, n = 4.
        // 0,5 7 -2 -0,2
        // 1 -3,3 8 -9,9
        // 8 7,8 -7,1 9

        Console.WriteLine("\n<Задача 47> Вывод двумерного массива, заполненного случайными вещественными числами\n");

        double[,] arrayRandom = GetArrayRandomDouble(m, n);

        // Задача 50: Напишите программу, которая на вход
        // принимает позиции элемента в двумерном массиве, и
        // возвращает значение этого элемента или же указание,
        // что такого элемента нет.
        // Например, задан массив:
        // 1 4 7 2
        // 5 9 2 3
        // 8 4 2 4
        // 17 -> такого числа в массиве нет

        Console.WriteLine("\n<Задача 50> Поиск элемента двумерного массива по индексу");

        int[,] arrayInt = GetArrayRandomInt(m, n);

        int index1 = EnterPositiveNumber($"Введите индекс строки массива (от 0 до {m - 1}):");

        int index2 = EnterPositiveNumber($"Введите индекс столбца массива (от 0 до {n - 1}):");

        ReturnNumberFromPosition(arrayInt, index1, index2);

        // Задача 52: Задайте двумерный массив из целых чисел.
        // Найдите среднее арифметическое элементов в каждом
        // столбце.
        // Например, задан массив:
        // 1 4 7 2
        // 5 9 2 3
        // 8 4 2 4
        // Среднее арифметическое каждого
        // столбца: 4,6; 5,6; 3,6;

        Console.WriteLine("\n<Задача 52> Поиск среднего арифметического элементов всех столбцов двумерного массива");

        ArithmeticMeanArrayRows(arrayInt);

        Console.WriteLine();
    }

    static int EnterPositiveNumber(string text)
    {
        Console.Write($"\n{text}\t");

        int num;

        while(true)
        {
            try
            {
                num = Convert.ToInt32(Console.ReadLine());

                if (num >= 0) break;

                else Console.Write($"\nВы ввели отрицательное число. Введите положительное:\t");
            }

            catch (FormatException)
            {
                Console.Write($"\nОшибка ввода. Повторите ввод:\t");
            }
        }

        return num;
    }

    static double[,] GetArrayRandomDouble(int rows, int columns, int MinValue = -9, int MaxValue = 9) // for task 47
    {
        double[,] array = new double[rows, columns];

        Console.WriteLine($"Массив {rows} x {columns}, заполненный случайными вещественными числами от {MinValue} до {MaxValue}:\n");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
array[i, j] = new Random().Next(MinValue, MaxValue) + new Random().NextDouble();
                Console.Write($"{Math.Round(array[i, j], 2)}; ");
            }
            Console.WriteLine();
        }
        return array;
    }

    static int[,] GetArrayRandomInt(int rows, int columns, int MinValue = 1, int MaxValue = 9) // for tasks 50, 52
    {
        int[,] arr = new int[rows, columns];

        Console.WriteLine($"\nМассив {rows} x {columns}, заполненный случайными целыми числами от {MinValue} до {MaxValue}:\n");

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                arr[i, j] = new Random().Next(MinValue, MaxValue + 1);
                Console.Write($"{arr[i, j]} ");
            }
            Console.WriteLine();
        }

        return arr;
    }

    static void ReturnNumberFromPosition(int[,] array, int indexRow = 0, int indexColumn = 0) // for task 50
    {
        if (indexRow < array.GetLength(0) && indexRow >= 0)
        {
            if (indexColumn < array.GetLength(1) && indexColumn >= 0)
            {
                Console.WriteLine($"\nЭлемент массива по индексу [{indexRow}, {indexColumn}]: {array[indexRow, indexColumn]}");
            }
        }

        else Console.WriteLine($"\nЭлемента с таким адресом в массиве нет.");
    }

    static void ArithmeticMeanArrayRows(int[,] array) // for task 52
    {
        double arithmeticMean = 0;

        Console.WriteLine($"\nСреднее арифметическое каждого столбца последнего массива:\n");

        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                arithmeticMean += array[i, j];
            }
            Console.Write($"{Math.Round(arithmeticMean / array.GetLength(0), 2)}; ");
            arithmeticMean = 0;
        }
    }

}