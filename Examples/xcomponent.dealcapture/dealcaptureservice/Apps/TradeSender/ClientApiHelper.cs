using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCClientAPICommon.Client;
using XComponent.DealCapture.DealApi;

namespace TradeSender
{
    class ClientApiHelper : IDisposable
    {
        static readonly ClientApiHelper _instance = new ClientApiHelper();
        private DealApi _dealApi;

        private ClientApiHelper()
        {
            
        }

        public static ClientApiHelper Instance
        {
            get
            {
                return _instance;                
            }
        }

        public bool Init()
        {
            _dealApi = new DealApi();
           InitReport dealReport;
            return _dealApi.Init(out dealReport);
        }

        public DealApi Api
        {
            get
            {
                return _dealApi;
            }
        }

        public void Dispose()
        {
           _dealApi.Dispose();
        }
    }
}
