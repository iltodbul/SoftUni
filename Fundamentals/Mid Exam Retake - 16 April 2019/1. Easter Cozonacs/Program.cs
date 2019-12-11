using System;

namespace _1._Easter_Cozonacs
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            double flourPrice = double.Parse(Console.ReadLine());
            double eggPrice = flourPrice * 0.75;
            double milkPrice250ml = (flourPrice * 1.25) * 0.25;
            double cost1Cozunak = flourPrice + eggPrice + milkPrice250ml;
            int producedCozunaks = 0;
            int counterColoredEggs = 0;
            while (budget > 0)
            {
                budget -= cost1Cozunak;
                if (budget < 0)
                {
                    budget += cost1Cozunak;
                    break;
                }
                producedCozunaks++;
                counterColoredEggs += 3;
                if (producedCozunaks % 3 == 0)
                {
                    int eggsToSubstract = producedCozunaks - 2;
                    counterColoredEggs -= eggsToSubstract;
                }
            }
            Console.WriteLine($"You made {producedCozunaks} cozonacs! Now you have {counterColoredEggs} eggs and {budget:f2}BGN left.");
        }
    }
}
