using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.WcfServices.Contracts;
using Contracts;
using System.ServiceModel;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallByWebRef();
            //CallByCode();
            using(ChannelFactory<ICalculator> ChannelFactory=new ChannelFactory<ICalculator>("calculatorservice"))
            {
                ICalculator proxy = ChannelFactory.CreateChannel();
                using (proxy as IDisposable)
                {
                    Console.WriteLine("x + y ={2} when x={0} and y={1}", 1, 2, proxy.Add(1, 2));
                    Console.WriteLine("x - y ={2} when x={0} and y={1}", 1, 2, proxy.Subtract(1, 2));
                    Console.WriteLine("x * y ={2} when x={0} and y={1}", 1, 2, proxy.Multiply(1, 2));
                    Console.WriteLine("x / y ={2} when x={0} and y={1}", 1, 2, proxy.Divide(1, 2));
                }
            }
        }

        private static void CallByCode()
        {
            using (ChannelFactory<ICalculator> ChannelFactory = new ChannelFactory<ICalculator>(new WSHttpBinding(), "http://127.0.0.1:9999/CalculatorService"))
            {
                ICalculator proxy = ChannelFactory.CreateChannel();
                using (proxy as IDisposable)
                {
                    Console.WriteLine("x + y ={2} when x={0} and y={1}", 1, 2, proxy.Add(1, 2));
                    Console.WriteLine("x - y ={2} when x={0} and y={1}", 1, 2, proxy.Subtract(1, 2));
                    Console.WriteLine("x * y ={2} when x={0} and y={1}", 1, 2, proxy.Multiply(1, 2));
                    Console.WriteLine("x / y ={2} when x={0} and y={1}", 1, 2, proxy.Divide(1, 2));
                }
            }
        }

        private static void CallByWebRef()
        {
            using (CalculatorServiceClient proxy = new CalculatorServiceClient())
            {
                Console.WriteLine("x + y ={2} when x={0} and y={1}", 1, 2, proxy.Add(1, 2));
                Console.WriteLine("x - y ={2} when x={0} and y={1}", 1, 2, proxy.Subtract(1, 2));
                Console.WriteLine("x * y ={2} when x={0} and y={1}", 1, 2, proxy.Multiply(1, 2));
                Console.WriteLine("x / y ={2} when x={0} and y={1}", 1, 2, proxy.Divide(1, 2));

            }
        }
    }
}
