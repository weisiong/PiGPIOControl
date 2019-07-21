using System;
using System.Device.Gpio;
using System.Threading;

namespace PiGpioControl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World 987641!");
            GpioController controller = new GpioController(PinNumberingScheme.Logical);
            var pin = 10;
            var lightTime = 400;

            controller.OpenPin(pin, PinMode.Output);
            try
            {
                var count = 0;
                while (true)
                {
                    Console.WriteLine($"{++count}");
                    controller.Write(pin, PinValue.High);
                    Thread.Sleep(lightTime);
                    controller.Write(pin, PinValue.Low);
                    Thread.Sleep(lightTime);
                }
            }
            finally
            {
                controller.ClosePin(pin);
            }
        }
    }
}
