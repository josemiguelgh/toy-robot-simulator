using System;
using MottMac.TRS.RoboCore;

namespace MottMac.TRS.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot(new RobotCore());

            Console.WriteLine("You can start entering the robocommands:");
            string command = null;
            string output = null;

            while ((command = Console.ReadLine()) != null)
            {
                output = robot.SendCommand(command);
                if(!string.IsNullOrWhiteSpace(output))
                    Console.WriteLine(output);
            }
        }
    }
}
