using System;

namespace Giftbox_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            
            double sizeSide = double.Parse(Console.ReadLine());
            double numberSheets = int.Parse(Console.ReadLine());
            double areaSingleSheet = double.Parse(Console.ReadLine());

            double boxArea = sizeSide * sizeSide * 6;

            double areaAllSheet = 0;

            for (int i = 1; i <= numberSheets; i++)
            {
                if (i % 3 == 0)
                {
                    areaAllSheet += areaSingleSheet * 0.25;
                }
                else
                {
                    areaAllSheet += areaSingleSheet;
                }

            }
            double percentage = areaAllSheet * 1.0 / boxArea * 100;
            Console.WriteLine($"You can cover {percentage:f2}% of the box.");
        }
    }
}
