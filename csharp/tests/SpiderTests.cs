using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiderNavigation.Models;
using SpiderNavigation.Services;

namespace SpiderNavigation.Tests
{
    [TestClass]
    public class SpiderTests
    {
        [TestMethod]
        public void TestExampleFromRequirements()
        {
            // Arrange
            var navigationService = new NavigationService();
            var spider = new Spider(4, 10, "Left", 7, 15);
            var instructions = "FLFLFRFFLF"; // CORRECT instructions from spec

            // Act
            var result = navigationService.Navigate(spider, instructions);

            // Assert
            Assert.AreEqual(5, result.X);
            Assert.AreEqual(7, result.Y);
            Assert.AreEqual("Right", result.Orientation);
        }

        [TestMethod]
        public void TestTurningLeft()
        {
            var spider = new Spider(0, 0, "Up", 10, 10);
            spider.TurnLeft();
            Assert.AreEqual("Left", spider.Orientation);
        }

        [TestMethod]
        public void TestTurningRight()
        {
            var spider = new Spider(0, 0, "Up", 10, 10);
            spider.TurnRight();
            Assert.AreEqual("Right", spider.Orientation);
        }

        [TestMethod]
        public void TestMovingForward()
        {
            var spider = new Spider(0, 0, "Up", 10, 10);
            spider.MoveForward();
            Assert.AreEqual(0, spider.X);
            Assert.AreEqual(1, spider.Y);
        }

        [TestMethod]
        public void TestBoundaryLimits()
        {
            var spider = new Spider(0, 0, "Down", 5, 5);
            spider.MoveForward();
            Assert.AreEqual(0, spider.X);
            Assert.AreEqual(0, spider.Y);
        }

        [TestMethod]
        public void TestInvalidInstructionsAreIgnored()
        {
            var navigationService = new NavigationService();
            var spider = new Spider(0, 0, "Up", 10, 10);
            var result = navigationService.Navigate(spider, "FXLYRZF"); // X, Y, Z should be ignored
            Assert.AreEqual(1, result.X);
            Assert.AreEqual(1, result.Y);
            Assert.AreEqual("Right", result.Orientation);
        }
    }
}
