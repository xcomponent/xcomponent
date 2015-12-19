using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCClientAPICommon.Client;
using XComponent.DealCapture.BlotterApi;
using XComponent.DealCapture.DealApi;

namespace WpfApplication1
{
    internal class ClientApiHelper : IDisposable
    {
        private static readonly ClientApiHelper _instance = new ClientApiHelper();
        private readonly BlotterApi _blotterApi = new BlotterApi();

        private ClientApiHelper()
        {

        }

        public static ClientApiHelper Instance
        {
            get { return _instance; }
        }

        public bool Init()
        {
            InitReport blotterReport;
            return _blotterApi.Init(out blotterReport);
        }

        public BlotterApi Api
        {
            get { return _blotterApi; }
        }

        public void Dispose()
        {
            _blotterApi.Dispose();
        }
    }
}
