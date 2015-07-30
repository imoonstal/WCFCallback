using ContractDll;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            Trace.Listeners.Add(new ConsoleTraceListener());
            DataHandlerClient client = new DataHandlerClient();
            IDataService service = DuplexChannelFactory<IDataService>.CreateChannel(client,
                new WSDualHttpBinding(), new EndpointAddress("http://localhost:8888/log"));

            //订阅消息
            service.RegisterListener();
            service.Start();

            //service.UnregisterListener();
        }
    }
}
