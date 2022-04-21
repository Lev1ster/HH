using Figures;
using NUnit.Framework;
using System;

namespace ClassFindAreaTests
{
    public class ClassFindAreaTests
    {
        [TestCase(5, 5, 5)]
        [TestCase(6, 6, 1)]
        [TestCase(2, 2, 3)]
        public void FindAreaTriangle_Success(int a, int b, int c)
        {
            //Act
            double p = (a + b + c) / 2;
            double expected = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            //Arrange
            double actual = FindAreaClass.FindAreaTriangle(a, b, c);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(1, 2, 1)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, -1, -1)]
        public void FindAreaTriangle_Exception(int a, int b, int c)
        {
            Assert.Throws<ArgumentException>(() => FindAreaClass.FindAreaTriangle(a, b, c));
        }

        [TestCase(5)]
        [TestCase(1)]
        [TestCase(2)]
        public void FindAreaCircle_Success(int radius)
        {
            //Act
            double expected = Math.PI * radius * radius;

            //Arrange
            double actual = FindAreaClass.FindAreaCircle(radius);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestCase(0)]
        [TestCase(-1)]
        public void FindAreaCircle_Exception(int radius)
        {
            Assert.Throws<ArgumentException>(() => FindAreaClass.FindAreaCircle(radius));
        }
    }
}