using System;
using rPiAccel.Services;

namespace rPiAccel
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Service Starting...");
            var service = new AccelerometerService(1000, 1, 0x68);
            service.MeasurementTaken += (sender, e) =>
            {
                foreach(var measurement in e.Values)
                {
                    Console.WriteLine($"Acceleration: x: {measurement.AccelerationX}, y:{measurement.AccelerationY}, z:{measurement.AccelerationZ}");
                    Console.WriteLine($"Gyro: x: {measurement.GyroX}, y:{measurement.GyroY}, z:{measurement.GyroZ}");
                }
            };
            service.Start();
            Console.WriteLine("Press any key to stop");
            Console.ReadLine();
            service.Stop();
            Console.WriteLine("Service Stopped");
        }
    }
}
