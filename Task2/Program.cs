// Задача 2. Напишите программу, которая на вход принимает позиции элемента в двумерном массиве, и возвращает значение этого элемента или же указание, что такого элемента нет.

// Например, задан массив:

// 1 4 7 2

// 5 9 2 3

// 8 4 2 4

// 1, 7 -> такого числа в массиве нет

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
    System.Console.WriteLine("Error! String and column numbers mast be > 1");
    Environment.Exit(-3);
    return array;
}
void PrintArray(int[,] array)
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
int FindElement(int[,] array, int RowPosition, int ColPosition)
{
    if (RowPosition < array.GetLength(0) && ColPosition < array.GetLength(1)) return array[RowPosition, ColPosition];
    System.Console.WriteLine("No such element in array");
    Environment.Exit(-2);
    return -1;
}


System.Console.WriteLine("Please, enter you 2D array");
int NumberStrings = InputInt32("Enter number of strings");
int NumberColumns = InputInt32("Enter number of columns");
int MinLimit = InputInt32("Enter minimal array range");
int MaxLimit = InputInt32("Enter maximal array range");
int[,] UserArray = GenerateArrayInt32(NumberStrings, NumberColumns, MinLimit, MaxLimit);
PrintArray(UserArray);
int PositionRow = InputInt32("Enter row position");
int PositionColumn = InputInt32("Enter column position");
System.Console.WriteLine($"Your element is {FindElement(UserArray, PositionRow, PositionColumn)}");
