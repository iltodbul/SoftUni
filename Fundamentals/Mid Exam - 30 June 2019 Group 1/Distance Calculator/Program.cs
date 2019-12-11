using System;

namespace Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double stepsLenght = double.Parse(Console.ReadLine())*1.0 / 100.0;
            double distanceToTravel = double.Parse(Console.ReadLine())*1.0;

            double shorterSteps = (stepsMade / 5) * (stepsLenght * 0.7);
            double longerSteps = (stepsMade*1.0 - (stepsMade/5)) * stepsLenght;
            double distance = shorterSteps + longerSteps;

            double percenteg= (distance/distanceToTravel)*100;

            Console.WriteLine($"You travelled {percenteg:f2}% of the distance!");
        }
    }
}
