using System;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private int happiness;
        private int energy;

        public Robot(string name, int happiness, int energy, int procedureTime)
        {
            this.Name = name;
            this.Happiness = happiness;
            this.Energy = energy;
            this.ProcedureTime = procedureTime;

            IsBought = false;
            IsChipped = false;
            IsChecked = false;
        }

        public string Name { get; }
        
        public int Happiness
        {
            get => this.happiness;
            set
            {
                if (value< 0 ||value> 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                this.happiness = value;
            }
        }

        public int Energy
        {
            get => this.energy;
            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }

        public int ProcedureTime { get; set; }

        public string Owner { get; set; }

        public bool IsBought { get; set; }

        public bool IsChipped { get; set; }

        public bool IsChecked { get; set; }

        public override string ToString()
        {
            string message = $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";

            return message;
        }
    }
}
