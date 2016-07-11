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

            using(ServiceHost host=new ServiceHost(typeof(CalculatorService)))
            {
                host.Opened+=host_Opened;
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
