using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_Lesson6_BronashkoAV
{
    public delegate double Fun(double x, double a);

    class Program
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

        static void Main(string[] args)
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
            Table(delegate (double x, double a) { return a*Math.Sin(x); }, 0, 3, 4);
            Console.ReadKey();
        }
    }
}
