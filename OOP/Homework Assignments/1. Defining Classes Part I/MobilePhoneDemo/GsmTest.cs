using MobilePhone;
using MobilePhone.Enums;
using System;

static class GsmTest
{
    /// <summary>
    /// For a complete list of the mobile phone brands, go to http://www.gsmarena.com/makers.php3
    /// </summary>
    public static void RunTests()
    {
        try
        {
            // create an array of instances of the Gsm class
            Gsm[] mobilePhones = new Gsm[]
                {
                    new Gsm(
                        MobilePhoneManufacturer.Nokia,
                        new Battery(BatteryType.LiIon, "BL-4U", 600, 0, 17, 0),
                        new Display(240, 400, 3.0, ColorDepth.Colors65K),
                        "Nokia Asha 310",
                        90,
                        "Dustin Hoffman"),

                    new Gsm(MobilePhoneManufacturer.Motorola, new Battery(), new Display(), "Motorola ATRIX HD MB886"),

                    new Gsm(
                        MobilePhoneManufacturer.Microsoft, 
                        new Battery(BatteryType.LiIon, "", null, null, 8, 0), 
                        new Display(null, null, 10.6, ColorDepth.Colors16M), 
                        "Microsoft Surface", 
                        390, 
                        "Robert De Niro")
                };

            // display information about each GSM in the array
            foreach (Gsm phone in mobilePhones)
            {
                Console.WriteLine("{0}\n", phone);
            }

            // display information about the static property IPhone4S
            Console.WriteLine(Gsm.IPhone4S);
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
