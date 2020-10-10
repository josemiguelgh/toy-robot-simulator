using MottMac.TRS.RoboCore.Enums;

namespace MottMac.TRS.RoboCore.Interfaces
{
    public interface IRobotCore
    {
        bool Place(int x, int y, Direction direction);
        bool Move();
        void ChangeDirection(DirectionChange directionChange);
        string Report();
    }
}