namespace Main
{
    public class task7Class
    {
        public static void task7()
        {
            Console.WriteLine("Задание 7");
            Console.WriteLine("Введите размерность массива:");
            int n = Convert.ToInt32(Console.ReadLine());
            int[,] array = new int[n,n];
            Random random = new Random();
            int[] temp = new int[n];
            Console.WriteLine("Изначальная матрица");
            for (int i = 0; i < array.GetLength(0); i++)
            {
               for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i,j] = random.Next(1,51);
                    Console.WriteLine($"[{i+1}][{j+1}]{array[i, j]}");
                }
                Console.WriteLine("\n");
            }
            Console.WriteLine("Результат");
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if(i==0) temp[j] = array[i, j];
                    if (i == n - 1)
                    {
                        array[i, j] = temp[j];
                        Console.WriteLine($"[{i + 1}][{j + 1}]{array[i, j]}");
                        continue;
                    }
                    array[i,j] = array[i+1,j];
                    Console.WriteLine($"[{i + 1}][{j + 1}]{array[i, j]}");
                }
                Console.WriteLine("\n");
            }

        }
    }
}
