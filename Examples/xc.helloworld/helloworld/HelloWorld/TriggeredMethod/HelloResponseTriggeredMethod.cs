using System;
using XComponent.Common.ApiContext;
using XComponent.Common.Timeouts;
using XComponent.HelloWorld.Common;
using XComponent.HelloWorld.Common.Senders;
using XComponent.Shared;

namespace XComponent.HelloWorld.TriggeredMethod
{
    using System;
    using XComponent.Common.ApiContext;
    using XComponent.Common.Timeouts;
    using XComponent.HelloWorld.Common.Senders;
    using XComponent.HelloWorld.Common;


    public static class HelloResponseTriggeredMethod
    {

        /// <summary>
        /// Executing triggeredMethod ExecuteOn_Done_Through_SayHello
        /// </summary>
        public static void ExecuteOn_Done_Through_SayHello(XComponent.HelloWorld.UserObject.SayHello sayHello, XComponent.HelloWorld.UserObject.HelloResponse helloResponse, object object_InternalMember, Context context, ISayHelloSayHelloOnDoneHelloResponseSenderInterface sender)
        {
            helloResponse.Text = "Hello " + sayHello.Name;
        }
    }
}