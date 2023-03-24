using System.Collections;
using System.Text.RegularExpressions;

namespace task6
{
    class Car:IComparable
    {
        int model;
        int yearOfCreation;
        string number;
        static string[] modelsArray = { "Тойота", "Форд", "Феррари", "Ламборгини" };
        string ownerSecondName;
        public int CompareTo(object obj)       
        {
            Car car = (Car)obj;
            if (this.YearOfCreation > car.YearOfCreation) return 1;
            else if (this.YearOfCreation < car.YearOfCreation) return -1;
            return 0;
        }
        public class SortCarSByYearOfCreation : IComparer
        {
            public int Compare(object object1, object object2)
            {
                Car car1 = (Car)object1;
                Car car2 = (Car)object2;
                return car1.CompareTo(car2);
            }
        }
        public class SortCarSByModel : IComparer
        {
            public int Compare(object object1, object object2)
            {
                Car car1 = (Car)object1;
                Car car2 = (Car)object2;
                return String.Compare(modelsArray[car1.Model], modelsArray[car2.Model]);
            }
        }
        public class SortCarsBySecondName:IComparer
        {   
            public int Compare(object object1, object object2)
            {
                Car car1 = (Car)object1;
                Car car2 = (Car)object2;
                return String.Compare(car1.OwnerSecondName,car2.OwnerSecondName);
            }
        }
        public static bool operator ==(Car car1, int neededModel)
        {
            return car1.Equals(neededModel);
        }
        public static bool operator !=(Car car1, int neededModel)
        {
            return !car1.Equals(neededModel);   
        }
        public bool Equals(int neededModel)
        {
            if (this.Model == neededModel) return true;
            else return false;
        }
        public Car(int CarModel, int CarYearOfCreation, string CarNumber, string CarOwnerSecondName)
        {
            Model = CarModel;
            YearOfCreation = CarYearOfCreation;
            Number = CarNumber;
            OwnerSecondName = CarOwnerSecondName;
        }

        public Car()
        {
            model = 1;
            yearOfCreation = 2001 ;
            number = "А012АА";
            ownerSecondName = "Павлов";
        }
        public Car(int Model, int YearOfCreation, string OwnerSecondName)
        {
            model = Model;
            yearOfCreation = YearOfCreation;
            Number = "А012АА";
            ownerSecondName = OwnerSecondName;
        }
        public string[] ModelsArray
        {
            get { return modelsArray; }
        }
        public int Model
        {
            set
            {
                model = value;
            }
            get { return model; }
        }
        public int YearOfCreation
        {
            set
            {
                 yearOfCreation = value; 
            }
            get { return yearOfCreation; }
        }
        public string Number
        {
            set
            {
                number = value;
            }
            get { return number; }
        }
     
        public string OwnerSecondName
        {
            set { ownerSecondName = value; }
            get { return ownerSecondName; }
        }
        public static void sortCars(Car[] carArray)
        {
            Console.Clear();
            if (carArray.Length == 0)
            {
                Console.WriteLine("Массив машин пустой,сортировка невозможна");
                return;
            }
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите параметры сортировки");
                Console.WriteLine("1)По году выпуска\n2)По марке\n3)Отсортировать по фамилии владельца\n4)Вернуться");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        sort_By_YearOfCreation(ref carArray);
                        break;
                    case 2:
                        sort_By_Model(ref carArray);
                        break;
                    case 3:
                        sort_By_Second_Name(ref carArray);
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Введите корректный номер");
                        break;
                }
                Console.WriteLine("Нажмите любую клавишу,чтобы продолжить");
                Console.ReadKey();
                Console.Clear();
            }
        }
        public static void sort_By_YearOfCreation(ref Car[] carArray)
        {
            Console.WriteLine("Отсорованные по году создания машины:");
            Array.Sort(carArray,new Car.SortCarSByYearOfCreation());
            carArrayOut(carArray);
        }
        public static void sort_By_Model(ref Car[] carArray)
        { 
            Console.WriteLine("Отсорованные по моделям машины:");
            Array.Sort(carArray, new Car.SortCarSByModel());
            carArrayOut(carArray);
        }

        public static void validateNumber(string Number,int choice)
        {
            string[] validateArray = { @"^[А-Я]{1}\d{3}[А-Я]{2}$", @"^\d{3}[A-Z]{3}$" };
            if (Regex.IsMatch(Number, validateArray[choice])==false) { throw new Exception("Введите корректный номер"); }
        }
        public static void validateYearOfCreation(int YearOfCreation)
        {
            if (YearOfCreation > 2022) { throw new Exception("Введите корректную дату"); }
         
        }
        public static void validateModel(int model)
        {
            if (model < 0 | model > 4) { throw new Exception("Введите кореектную модель"); }

        }
        public static void find_Difference_Between_Cars_YearOfCreation(Car car1, Car car2)
        {
            int difference;
            if (car1.YearOfCreation > car2.YearOfCreation) { difference = car1.YearOfCreation - car2.YearOfCreation; }
            else { difference = car2.YearOfCreation - car1.YearOfCreation; }
            Console.WriteLine($"Разница в годах = {difference}");
        }
        public static bool Is_carArray_empty(Car[] carArray)
        {
            if (carArray.Length == 0) { Console.WriteLine("Массив пустой,действие невозиожно"); return true; };
            return false;
        }
        public static void select_Car_For_Method(Car[] carArray)
        {
            Console.Clear();
            if (Is_carArray_empty(carArray)) return;
            Console.WriteLine("Выберите машины,у которых хотите найти разницу в годе выпуска");
            carArrayOut(carArray);
            for(int i = 0; i < carArray.Length; i++) { Console.WriteLine($"{i+1}-ая машина"); }    
            Console.WriteLine("Ваш выбор 1");    
            int choice1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Ваш выбор 2");
            int choice2 = Convert.ToInt32(Console.ReadLine());
            find_Difference_Between_Cars_YearOfCreation(carArray[choice1-1], carArray[choice2-1]);  
        }
        public static void sort_By_Second_Name(ref Car[] carArray)
        {
            int count = 0;
            for (int i = 0; i < carArray.Length; i++)
            {
                if (carArray[i].OwnerSecondName == null) { Console.WriteLine($" Фамилия = {carArray[i].OwnerSecondName}"); count++; };
            }
            if (count == carArray.Length) { Console.WriteLine("Все поля моделей пустые,сортировка невозможна"); return; }
            Console.WriteLine("Отсорованные по фамилиям машины:");
            Array.Sort(carArray,new Car.SortCarsBySecondName());
            carArrayOut(carArray);
        }
        public static void arrayPrint (string[] array)
        {
            Console.WriteLine("Массив");
            foreach(string s in array) Console.WriteLine(s);
        }
        public static void print_Cars_With_Same_Model(Car[] carArray, int neededModel)
        {
            Console.WriteLine("Машины этой модели:");
            for (int i = 0; i < carArray.Length; i++)
                if (carArray[i] == neededModel) carArray[i].car_Print();
        }
        public void car_Print()
        {
            Console.WriteLine($"\nМодель:{Car.modelsArray[this.Model]}\nГод создания:{this.YearOfCreation}\nНомер:{this.Number}\nФамилия владельца:{this.OwnerSecondName}");
        }
        public static void carArrayOut(Car[] carArray)
        {
            if (Is_carArray_empty(carArray)) return;
            foreach (Car car in carArray) { car.car_Print(); }
        }
        public static Car print_Car()
        {
            Console.Clear();
            Console.WriteLine("\nМодель");
            for(int i =0;i< modelsArray.Length; i++)
            {
                Console.WriteLine($"{i + 1}){modelsArray[i]}");
            }
            int model = Convert.ToInt32(Console.ReadLine());
            validateModel(model);
            Console.WriteLine("Год создания");

            int yearOfCreation = Convert.ToInt32(Console.ReadLine());
            validateYearOfCreation(yearOfCreation);
            Console.WriteLine("Номер");
            int choice = chooseNumberValidation();
            Console.WriteLine("Введите номер");
            string number = Console.ReadLine();
            validateNumber(number, choice);
            Console.WriteLine("Фамилия владельца");
            string ownerSecondName = Console.ReadLine();
            Car car = new Car(model,yearOfCreation,number,ownerSecondName);
            return car;

        }
        public static Car[] print_Car_Array()
        {
            Console.WriteLine("Введите кол-во машин");
            int number = Convert.ToInt32(Console.ReadLine());
            Car[] carArray = new Car[number];
            for (int i = 0; i < carArray.Length; i++)
                carArray[i] = Car.print_Car();
            return carArray;
        }
        public static int chooseNumberValidation()
        {
            Console.WriteLine("Введите тип номера:\n1)Русский номер\n2)Американский номер");
            int choice = Convert.ToInt32(Console.ReadLine());
            return choice-1;
        }
        public static Car[] enter_Car_Array()
        {
            Car[] carArray = new Car[6];
            carArray[0] = new Car(0, 2005, "А012АА", "Пахомов");
            carArray[1] = new Car(0, 2010, "А012АА", "Абросов");
            carArray[2] = new Car(2, 2020, "А012АА", "Ведров");
            carArray[3] = new Car(3,2022, "А012АА", "Кренев");
            carArray[4] = new Car(2, 2009, "А012АА", "Мелковs");
            carArray[5] = new Car(3, 2010, "А012АА", "Кеков");
            return carArray;
        }
        public static void select_Model_For_Method(Car[] carArray)
        {
            Console.Clear();
            if (Is_carArray_empty(carArray)) return;
            Console.WriteLine("Выберите модель");
            for (int i = 0; i < modelsArray.Length; i++) { Console.WriteLine($"{i + 1}){modelsArray[i]}"); }
            Console.WriteLine("Ваш выбор ");
            int choice = Convert.ToInt32(Console.ReadLine());
            print_Cars_With_Same_Model(carArray, choice-1);
        }
        public static Car[] Read_car_array_from_file()
        {
            Car[] carArray = new Car[0];
            int i = 0;
            //int numberOfLines = 0;
            //using (StreamReader fs = new StreamReader(@"F:\C#\task5\files\ReadCarObjects.txt"))
            //{
            //    while (fs.ReadLine()!=null)
            //    {
            //        numberOfLines++;
            //    }
            //}
            using (StreamReader fs = new StreamReader(@"E:\C#\task5\files\ReadCarObjects.txt"))
            {
                while (true)
                {
                   
                    string modelS = fs.ReadLine();
                    if (modelS == null) break;
                    int model=0;
                    for (int z = 0; z < modelsArray.Length; z++)
                             if (modelS == modelsArray[z]) model = z;
                    int yearOfCreation = Convert.ToInt32(fs.ReadLine());
                    validateYearOfCreation(yearOfCreation);
                    string number = fs.ReadLine();
                    string ownderSecondName = fs.ReadLine();
                    if (number == null | ownderSecondName == null) break; 
                    Array.Resize(ref carArray, carArray.Length + 1);
                    carArray[i] = new Car(model, yearOfCreation, number, ownderSecondName);
                    i++;
                }
            }
            return carArray;
        }
        public static void Write_carArray_in_file(Car[] carArray)
        {
            if (Is_carArray_empty(carArray)) return;
            StreamWriter sw = new StreamWriter(@"E:\C#\task5\files\WriteCarObjects.txt");
            foreach (Car car in carArray) car.Write_car_in_file(sw);
            sw.Close();
            Console.WriteLine("Все машины были успешно записаны в файл");

        }
        public void Write_car_in_file(StreamWriter sw)
        {
            sw.WriteLine($"{modelsArray[this.Model]}\n{this.YearOfCreation}\n{this.Number}\n{this.OwnerSecondName}");
        }
        public static void Add_or_delete_element_in_carArray(ref Car[] carArray)
        {
            Console.Clear();
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите действие:\n1)Добавить новую машину\n2)Удалить машину\n3)Вернуться");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Add_element_in_carArray(ref carArray);
                        break;
                    case 2:
                        Delete_elements_in_carArray(ref carArray);
                        break;
                    case 3:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Введите корректный номер");
                        break;
                }
            }
        }
        public static void Add_element_in_carArray(ref Car[] carArray)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите действие:\n1)Добавить новую машину\n2)Вернуться");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Array.Resize(ref carArray, carArray.Length + 1);
                        carArray[carArray.Length-1] = print_Car();
                        break;
                    case 2:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Введите корректный номер");
                        break;
                }
              Console.Clear();
            }
        }
        public static void Delete_elements_in_carArray(ref Car[] carArray)
        {
            bool flag = true;
            while (flag)
            {
                Console.WriteLine("Выберите действие:\n1)Удалить машину\n2)Вернуться");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Delete_element(ref carArray);
                        break;
                    case 2:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Введите корректный номер");
                        break;
                }
            }
        }
        public static void Delete_element(ref Car[] carArray)
        {
            Console.WriteLine("Выберите машину,которую вы хотите удалить");
            carArrayOut(carArray);
            Console.WriteLine();
            for (int i = 0; i < carArray.Length; i++) { Console.WriteLine($"{i + 1}-ая машина"); }
            Console.WriteLine("Ваш выбор");
            int choice = Convert.ToInt32(Console.ReadLine()) -1;
            Car[] temp = new Car[carArray.Length-1];
            for(int i=0,j=0; i < carArray.Length; i++)
            {
                if (carArray[i] == carArray[choice]) continue;
                temp[j] = carArray[i];
                j++;
            }
            //Array.Resize(ref carArray, carArray.Length - 1);
            carArray = temp;
            Console.WriteLine("\nМашина была успешно удалена\n\nСписок машин после удаления");
            carArrayOut(carArray);
            Console.WriteLine("Нажмите любую клавишу,чтобы продолжить");
            Console.ReadKey();
            Console.Clear();
        }

    }
    public class task9Class
    {
        public static void task9()
        {
            Console.Clear();
            Console.WriteLine("Выберите способ создания массива:\n1)С клавиатуры\n2)Использовать заранее созданный\n3)Считать из файла");
            int choice_Way_To_Enter_Array = Convert.ToInt32(Console.ReadLine());
            Car[] carArray;
            switch (choice_Way_To_Enter_Array)
            {
                case 1:
                    carArray = Car.print_Car_Array();
                    break;
                case 2:
                    carArray = Car.enter_Car_Array();
                    break;
                case 3:
                    carArray = Car.Read_car_array_from_file();
                    break;
                default:
                    throw new Exception("Введите корректный номер");
            }
            Console.Clear();
            bool flag = true;
            while (flag == true)
            {
                Console.WriteLine("Нажмите любую клавишу,чтобы продолжить");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Что вы хотите сделать:\n1)Найти разницу в годах выпуска 2-ух машин\n2)Вывести все машины одной марки\n3)Вывести массив на экран\n4)Отсортировать машины\n5)Выписать все машины в файл\n6)Добавить или удалить машину\n7)Выйти");
                int choiceTask = Convert.ToInt32(Console.ReadLine());
                switch (choiceTask)
                {
                    case 1:
                        Car.select_Car_For_Method(carArray);
                        break;
                    case 2:
                        Car.select_Model_For_Method(carArray);
                        break;
                    case 3:
                        Console.WriteLine("Все машины");
                        Car.carArrayOut(carArray);
                        break;
                    case 4:
                        Car.sortCars(carArray);
                        break;
                    case 5:
                        Car.Write_carArray_in_file(carArray);
                        break;
                    case 6:
                        Car.Add_or_delete_element_in_carArray(ref carArray);
                        break;
                    case 7:
                        flag = false;
                        break;
                    default:
                        Console.WriteLine("Введите корректный номер");
                        break;
                }
            }
          
        }
    }







}

