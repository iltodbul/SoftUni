using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Procedures.Contracts
{
    public interface IProcedure
    {
        string History();

        void DoService(IRobot robot, int procedureTime);
    }
}
