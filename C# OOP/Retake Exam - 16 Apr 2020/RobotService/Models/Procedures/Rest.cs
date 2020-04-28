using System.Collections.Generic;

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Rest : Procedure
    {
        public Rest()
        {
            this.robotsProcedures = new List<IRobot>();
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            //removes 3 happiness and adds 10 energy

            robot.Happiness -= 3;
            robot.Energy += 10;
            this.robotsProcedures.Add(robot);
        }
    }
}
