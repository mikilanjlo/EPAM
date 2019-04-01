using NUnit.Framework;
using PolynomialAndBubbleSort;
namespace Tests
{
    [TestFixture]
    class MatrixSortClass
    {
        private  int[,] matrix ={ { 1, 4, 6 }, { 2, 3, 4 }, { 7, 8, 9 } };
        
        [Test]
        public void MatrixSumSortLineTest()
        {
            int[,] actual = Matrix.GetClone(matrix);
            Matrix.SumSortLine(actual);
            
            int[,] expected = { { 2, 3, 4 }, { 1, 4, 6 },{ 7, 8, 9 }  };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MatrixMaxSortLineTest()
        {
            int[,] actual = Matrix.GetClone(matrix);
            Matrix.MaxSortLine(actual);
            int[,] expected = { { 2, 3, 4 }, { 1, 4, 6 }, { 7, 8, 9 } };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MatrixMinSortLineTest()
        {
            int[,] actual = Matrix.GetClone(matrix);
            Matrix.MinSortLine(actual);
            int[,] expected = { { 1, 4, 6 },  { 2, 3, 4 },  { 7, 8, 9 } };
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MatrixReverseLineTest()
        {
            int[,] actual = Matrix.GetClone(matrix);
            Matrix.ReverseLine(actual);
            int[,] expected = { { 7, 8, 9 }, { 2, 3, 4 }, { 1, 4, 6 }  };
            Assert.AreEqual(expected, actual);
        }
    }
}
