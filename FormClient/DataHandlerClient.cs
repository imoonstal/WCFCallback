using ContractDll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormClient
{
    public class DataHandlerClient : IDataCallback
    {
        public event FormViewHandler formView;
        public void OnDataHandler(string data)
        {
            formView(data);
        }
    }
}
