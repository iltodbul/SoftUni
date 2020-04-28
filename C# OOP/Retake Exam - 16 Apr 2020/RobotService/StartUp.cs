using RobotService.Core;
using RobotService.Core.Contracts;

namespace RobotService
{
    public class StartUp
    {
        public static void Main()
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}
