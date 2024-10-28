using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace QuadEquationCalc.UnitTests
{
    [TestFixture]
    public class CalculationTests
    {
        [TestCase(new double[] { 2, 5, -3.5 })]
        [TestCase(new double[] { 1, 4, 1 })]
        public void GetDiscriminant_ReturnsGreaterThanZero(double[] arguments)
        {
            Calculation calculation = new Calculation(arguments);

            double result = calculation.GetDiscriminant();

            ClassicAssert.Greater(result, 0);
        }

        [TestCase(new double[] { 1, 0, 1 })]
        [TestCase(new double[] { 1, 1, 1 })]
        public void GetDiscriminant_ReturnsLessThanZero(double[] arguments)
        {
            Calculation calculation = new Calculation(arguments);

            double result = calculation.GetDiscriminant();

            ClassicAssert.Less(result, 0);
        }

        [TestCase(new double[] { 4, 4, 1 })]
        [TestCase(new double[] { 3, 6, 3 })]
        public void GetDiscriminant_ReturnsEqualsZero(double[] arguments)
        {
            Calculation calculation = new Calculation(arguments);

            double result = calculation.GetDiscriminant();

            ClassicAssert.AreEqual(0, result);
        }

        [Test]
        public void GetRoots_DiscriminantIsGreaterThanZero_ReturnsTwoRoots()
        {
            Calculation calculation = new Calculation(new double[] { 2, 5, -3.5 });

            calculation.GetRoots();

            Assert.Multiple(() =>
            {
                ClassicAssert.AreEqual(2, calculation.RootCount);
                ClassicAssert.AreEqual(-3.07, calculation.FirstRoot);
                ClassicAssert.AreEqual(0.57, calculation.SecondRoot);
            });
        }

        [Test]
        public void GetRoots_DiscriminantIsLessThanZero_ReturnZeroRoots()
        {
            Calculation calculation = new Calculation(new double[] { 1, 0, 1 });

            calculation.GetRoots();

            ClassicAssert.AreEqual(0, calculation.RootCount);
        }

        [Test]
        public void GetRoots_DiscriminantIsZero_ReturnsOneRoot()
        {
            Calculation calculation = new Calculation(new double[] { 3, 6, 3 });

            calculation.GetRoots();

            Assert.Multiple(() =>
            {
                ClassicAssert.AreEqual(1, calculation.RootCount);
                ClassicAssert.AreEqual(calculation.FirstRoot, calculation.SecondRoot);
                ClassicAssert.AreEqual(-1, calculation.FirstRoot);
            });
        }
    }
}
