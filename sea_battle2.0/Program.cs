using System;
using System.Collections.Generic;

class Game
{
    public static Random rand = new Random();
    public static void Main(string[] args)
    {
        int[,] mas1 = new int[10, 10];
        int[,] mas2 = new int[10, 10];
        int x, y, hitCount = 0;
        List<string> movesHistory = new List<string>();

        // Инициализируем игровое поле
        for (int i = 0; i < 10; i++)
        {
            for (int j = 0; j < 10; j++)
            {
                if ((i % 2) == 0)
                {
                    mas1[i, j] = rand.Next(0, 2);
                }
                else
                {
                    mas1[i, j] = 0;
                }
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
            Console.WriteLine("введите координаты корабля через Enter:");
            x = Convert.ToInt32(Console.ReadLine());
            y = Convert.ToInt32(Console.ReadLine());
            y--;
            x--;
            Console.Clear();

            // Проверяем, попал ли игрок в корабль
            if (mas1[x, y] == 1)
            {
                mas2[x, y] = 1;
                hitCount++;
                movesHistory.Add($"ход {t + 1}: игрок попал в корабль по координатам [{x + 1}, {y + 1}]");
            }
            else
            {
                mas2[x, y] = 2;
                movesHistory.Add($"ход {t + 1}: игрок промахнулся по координатам [{x + 1}, {y + 1}]");
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
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("количество попаданий: " + hitCount);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\nИстория ходов игрока:");
            foreach (var move in movesHistory)
            {
                Console.WriteLine(move);
            }
            Console.ResetColor();
        }
        Console.Read();
    }
}
