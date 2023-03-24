using static System.Console;
namespace task6
{
    class CPoint
    {
        int x;
        int y;
        public int X { set { x = value; } get { return x; } }
        public int Y { set { y = value; } get { return y; } }
        public CPoint(int X, int Y)
        {
            x = X;
            y = Y;
        }
        public CPoint()
        {
            x = 0;
            y = 0;
        }
        public static bool operator ==(CPoint point1, CPoint point2)
        {
           return point1.Equals(point2);
        }
        public static bool operator !=(CPoint point1, CPoint point2)
        {
            return !point1.Equals(point2);
        }
        public bool Equals(CPoint point)
        {
            if (this.X == point.X && this.Y == point.Y) return true;
            else return false;
        }
    }

    class CRectangle
    {
        string name;
        CPoint dot1;
        CPoint dot2;
        CPoint dot3;
        CPoint dot4;
        int length1;
        int length2;
        int length3;
        int length4;
        public string Name { set { name = value; } get { return name; } }
        public CPoint Dot1 { set { dot1 = value; } get { return dot1; } }
        public CPoint Dot2 { set { dot2 = value; } get { return dot2; } }
        public CPoint Dot3 { set { dot3 = value; } get { return dot3; } }
        public CPoint Dot4 { set { dot4 = value; } get { return dot4; } }
        public int Length1 { set { length1 = value; } get { return length1; } }
        public int Length2 { set { length2 = value; } get { return length2; } }
        public int Length3 { set { length3 = value; } get { return length3; } }
        public int Length4 { set { length4 = value; } get { return length4; } }
        public CRectangle()
        {
            Dot1 = new CPoint(0, 0);
        }
        public CRectangle(CPoint Dot_1, CPoint Dot_2, CPoint Dot_3, CPoint Dot_4)
        {
            CPoint[] CPointArray = createDotArray(Dot_1, Dot_2, Dot_3, Dot_4);
            validate_figure(CPointArray);
            Dot1 = Dot_1;
            Dot2 = Dot_2;
            Dot3 = Dot_3;
            Dot4 = Dot_4;
        }
        public static CPoint[] createDotArray(CPoint Dot_1, CPoint Dot_2, CPoint Dot_3, CPoint Dot_4)
        {
            CPoint[] dotArray = new CPoint[4];
            dotArray[0] = Dot_1;
            dotArray[1] = Dot_2;
            dotArray[2] = Dot_3;
            dotArray[3] = Dot_4;
            return dotArray;
        }
        //public void validate_figure()
        //{
        //    CPoint[] dotArray = createDotArray(this.Dot1,this.Dot2,this.Dot3,this.Dot4);
        //    //validatePoints(dotArray);
        //    if (how_much_lines_in_figure_are_parallel(dotArray) != 4) throw new Exception("Фигура не валидна");
        //}
        public static void validate_figure(CPoint[] CPointArray)
        {
            validatePoints(CPointArray);
            if (how_much_lines_in_figure_are_parallel(CPointArray) != 2) throw new Exception("Фигура не валидна");
        }
        public static int how_much_lines_in_figure_are_parallel(CPoint[] CPointArray)
        {
            int count = 0;
            for (int i = 0; i < CPointArray.Length; i++)
                for (int j = 0; j < CPointArray.Length; j++)
                    if(Is_lines_are_parallel(CPointArray[i],CPointArray[j])) count++;
            count = count / 2;
            WriteLine($" Количество параллельных прямых = {count}");
            return count;
        }
        public static bool Is_lines_are_parallel(CPoint point1,CPoint point2)
        {
            bool flag = false;
            if (point1.X == point2.X && point1.Y != point2.Y) flag = true;
            else if(point1.X != point2.X && point1.Y == point2.Y) flag |= true;
            return flag;
        }
        public static void validatePoints(CPoint[] dotArray)
        {
            int count=0;
            for (int i = 0; i < dotArray.Length; i++)
            {
                count = 0;
                for (int j = 0; j < dotArray.Length; j++)
                {
                    if (dotArray[i] == dotArray[j]) count++; 
                }
                if (count >= 2) throw new Exception("Введите корректные точки");
            }
        }
        public static CPoint[] create_CPoint_Array(CRectangle rectangle)
        {
            CPoint[] CPointArray = { rectangle.Dot1, rectangle.Dot2, rectangle.Dot3, rectangle.Dot4 };
            return CPointArray;
        }
        public static void is_the_figures_cross(CRectangle figure1, CRectangle figure2)
        {
            CPoint[] pointArray1 = create_CPoint_Array(figure1);
            CPoint[] pointArray2 = create_CPoint_Array(figure2);
            bool flag = false;
            int[] x_array_first = create_x_array(pointArray1);
            int[] y_array_first = create_y_array(pointArray1);
            //Находим максимальный X и Y для второй фигуры
            int x_second_max = x_array_first.Max();
            int y_second_max = y_array_first.Max();
            //Находим минимальный X и Y для второй фигуры
            int x_second_min = x_array_first.Min();
            int y_second_min = y_array_first.Max();
            for (int i = 0; i < pointArray1.Length; i++)
            {
                if (pointArray1[i].X >= x_second_min && pointArray1[i].X <= x_second_max && pointArray1[i].Y >= y_second_min && pointArray1[i].X <= y_second_max)
                {
                    Console.WriteLine("Фигуры пересекаются");
                    flag = true;
                    break;
                }
            }
            if (flag == false) { WriteLine("Фигуры не пересекаются"); }
        }
        public static int[] create_x_array(CPoint[] pointArray)
        {
            int[] xArray = new int[pointArray.Length];
            for (int i = 0; i < pointArray.Length; i++)
            {
                xArray[i] = pointArray[i].X;
            }
            return xArray;
        }
        public static int[] create_y_array(CPoint[] pointArray)
        {
            int[] yArray = new int[pointArray.Length];
            for (int i = 0; i < pointArray.Length; i++)
            {
                yArray[i] = pointArray[i].Y;
            }
            return yArray;
        }
        public void find_the_perimetre_of_figure()
        {
            int perimetre = this.Length1 + this.Length2 + this.Length3 + this.Length4;
            WriteLine($"Периметр={perimetre}");
        }
        public void find_the_square_of_figure()
        {
            int square = this.Length1 * this.Length2;
            WriteLine($"Площадь={square}");
        }
        public  void calculate_Lengths()
        {
            CPoint[] CPointArray = create_CPoint_Array(this);
            int[] sidesArray = new int[4];
            for (int i = 0; i < CPointArray.Length; i++)
            {
                for (int j = 0; j < CPointArray.Length; j++)
                {
                    if (CPointArray[i].X == CPointArray[j].X && CPointArray[i].Y != CPointArray[j].Y)
                    {
                        sidesArray[i] = calculate_Length(CPointArray[i].Y, CPointArray[j].Y);
                    }
                    else if (CPointArray[i].Y == CPointArray[j].Y && CPointArray[i].X != CPointArray[j].X)
                    {
                        sidesArray[i] = calculate_Length(CPointArray[i].X, CPointArray[j].X);
                    }
                }
            }
            this.Length1 = sidesArray[0];
            this.Length2 = sidesArray[1];
            this.Length3 = sidesArray[2];
            this.Length4 = sidesArray[3];
            //WriteLine($"Длина\n 1){this.Length1}\n 2){this.Length2}\n 3){this.Length3}\n 4){this.Length4}"
        }
        public int calculate_Length(int point1, int point2)
        {
            int length = 0;
            if (point1 > point2) { length = point1 - point2; }
            if (point2 > point1) { length = point2 - point1; }
            return length;
        }
        public static void choose_multiple_figures(CTrapezoid[] cTrapezoidArray)
        {
            WriteLine("Выберите фигуру ");
            for (int i = 0; i < cTrapezoidArray.Length; i++) { WriteLine($"{i + 1})"); }
            Console.WriteLine("Ваш выбор 1 ");
            int choice1 = Convert.ToInt32(ReadLine());
            Console.WriteLine("Ваш выбор 2 ");
            int choice2 = Convert.ToInt32(ReadLine());
            is_the_figures_cross(cTrapezoidArray[choice1 - 1], cTrapezoidArray[choice2 - 1]);
        }
        public static void print_figure_Array(CRectangle[] figureArray)
        {
            for (int i = 0; i < figureArray.Length; i++) { WriteLine($"Фигура {i + 1}"); figureArray[i].figure_print(); }
        }
        public void figure_print()
        {
            this.calculate_Lengths();
            CPoint[] CPointArray = create_CPoint_Array(this);
            string[] lettersArray = new string[] { "A", "B", "C", "D" };
            WriteLine("Точки фигуры");
            for (int i = 0; i < CPointArray.Length; i++)
            {
                WriteLine($"{lettersArray[i]})X = {CPointArray[i].X}; Y = {CPointArray[i].Y}");
            }
            WriteLine($"Длины сторон фигуры\n1){this.Length1} 2){this.Length2} 3){this.Length3} 4){this.Length4}\n");
        }
        public void is_Figure_isosceles()
        {
            bool flag = false;
            int[] lengthArray = { this.Length1, this.Length2, this.Length3, this.Length4 };
            int count;
            for (int i = 0; i < lengthArray.Length; i++)
            {
                count = 0;
                for (int j = 0; j < lengthArray.Length; j++) { if (lengthArray[i] == lengthArray[j]) { count++; } }
                if (count >= 2)
                {
                    WriteLine("Фигура равнобедренная");
                    flag = true;
                    break;
                }
            }
            if (flag == false) { Console.WriteLine("Фигура не равнобедренная"); }
        }
    }
    class CTrapezoid : CRectangle
    {
        public CTrapezoid()
        {
            Dot1 = new CPoint(0, 0);
        }
        public CTrapezoid(CPoint Dot_1, CPoint Dot_2, CPoint Dot_3, CPoint Dot_4)
        {
            CPoint[] dotArray = createDotArray(Dot_1, Dot_2, Dot_3, Dot_4);
            validate_figure(dotArray);
            Dot1 = Dot_1;
            Dot2 = Dot_2;
            Dot3 = Dot_3;
            Dot4 = Dot_4;
        }
        public static CTrapezoid[] create_Trapezoid_Array()
        {
            CTrapezoid[] cTrapezoidArray = new CTrapezoid[2];
            cTrapezoidArray[0] = new CTrapezoid(new CPoint(3, 5), new CPoint(8, 5), new CPoint(1, 1), new CPoint(10, 1));
            cTrapezoidArray[1] = new CTrapezoid(new CPoint(1, 1), new CPoint(3, 5), new CPoint(7, 5), new CPoint(9, 1));
            return cTrapezoidArray;
        }
        public static CTrapezoid print_figure()
        {

            Console.WriteLine("Введите первую точку ");
            WriteLine("X");
            int x1 = Convert.ToInt32(Console.ReadLine());
            WriteLine("Y");
            int y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВведите вторую точку ");
            WriteLine("X");
            int x2 = Convert.ToInt32(Console.ReadLine());
            WriteLine("Y");
            int y2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВведите третью точку ");
            WriteLine("X");
            int x3 = Convert.ToInt32(Console.ReadLine());
            WriteLine("Y");
            int y3 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\nВведите четвёртую точку ");
            WriteLine("X");
            int x4 = Convert.ToInt32(Console.ReadLine());
            WriteLine("Y");
            int y4 = Convert.ToInt32(Console.ReadLine());
            CTrapezoid trapezoid = new CTrapezoid(new CPoint(x1, y1), new CPoint(x2, y2), new CPoint(x3, y3), new CPoint(x4, y4));
            return trapezoid;


        }
        public static CTrapezoid[] print_figure_Array()
        {
            Console.WriteLine("Введите кол-во фигур");
            int number = Convert.ToInt32(Console.ReadLine());
            CTrapezoid[] trapezoidArray = new CTrapezoid[number];
            for (int i = 0; i < trapezoidArray.Length; i++)
            {
                Console.WriteLine($"Фигура {i+1}");
                trapezoidArray[i] = print_figure();
            }
            return trapezoidArray;
        }
        public static void choose_the_figure(CTrapezoid[] cTrapezoidArray)
        {
            WriteLine("Выберите фигуру");
            for (int i = 0; i < cTrapezoidArray.Length; i++) { WriteLine($"{i + 1})"); }
            Console.WriteLine("Ваш выбор ");
            int choiceFigure = Convert.ToInt32(ReadLine());
            CTrapezoid figure = cTrapezoidArray[choiceFigure - 1];
            figure.calculate_Lengths();
            bool flag = true;
            while (flag)
            {
                WriteLine("Что хотите сделать?\n1)Расчитать площадь трапеции\n2)Расчитать периметр трапеции\n3)Является ли трапеция равнобедренной\n4)Выход");
                int choice = Convert.ToInt32(ReadLine());
                switch (choice)
                {
                    case 1:
                        figure.find_the_square_of_figure();
                        break;
                    case 2:
                        figure.find_the_perimetre_of_figure();
                        break;
                    case 3:
                        figure.is_Figure_isosceles();
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        WriteLine("Введите корректный номер");
                        break;
                }
            }
        }

    }


    public class task10Class
    {
        public static void task10()
        {
            Clear();
            Console.WriteLine("Выберите способ создания массива:\n1)С клавиатуры\n2)Использовать заранее созданный\n3)Считать из файла");
            int choice_Way_To_Enter_Array = Convert.ToInt32(Console.ReadLine());
            CTrapezoid[] cTrapezoidArray;
            switch (choice_Way_To_Enter_Array)
            {
                case 1:
                    cTrapezoidArray = CTrapezoid.print_figure_Array();
                    break;
                case 2:
                    cTrapezoidArray = CTrapezoid.create_Trapezoid_Array();
                    break;
                default:
                    throw new Exception("Введите корректный номер");
            }
            Clear();
            bool flag = true;
            while (flag)
            {
                WriteLine("Что вы хотите сделать?\n1)Вывести все трапеции\n2)Выбрать фигуру для дальнейших действий\n3)Просчитать,пересекаются ли 2 фигуры\n4)Выход");
                int choice1 = Convert.ToInt32(ReadLine());
                switch (choice1)
                {
                    case 1:
                        CTrapezoid.print_figure_Array(cTrapezoidArray);
                        break;
                    case 2:
                        CTrapezoid.choose_the_figure(cTrapezoidArray);
                        break;
                    case 3:
                        CTrapezoid.choose_multiple_figures(cTrapezoidArray);
                        break;
                    case 4:
                        flag = false;
                        break;
                    default:
                        WriteLine("Введите корректный номер");
                        break;

                }
            }



        }
    }
}
