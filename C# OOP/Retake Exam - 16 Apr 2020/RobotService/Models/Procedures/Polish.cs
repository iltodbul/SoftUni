using System.Collections.Generic;

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Polish : Procedure
    {
        public Polish()
        {
            this.robotsProcedures = new List<IRobot>();
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            // removes 7 happiness

            robot.Happiness -= 7;
            this.robotsProcedures.Add(robot);
        }
    }
}
