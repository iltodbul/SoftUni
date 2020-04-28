using System.Collections.Generic;

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures
{
    public class TechCheck : Procedure
    {
        public TechCheck()
        {
            this.robotsProcedures = new List<IRobot>();
        }

        public override void DoService(IRobot robot, int procedureTime)
        {
            base.DoService(robot, procedureTime);
            //removes 8 energy and checks current robot (set IsChecked to true). If robot is already checked, just remove 8 energy again.
            if(!robot.IsChecked)
            {
                robot.IsChecked = true;
                robot.Energy -= 8;
            }

            robot.Energy -= 8;//TODO twice???
            this.robotsProcedures.Add(robot);
        }
    }
}
