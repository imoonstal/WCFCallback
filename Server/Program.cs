using ContractDll;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            DataService service = new DataService();
            Uri address = new Uri("http://localhost:8888/log");
            ServiceHost host = new ServiceHost(service, address);
            host.Opened += new EventHandler(host_Opened);
            host.Opening += new EventHandler(host_Opening);
            host.AddServiceEndpoint(typeof(IDataService), new WSDualHttpBinding(), string.Empty);
            ServiceMetadataBehavior behavior = new ServiceMetadataBehavior();
            behavior.HttpGetEnabled = true;
            host.Description.Behaviors.Add(behavior);
            host.Open();
            int n = 0;
            new Task(() =>
            {
                while (true)
                {
                    DataService.Send(n.ToString() + DateTime.Now.ToShortTimeString());
                    n++;
                    Thread.Sleep(1000 * 2);
                }
            }).Start();

            Console.WriteLine("Press enter key to exit.");
            Console.ReadLine();
            host.Close();
        }

        static void host_Opening(object sender, EventArgs e)
        {
            Trace.WriteLine("Service Openning");
        }

        static void host_Opened(object sender, EventArgs e)
        {
            Trace.WriteLine("Service Opened");
        }
    }
}
