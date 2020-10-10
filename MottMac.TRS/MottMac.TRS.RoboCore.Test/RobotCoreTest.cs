using MottMac.TRS.RoboCore.Enums;
using NUnit.Framework;

namespace MottMac.TRS.RoboCore.Test
{
    [TestFixture]
    public class RobotCoreTest
    {
        [Test]
        public void Place_DiffScenarios_EvalAccept()
        {
            var robot = new RobotCore();
            Assert.AreEqual(false, robot.Place(-20, 0, Direction.North));
            Assert.AreEqual(false, robot.Place(0, -20, Direction.North));
            Assert.AreEqual(true, robot.Place(0, 0, Direction.North));
            Assert.AreEqual(true, robot.Place(4, 4, Direction.North));
            Assert.AreEqual(false, robot.Place(5, 5, Direction.North));
        }

        [Test]
        public void Move_WithoutPlacement_Ignore()
        {
            var robot = new RobotCore();
            Assert.AreEqual(false, robot.Move());
        }

        [Test]
        public void Move_WithIncorrectPlacement_Ignore()
        {
            var robot = new RobotCore();
            robot.Place(-1, 0, Direction.North);
            Assert.AreEqual(false, robot.Move());
        }

        [Test]
        public void Move_WithProperPlacementAndDirection_Accepts()
        {
            var robot = new RobotCore();
            robot.Place(0, 0, Direction.North);
            Assert.AreEqual(true, robot.Move());
        }

        [Test]
        public void Move_WithProperPlacementAndBadDirection_Ignores()
        {
            var robot = new RobotCore();
            robot.Place(0, 0, Direction.South);
            Assert.AreEqual(false, robot.Move());
        }

        [Test]
        public void Move_WithProperPlacementAndMultipleSteps_FinalIgnores()
        {
            var robot = new RobotCore();
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
            var robot = new RobotCore();
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
            var robot = new RobotCore();
            robot.Place(0, 0, Direction.North);
            robot.Move();
            robot.ChangeDirection(DirectionChange.Right);
            Assert.AreEqual(true, robot.Move());
        }

        [Test]
        public void FullMovement_WithProperPlacementStepsChangeDir_Ignores()
        {
            var robot = new RobotCore();
            robot.Place(4, 4, Direction.South);
            robot.Move();
            robot.ChangeDirection(DirectionChange.Left);
            Assert.AreEqual(false, robot.Move());
        }

        [Test]
        public void FullMovement_TopCornerStepsChangeDir_GetExpectedOutput()
        {
            var robot = new RobotCore();
            robot.Place(4, 4, Direction.South);
            robot.Move();
            robot.ChangeDirection(DirectionChange.Right);
            robot.Move();
            robot.ChangeDirection(DirectionChange.Left);
            robot.Move();
            Assert.AreEqual("Output: 3,2,SOUTH", robot.Report()); 
        }

        [Test]
        public void FullMovement_WithMidPlacementStepsChangeDir_GetExpectedOutput()
        {
            var robot = new RobotCore();
            robot.Place(2, 2, Direction.West);
            robot.Move();
            robot.Move();
            robot.ChangeDirection(DirectionChange.Right);
            robot.Move();
            robot.ChangeDirection(DirectionChange.Left);
            robot.ChangeDirection(DirectionChange.Left);
            robot.Move();
            robot.Move();
            robot.ChangeDirection(DirectionChange.Right);
            robot.Move();
            Assert.AreEqual("Output: 0,1,WEST", robot.Report());
        }

        [Test]
        public void Report_WithoutPlacement_Ignore()
        {
            var robot = new RobotCore();
            Assert.AreEqual(null, robot.Report());
        }

        //[Test]
        //public void Report_WithoutPlacement2_Ignore()
        //{
        //    var robot = new Robot(new RobotCore());
        //    Assert.AreEqual("", robot.Listen("PLACE 0,0,NORTH"));
        //}
    }

}
