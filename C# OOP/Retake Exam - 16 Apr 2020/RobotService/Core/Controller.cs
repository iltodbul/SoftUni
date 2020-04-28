using System;
using System.Collections.Generic;

using RobotService.Models.Robots;
using RobotService.Models.Garages;
using RobotService.Core.Contracts;
using RobotService.Models.Procedures;
using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures.Contracts;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;
        private IProcedure charge;
        private IProcedure chip;
        private IProcedure polish;
        private IProcedure rest;
        private IProcedure techCheck;
        private IProcedure work;

        public Controller()
        {
            this.garage = new Garage();
            this.charge = new Charge();
            this.chip = new Chip();
            this.polish = new Polish();
            this.rest = new Rest();
            this.techCheck = new TechCheck();
            this.work = new Work();
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot = null;

            if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, happiness, energy, procedureTime);
            }
            else if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, happiness, energy, procedureTime);
            }
            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, happiness, energy, procedureTime);
            }
            else
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            string message = string.Format(OutputMessages.RobotManufactured, robot.Name);

            return message;
        }

        public string Chip(string robotName, int procedureTime)
        {
            CheckName(robotName);

            IRobot robot = garage.Robots.GetValueOrDefault(robotName);

            this.chip.DoService(robot, procedureTime);

            string message = string.Format(OutputMessages.ChipProcedure, robotName);

            return message;
        }


        public string TechCheck(string robotName, int procedureTime)
        {
            CheckName(robotName);

            IRobot robot = garage.Robots.GetValueOrDefault(robotName);

            this.techCheck.DoService(robot, procedureTime);

            string message = string.Format(OutputMessages.TechCheckProcedure, robotName);

            return message;
        }

        public string Rest(string robotName, int procedureTime)
        {
            CheckName(robotName);

            IRobot robot = garage.Robots.GetValueOrDefault(robotName);

            this.rest.DoService(robot, procedureTime);

            string message = string.Format(OutputMessages.RestProcedure, robotName);

            return message;
        }

        public string Work(string robotName, int procedureTime)
        {
            CheckName(robotName);

            IRobot robot = garage.Robots.GetValueOrDefault(robotName);

            this.work.DoService(robot, procedureTime);

            string message = string.Format(OutputMessages.WorkProcedure, robotName, procedureTime);

            return message;
        }

        public string Charge(string robotName, int procedureTime)
        {
            CheckName(robotName);

            IRobot robot = garage.Robots.GetValueOrDefault(robotName);

            this.charge.DoService(robot, procedureTime);

            string message = string.Format(OutputMessages.ChargeProcedure, robotName);

            return message;
        }

        public string Polish(string robotName, int procedureTime)
        {
            CheckName(robotName);

            IRobot robot = garage.Robots.GetValueOrDefault(robotName);

            this.polish.DoService(robot, procedureTime);

            string message = string.Format(OutputMessages.PolishProcedure, robotName);

            return message;
        }

        public string Sell(string robotName, string ownerName)
        {
            CheckName(robotName);

            IRobot robot = garage.Robots.GetValueOrDefault(robotName);

            this.garage.Sell(robotName, ownerName);

            if (robot.IsChipped)
            {
                return string.Format(OutputMessages.SellChippedRobot, ownerName);
            }

            return string.Format(OutputMessages.SellNotChippedRobot, ownerName);
        }

        public string History(string procedureType)
        {
            string message = string.Empty;

            if (procedureType == nameof(Charge))
            {
                message = this.charge.History();
            }
            else if (procedureType == nameof(Chip))
            {
                message = this.chip.History();
            }
            else if (procedureType == nameof(Polish))
            {
                message = this.polish.History();
            }
            else if (procedureType == nameof(Rest))
            {
                message = this.rest.History();
            }
            else if (procedureType == nameof(TechCheck))
            {
                message = this.techCheck.History();
            }
            else if (procedureType == nameof(Work))
            {
                message = this.work.History();
            }

            return message;
        }

        private void CheckName(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
    }
}
