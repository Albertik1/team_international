using NUnit.Framework;

[TestFixture]
public class GameProcessorTests
{
    private GameProcessor _gameProcessor;

    [SetUp]
    public void Setup()
    {
        // Initialize the GameProcessor with a minefield that has no mines
        bool[,] mineField = new bool[3, 3];
        _gameProcessor = new GameProcessor(mineField);
    }

    [Test]
    public void Open_InvalidPosition_ThrowsException()
    {
        // Attempt to open a cell that is outside of the minefield bounds
        Assert.Throws<IndexOutOfRangeException>(() => _gameProcessor.Open(4, 2));
    }

    [Test]
    public void GetCurrentField_GameNotStarted_ReturnsNull()
    {
        // The GetCurrentField method should return null if the game has not yet started
        Assert.IsNull(_gameProcessor.GetCurrentField());
    }

    [Test]
    public void Open_GameOver_ThrowsException()
    {
        // Initialize the GameProcessor with a minefield that has a mine in the top-left corner
        bool[,] mineField = new bool[3, 3] { { true, false, false }, { false, false, false }, { false, false, false } };
        _gameProcessor = new GameProcessor(mineField);

        // Open the top-left cell, which should trigger a game over
        _gameProcessor.Open(0, 0);

        // Attempt to open another cell after the game is over, which should throw an exception
        Assert.Throws<GameOverException>(() => _gameProcessor.Open(0, 1));
    }
[Test]
public void GetCurrentField_GameOver_NotAllCellsRevealed()
{
    // Initialize the GameProcessor with a minefield that has a mine in the top-left corner
    bool[,] mineField = new bool[3, 3] { { true, false, false }, { false, false, false }, { false, false, false } };
    _gameProcessor = new GameProcessor(mineField);

    // Open the top-left cell, which should trigger a game over
    _gameProcessor.Open(0, 0);

    // Get the current field after the game is over
    PointState[,] currentField = _gameProcessor.GetCurrentField();

    // Assert that not all cells are revealed
    bool allCellsRevealed = true;
    for (int row = 0; row < currentField.GetLength(0); row++)
    {
        for (int col = 0; col < currentField.GetLength(1); col++)
        {
            if (currentField[row, col] == PointState.Closed)
            {
                allCellsRevealed = false;
                break;
            }
        }
    }

    Assert.IsFalse(allCellsRevealed);
}


//     [Test]
//     public void GetCurrentField_GameOver_ReturnsAllCells()
//     {
//         // Initialize the GameProcessor with a minefield that has a mine in the top-left corner
//         bool[,] mineField = new bool[3, 3] { { true, false, false }, { false, false, false }, { false, false, false } };
//         _gameProcessor = new GameProcessor(mineField);

//         // Open the top-left cell, which should trigger a game over
//         _gameProcessor.Open(0, 0);

//         // GetCurrentField should return a two-dimensional array with all cells revealed
//         PointState[,] expectedField = new PointState[3, 3]
//         {
//             { PointState.Mine, PointState.One, PointState.Zero },
//             { PointState.One, PointState.One, PointState.Zero },
//             { PointState.Zero, PointState.Zero, PointState.Zero }
//         };
//         Assert.AreEqual(expectedField, _gameProcessor.GetCurrentField());
//     }
// }
