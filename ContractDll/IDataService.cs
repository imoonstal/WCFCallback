using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ContractDll
{
    [ServiceContract(SessionMode = SessionMode.Required, CallbackContract = typeof(IDataCallback))]
    public interface IDataService
    {
        [OperationContract(IsInitiating = true, IsTerminating = false)]
        void Start();

        [OperationContract(IsInitiating = true, IsTerminating = false)]
        void RegisterListener();

        [OperationContract(IsInitiating = false, IsTerminating = false)]
        void UnregisterListener();
    }

    [ServiceContract]
    public interface IDataCallback
    {
        [OperationContract(IsOneWay = true)]
        void OnDataHandler(string data);
    }
}
