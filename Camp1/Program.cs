using System;

namespace Camp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[,] matrix = new int[3, 3];

            for (int i = 0; i < matrix.GetLongLength(0); i++)
                for (int j = 0; j < matrix.GetLongLength(1); j++)
                    matrix[i, j] = random.Next(-3, 4);


            Console.WriteLine("Matrix 3x3");
            Print(matrix);

            Console.WriteLine("Matrix 3x3 determinant");
            Console.WriteLine(Determinant(matrix));

            Console.WriteLine("Matrix 3x1");
            int[] massive = new int[3];
            for (int i = 0; i < massive.GetLongLength(0); i++)
                massive[i] = random.Next(-3, 4);

            for (int i = 0; i < massive.GetLongLength(0); i++)
                Console.WriteLine($"{massive[i]} ");

            Console.WriteLine("Result");
            Result(massive, matrix);
        }

        static void Print(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                    Console.Write($"{matrix[i, j]} ");
                Console.WriteLine();
            }
        }
       static void Retrive(int[,] metaMatrix, int[,] standartMatrix)
        {

            for (int i = 0; i < metaMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < metaMatrix.GetLength(1); j++)
                {
                     standartMatrix[i, j] = metaMatrix[i, j];
                }
            }
        }

        static int Determinant(int[,] matrix)
        {
            
            int determinant = matrix[0, 0] * matrix[1, 1] * matrix[2, 2] +
              matrix[0, 1] * matrix[1, 2] * matrix[2, 0] +
              matrix[0, 2] * matrix[1, 0] * matrix[2, 1] -
              matrix[0, 2] * matrix[1, 1] * matrix[2, 0] -
              matrix[0, 1] * matrix[1, 0] * matrix[2, 2] -
              matrix[0, 0] * matrix[1, 2] * matrix[2, 1];

            return determinant;
        }

        static void Result(int[] miniMatrix, int[,] megaMatrix)
        {
            int[] array = new int[3];
            int[,] matrixTest = new int[3, 3];
            for (int i = 0; i < matrixTest.GetLength(0); i++)
                for (int j = 0; j < matrixTest.GetLength(0); j++)
                    matrixTest[i, j] = megaMatrix[i, j];

            for (int j = 0; j < miniMatrix.GetLength(0); j++)
            {
                megaMatrix[0, j] = miniMatrix[0];
                megaMatrix[1, j] = miniMatrix[1];
                megaMatrix[2, j] = miniMatrix[2];
                array[j] = Determinant(megaMatrix);
                Retrive(matrixTest, megaMatrix);
            }
            int size = Determinant(megaMatrix);
            if (size == 0)
                Console.WriteLine("Error");
            else
            {
                for (int i = 0; i < miniMatrix.GetLength(0); i++)
                    Console.Write($"{array[i] / size} ");
                Console.WriteLine();
            }
            
        }
          
    }
}
