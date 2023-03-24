namespace Main
{
    public class task7AltClass
    {
        public static void task7Alt()
        {
            Console.WriteLine("Задание 7(усложнённое)");
            string path1 = @"E:\\C#\\files\\Matrix1\\fileIn.txt";
            string path2 = @"E:\\C#\\files\\Matrix2\\fileIn.txt";
            Console.WriteLine("Матрица 1:");
            double[][] rerverseMatrix1 = calculateReverseMatrix(path1);
            Console.WriteLine("Матрица 2:");
            double[][] rerverseMatrix2 = calculateReverseMatrix(path2);
            compareDeterminant(rerverseMatrix1, rerverseMatrix2);   
        }
        public static void compareDeterminant(double[][] rerverseMatrix1, double[][] rerverseMatrix2)
        {
            string biggerMatrixName;
            double determinant1 = calculateDeterminant(rerverseMatrix1);
            Console.WriteLine($"Определитель первой обратной - {determinant1}");
            double determinant2 = calculateDeterminant(rerverseMatrix2);
            Console.WriteLine($"Определитель второй обратной - {determinant2}");
            double diagonalSum;
            if (determinant1 > determinant2)
            { 
                diagonalSum = calculateDiagonalSum(rerverseMatrix1);
                biggerMatrixName = "первой";

            }
            else 
            { 
                diagonalSum = calculateDiagonalSum(rerverseMatrix2);
                biggerMatrixName = "второй";
            }
            Console.WriteLine("Сумма диагоналей "+biggerMatrixName+" матрицы="+ diagonalSum);
        }
        public static double[][] calculateReverseMatrix(string path)
        {
            int[][] matrix = createMatrix(path);
            matrixOut(matrix);
            Console.WriteLine($"Определитель - {calculateDeterminant(matrix)}");
            int[][] minorArray= calculateMinorArray(matrix);
            Console.WriteLine("Массив миноров");
            matrixOut(minorArray);
            int[][] transposeArray = calculateTransposedMatrix(minorArray);
            Console.WriteLine("Транспонированная матрица");
            matrixOut(transposeArray);
            Console.WriteLine("Обратная матрица");
            double[][]reverseMatrix = calculateReverseMatrix(matrix, transposeArray);
            matrixOut(reverseMatrix);
            return reverseMatrix;
        }
        static int[][] createMatrix(string path)
        {
            int[][] array = File.ReadAllLines(path)
                   .Select(l => l.Split(' ').Select(i => int.Parse(i)).ToArray())
                   .ToArray();
            return array;
        }
        static int calculateDeterminant(int[][] matrix)
        {
            int a1 = matrix[0][0], a2 = matrix[1][0], a3 = matrix[2][0];
            int b1 = matrix[0][1], b2 = matrix[1][1], b3 = matrix[2][1];
            int c1 = matrix[0][2], c2 = matrix[1][2], c3 = matrix[2][2];
            int determinant = (a1 * b2 * c3) + (a3 * b1 * c2) + (a2 * b3 * c1) - (a3 * b2 * c1) - (a1 * b3 * c2) - (a2 * b1 * c3);
            return determinant;
        }
        static double calculateDeterminant(double[][] matrix)
        {
            double a1 = matrix[0][0], a2 = matrix[1][0], a3 = matrix[2][0];
            double b1 = matrix[0][1], b2 = matrix[1][1], b3 = matrix[2][1];
            double c1 = matrix[0][2], c2 = matrix[1][2], c3 = matrix[2][2];
            double determinant = (a1 * b2 * c3) + (a3 * b1 * c2) + (a2 * b3 * c1) - (a3 * b2 * c1) - (a1 * b3 * c2) - (a2 * b1 * c3);
            return determinant;
        }
        static int calculateDeterminant2(int[][] matrix)
        {
            int determinant = matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];
            return determinant;
        }
        static int[][] deleteColumn(int[][]matrix,int n)
        {
            int[][] newMatrix = new int[0][];
            int k;
            for (int i = 0; i < matrix.Length; i++)
            {
                k = 0;
                Array.Resize<int[]>(ref newMatrix, newMatrix.Length + 1);
                newMatrix[^1] = new int[matrix[i].Length-1];
                for (int j= 0; j < matrix[i].Length; j++)
                {
                    if(j == n){continue;}
                    else
                    {
                        newMatrix[^1][k] = matrix[i][j];
                        k++;
                    }
                }   
            }
           
            return newMatrix;
        }
        static int[][] deleteRow(int[][] matrix, int n)
        {
            int[][] newMatrix = new int[0][];
            for (int i = 0; i < matrix.Length; i++)
            {
                if (i == n) { continue; }
                Array.Resize<int[]>(ref newMatrix,newMatrix.Length+1);
                newMatrix[^1] = new int[matrix[i].Length];
                for (int j = 0; j < matrix[i].Length; j++){newMatrix[^1][j] = matrix[i][j];}
            }
            return newMatrix;
        }
        static void matrixOut(int[][] matrix)
        {
            foreach(int[] row in matrix)
            {
                foreach(int i in row)
                {
                    Console.Write($"{i}\t");

                }
                Console.WriteLine();
            }
        }
        static void matrixOut(double[][] matrix)
        {
            foreach (double[] row in matrix)
            {
                foreach (double i in row)
                {
                    Console.Write($"{i}\t");

                }
                Console.WriteLine();
            }
        }
        //static void matrixOut(int[,] matrix)
        //{
        //  for(int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for(int j=0; j < matrix.GetLength(1); j++)
        //        {
        //            Console.Write(matrix[i, j]);
        //        }
        //        Console.WriteLine();
        //    }    
        //}
        static int[][] calculateMinorArray(int[][] matrix)
        {
            int[][] minorArray = new int[3][];
            for(int i = 0; i < matrix.Length; i++)
            {
                minorArray[i] = new int[3];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    int[][] helpArray = new int[matrix.Length - 1][];
                    helpArray = deleteColumn(deleteRow(matrix, i),j);
                    minorArray[i][j]= calculateDeterminant2(helpArray);
                    
                }
            }
            return minorArray;
        }
        //static int[,] turnToTwoDimensionalArray(int[][] matrix)
        //{
        //    int[,] arrayOut = new int[matrix.Length, 3];
        //    for (int i = 0; i < matrix.Length; i++)
        //    {
        //        for(int j = 0; j < matrix[i].Length; j++)
        //        {
        //            arrayOut[i,j] = matrix[i][j];
        //        }   
        //    }
        //    return arrayOut;
        //}
        //static int[][] turnToMultiDimensionalArray(int[,] matrix)
        //{
        //    int[][] arrayOut = new int[matrix.Length][];
        //    for (int i = 0; i < matrix.GetLength(0); i++)
        //    {
        //        for (int j = 0; j < matrix.GetLength(1); j++)
        //        {
        //            arrayOut[i][j] = matrix[i,j];
        //        }
        //    }
        //    return arrayOut;
        //}
     
        static int[][] calculateTransposedMatrix(int[][] matrix)
        {
            matrix[0][1] = -matrix[0][1];
            matrix[1][0] = -matrix[1][0];
            matrix[1][2] = - matrix[1][2];
            matrix[2][1] = -matrix[2][1];
            int[][] transopeseMatrix = new int[matrix.Length][];
            for(int i = 0; i < matrix.Length; i++)
            {
                transopeseMatrix[i]=new int[matrix[i].Length];
                for(int j = 0; j < matrix[i].Length; j++)
                {
                    transopeseMatrix[i][j]=matrix[j][i];
                }
            }
            return transopeseMatrix;
        }
        static double[][] calculateReverseMatrix(int[][] matrix, int[][] transposeMatrix)
        {
            double[][] doubleMatrix = new double[matrix.Length][];
            doubleMatrix = convertMatrixToDouble(matrix);
            double aboba =(double) 1 / (Math.Abs(calculateDeterminant(matrix)));
            for(int i = 0; i < transposeMatrix.Length; i++)
            {
                for (int j = 0; j < transposeMatrix[i].Length; j++)
                {
                    doubleMatrix[i][j] =(transposeMatrix[i][j] * aboba);
                }
            }
            doubleMatrix = MatrixRound(doubleMatrix);
            return doubleMatrix;
        }
        static double[][] convertMatrixToDouble(int[][] matrix)
        {
            double[][] doubleMatrix = new double[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                doubleMatrix[i]= new double[matrix[i].Length];  
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    doubleMatrix[i][j] = (double)matrix[i][j];
                }
            }
            return doubleMatrix;
        }
        static double[][] MatrixRound(double[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = Math.Round(matrix[i][j],2);
                }
            }
            return matrix;
        }
        static double calculateDiagonalSum(double[][] matrix)
        {
            double diagonalSum = 0;
            int k = 0;
            for (int i = 0; i < matrix.Length; i++) { diagonalSum += matrix[i][i];}
            for (int i = matrix.Length-1; i > -1; i--)
            {
                diagonalSum += matrix[k][i];
                k++;
            }
            diagonalSum = Math.Round(diagonalSum,2);
            return diagonalSum;
        }



    }
}
