using System;
using System.Collections.Generic;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private readonly Dictionary<string, IRobot> garageRobots;
        private int capacity;

        public Garage()
        {
            this.capacity = 10;
            this.garageRobots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.garageRobots;

        public void Manufacture(IRobot robot)
        {
            if (this.capacity == this.Robots.Count)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }

            if (this.Robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            this.garageRobots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            IRobot robot = this.garageRobots.GetValueOrDefault(robotName);

            robot.Owner = ownerName;
            robot.IsBought = true;
            this.garageRobots.Remove(robotName);
        }
    }
}
