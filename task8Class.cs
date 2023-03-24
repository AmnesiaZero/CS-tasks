using DeepMorphy;
using DeepMorphy.Model;


namespace task6
{
    public class task8Class
    {
        public static void task8()
        {
            var morph = new MorphAnalyzer(withLemmatization: true);
            Console.WriteLine("Задание 8");
            string path = @"E:\\C#\\files\\txt.txt";
            string txt = File.ReadAllText(path);
            string[] txtArray = txt.Split(' ');
            txt = txt.ToLower();
            txt = deleteSymbols(txt);   
            findMostPopularWordsAndTheirNumber(txtArray);
           // Lemmitisation(txtArray,morph);
            txt = txt.Replace(" ", "");
        }

        //static string[] Lemmitisation(string[] txtArray,MorphAnalyzer morph)
        //{
        //    int i = 0;
        //    //var results = morph.Parse(txtArray).ToArray;
        //    //var prekol = morph.Inflect(results);

        //    //var mainWord = results[0];
        //    //foreach (var morphInfo in results)
        //    //{
        //    //    Console.WriteLine(morphInfo);
        //    //}
        //    //return txtArray;
        //}
     
      
        static string deleteSymbols(string txt)
        {
            string[] deleteSymbols = { "!", ",", ".", "...", ":", ";", "?" };
            foreach (string sym in deleteSymbols)
            {
                txt = txt.Replace($"{sym}", "");
            }
            return txt;
        }
        //static object findMostCommonElemetInArray(object[] array)
        //{
        //    var query = (from item in array
        //                 group item by item into g
        //                 orderby g.Count() descending
        //                 select new { Item = g.Key, Count = g.Count() }).First();
        //    return query;
        //}
        static void findMostPopularWordsAndTheirNumber(string[] txtArray)
        {

            int[] resultArray = findNumberOfSameElementsInArrays(txtArray, txtArray);
            resultArray = sort(deleteDuplicates(resultArray));
            int num = 5;
            string[] mostPopularWordsArray = new string[num];
            for (int i = 0; i < num; i++) { mostPopularWordsArray[i] = txtArray[resultArray[i]]; }
            Console.WriteLine("Топ 5 популярных слов и количество их вхождений в тексте");
            Array.Reverse(resultArray, 0, resultArray.Length);
            for (int i = 0; i < mostPopularWordsArray.Length; i++) { Console.WriteLine($"{mostPopularWordsArray[i]}={resultArray[i]}"); }

        }
        static int[] findNumberOfSameElementsInArrays(string[] array1,string[] array2)
        {
            int result;
            int[] resultArray = new int[array1.Length];
            for (int i = 0; i < array1.Length; i++)
            {
                result = 0;
                for (int j = 0; j < array2.Length; j++)
                {
                    if (array1[i] == array2[j]) { result++; }
                }
                resultArray[i] = result;
            }
            return resultArray;
        }
        static int[] deleteDuplicates(int[] array)
        {
            int[] distinct = array.Distinct().ToArray();
            return distinct;
        }
        static int[] sort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i] > array[j])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }
        static void stringArrayOut(string[] array)
        {
            foreach(string str in array) { Console.WriteLine(str); }
        }
        static void intArrayOut(int[] array)
        {
            foreach (int i in array) { Console.WriteLine(i); }
        }

    }
}
               
        
        

