using System;
using System.Text.RegularExpressions;
using MottMac.TRS.RoboCore.Enums;
using MottMac.TRS.RoboCore.Interfaces;

namespace MottMac.TRS.RoboCore
{
    public class Robot : IRobot
    {
        private IRobotCore _robotCore;

        public Robot(IRobotCore robotCore)
        {
            _robotCore = robotCore;
        }

        public string SendCommand(string command)
        {
            if (string.IsNullOrWhiteSpace(command))
                return null;

            if (Regex.IsMatch(command, @"PLACE \d,\d,(NORTH|EAST|SOUTH|WEST)"))
            {
                _robotCore.Place(Convert.ToInt32(command.Substring(6, 1)), Convert.ToInt32(command.Substring(8, 1)),
                    Enum.Parse<Direction>(command.Substring(10), true));
                return null;
            }

            if (command == "MOVE")
            {
                _robotCore.Move();
                return null;
            }

            if (command == "LEFT")
            {
                _robotCore.ChangeDirection(DirectionChange.Left);
                return null;
            }

            if (command == "RIGHT")
            {
                _robotCore.ChangeDirection(DirectionChange.Right);
                return null;
            }

            if (command == "REPORT")
                return _robotCore.Report();

            return null;
        }
    }
}