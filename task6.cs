using System;
namespace task5
{
    class task6Class
    {
        public static void task6()
        {
            Console.WriteLine("Задание 6");
            Console.WriteLine("Введите размерность массива");
            Random rnd = new Random();
            int n = Convert.ToInt32(Console.ReadLine());
            int[] rez = new int[n];
            Console.WriteLine("Массив");
            int count4 = 0, count5 = 0;
            for (int i = 0; i < rez.Length; i++)
            {
                rez[i] = rnd.Next(2, 6);
                Console.WriteLine($"[{i + 1}]{rez[i]}");
            }
            foreach (int i in rez)
            {
                if (rez[i] == 4) count4++;
                if (rez[i] == 5) count5++;
            }
            Console.WriteLine($"Количество людей с 4 - {count4}\nКоличество людей с 5 - {count5}");
        }
    }
}

