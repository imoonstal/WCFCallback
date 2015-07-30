using ContractDll;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{

    [ServiceBehavior(
        IncludeExceptionDetailInFaults = true,
        InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DataService : IDataService
    {

        public DataService()
        {
            Trace.WriteLine("创建服务实例");
        }

        Dictionary<string, OperationContext> listeners = new Dictionary<string, OperationContext>();

        public void Send()
        {
            List<string> errorClinets = new List<string>();
            string data = "567893";

            foreach (KeyValuePair<string, OperationContext> listener in listeners)
            {
                try
                {
                    listener.Value.GetCallbackChannel<IDataCallback>().OnDataHandler(data);
                }
                catch (System.Exception e)
                {
                    errorClinets.Add(listener.Key);
                    Trace.WriteLine("Send错误信息:" + e.Message);
                }
            }

            foreach (string id in errorClinets)
            {
                listeners.Remove(id);
            }
        }


        public void Start()
        {
            Trace.WriteLine("Start");
            while (true)
            {
                Send();
                Thread.Sleep(1000 * 2);
            }
        }

        public void RegisterListener()
        {
            listeners.Add(OperationContext.Current.SessionId, OperationContext.Current);

            Trace.WriteLine("SessionID:" + OperationContext.Current.SessionId);
            Trace.WriteLine("Register listener. Client Count:" + listeners.Count.ToString());
        }

        public void UnregisterListener()
        {
            listeners.Remove(OperationContext.Current.SessionId);
            Trace.WriteLine("SessionID:" + OperationContext.Current.SessionId);
            Trace.WriteLine("Unregister listener. Client Count:" + listeners.Count.ToString());
        }
    }
}
