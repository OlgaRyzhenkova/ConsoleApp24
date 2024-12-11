using System;
class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Оберіть спосіб заповнення масиву:");
            Console.WriteLine("1 - Випадкове заповнення масиву");
            Console.WriteLine("2 - Введення елементів масиву по одному в окремих рядках");
            Console.WriteLine("3 - Введення всього масиву в одному рядку через пробіли");
            Console.WriteLine("0 - Вихід із програми");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 0) return;
            int[] array = null;
            switch (choice)
            {
                case 1:
                    array = FillArrayRandomly();
                    break;
                case 2:
                    array = FillArrayManually();
                    break;
                case 3:
                    array = FillArrayFromSingleLine();
                    break;
                default:
                    Console.WriteLine("Неправильний вибір!");
                    continue;
            }
            if (array == null)
            {
                Console.WriteLine("Масив не заповнений. Повернення до головного меню.");
                continue;
            }
            DisplayArray(array);
            int result = CalculateSumBeforeLastMin(array);
            Console.WriteLine("Сума елементів перед останнім входженням мінімального числа:" + result);
        }
    }
    static int[] FillArrayRandomly()
    {
        Console.WriteLine("Введіть кількість елементів масиву:");
        int size = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть нижню межу:");
        int lowerBound = int.Parse(Console.ReadLine());
        Console.WriteLine("Введіть верхню межу:");
        int upperBound = int.Parse(Console.ReadLine());
        if (lowerBound > upperBound)
        {
            Console.WriteLine("Нижня межа не може бути більшою за верхню.");
            return null;
        }
        int[] array = new int[size];
        Random rand = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = rand.Next(lowerBound, upperBound + 1);
        }
        return array;
    }
    static int[] FillArrayManually()
    {
        Console.WriteLine("Введіть кількість елементів масиву: ");
        int size = int.Parse(Console.ReadLine());
        int[] array = new int[size];
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"Елемент {i + 1}:");
            array[i] = int.Parse(Console.ReadLine());
        }
        return array;
    }
    static int[] FillArrayFromSingleLine()
    {
        Console.WriteLine("Введіть елементи масиву через пробіл:");
        string[] input = Console.ReadLine().Split(' ');
        int[] array = new int[input.Length];
        for (int i = 0; i < input.Length; i++)
        {
            array[i] = int.Parse(input[i]);
        }
        return array;
    }
    static void DisplayArray(int[] array)
    {
        Console.WriteLine("Заповнений масив:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine($"{array[i]} ");
        }
        Console.WriteLine();
    }
    static int CalculateSumBeforeLastMin(int[] array)
    {
        int min = int.MaxValue;
        int lastMinIndex = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] <= min)
            {
                min = array[i];
                lastMinIndex = i;
            }
        }
        int sum = 0;
        for (int i = 0; i < lastMinIndex; i++)
        {
            sum += array[i];
        }
        return sum;
    }
}