﻿using System;

using RobotService.IO.Contracts;

namespace RobotService.IO
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}