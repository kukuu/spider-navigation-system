using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiderNavigation.Models;
using SpiderNavigation.Utils;

namespace SpiderNavigation.Tests
{
    [TestClass]
    public class SpiderTests
    {
        [TestMethod]
        public void TestExampleFromRequirements()
        {
            // Arrange
            var spider = new Spider(4, 10, "Left", 7, 15);
            var instructions = "FLEEREFLF";

            // Act
            spider.ExecuteInstructions(instructions);
            var result = spider.GetFinalPosition();

            // Assert
            Assert.AreEqual("5 7 Right", result);
        }

        [TestMethod]
        public void TestTurningLeft()
        {
            var spider = new Spider(0, 0, "Up", 10, 10);
            spider.ExecuteInstructions("L");
            Assert.AreEqual("Left", spider.Orientation);
        }

        [TestMethod]
        public void TestTurningRight()
        {
            var spider = new Spider(0, 0, "Up", 10, 10);
            spider.ExecuteInstructions("R");
            Assert.AreEqual("Right", spider.Orientation);
        }

        [TestMethod]
        public void TestMovingForward()
        {
            var spider = new Spider(0, 0, "Up", 10, 10);
            spider.ExecuteInstructions("F");
            Assert.AreEqual(0, spider.X);
            Assert.AreEqual(1, spider.Y);
        }

        [TestMethod]
        public void TestBoundaryLimits()
        {
            var spider = new Spider(0, 0, "Down", 5, 5);
            spider.ExecuteInstructions("F");
            Assert.AreEqual(0, spider.X);
            Assert.AreEqual(0, spider.Y);
        }
    }

    [TestClass]
    public class InputParserTests
    {
        [TestMethod]
        public void ParseWallSize_ValidInput_ReturnsCorrectValues()
        {
            var (width, height) = InputParser.ParseWallSize("7 15");
            Assert.AreEqual(7, width);
            Assert.AreEqual(15, height);
        }

        [TestMethod]
        public void ParseSpiderPosition_ValidInput_ReturnsCorrectValues()
        {
            var (x, y, orientation) = InputParser.ParseSpiderPosition("4 10 Left");
            Assert.AreEqual(4, x);
            Assert.AreEqual(10, y);
            Assert.AreEqual("Left", orientation);
        }

        [TestMethod]
        public void ParseInstructions_ValidInput_ReturnsCorrectValue()
        {
            var instructions = InputParser.ParseInstructions("FLEEREFLF");
            Assert.AreEqual("FLEEREFLF", instructions);
        }
    }
}
