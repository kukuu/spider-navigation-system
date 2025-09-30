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
            var navigationService = new NavigationService(7, 15);
            var spider = new Spider { X = 4, Y = 10, Orientation = "Left" };
            var instructions = "FLEEREFLF";

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
            var navigationService = new NavigationService(10, 10);
            var spider = new Spider { X = 0, Y = 0, Orientation = "Up" };
            
            var result = navigationService.Navigate(spider, "L");
            
            Assert.AreEqual("Left", result.Orientation);
        }

        [TestMethod]
        public void TestTurningRight()
        {
            var navigationService = new NavigationService(10, 10);
            var spider = new Spider { X = 0, Y = 0, Orientation = "Up" };
            
            var result = navigationService.Navigate(spider, "R");
            
            Assert.AreEqual("Right", result.Orientation);
        }

        [TestMethod]
        public void TestMovingForward()
        {
            var navigationService = new NavigationService(10, 10);
            var spider = new Spider { X = 0, Y = 0, Orientation = "Up" };
            
            var result = navigationService.Navigate(spider, "F");
            
            Assert.AreEqual(0, result.X);
            Assert.AreEqual(1, result.Y);
        }

        [TestMethod]
        public void TestBoundaryLimits()
        {
            var navigationService = new NavigationService(5, 5);
            var spider = new Spider { X = 0, Y = 0, Orientation = "Down" };
            
            var result = navigationService.Navigate(spider, "F");
            
            Assert.AreEqual(0, result.X);
            Assert.AreEqual(0, result.Y);
        }

        [TestMethod]
        public void TestInvalidInstructionsAreIgnored()
        {
            var navigationService = new NavigationService(10, 10);
            var spider = new Spider { X = 0, Y = 0, Orientation = "Up" };
            
            var result = navigationService.Navigate(spider, "FXLYRZF");
            
            Assert.AreEqual(1, result.X);
            Assert.AreEqual(1, result.Y);
            Assert.AreEqual("Right", result.Orientation);
        }
    }
}
