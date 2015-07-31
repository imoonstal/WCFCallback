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

        static Dictionary<string, OperationContext> listeners = new Dictionary<string, OperationContext>();

        public static void Send(string data)
        {
            List<string> errorClinets = new List<string>();

            foreach (var listener in listeners)
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
