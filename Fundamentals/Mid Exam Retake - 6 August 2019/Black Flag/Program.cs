using System;

namespace Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dayliPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double totalPlunder = 0;

            for (int i = 1; i <= days; i++)
            {
                totalPlunder += dayliPlunder;

                if (i % 3 == 0)
                {
                    totalPlunder += dayliPlunder / 2.0;

                }
                if (i%5==0)
                {
                    totalPlunder -= totalPlunder * 0.3;
                }

            }
            if (totalPlunder>=expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {totalPlunder:f2} plunder gained.");
            }
            else
            {
                double difference = totalPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {difference:f2}% of the plunder.");
            }
        }
    }
}
