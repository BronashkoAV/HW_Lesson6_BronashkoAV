using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Lesson6_BronashkoAV
{
    class Program
    {
        #region FirstTask
        public delegate double Fun(double x, double a);

        class ProgramOne
        {
            public static void Table(Fun F, double x, double b, double a)
            {
                Console.WriteLine("----- X ----- Y -----");
                while (x <= b)
                {
                    Console.WriteLine("| {0,8:0.000} | {1,8:0.000} |", x, F(x, a));
                    x += 1;
                }
                Console.WriteLine("---------------------");
            }
            // Создаем метод для передачи его в качестве параметра в Table
            public static double MyFunc(double x, double a)
            {
                return a * (x * x);
            }
            public static double MyFuncSin(double x, double a)
            {
                return a * Math.Sin(x);
            }

            public void FirstTask()
            {
                // Создаем новый делегат и передаем ссылку на него в метод Table
                Console.WriteLine("Таблица функции MyFunc:");
                // Параметры метода и тип возвращаемого значения, должны совпадать с делегатом
                Table(new Fun(MyFunc), -2, 2, 3);
                Console.WriteLine("Еще раз та же таблица, но вызов организован по новому");
                // Упрощение(c C# 2.0).Делегат создается автоматически.
                Table(MyFunc, -2, 2, 3);
                Console.WriteLine("Таблица функции Sin:");
                Table(MyFuncSin, -2, 2, 3); // Можно передавать уже созданные методы
                Console.WriteLine("Таблица функции x^2:");
                // Упрощение(с C# 2.0). Использование анонимного метода
                Table(delegate (double x, double a) { return a * Math.Sin(x); }, 0, 3, 4);
                Console.ReadKey();
            }
        }
        #endregion

        #region SecondTask
        public delegate double Function(double x);

        class ProgramTwo
        {

            public struct Functions
            {
                public static double Line(double x)
                {
                    return x;
                }
                public static double Parabola(double x)
                {
                    return x * x;
                }
                public static double Hyperbola(double x)
                {
                    return x * x * x;
                }
                public static double Sin(double x)
                {
                    return Math.Sin(x);
                }
                public static double Cos(double x)
                {
                    return Math.Cos(x);
                }
                public static double Write(double x)
                {
                    return 10 + x * 3 + x * x;
                }
            }

            public static double ScanMin(Function F, double from, double before)
            {
                double x = from;
                double min = F(x);
                while (x >= from && x <= before)
                {
                    if (F(x) <= min) min = F(x);
                    x += 1;
                }
                Console.WriteLine("min: " + min);
                return min;
            }

            public static void Scan()
            {
                double from, before;
                Console.Write("from: "); from = Convert.ToDouble(Console.ReadLine());
                Console.Write("before: "); before = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Select Fun:");
                Console.WriteLine("1)Line");
                Console.WriteLine("2)Parabola");
                Console.WriteLine("3)Hyperbola");
                Console.WriteLine("4)Sin");
                Console.WriteLine("5)Cos");
                Console.WriteLine("6)Write");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Line");
                        ProgramTwo.ScanMin(ProgramTwo.Functions.Line, from, before);
                        break;
                    case "2":
                        Console.WriteLine("Parabola");
                        ProgramTwo.ScanMin(ProgramTwo.Functions.Parabola, from, before);
                        break;
                    case "3":
                        Console.WriteLine("Hyperbola");
                        ProgramTwo.ScanMin(ProgramTwo.Functions.Hyperbola, from, before);
                        break;
                    case "4":
                        Console.WriteLine("Sin");
                        ProgramTwo.ScanMin(ProgramTwo.Functions.Sin, from, before);
                        break;
                    case "5":
                        Console.WriteLine("Cos");
                        ProgramTwo.ScanMin(ProgramTwo.Functions.Cos, from, before);
                        break;
                    case "6":
                        Console.WriteLine("Write");
                        ProgramTwo.ScanMin(ProgramTwo.Functions.Write, from, before);
                        break;
                }
            }

        }
        #endregion

        static void Main(string[] args)
        {


            Console.ReadKey();
        }
    }
}
