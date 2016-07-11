using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Client.WcfServices.Contracts;
using Contracts;
using System.ServiceModel;
using System.ServiceModel.Channels;
namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //CallByWebRef();
            //CallByCode();

           // InvocateCalclatorServiceViaCode();
            InvocateCalclatorServiceViaConfiguration();
            //using(ChannelFactory<ICalculator> ChannelFactory=new ChannelFactory<ICalculator>("calculatorservice"))
            //{
            //    ICalculator proxy = ChannelFactory.CreateChannel();
            //    using (proxy as IDisposable)
            //    {
            //        Console.WriteLine("x + y ={2} when x={0} and y={1}", 1, 2, proxy.Add(1, 2));
            //        Console.WriteLine("x - y ={2} when x={0} and y={1}", 1, 2, proxy.Subtract(1, 2));
            //        Console.WriteLine("x * y ={2} when x={0} and y={1}", 1, 2, proxy.Multiply(1, 2));
            //        Console.WriteLine("x / y ={2} when x={0} and y={1}", 1, 2, proxy.Divide(1, 2));
            //    }
            //}
        }

        static void InvocateCalclatorServiceViaConfiguration()
        {
            using (ChannelFactory<ICalculator> ChannelFactory = new ChannelFactory<ICalculator>("calculatorservice"))
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



            using (ChannelFactory<ICalculator> ChannelFactory = new ChannelFactory<ICalculator>("calculatorservice_http"))
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


            using (ChannelFactory<ICalculator> ChannelFactory = new ChannelFactory<ICalculator>("calculatorservice_tcp"))
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


        private static void InvocateCalclatorServiceViaCode()
        {
            Binding httpbinding = new BasicHttpBinding();
            Binding tcpbinding = new NetTcpBinding();
            Binding iisBinding = new WSHttpBinding();

            EndpointAddress httpaddress = new EndpointAddress("http://localhost:8888/CalculatorService");
            EndpointAddress tcpaddress = new EndpointAddress("net.tcp://localhost:9998/CalculatorService");
            EndpointAddress iisAddress = new EndpointAddress("http://127.0.0.1:81/wcfservices/calculatorservice.svc");

            using (ChannelFactory<ICalculator> ChannelFactory = new ChannelFactory<ICalculator>(httpbinding, httpaddress))
            {
                ICalculator proxy_http = ChannelFactory.CreateChannel();
                using (proxy_http as IDisposable)
                {
                    Console.WriteLine("x + y ={2} when x={0} and y={1}", 1, 2, proxy_http.Add(1, 2));
                    Console.WriteLine("x - y ={2} when x={0} and y={1}", 1, 2, proxy_http.Subtract(1, 2));
                    Console.WriteLine("x * y ={2} when x={0} and y={1}", 1, 2, proxy_http.Multiply(1, 2));
                    Console.WriteLine("x / y ={2} when x={0} and y={1}", 1, 2, proxy_http.Divide(1, 2));
                }
            }

            using (ChannelFactory<ICalculator> ChannelFactory = new ChannelFactory<ICalculator>(tcpbinding, tcpaddress))
            {
                ICalculator proxy_tcp = ChannelFactory.CreateChannel();
                using (proxy_tcp as IDisposable)
                {
                    Console.WriteLine("x + y ={2} when x={0} and y={1}", 1, 2, proxy_tcp.Add(1, 2));
                    Console.WriteLine("x - y ={2} when x={0} and y={1}", 1, 2, proxy_tcp.Subtract(1, 2));
                    Console.WriteLine("x * y ={2} when x={0} and y={1}", 1, 2, proxy_tcp.Multiply(1, 2));
                    Console.WriteLine("x / y ={2} when x={0} and y={1}", 1, 2, proxy_tcp.Divide(1, 2));
                }
            }

            using (ChannelFactory<ICalculator> ChannelFactory = new ChannelFactory<ICalculator>(iisBinding, iisAddress))
            {
                ICalculator proxy_iis = ChannelFactory.CreateChannel();
                using (proxy_iis as IDisposable)
                {
                    Console.WriteLine("x + y ={2} when x={0} and y={1}", 1, 2, proxy_iis.Add(1, 2));
                    Console.WriteLine("x - y ={2} when x={0} and y={1}", 1, 2, proxy_iis.Subtract(1, 2));
                    Console.WriteLine("x * y ={2} when x={0} and y={1}", 1, 2, proxy_iis.Multiply(1, 2));
                    Console.WriteLine("x / y ={2} when x={0} and y={1}", 1, 2, proxy_iis.Divide(1, 2));
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
