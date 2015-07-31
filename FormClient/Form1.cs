using ContractDll;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormClient
{
    public partial class Form1 : Form
    {
        
        static DataHandlerClient client = new DataHandlerClient();
        IDataService service;
        public Form1()
        {
            InitializeComponent();
            service = DuplexChannelFactory<IDataService>.CreateChannel(client,
            new WSDualHttpBinding(), new EndpointAddress("http://localhost:8888/log"));
            client.formView += Form1_formView;
        }

        void Form1_formView(string data)
        {
            this.tbDataView.AppendText(data+"\r\n");
        }

        private void btnReg_Click(object sender, EventArgs e)
        {
            service.RegisterListener();
            
        }

        private void btnUnReg_Click(object sender, EventArgs e)
        {
            service.UnregisterListener();
        }
    }
}
