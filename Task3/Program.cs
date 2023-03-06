// Задача 3. Задайте двумерный массив из целых чисел. Найдите среднее арифметическое элементов в каждом столбце.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// Среднее арифметическое каждого столбца: 4,6; 5,6; 3,6; 3.

int InputInt32(string message)
{
    System.Console.Write(($"{message}: "));
    int value;
    bool isCorrectInt32 = int.TryParse(Console.ReadLine(), out value);
    if (isCorrectInt32)
    {
        return value;
    }
    System.Console.WriteLine("You entered not a number");
    Environment.Exit(-1);
    return 0;
}
int[,] GenerateArrayInt32(int row, int col, int MinValue, int MaxValue) //Создание ТОЛЬКО двумерного массива. Если невозможно - то выход из программы.
{
    int[,] array = new int[,] { };
    if (row > 1 && col > 1)
    {
        array = new int[row, col];
        Random random = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(MinValue, MaxValue + 1);
            }
        }
        return array;
    }
    System.Console.WriteLine("Error! Can not generate array: invalid String or column numbers");
    Environment.Exit(-3);
    return array;
}
void PrintArray2D(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]}\t");
        }
    }
    Console.WriteLine();
}
void PrintArray1D(double[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.Write($"{array[i]:F2};\t");        
    }
    Console.WriteLine();
}

double[] AverageColumnsToArray(int[,] array)
{
    double[] ResultArray = new double[array.GetLength(1)];
    for (int j = 0; j < array.GetLength(1); j++)
    {
        double Sum = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            Sum = Sum + array[i,j];
        }
        ResultArray[j]=Sum/array.GetLength(0);        
    }
    return ResultArray;
}

System.Console.WriteLine("Please, enter you 2D array");
int NumberStrings = InputInt32("Enter number of strings");
int NumberColumns = InputInt32("Enter number of columns");
int MinLimit = InputInt32("Enter minimal array range");
int MaxLimit = InputInt32("Enter maximal array range");
int[,] UserArray = GenerateArrayInt32(NumberStrings, NumberColumns, MinLimit, MaxLimit);
PrintArray2D(UserArray);
System.Console.Write($"Averages of each column: ");
PrintArray1D(AverageColumnsToArray(UserArray));

