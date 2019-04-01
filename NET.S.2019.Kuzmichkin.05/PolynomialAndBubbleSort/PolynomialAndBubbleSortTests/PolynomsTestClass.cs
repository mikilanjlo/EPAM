using NUnit.Framework;
using PolynomialAndBubbleSort;
namespace Tests
{
    [TestFixture]
    public class PolynomTwstsClass
    {
        [Test]
        public void PolynomsEquelsTrueTest()
        {
            Polynomial first = new Polynomial(3, 2, 4);
            Polynomial second = new Polynomial(3, 2, 4);
            Assert.IsTrue(first.Equals(second));
        }

        [Test]
        public void PolynomsEquelsTrueOperatorTest()
        {
            Polynomial first = new Polynomial(3, 2, 4);
            Polynomial second = new Polynomial(3, 2, 4);
            Assert.IsTrue(first == second);
        }

        [Test]
        public void PolynomsEquelsFalseOperatorTest()
        {
            Polynomial first = new Polynomial(3, 2, 4);
            Polynomial second = new Polynomial(3, 5, 4);
            Assert.IsTrue(first != second);
        }

        //[Test]
        //public void PolynomsGetHashCodeTest()
        //{
        //    Polynomial polynom = new Polynomial(2, 3, 4);
        //    Assert.AreEqual(466, polynom.GetHashCode());
        //}

        [Test]
        public void PolynomsToStringTest()
        {
            Polynomial polynom = new Polynomial(2, -3, 4);
            Assert.AreEqual("4x^2 -3x^1 + 2x^0 ", polynom.ToString());
        }

        [TestCase(new double[] { 2, 3, 4}, new double[] { 2,3,4}, new double[] { 4, 6, 8})]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 3, 4, 2 }, new double[] { 4, 6, 8, 2 })]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 3 }, new double[] { 4, 6, 4 })]
        public void PolynomsSumTests(double[] arr, double[] arr2, double[] arrExpect)
        {
            Polynomial first = new Polynomial(arr);
            Polynomial second = new Polynomial(arr2);
            Polynomial actual = first + second;
            Polynomial expected = new Polynomial(arrExpect);
            Assert.AreEqual(expected,actual);
        }

        [TestCase(new double[] { 2, 2, 4 }, new double[] { 2, 4, 4 }, new double[] { 0, -2, 0 })]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 3, 4, 2 }, new double[] { 0, 0, 0, -2 })]
        [TestCase(new double[] { 2, 3, 4 }, new double[] { 2, 3 }, new double[] { 0, 0, 4 })]
        public void PolynomsSubTests(double[] arr, double[] arr2, double[] arrExpect)
        {
            Polynomial first = new Polynomial(arr);
            Polynomial second = new Polynomial(arr2);
            Polynomial actual = first - second;
            Polynomial expected = new Polynomial(arrExpect);
            Assert.AreEqual(expected, actual);
        }

        [TestCase(new double[] { -5, 3, 1 }, new double[] { 11, -2, -3,0, 1 }, new double[] { -55, 43,20,-11,-8,3,1 })]
        public void PolynomsMulTests(double[] arr, double[] arr2, double[] arrExpect)
        {
            Polynomial first = new Polynomial(arr);
            Polynomial second = new Polynomial(arr2);
            Polynomial actual = first * second;
            Polynomial expected = new Polynomial(arrExpect);
            Assert.IsTrue(expected== actual);
        }


        [TestCase(new double[] { 2, 2, -4 }, 2, new double[] { 4, 4, -8 })]
        public void PolynomsMulByIntTests(double[] arr, int number, double[] arrExpect)
        {
            Polynomial first = new Polynomial(arr);
            Polynomial actual = first * number;
            Polynomial expected = new Polynomial(arrExpect);
            Assert.IsTrue(expected== actual);
        }
    }
}