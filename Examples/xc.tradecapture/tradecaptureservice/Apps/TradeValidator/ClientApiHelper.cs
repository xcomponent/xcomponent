using System;
using XCClientAPICommon.Client;
using XComponent.TradeCapture.TradeValidatorApi;

namespace WpfApplication1
{
    internal class ClientApiHelper : IDisposable
    {
        private static readonly ClientApiHelper _instance = new ClientApiHelper();
        readonly private TradeValidatorApi _tradeValidatorApi = new TradeValidatorApi();

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
            return _tradeValidatorApi.Init(out blotterReport);
        }

        public TradeValidatorApi Api
        {
            get { return _tradeValidatorApi; }
        }

        public void Dispose()
        {
            _tradeValidatorApi.Dispose();
        }
    }
}
