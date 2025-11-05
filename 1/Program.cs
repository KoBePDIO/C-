using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1
{

    // Интерфейсы 
    interface Ix
    {
        double IxF0(double w);
        double IxF1();
    }

    interface Iy
    {
        double F0(double w);
        double F1();
    }

    interface Iz
    {
        double F0(double w);
        double F1();
    }

    //  Класс, реализующий три интерфейса
    class TestClass : Ix, Iy, Iz
    {
        public double w;

        // Конструктор
        public TestClass(double w)
        {
            this.w = w;
        }

        //  Реализация интерфейса Ix (неявная)
        public double IxF0(double w)
        {
            this.w = w;
            double result = Math.Abs(w);
            Console.WriteLine("IxF0: |w| = {0}", result);
            return result;
        }

        public double IxF1()
        {
            double result = Math.Abs(w);
            Console.WriteLine("IxF1: |w| = {0}", result);
            return result;
        }

        //  Реализация интерфейса Iy (неявная) 
        public double F0(double w)
        {
            this.w = w;
            double result = Math.Sin(w);
            Console.WriteLine("Iy F0 (неявно): sin(w) = {0}", result);
            return result;
        }

        public double F1()
        {
            double result = Math.Sin(w);
            Console.WriteLine("Iy F1 (неявно): sin(w) = {0}", result);
            return result;
        }

        //  Реализация интерфейса Iz (явная) 
        double Iz.F0(double w)
        {
            this.w = w;
            double result = w + 2;
            Console.WriteLine("Iz F0 (явно): w + 2 = {0}", result);
            return result;
        }

        double Iz.F1()
        {
            double result = w + 2;
            Console.WriteLine("Iz F1 (явно): w + 2 = {0}", result);
            return result;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            TestClass obj = new TestClass(5.0);

            Console.WriteLine("ПРЯМОЙ ВЫЗОВ МЕТОДОВ ОБЪЕКТА ");
            obj.IxF0(4.2);
            obj.IxF1();
            obj.F0(3.7);
            obj.F1();

            Console.WriteLine("\nВЫЗОВ С ЯВНЫМ ПРИВЕДЕНИЕМ ТИПА ");
            ((Ix)obj).IxF0(6.3);
            ((Ix)obj).IxF1();
            ((Iy)obj).F0(5.1);
            ((Iy)obj).F1();
            ((Iz)obj).F0(7.8);
            ((Iz)obj).F1();

            Console.WriteLine("\nВЫЗОВ ЧЕРЕЗ ИНТЕРФЕЙСНЫЕ ССЫЛКИ ");
            Ix ix = obj;
            Iy iy = obj;
            Iz iz = obj;

            Console.WriteLine(" Через Ix ");
            ix.IxF0(2.5);
            ix.IxF1();

          
        }
    }
}