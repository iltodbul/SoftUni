using System.Collections.Generic;

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class Charge : Procedure
    {
        public Charge()
        {
            this.robotsProcedures = new List<IRobot>();
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            //adds 12 happiness and 10 energy

            robot.Happiness += 12;
            robot.Energy += 10;
            this.robotsProcedures.Add(robot);
        }
    }
}
