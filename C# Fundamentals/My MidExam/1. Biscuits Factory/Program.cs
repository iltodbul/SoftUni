using System;

namespace _1._Biscuits_Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            int biskuitsPerDayPerWorker = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());
            int biskuitsOtherFactory = int.Parse(Console.ReadLine());

            int biskuitPerDay = biskuitsPerDayPerWorker * workers;
            double totalBiskuit = 0;

            for (int i = 1; i <= 30; i++)
            {
                if (i % 3 == 0)
                {
                   double therdDayBiskuit= Math.Floor(biskuitPerDay * 0.75);
                    totalBiskuit += therdDayBiskuit;
                }
                else
                {
                    totalBiskuit += biskuitPerDay;
                }

            }
            Console.WriteLine($"You have produced {totalBiskuit} biscuits for the past month.");

            if (totalBiskuit>biskuitsOtherFactory)
            {
                double difference = totalBiskuit - biskuitsOtherFactory;
                double percentage = (difference / biskuitsOtherFactory*1.0) * 100;
                Console.WriteLine($"You produce {percentage:f2} percent more biscuits.");
            }
            else
            {
                double differ = biskuitsOtherFactory - totalBiskuit;
                double percentage = (differ / biskuitsOtherFactory * 1.0) * 100;
                Console.WriteLine($"You produce {percentage:f2} percent less biscuits.");
            }
        }
    }
}
