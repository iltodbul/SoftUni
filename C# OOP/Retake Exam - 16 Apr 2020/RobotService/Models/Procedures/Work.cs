using System.Collections.Generic;

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Work : Procedure
    {
        public Work()
        {
            this.robotsProcedures = new List<IRobot>();
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            //removes 6 energy and adds 12 happiness

            robot.Energy -= 6;
            robot.Happiness += 12;
            this.robotsProcedures.Add(robot);

        }
    }
}
