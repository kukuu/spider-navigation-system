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
            // Arrange
            var spider = new Spider(0, 0, "Up", 5, 5);
            
            // Act & Assert - Right turn
            spider.TurnRight();
            Assert.AreEqual("Right", spider.Orientation);
            
            // Act & Assert - Left turn
            spider.TurnLeft();
            Assert.AreEqual("Up", spider.Orientation);
        }
        
        [TestMethod]
        public void TestMoveOperations()
        {
            // Arrange
            var spider = new Spider(2, 2, "Up", 5, 5);
            
            // Act & Assert - Move up
            spider.MoveForward();
            Assert.AreEqual(3, spider.Y);
            Assert.AreEqual(2, spider.X);
            
            // Act & Assert - Turn and move right
            spider.TurnRight();
            spider.MoveForward();
            Assert.AreEqual(3, spider.X);
            Assert.AreEqual(3, spider.Y);
        }
        
        [TestMethod]
        public void TestBoundaryMovement()
        {
            // Arrange - Spider at top right corner facing up and right
            var spider = new Spider(5, 5, "Up", 5, 5);
            
            // Act - Try to move beyond boundaries
            spider.MoveForward(); // Up - should not move (already at top)
            spider.TurnRight();
            spider.MoveForward(); // Right - should not move (already at right edge)
            
            // Assert
            Assert.AreEqual(5, spider.X);
            Assert.AreEqual(5, spider.Y);
            Assert.AreEqual("Right", spider.Orientation);
        }
        
        [TestMethod]
        public void TestInputParsing()
        {
            // Arrange & Act
            var wallSize = InputParser.ParseWallSize("7 15");
            var spiderPos = InputParser.ParseSpiderPosition("4 10 Left");
            var instructions = InputParser.ParseInstructions("FLFLFRFFLF");
            
            // Assert
            Assert.AreEqual(7, wallSize.Width);
            Assert.AreEqual(15, wallSize.Height);
            Assert.AreEqual(4, spiderPos.X);
            Assert.AreEqual(10, spiderPos.Y);
            Assert.AreEqual("Left", spiderPos.Orientation);
            Assert.AreEqual("FLFLFRFFLF", instructions);
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidWallSizeInput()
        {
            InputParser.ParseWallSize("7");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidSpiderPositionInput()
        {
            InputParser.ParseSpiderPosition("4 10 InvalidDirection");
        }
        
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestInvalidInstructionsInput()
        {
            InputParser.ParseInstructions("FLFX"); // X is invalid
        }
        
        [TestMethod]
        public void TestCompleteCycleTurns()
        {
            // Arrange
            var spider = new Spider(0, 0, "Up", 5, 5);
            
            // Act - Complete right turn cycle
            spider.TurnRight(); // Up -> Right
            spider.TurnRight(); // Right -> Down
            spider.TurnRight(); // Down -> Left
            spider.TurnRight(); // Left -> Up
            
            // Assert - Back to original orientation
            Assert.AreEqual("Up", spider.Orientation);
        }
    }
}
