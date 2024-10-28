using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuadEquationCalc
{
    /// <summary>
    /// Класс с параметрами и формулами для поиска корней квадратного уравнения
    /// </summary>
    public class Calculation
    {
        #region Свойства

        /// <summary>
        /// Возвращает аргумент a уравнения
        /// </summary>
        public double A { get; private set; }

        /// <summary>
        /// Возвращает аргумент b уравнения
        /// </summary>
        public double B { get; private set; }

        /// <summary>
        /// Возвращает аргумент c уравнения
        /// </summary>
        public double C { get; private set; }

        /// <summary>
        /// Возвращает первый корень уравнения
        /// </summary>
        public double FirstRoot { get; private set; }

        /// <summary>
        /// Возвращает второй корень уравнения
        /// </summary>
        public double SecondRoot { get; private set; }

        /// <summary>
        /// Возвращает количество корней в уравнении
        /// </summary>
        public int RootCount { get; private set; }

        #endregion

        #region Конструкторы

        /// <summary>
        /// Инициализирует экземпляр класса
        /// </summary>
        /// <param name="arguments">Массив аргументов уравнения</param>
        public Calculation(double[] arguments)
        {
            this.A = arguments[0];
            this.B = arguments[1];
            this.C = arguments[2];
        }

        #endregion

        #region Методы

        /// <summary>
        /// Рассчитывает корни уравнения с округлением до второго знака
        /// </summary>
        public void GetRoots()
        {
            double discriminant = GetDiscriminant();

            if (discriminant > 0)
            {
                RootCount = 2;
                FirstRoot = Math.Round(((-B) - Math.Sqrt(discriminant)) / (2 * A), 2);
                SecondRoot = Math.Round(((-B) + Math.Sqrt(discriminant)) / (2 * A), 2);
            }
            else if (discriminant == 0)
            {
                RootCount = 1;
                FirstRoot = SecondRoot = Math.Round((-B) / (2 * A), 2);
            }
            else
            {
                RootCount = 0;
                FirstRoot = SecondRoot = 0;
            }
        }

        /// <summary>
        /// Рассчитывает дискриминант
        /// </summary>
        /// <returns>Значение дискриминанта</returns>
        public double GetDiscriminant()
        {
            return B * B - 4 * A * C;
        }

        #endregion
    }
}
