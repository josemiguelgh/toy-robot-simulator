using NUnit.Framework;

namespace MottMac.TRS.RoboCore.Test
{
    [TestFixture]
    public class RobotTest
    {
        [Test]
        public void Place_DiffScenarios_EvalAccept()
        {
            var robot = new Robot();
            Assert.AreEqual(false, robot.Place(-20, 0, Direction.North));
            Assert.AreEqual(false, robot.Place(0, -20, Direction.North));
            Assert.AreEqual(true, robot.Place(0, 0, Direction.North));
            Assert.AreEqual(true, robot.Place(4, 4, Direction.North));
            Assert.AreEqual(false, robot.Place(5, 5, Direction.North));
        }

        [Test]
        public void Move_WithoutPlacement_Ignore()
        {
            var robot = new Robot();
            Assert.AreEqual(false, robot.Move());
        }

        [Test]
        public void Move_WithIncorrectPlacement_Ignore()
        {
            var robot = new Robot();
            robot.Place(-1, 0, Direction.North);
            Assert.AreEqual(false, robot.Move());
        }

        [Test]
        public void Move_WithProperPlacementAndDirection_Accepts()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.North);
            Assert.AreEqual(true, robot.Move());
        }

        [Test]
        public void Move_WithProperPlacementAndBadDirection_Ignores()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.South);
            Assert.AreEqual(false, robot.Move());
        }

        [Test]
        public void Move_WithProperPlacementAndMultipleSteps_FinalIgnores()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.North);
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(false, robot.Move());
        }

        [Test]
        public void Move_WithProperPlacementHorAndMultipleSteps_FinalIgnores()
        {
            var robot = new Robot();
            robot.Place(4, 4, Direction.West);
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(false, robot.Move());
        }
    }

    public class Robot
    {
        private int? _positionX;
        private int? _positionY;
        private Direction? _currentDirection;

        public bool IsPlacedInBoard => _positionX != null && _positionY != null && _currentDirection != null;

        public Robot()
        {
            _positionX = null;
            _positionY = null;
            _currentDirection = null;
        }
    
        public bool Place(int x, int y, Direction direction)
        {
            if (!IsValidBoardPosition(x,y))
                return false;

            _positionX = x;
            _positionY = y;
            _currentDirection = direction;
            return true;
        }

        public bool Move()
        {
            if (!IsPlacedInBoard)
                return false;

            if (_currentDirection == Direction.North && IsValidBoardPosition(_positionX, _positionY + 1))
            {
                _positionY = _positionY + 1;
                return true;
            }

            if (_currentDirection == Direction.South && IsValidBoardPosition(_positionX, _positionY - 1))
            {
                _positionY = _positionY - 1;
                return true;
            }

            if (_currentDirection == Direction.East && IsValidBoardPosition(_positionX + 1, _positionY))
            {
                _positionX = _positionX + 1;
                return true;
            }

            if (_currentDirection == Direction.West && IsValidBoardPosition(_positionX -1, _positionY))
            {
                _positionX = _positionX -1;
                return true;
            }

            return false;
        }

        private bool IsValidBoardPosition(int? x, int? y)
        {
            if (x == null || y == null)
                return false;

            if (x < 0 || x > 4 || y < 0 || y > 4)
                return false;

            return true;
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }
}
