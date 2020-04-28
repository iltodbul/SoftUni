using System;
using System.Collections.Generic;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Chip : Procedure
    {
        public Chip()
        {
            this.robotsProcedures = new List<IRobot>();
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime); // TODO if first??
            if (robot.IsChipped)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AlreadyChipped,robot.Name));
            }

            //removes 5 happiness and chips current robot

            robot.Happiness -= 5;
            robot.IsChipped = true;
            this.robotsProcedures.Add(robot);
        }
    }
}
