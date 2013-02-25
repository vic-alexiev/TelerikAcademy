using MobilePhone;
using MobilePhone.Enums;
using System;

static class GsmCallHistoryTest
{
    public static void RunTests()
    {
        try
        {
            // create an instance of the Gsm class
            Gsm mobilePhone = new Gsm(
                MobilePhoneManufacturer.BlackBerry,
                new Battery(BatteryType.LiIon, null, 432, 0, 7, 0),
                new Display(320, 240, 2.44, ColorDepth.Colors65K),
                "BlackBerry Curve 9320",
                170,
                "Julia Roberts");

            // add a few calls
            mobilePhone.AddCallToHistory(2012, 8, 28, 13, 5, "00359 888 967584", 129);
            mobilePhone.AddCallToHistory(2012, 10, 15, 9, 34, "00359 878 900581", 907);
            mobilePhone.AddCallToHistory(2012, 12, 9, 2, 15, "00359 882 123456", 457);
            mobilePhone.AddCallToHistory(2013, 1, 7, 1, 57, "00359 883 969956", 307);
            mobilePhone.AddCallToHistory(2013, 2, 5, 10, 27, "00359 879 967584", 456);
            mobilePhone.AddCallToHistory(2013, 2, 12, 15, 45, "00359 885 962387", 812);

            // display call history
            Console.WriteLine("Call history:\n{0}", mobilePhone.GetCallHistory());

            // calculate total call price (given the price per minute)
            decimal totalCallPrice = mobilePhone.CalculateTotalCallPrice(0.37M);
            Console.WriteLine("Total call price: {0:N2}", totalCallPrice);

            // delete the longest call from history
            int callsRemoved = mobilePhone.DeleteLongestCallFromHistory();
            Console.WriteLine("{0} call(s) removed.", callsRemoved);

            // calculate total call price after deleting the longest call
            totalCallPrice = mobilePhone.CalculateTotalCallPrice(0.37M);
            Console.WriteLine("Total call price: {0:N2}", totalCallPrice);

            // clear call history
            mobilePhone.ClearCallHistory();

            // print the call history
            Console.WriteLine("Call history:\n{0}", mobilePhone.GetCallHistory());
        }
        catch (MobilePhoneException mpex)
        {
            Console.WriteLine(mpex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
