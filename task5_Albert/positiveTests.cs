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

        [Test]
        public void OpenMethod_ReturnsGameStateWithCorrectPointStates_AfterMultipleOpeningCells()
        {
            // Arrange
            bool[,] field = new bool[4, 4] { { false, true, false, false }, { true, false, true, false }, { false, true, false, true }, { false, false, true, false } };
            GameProcessor game = new GameProcessor(field);

            // Act
            GameState newState = game.Open(0, 0);
            newState = game.Open(1, 0);
            newState = game.Open(2, 1);
            newState = game.Open(3, 2);

            // Assert
            PointState[,] expectedField = new PointState[4, 4] { { PointState.Opened,
        [Test]
        public void OpenMethod_ReturnsGameStateWithCorrectPointStates_AfterMultipleOpeningCells()
        {
            // Arrange
            bool[,] field = new bool[4, 4] { { false, true, false, false }, { true, false, true, false }, { false, true, false, true }, { false, false, true, false } };
            GameProcessor game = new GameProcessor(field);

            // Act
            GameState newState = game.Open(0, 0);
            newState = game.Open(1, 0);
            newState = game.Open(2, 1);
            newState = game.Open(3, 2);

            // Assert
            PointState[,] expectedField = new PointState[4, 4] { { PointState.Opened, PointState.Opened, PointState.Closed, PointState.Closed },
                                                                 { PointState.Opened, PointState.Opened, PointState.Closed, PointState.Closed },
                                                                 { PointState.Closed, PointState.Opened, PointState.Closed, PointState.Closed },
                                                                 { PointState.Closed, PointState.Closed, PointState.Opened, PointState.Closed } };
            Assert.AreEqual(expectedField, newState.Field);
        }

        [Test]
        public void OpenMethod_DoesNotChangeState_IfOpeningAnAlreadyOpenedCell()
        {
            // Arrange
            bool[,] field = new bool[3, 3] { { false, false, false }, { false, true, false }, { false, false, false } };
            GameProcessor game = new GameProcessor(field);

            // Act
            GameState initialState = game.Open(1, 1);
            GameState newState = game.Open(1, 1);

            // Assert
            Assert.AreEqual(initialState, newState);
        }

        [Test]
        public void OpenMethod_SetsStateToLost_IfOpeningAMineCell()
        {
            // Arrange
            bool[,] field = new bool[3, 3] { { false, false, false }, { false, true, false }, { false, false, false } };
            GameProcessor game = new GameProcessor(field);

            // Act
            GameState newState = game.Open(1, 1);

            // Assert
            Assert.AreEqual(GameState.Lost, newState.GameState);
        }

        [Test]
        public void OpenMethod_SetsStateToWon_IfAllNonMineCellsAreOpened()
        {
            // Arrange
            bool[,] field = new bool[3, 3] { { false, false, false }, { false, false, false }, { false, false, false } };
            GameProcessor game = new GameProcessor(field);

            // Act
            GameState newState = game.Open(0, 0);
            newState = game.Open(0, 1);
            newState = game.Open(0, 2);
            newState = game.Open(1, 0);
            newState = game.Open(1, 1);
            newState = game.Open(1, 2);
            newState = game.Open(2, 0);
            newState = game.Open(2, 1);
            newState = game.Open(2, 2);

            // Assert
            Assert.AreEqual(GameState.Won, newState.GameState);
        }
    }
}
