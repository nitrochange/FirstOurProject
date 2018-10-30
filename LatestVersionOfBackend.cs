using System;
namespace CiQuick.Matrix
{
    public class Matrix
    {
        static Random rnd = new Random();
        /// <summary>
        /// Генерирует матрицу случайных целых цисел(её размер содержится в передаваемых параметрах)
        /// (диапазон чисел от [-9,9])
        /// </summary>
        /// <param name="lines">количество строк выходной матрицы</param>
        /// <param name="columns">количество столбцов выходной матрицы</param>
        /// <returns>Матрица целых чисел</returns>
        static int[][] GeneratorMatrix(int lines, int columns)
        {
            int[][] Matrix = new int[lines][];
            for (int i = 0; i < lines; i++)
                Matrix[i] = new int[columns];
            for (int i = 0; i < lines; i++)
                for (int j = 0; j < columns; j++)
                    Matrix[i][j] = rnd.Next(-9, 10);
            return Matrix;

        }


        /// <summary>
        /// Метод складывает две целочисленные матрицы размера m*n
        /// на вход должны подаваться матрицы, которые можно складывать
        /// если fl = true выполняется сложение матриц, иначе - вычитание
        /// </summary>
        /// <param name="FirstMatrix">Первая матрица</param>
        /// <param name="SecondMatrix">Вторая матрица</param>
        /// <param name="m">количество столбцов</param>
        /// <param name="n">количество строк</param>
        /// <param name="sgn">Знак</param>
        /// <returns>целочисленная матрица размера n*k</returns>
        static int[][] MatrixAdnAndSubt(int[][] FirstMatrix, int[][] SecondMatrix, int m, int n, sbyte sgn)
        {
            int[][] result = new int[m][];
            for (int i = 0; i < m; i++)
                result[i] = new int[n];
            for (int i = 0; i < n; i++)
                for (int j = 0; j < m; j++)
                    result[i][j] = FirstMatrix[i][j] + sgn * SecondMatrix[i][j];
            return result;
        }
        static int[][] MatrixMultiplication(int[][] First_Matrix, int[][] Second_Matrix, int n, int k)
        {
            //создание выходной матрицы
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[k];
            }
            for (int i=0; i<n; i++)
                for(int j=0; j<k; j++)
                {
                    for (int f = 0; f < n; f++)
                        result[i][j] += First_Matrix[i][f] * Second_Matrix[f][j];
                }
            return result;
        }
        static void ShowMatrix(int[][] Matrix,int n, int k)
        {

            //Console.WriteLine(Matrix.GetLength(0));
            //Console.WriteLine(Matrix.GetLength(1));
            //Console.WriteLine(i);
            for (int i =0; i<n; i++)
            {
                
                for (int j = 0; j < k; j++)
                    Console.Write(Matrix[i][j]+" ");
                Console.WriteLine();
            }
            Console.WriteLine("--------------");
        }
            static void Main()
        {
            int[][] Mat1 = GeneratorMatrix(3, 3);
            int[][] Mat2 = GeneratorMatrix(3, 3);
            int[][] Mat3 = MatrixMultiplication(Mat1, Mat2, 3, 3);
            ShowMatrix(Mat1,3,3);
            ShowMatrix(Mat2,3,3);
            ShowMatrix(Mat3,3,3);

        }
    }
}