using System;

namespace Buying_a_car
{
    public class BuyCar
    {
        public static int[] nbMonths(double startPriceOld, double startPriceNew, double savingPerMonth, double percentLossByMonth)
        {
            double diff = -1;
            if (startPriceOld >= startPriceNew)
            {
                int month = 0;
                diff = startPriceOld - startPriceNew;
                return new int[] { month, (int)diff};
            }
            else
            {
                int month = 0;
                double saving = savingPerMonth;
                for (month = 0; diff < 0; month++)
                {

                    if (month % 2 != 0)
                    {
                        percentLossByMonth = percentLossByMonth + 0.5;
                        startPriceOld = startPriceOld - (startPriceOld / 100 * percentLossByMonth);
                        startPriceNew = startPriceNew - (startPriceNew / 100 * percentLossByMonth);
                        diff = startPriceOld - startPriceNew + saving;
                        saving += savingPerMonth;
                    }
                    else
                    {
                        startPriceOld = startPriceOld - (startPriceOld / 100 * percentLossByMonth);
                        startPriceNew = startPriceNew - (startPriceNew / 100 * percentLossByMonth);
                        diff = startPriceOld - startPriceNew + saving;
                        saving += savingPerMonth;
                    }
                }
                return new int[] {month, (int)Math.Round(diff)};
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            int[] r = new int[] { 6, 766 };
            BuyCarTests.Test(r, BuyCar.nbMonths(2000, 8000, 1000, 1.5));
            r = new int[] { 0, 4000 };
            BuyCarTests.Test(r, BuyCar.nbMonths(12000, 8000, 1000, 1.5));
            r = new int[] { 8, 597 };
            BuyCarTests.Test(r, BuyCar.nbMonths(8000, 12000, 500, 1));
            r = new int[] { 8, 332 };
            BuyCarTests.Test(r, BuyCar.nbMonths(18000, 32000, 1500, 1.25));
        }
    }

    public class BuyCarTests
    {
        public static void Test(int[] a, int[] b)
        {
            if (a[0] == b[0] && a[1] == b[1]) Console.WriteLine("Correct!");
            else Console.WriteLine("Incorrect");
        }
    }
}
