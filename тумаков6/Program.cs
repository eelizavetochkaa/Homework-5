using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тумаков6
{
    internal class Program
    {
        public static double[,] CountTemperature(int lenght, int width)
        {
            Random random = new Random();
            double[,] temperature = new double[lenght, width];
            for (int i = 0; i < lenght; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    temperature[i, j] = random.Next(-20, 40); /// Генерация случайной температуры от -20 до 40 градусов
                }
            }
            return temperature;
        }
        public static double Count(double[,] matrix)
        {
            double sum = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    sum += matrix[i, j];
                }
            }
            return sum / matrix.Length;
        }
        public static void Matrix()
        {
            Random random = new Random();
            byte a = (byte)random.Next(1, 10);
            byte b = (byte)random.Next(1, 10);
            byte c = (byte)random.Next(1, 10);
            int[,] A = new int[b, a];
            int[,] B = new int[c, b];
            int[,] C = new int[c, a];
            for (int j = 0; j < a; j++)
                for (int i = 0; i < b; i++)
                    A[i, j] = random.Next(100);
            for (int j = 0; j < b; j++)
                for (int i = 0; i < c; i++)
                    B[i, j] = random.Next(100);
            for (byte y = 0; y < a; y++)
                for (byte x = 0; x < c; x++)
                    for (byte z = 0; z < b; z++)
                        C[x, y] += A[z, y] * B[x, z];
            Console.WriteLine("\nA:");
            for (byte j = 0; j < a; j++)
            {
                for (byte i = 0; i < b; i++)
                    Console.Write(A[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("\nB:");
            for (byte j = 0; j < b; j++)
            {
                for (byte i = 0; i < c; i++)
                    Console.Write(B[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("\nC:");
            for (byte j = 0; j < a; j++)
            {
                for (byte i = 0; i < c; i++)
                    Console.WriteLine(C[i, j] + " ");
                Console.WriteLine();
            }

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Упражнение 6.2 \n Программа умножает две матрицы \n");
            Matrix();

            Console.WriteLine("Упражнение 6.3\n Программа считает среднюю температуру");
            double[,] mat = CountTemperature(12, 30);
            Console.WriteLine("Температуры каждый день:");
            for (int i = 0; i < mat.GetLength(0); i++)
            {
                for (int j = 0; j < mat.GetLength(1); j++)
                {
                    Console.Write(mat[i, j]); Console.Write(' ');
                }
                Console.WriteLine();
            }
            Console.WriteLine("Средняя температура: " + Count(mat));
            Console.ReadKey();

        }
    }
}
