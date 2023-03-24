using Main;
using System;
using task6;

namespace task5
{
    class MainMenu
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Выберите номер практической:\n6)Одномерные массивы\n7)Двумерные массивы\n8)Усложнённая по массивам\n9)Усложнённая по строкам\n10)Классы\n11)Усложнённое классы\n12)Наследование");
                int numb = Convert.ToInt32(Console.ReadLine());
                switch (numb)
                {
                    case 6:
                        task6Class.task6();
                        break;
                    case 7:
                        task7Class.task7();
                        break;
                    case 8:
                        task7AltClass.task7Alt();
                        break;
                    case 9:
                        task8Class.task8();
                        break;
                    case 10:
                        task9Class.task9();
                        break;
                    case 11:
                        task9AltClass.task9Alt();
                        break;
                    case 12:
                        task10Class.task10();
                        break;
                    default:
                        Console.WriteLine("Выберите корренктный номер");
                        break;
                }
            }
            catch (ArithmeticException e)
            {
                Console.WriteLine("Арифметическая ошибка : {0}\nFile: {1}\nLocation : {2} ", e.Message, e.Source, e.TargetSite);
            }
            catch (FormatException e)
            {
                Console.WriteLine("Ошибка формата : {0}\nFile: {1}\nLocation : {2} ", e.Message, e.Source, e.TargetSite);
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine("Вне зоны значений : {0}\nFile: {1}\nLocation : {2} ", e.Message, e.Source, e.TargetSite);
            }
            catch (IOException e)
            {
                Console.WriteLine("Ошибка файла : {0}\nFile: {1}\nLocation : {2} ", e.Message, e.Source, e.TargetSite);
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка : {0}\nFile: {1}\nLocation : {2} ", e.Message, e.Source, e.TargetSite);
            }
        }
    }

}

