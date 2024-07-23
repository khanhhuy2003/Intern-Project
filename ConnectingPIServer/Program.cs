
using System;
using System.Timers;
using PISDK;

namespace ConnectingPIServer
{
    internal class Program
    {
        private static Timer timer;
        private static PISDK.Server piServer;
        private static string[] ActualSpeeds = {
            "VNBD_BD03_MMC2_OSI_ProductionData.ActualSpeed",
            "VNBD_BD03_OSI_Production Data.OEE1",
            "VNBD_BD03_OSI_Production Data.Waste",
            "VNBD_BD03_MMC2_OSI_ProductionData.StackerSpeed"
        };
        static void Main(string[] args)
        {
            try
            {
                
                PISDK.PISDK sdk = new PISDK.PISDK();                
                string serverName = "vnbda020";
                piServer = sdk.Servers[serverName];

                // Open a connection to the PI Server
                piServer.Open();
                Console.WriteLine("Successfully connected to the PI Server: " + piServer.Name);

                foreach (PISDK.PIPoint piPoint in piServer.GetPoints("tag='*'"))
                {
                    Console.WriteLine("PI Point: " + piPoint.Name);
                }


                // Set up the timer to fetch data every 10 seconds
                /*timer = new Timer(5000); // 10 seconds
                timer.Elapsed += FetchData;
                timer.AutoReset = true;
                timer.Enabled = true;*/

                // Keep the application running
                //Console.WriteLine("Press [Enter] to exit the program.");
                //Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            
        }

       /* private static void FetchData(Object source, ElapsedEventArgs e)
        {
            foreach (string ActualSpeed in ActualSpeeds)
            {
                try
                {
                    PISDK.PIPoint piPoint = piServer.PIPoints[ActualSpeed];
                    Console.WriteLine("Found PI Point: " + piPoint.Name);

                    PISDK.PIValue currentValue = piPoint.Data.Snapshot;
                    Console.WriteLine("Current Value: " + currentValue.Value);
                    Console.WriteLine("Timestamp: " + currentValue.TimeStamp.LocalDate);
                    Console.WriteLine("----------------------");
               }

                catch (Exception ex)
                {
                    Console.WriteLine("PI Point not found: " + ActualSpeed);
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }*/
    }
}
