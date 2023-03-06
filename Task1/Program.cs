// Задача 1. Задайте двумерный массив размером m×n, заполненный случайными вещественными числами.

// m = 3, n = 4.

// 0,5 7 -2 -0,2

// 1 -3,3 8 -9,9

// 8 7,8 -7,1 9

int InputInt32(string message)
{
    System.Console.Write(($"{message} "));
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
double InputDouble(string message)
{
    System.Console.Write(($"{message} "));
    double value;
    bool isCorrectInt32 = double.TryParse(Console.ReadLine(), out value);
    if (isCorrectInt32)
    {
        return value;
    }
    System.Console.WriteLine("You enter not a number");
    Environment.Exit(-2);
    return 0;
}

double[,] GenerateArray(int row, int col, double MinValue, double MaxValue) //Создание ТОЛЬКО двумерного массива. Если невозможно - то выход из программы.
{
    double[,] array = new double[,] { };
    if (row > 1 && col > 1)
    {
        array = new double[row, col];
        Random random = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = (MaxValue - MinValue) * random.NextDouble() + MinValue;
            }
        }
        return array;
    }
    System.Console.WriteLine("Error! Can not generate array: invalid String or column numbers");
    Environment.Exit(-3);
    return array;
}

void PrintArray(double[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.WriteLine();
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]:F3}\t");
        }
    }
    Console.WriteLine();
}

System.Console.WriteLine("Please, enter you 2D array");
int NumberStrings = InputInt32("Enter number of strings");
int NumberColumns = InputInt32("Enter number of columns");
double MinLimit = InputDouble("Enter minimal array range");
double MaxLimit = InputDouble("Enter maximal array range");
double[,] UserArray = GenerateArray(NumberStrings, NumberColumns, MinLimit, MaxLimit);
PrintArray(UserArray);
