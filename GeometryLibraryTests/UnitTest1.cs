using NUnit.Framework;
using GeometryLibrary;
using System;

namespace GeometryLibraryTests
{
    public class Tests
    {
        [Test]
        public void CircleAreaCalculation()
        {
            CircleShape circle = new CircleShape(5);
            Assert.AreEqual(78.54, circle.CalculateArea(), 0.01);
        }

        [Test]
        public void TriangleAreaCalculation()
        {
            TriangleShape triangle = new TriangleShape(3, 4, 5);
            Assert.AreEqual(6, triangle.CalculateArea(), 0.01);
        }

        [Test]
        public void RightAngleTriangleCheck()
        {
            TriangleShape triangle = new TriangleShape(3, 4, 5);
            Assert.IsTrue(triangle.IsRightAngleTriangle());
        }

        [Test]
        public void ShapeFactory_CreateCircle()
        {
            IShape shape = ShapeFactory.CreateShape(new double[] { 5 });
            Assert.IsInstanceOf<CircleShape>(shape);
            Assert.AreEqual(78.54, shape.CalculateArea(), 0.01);
        }

        [Test]
        public void ShapeFactory_CreateTriangle()
        {
            IShape shape = ShapeFactory.CreateShape(new double[] { 3, 4, 5 });
            Assert.IsInstanceOf<TriangleShape>(shape);
            Assert.AreEqual(6, shape.CalculateArea(), 0.01);
        }

        [Test]
        public void ShapeFactory_InvalidParameters()
        {
            Assert.Throws<ArgumentException>(() => ShapeFactory.CreateShape(new double[] { 1, 2 }));
        }
    }
}
