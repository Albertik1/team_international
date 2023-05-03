using NUnit.Framework;
using Minesweeper.Core;

namespace Minesweeper.Tests
{
    [TestFixture]
    public class GameProcessorTests
    {
        [Test]
        public void OpenMethod_SetsStateToActive_IfNotFinished()
        {
            // Arrange
            bool[,] field = new bool[5, 5];
            GameProcessor game = new GameProcessor(field);

            // Act
            game.Open(0, 0);

            // Assert
            Assert.AreEqual(GameState.Active, game.GameState);
        }

        [Test]
        public void GetCurrentFieldMethod_ReturnsFieldWithSameDimensions()
        {
            // Arrange
            bool[,] field = new bool[10, 10];
            GameProcessor game = new GameProcessor(field);

            // Act
            PointState[,] currentField = game.GetCurrentField();

            // Assert
            Assert.AreEqual(field.GetLength(0), currentField.GetLength(0));
            Assert.AreEqual(field.GetLength(1), currentField.GetLength(1));
        }

        [Test]
        public void GetCurrentFieldMethod_ReturnsFieldWithAllCellsClosed_Initially()
        {
            // Arrange
            bool[,] field = new bool[5, 5];
            GameProcessor game = new GameProcessor(field);

            // Act
            PointState[,] currentField = game.GetCurrentField();

            // Assert
            foreach (PointState state in currentField)
            {
                Assert.AreEqual(PointState.Closed, state);
            }
        }

        [Test]
        public void OpenMethod_ReturnsGameStateWithSameDimensions_AsCurrentField()
        {
            // Arrange
            bool[,] field = new bool[8, 8];
            GameProcessor game = new GameProcessor(field);

            // Act
            GameState newState = game.Open(3, 5);

            // Assert
            Assert.AreEqual(field.GetLength(0), newState.Field.GetLength(0));
            Assert.AreEqual(field.GetLength(1), newState.Field.GetLength(1));
        }

        [Test]
        public void OpenMethod_ReturnsGameStateWithCorrectPointStates_AfterOpeningCell()
        {
            // Arrange
            bool[,] field = new bool[3, 3] { { true, false, false }, { false, true, false }, { false, false, false } };
            GameProcessor game = new GameProcessor(field);

            // Act
            GameState newState = game.Open(1, 0);

            // Assert
            PointState[,] expectedField = new PointState[3, 3] { { PointState.Opened, PointState.Closed, PointState.Closed },
                                                                 { PointState.Closed, PointState.Closed, PointState.Closed },
                                                                 { PointState.Closed, PointState.Closed, PointState.Closed } };
            Assert.AreEqual(expectedField, newState.Field);
        }
    }
}
