using System;

namespace QuadEquationCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите аргументы a, b и c через пробел:");
            if (GetArguments(out double[] arguments))
            {
                Calculation calculation = new Calculation(arguments);
                calculation.GetRoots();
                if (calculation.RootCount == 2)
                {
                    Console.WriteLine($"Корни уравнения: {calculation.FirstRoot}, {calculation.SecondRoot}");
                }
                else if (calculation.RootCount == 1)
                {
                    Console.WriteLine($"Единственный корень уравнения: {calculation.FirstRoot}");
                }
                else
                {
                    Console.WriteLine("Дискриминант отрицательный. Корней нет.");
                }
            }
        }

        static bool GetArguments(out double[] arguments)
        {
            try
            {
                arguments = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            }
            catch (FormatException)
            {
                Console.WriteLine("\nВведены некорректные значения.");
                arguments = new double[3];
                return false;
            }
            if (arguments.Length != 3)
            {
                Console.WriteLine("\nНеобходимо ввести только три аргумента!");
                return false;
            }
            if (arguments[0] == 0)
            {
                Console.WriteLine("\nАргумент a не может быть равен 0");
                return false;
            }
            return true;
        }
    }
}