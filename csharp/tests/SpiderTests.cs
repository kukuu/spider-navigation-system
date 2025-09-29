using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpiderNavigation.Models;
using SpiderNavigation.Services;
using SpiderNavigation.Utils;

namespace SpiderNavigation.Tests
{
    [TestClass]
    public class SpiderTests
    {
        [TestMethod]
        public void TestExampleNavigation()
        {
            // Arrange
            var wallSize = (7, 15);
            var spiderPosition = (4, 10, "Left");
            var instructions = "FLFLFRFFLF";
            
            // Act
            var spider = NavigationService.Navigate(wallSize, spiderPosition, instructions);
            
            // Assert
            Assert.AreEqual("5 7 Right", spider.GetFinalPosition());
        }
        
        [TestMethod]
        public void TestTurnOperations()
        {
            var spider = new Spider(0, 0, "Up", 5, 5);
            
            spider.TurnRight();
            Assert.AreEqual("Right", spider.Orientation);
            
            spider.TurnLeft();
            Assert.AreEqual("Up", spider.Orientation);
        }
        
        [TestMethod]
        public void TestMoveOperations()
        {
            var spider = new Spider(2, 2, "Up", 5, 5);
            
            spider.MoveForward();
            Assert.AreEqual(3, spider.Y);
            
            spider.TurnRight();
            spider.MoveForward();
            Assert.AreEqual(3, spider.X);
        }
    }
}