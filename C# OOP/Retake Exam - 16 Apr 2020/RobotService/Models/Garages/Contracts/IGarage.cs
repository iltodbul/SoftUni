using System.Collections.Generic;

using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Garages.Contracts
{
    public interface IGarage
    {
        IReadOnlyDictionary<string, IRobot> Robots { get; }

        void Manufacture(IRobot robot);

        void Sell(string robotName, string ownerName);
    }
}
