using System;
using System.Threading;

namespace Camp2
{
    class Program
    {
        public static void Main()
        {
            Random random = new Random();
            int width = 0, height = 0;
            Console.Write("Enter height: ");
            height = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter width: ");
            width = Convert.ToInt32(Console.ReadLine());
            int[,] field = new int[height, width];

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = random.Next(0, 2);
                    if (field[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(field[i, j]);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(field[i, j]);
                    }
                }
                Console.WriteLine();
            }
            Thread.Sleep(1500);
            Console.Clear();

            int[,] futureField = new int[field.GetLength(0), field.GetLength(1)];

            while (true)
            {
                for (int i = 1; i < futureField.GetLength(0) - 1; i++)
                {
                    for (int j = 1; j < futureField.GetLength(1) - 1; j++)
                    {
                        int alive = 0;
                        for (int l = -1; l <= 1; l++)
                            for (int n = -1; n <= 1; n++)
                                alive += field[i + l, j + n];

                        alive -= field[i, j];

                        if ((field[i, j] == 1) && (alive < 2))
                            futureField[i, j] = 0;

                        if ((field[i, j] == 1) && (alive > 3))
                            futureField[i, j] = 0;

                        if ((field[i, j] == 0) && (alive == 3))
                            futureField[i, j] = 1;

                        else
                            futureField[i, j] = field[i, j];

                    }
                }
                field = futureField;

                for (int i = 0; i < futureField.GetLength(0); i++)
                {
                    for (int j = 0; j < futureField.GetLength(1); j++)
                    {
                        if (futureField[i, j] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(futureField[i, j]);
                        }

                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write(futureField[i, j]);
                        }
                    }
                    Console.WriteLine();
                }
                Thread.Sleep(1500);
                Console.Clear();
            }

        }
    }
}
