using ContractDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client
{
    public class DataHandlerClient : IDataCallback
    {

        public void OnDataHandler(string data)
        {
            Console.WriteLine(data);
        }
    }
}
