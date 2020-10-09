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
        public void Move_WithProperPlacementHorizAndMultipleSteps_FinalIgnores()
        {
            var robot = new Robot();
            robot.Place(4, 4, Direction.West);
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(true, robot.Move());
            Assert.AreEqual(false, robot.Move());
        }

        [Test]
        public void FullMovement_WithProperPlacementStepsChangeDir_Ok()
        {
            var robot = new Robot();
            robot.Place(0, 0, Direction.North);
            robot.Move();
            robot.ChangeDirection(DirectionChange.Right);
            Assert.AreEqual(true, robot.Move());
        }

        [Test]
        public void FullMovement_WithProperPlacementStepsChangeDir_Ignores()
        {
            var robot = new Robot();
            robot.Place(4, 4, Direction.South);
            robot.Move();
            robot.ChangeDirection(DirectionChange.Left);
            Assert.AreEqual(false, robot.Move());
        }
    }

    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public enum DirectionChange
    {
        Right,
        Left
    }
}
