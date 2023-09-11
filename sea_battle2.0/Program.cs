using System;

class Game
{
    public static Random rand = new Random();

    public static void Main(string[] args)
    {
        int[,] mas = new int[10, 10];
        int[,] mas1 = new int[10, 10];
        int[,] mas2 = new int[10, 10];
        int x, y, hitCount = 0;

        // Инициализируем игровое поле
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if ((i % 2) == 0)
                {
                    mas[i, j] = rand.Next(0, 2);
                }
                else
                {
                    mas[i, j] = 0;
                }
            }
        }

        // Очищаем массивы mas1 и mas2
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                mas1[i, j] = 0;
                mas2[i, j] = 0;
            }
        }

        // Отображаем игровое поле
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                Console.Write("[ ]");
            }
            Console.WriteLine();
        }

        // Цикл ввода координат кораблей и обновления игрового поля
        for (int t = 0; t < 30; t++)
        {
            Console.WriteLine("введите координаты корабля через enter:");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            y--;
            x--;
            mas1[x, y] = 1;
            Console.Clear();

            // Проверяем, попал ли игрок в корабль
            if (mas1[x, y] == mas[x, y] && mas[x, y] == 1)
            {
                mas2[x, y] = 1;
                hitCount++;
            }
            else
            {
                mas2[x, y] = 2;
            }

            // Отображаем обновленное игровое поле
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (mas2[i, j] == 0)
                    {
                        Console.Write("[ ]");
                    }
                    if (mas2[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("[x]");
                        Console.ResetColor();
                    }
                    if (mas2[i, j] == 2)
                    {
                        Console.Write("[o]");
                    }
                }
                Console.WriteLine();
            }
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("количество попаданий: " + hitCount);
        Console.ResetColor();
        }
        Console.Read();
    }
}
