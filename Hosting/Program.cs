using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Contracts;
using Services;
using System.ServiceModel.Description;
namespace Hosting
{
    class Program
    {
        static void Main(string[] args)
        {
            //HostByCode();

           // HostCalculatorServiceViaCode();

            HostCalculatorSerivceViaConfiguration();

            //using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            //{
            //    host.Opened += host_Opened;
            //    host.Open();
            //    Console.ReadLine();
            //}
        }

        private static void HostCalculatorSerivceViaConfiguration()
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.Opened += host_Opened;
                host.Open();
                Console.ReadLine();
            }

        }

        private static void HostCalculatorServiceViaCode()
        {
            Uri httpbaseAddress = new Uri("http://localhost:8888/CalculatorService");
            Uri tcpbaseAddress = new Uri("net.tcp://localhost:9998/CalculatorService");
            using(ServiceHost host=new ServiceHost(typeof(CalculatorService),httpbaseAddress,tcpbaseAddress))
            {
                BasicHttpBinding httpBinding=new BasicHttpBinding();
                NetTcpBinding tcpBinding=new NetTcpBinding();
                host.AddServiceEndpoint(typeof(ICalculator),httpBinding,String.Empty);
                host.AddServiceEndpoint(typeof(ICalculator),tcpBinding,string.Empty);
                ServiceMetadataBehavior behavior=host.Description.Behaviors.Find<ServiceMetadataBehavior>();
                {
                    if(behavior==null)
                    {
                        behavior=new ServiceMetadataBehavior();
                        behavior.HttpGetEnabled=true;
                        host.Description.Behaviors.Add(behavior);

                    }
                    else
                    {
                        behavior.HttpGetEnabled=true;
                    }
                }
                 host.Opened += host_Opened;
                host.Open();
                Console.ReadLine();

            }
        }

        private static void HostByCode()
        {
            using (ServiceHost host = new ServiceHost(typeof(CalculatorService)))
            {
                host.AddServiceEndpoint(typeof(ICalculator), new WSHttpBinding(), "http://127.0.0.1:9999/CalculatorService");
                if (host.Description.Behaviors.Find<ServiceMetadataBehavior>() == null)
                {
                    ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
                    behavior.HttpGetEnabled = true;
                    behavior.HttpGetUrl = new Uri("http://127.0.0.1:9999/CalculatorService/metadata");
                    host.Description.Behaviors.Add(behavior);
                }
                host.Opened += host_Opened;
                host.Open();
                Console.ReadLine();

            }
        }

        private static void host_Opened(object sender, EventArgs e)
        {
            Console.WriteLine("CalculatorService已经启动成功，按任意键终止服务");
        }
    }
}
