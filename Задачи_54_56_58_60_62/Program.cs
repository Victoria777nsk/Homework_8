Start();

void Start()
{
    while (true)
    {
        Console.ReadLine();
        Console.Clear();

        Console.WriteLine("54) Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.");
        Console.WriteLine("56) Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.");
        Console.WriteLine("58) Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.");
        Console.WriteLine("60) Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.");
        Console.WriteLine("62) Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.");
        Console.WriteLine("0) Выход.");

        Console.Write("Введите номер задачи: ");
        int taskNumber = Convert.ToInt32(Console.ReadLine());

        switch (taskNumber)
        {
            case 0: return;
            case 54: PrintSortArray(SortArray(GetArray())); break;
            case 56: MinSumElements(GetArray2()); break;
            case 58: Console.Clear();
                     Console.Write("Введите количество строк массива: ");
                     int rows = Convert.ToInt32(Console.ReadLine());
                     Console.Write("Введите количество столбцов массива: ");
                     int columns = Convert.ToInt32(Console.ReadLine());

                     int[,] firstArray = new int[rows, columns];
                     int[,] secondArray = new int[rows, columns];
                     int[,] resultArray = new int[rows, columns];
            
                     Console.WriteLine();
                     Console.WriteLine("Первая матрица: ");
                     GetArrayMatrix(firstArray);
                     Console.WriteLine();
                     Console.WriteLine("Вторая матрица: ");
                     GetArrayMatrix(secondArray); 
                     PrintResultMatrix(ResultArray(firstArray, secondArray, resultArray)); break;
            case 60: Array3D(); break;
            case 62: Console.Clear();
                     int[,] array = new int[4, 4];
                     PrintArray(FillArraySpiral(array)); break;
            default: Console.WriteLine("ERROR"); break;
        }
    }
}

// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.

int[,] GetArray() // Создание массива, заполненного случайными числами от 10 до 99.
{
    Console.Clear();
    Console.Write("Введите количество строк массива: ");
    int rows = Convert.ToInt32(Console.ReadLine());

    Console.Write("Введите количество столбцов массива: ");
    int columns = Convert.ToInt32(Console.ReadLine());
                
    int[,] array = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = new Random().Next(10,100);
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
    return array;
}

int[,] SortArray(int[,] newArray) // Сортировка элементов строк по убыванию.
{
    for (int i = 0; i < newArray.GetLength(0); i++)
    {
        for (int j = 0; j < newArray.GetLength(1) - 1; j++)
        {
            for (int k = 0; k < newArray.GetLength(1) - 1; k++)
            {
                if (newArray[i, k] < newArray[i, k + 1])
                {
                    int temp = 0;
                    temp = newArray[i, k];
                    newArray[i, k] = newArray[i, k + 1];
                    newArray[i, k + 1] = temp;
                }
            }
        }
    }
    return newArray;
} 

int[,] PrintSortArray(int[,] newArray) // Вывод массива с упорядоченными элементами.
{
    Console.WriteLine();
    Console.WriteLine("Массив с упорядоченными по убыванию элементами в строках: ");
    for (int i = 0; i < newArray.GetLength(0); i++)
    {
        for (int j = 0; j < newArray.GetLength(1); j++)
        {
            Console.Write($"{newArray[i, j]}\t");
        }
        Console.WriteLine();
    }
    return newArray;
}


// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

int[,] GetArray2() // Создание массива, заполненного случайными числами от 1 до 9.
{
    Console.Clear();
    Console.Write("Введите количество строк массива: ");
    int rows = Convert.ToInt32(Console.ReadLine());

    Console.Write("Введите количество столбцов массива: ");
    int columns = Convert.ToInt32(Console.ReadLine());
                
    int[,] array = new int[rows, columns];
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = new Random().Next(1,10);
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
    return array;
}

void MinSumElements(int[,] array) // Поиск номера строки с наименьшей суммой элементов.
{
    int minRow = 0;       // Наименьшая сумма элементов.
    int minSumRow = 0;   // Строка с наименьшей суммой элементов.
    int sumRow = 0;     // Сумма элементов строки.
    
    for (int j = 0; j < array.GetLength(1); j++) 
    {
        minRow += array[0, j];  // Сначала принимаем за наименьшую первую строку (с индеком 0) и находим сумму элементов в ней.
    }
    
    for (int i = 0; i < array.GetLength(0); i++)  // После этого перебираем все строки..
    {
        for (int j = 0; j < array.GetLength(1); j++) 
        {
            sumRow += array[i, j];               // .. и находим сумму элементов в каждой строке.
        }
        
        if (sumRow <= minRow)  // Сравниваем получившуюся в каждой строке сумму с наименьшей.
        {
            minRow = sumRow;
            minSumRow = i;
        }
        sumRow = 0;
    }
    Console.WriteLine($"Строка с наименьшей суммой элементов: {minSumRow + 1}");  // Прибавляем к индексу строки 1, чтобы номинально 
}                                                                                // считать с 1-ой строки, а не с нулевой.


// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.

int[,] GetArrayMatrix(int[,] array) // Создание матрицы.
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(1,10);
            Console.Write($"{array[i, j]}\t");
        }
        Console.WriteLine();
    }
    return array;
}

int[,] ResultArray(int[,] firstArray, int[,] secondArray, int[,] resultArray)
{
    if (firstArray.GetLength(0) != secondArray.GetLength(1)) // Перемножить можно только те матрицы, в которых 
    {                                                        // кол-во строк первой равно кол-ву столбцов второй.
        Console.WriteLine("Ошибка! Данные матрицы нельзя перемножить.");
    }
    for (int i = 0; i < firstArray.GetLength(0); i++)
    {
        for (int j = 0; j < secondArray.GetLength(1); j++)
        {
            resultArray[i, j] = 0;                                // Матрицы умножаются по принципу строка на столбец. 
            for (int k = 0; k < firstArray.GetLength(1); k++)     // Умножаем 1-ую строку первой матрицы на 1-ый столбец второй матрицы, 
            {                                                     // складываем результаты и получаем первый элемент новой матрицы.
                resultArray[i, j] += firstArray[i, k] * secondArray[k, j];
            }
        }
    }
    return resultArray;
}

int[,] PrintResultMatrix(int[,] resultArray)
{
    Console.WriteLine();
    Console.WriteLine("Произведение двух матриц: ");
    for (int i = 0; i < resultArray.GetLength(0); i++)
    {
        for (int j = 0; j < resultArray.GetLength(1); j++)
        {
            Console.Write($"{resultArray[i, j]}\t");
        }
        Console.WriteLine();
    }
    return resultArray;
}


// Задача 60. Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.

int[,,] Array3D()
{
    Console.Clear();
    Console.Write("Трёхмерный массив из случайных неповторяющихся двузначных чисел: ");
    int[,,] array = new int[2, 2, 2]; // Для примера взят трёхмерный массив размером 2 x 2 x 2.

    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.WriteLine();
            for (int k = 0; k < array.GetLength(2); k++)
            {
                while (array[i, j, k] == 0) // Чтобы не было нулевых элементов.
                {
                    int number = new Random().Next(10,100);
                    if (IsNumberInArray(array, number) == false)
                    {
                        array[i, j, k] = number;
                    }
                }
                Console.Write($"{array[i, j, k]} ({i}, {j}, {k})  ");
            }
        }
    }
    return array;
}

bool IsNumberInArray(int[,,] array, int number) // Определяем, было ли уже число в массиве, т.к. они не должны повторяться.
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(2); k++)
            {
                if (array[i, j, k] == number) return true;
            }
        }
    }
    return false;
}


// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.

int[,] FillArraySpiral(int[,] array)
{
    int number = 1; // Начинаем заполнять массив с единицы.
    int i = 0;      // Индекс строки первого элемента = 0.
    int j = 0;      // Индекс столбца первого элемента = 0.

    while (number <= array.GetLength(0) * array.GetLength(1))  // Массив 4х4 содержит 16 элементов => последний элемент будет = 16.
    {
        array[i, j] = number;
        number++;
        if (i <= j + 1 && i + j < array.GetLength(1) - 1) 
        {
            j++;                                            // Остаёмся на той же строке, переходим в следующий столбец вправо.
        }
        else if (i < j && i + j >= array.GetLength(0) - 1)
        {
            i++;                                            // Дошли до последнего столбца, переходим на следующую строку вниз.
        }
        else if (i >= j && i + j > array.GetLength(1) - 1) 
        {
            j--;                                            // Доходим до нижней строки последнего столбца, поворачиваем влево.
        }
        else 
        {
            i--;                                            // Доходим до первого столбца последней строки, поднимаемся на строку вверх.
        }
    }
    return array;
}

int[,] PrintArray(int[,] array)
{
    Console.WriteLine("Массив 4х4, заполненный по спирали: ");
    Console.WriteLine();
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] < 10)
            {
                Console.Write("0" + array[i, j] + " ");  // Добавляем "0" перед однозначными числами.
            }
            else 
            {
                Console.Write(array[i, j] + " ");
            }
        }
        Console.WriteLine();
    }
    return array;
}
