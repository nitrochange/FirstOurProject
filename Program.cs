using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace generator_primerov_NIS
{
    class Program
 {
        /// <summary>
        /// метод генерирует матрицу случайных целых цисел(её размер содержится в передаваемых параметрах)
        /// (диапазон чисел от [-9,9])
        /// </summary>
        /// <param name="num_of_lines">количество строк выходной матрицы</param>
        /// <param name="num_of_colomns">количество столбцов выходной матрицы</param>
        /// <param name="T">инициализатор рандома</param>
        /// <returns>матрица целых чисел(массив массивов)</returns>
        static int[][] GeneratorMatrix(int num_of_lines, int num_of_colomns, int T)
        {
            Random rnd = new Random(T);
            int[][] Matrix = new int[num_of_lines][];
            for (int i =0; i<num_of_lines; i++)
            {
                Matrix[i] = new int[num_of_colomns]; 
            }
            for (int i = 0; i<num_of_lines; i++)
                for (int j = 0; j<num_of_colomns; j++)
                {
                    Matrix[i][j] = rnd.Next(-9,10);
                }
            return Matrix;

        }
        /// <summary>
        /// требуется гарантия того, что передаваемые две матрицы можно перемножать
        /// сам метод перемножает две целочисленные матрицы и возвращает матрицу интов
        /// </summary>
        /// <param name="First_Matrix">левая матрица</param>
        /// <param name="Second_Matrix">правая матрица</param>
        /// <returns>матрица интов</returns>
        static int[][] MatrixMultiplication(int[][] First_Matrix, int[][] Second_Matrix, int FirstNumOfColomns, int SecondNumOfLines)
        {
            //создание выходной матрицы
            int[][] result  = new int[FirstNumOfColomns][];
            for (int i = 0; i < FirstNumOfColomns; i++)
            {
                result[i] = new int[SecondNumOfLines];
            }
            //заполнение выходной матрицы
            for (int i =0; i<First_Matrix.Length; i++)
            {
               for (int j = 0; j<FirstNumOfColomns; j++)
                {
                    result[i][j] = First_Matrix[i][j] * Second_Matrix[j][i];

                }
            }
            return result;
        }
        /// <summary>
        /// метод складывает две целочисленные матрицы размера n*k
        /// на вход должны подаваться матрицы, которые можно складывать
        /// если fl = true выполняется сложение матриц, иначе - вычитание
        /// </summary>
        /// <param name="First_Matrix">левая матрица</param>
        /// <param name="Second_Matrix">правая матрица</param>
        /// <param name="n">количество столбцов</param>
        /// <param name="k">количество строк</param>
        /// <returns>целочисленная матрица размера n*k</returns>
        static int[][] MatrixAdnAndSubt(int[][] First_Matrix, int[][] Second_Matrix, int n , int k, bool fl)
        {
            int[][] result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[k];
            }

            for (int i =0; i< k; i++)
                for (int j = 0; j<n; j++)
                {
                    if (fl) result[i][j] = First_Matrix[i][j] + Second_Matrix[i][j];
                    else result[i][j] = First_Matrix[i][j] - Second_Matrix[i][j];
                }
            return result;
        }
        static void Show3Matrix(int[][] Left, int[][] Middle, int [][]Right)
        {
            
        }

        static void Main(string[] args)
        {   
            //количество строк первой матрицы
            int n;
            int.TryParse(Console.ReadLine(), out n);
            //количество столбцов первой матрицы
            int k;
            int.TryParse(Console.ReadLine(), out k);
            bool fl = true;
            Random rnd = new Random();
            int T = rnd.Next();
            int[][] Matrix1 = GeneratorMatrix(n, k,T);
            for (int i = 0; i<n; i++)
            {
                for (int j = 0; j < k; j++)
                    Console.Write(Matrix1[i][j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("------------------------");
            //количество  столбцов второй матрицы
            int p =3;
             T = rnd.Next();
            int[][] Matrix2 = GeneratorMatrix(k, p,T);
            for (int i = 0; i < k; i++)
            {
                for (int j = 0; j < p; j++)
                    Console.Write(Matrix2[i][j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine("------------------------");
            int[][] Matrix3 =MatrixAdnAndSubt(Matrix1, Matrix2, n,k,fl);
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < k; j++)
                    Console.Write(Matrix3[i][j] + " ");
                Console.WriteLine();
            }
        }
    }
}
