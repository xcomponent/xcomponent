﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by XCTools.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using XComponent.Common.ApiContext;
using XComponent.Engine.Processing;
using XComponent.Engine.Processing.Domain;

namespace XComponent.Authentication.Common
{
    public class InternalAPI : IInternalAPI
    {
		private IInternalCommunication _internalCommunicationLayer;
        
        public InternalAPI(IAgentManager agentManager)
        {
            _internalCommunicationLayer = new InternalCommunication(agentManager);
        }
        
        public void Init()
        {
            _internalCommunicationLayer.Init("DeploymentConfiguration.xml");
        }
        
        public void Init(string configFile)
        {
            _internalCommunicationLayer.Init(configFile);
        }

		public void Initialize(Context context, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, default(XComponent.Common.Event.DefaultEvent), privateTopic);
        }

		public void InitializationSuccess(Context context, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, default(XComponent.Authentication.UserObject.InitializationSuccess), privateTopic);
        }

		public void InitializationError(Context context, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, default(XComponent.Authentication.UserObject.InitializationError), privateTopic);
        }

		public void CheckLogin(Context context, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, default(XComponent.Authentication.UserObject.CheckLogin), privateTopic);
        }

		public void CreateHeartBeat(Context context, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, default(XComponent.Authentication.UserObject.CreateHeartBeat), privateTopic);
        }

		public void LoginSuccess(Context context, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, default(XComponent.Authentication.UserObject.LoginSuccess), privateTopic);
        }

		public void LoginError(Context context, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, default(XComponent.Authentication.UserObject.LoginError), privateTopic);
        }

		public void NotifyUp(Context context, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, default(XComponent.Common.Event.DefaultEvent), privateTopic);
        }

		public void Initialize(Context context, XComponent.Common.Event.DefaultEvent transitionEvent, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, transitionEvent, privateTopic);
        }

		public void InitializationSuccess(Context context, XComponent.Authentication.UserObject.InitializationSuccess transitionEvent, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, transitionEvent, privateTopic);
        }

		public void InitializationError(Context context, XComponent.Authentication.UserObject.InitializationError transitionEvent, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, transitionEvent, privateTopic);
        }

		public void CheckLogin(Context context, XComponent.Authentication.UserObject.CheckLogin transitionEvent, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, transitionEvent, privateTopic);
        }

		public void CreateHeartBeat(Context context, XComponent.Authentication.UserObject.CreateHeartBeat transitionEvent, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, transitionEvent, privateTopic);
        }

		public void LoginSuccess(Context context, XComponent.Authentication.UserObject.LoginSuccess transitionEvent, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, transitionEvent, privateTopic);
        }

		public void LoginError(Context context, XComponent.Authentication.UserObject.LoginError transitionEvent, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, transitionEvent, privateTopic);
        }

		public void NotifyUp(Context context, XComponent.Common.Event.DefaultEvent transitionEvent, string privateTopic = null)
        {
            _internalCommunicationLayer.Send(context, transitionEvent, privateTopic);
        }

		public void SendEvent(XComponent.Authentication.UserObject.InitializationSuccess evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(evt, privateTopic);
        }

		public void SendEvent(XComponent.Authentication.UserObject.InitializationError evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(evt, privateTopic);
        }

		public void SendEvent(XComponent.Authentication.UserObject.CheckLogin evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(evt, privateTopic);
        }

		public void SendEvent(XComponent.Authentication.UserObject.CreateHeartBeat evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(evt, privateTopic);
        }

		public void SendEvent(XComponent.Authentication.UserObject.LoginSuccess evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(evt, privateTopic);
        }

		public void SendEvent(XComponent.Authentication.UserObject.LoginError evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(evt, privateTopic);
        }

		public void SendEvent(StdEnum stdEnum, XComponent.Authentication.UserObject.InitializationSuccess evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(stdEnum, evt, privateTopic);
        }

		public void SendEvent(StdEnum stdEnum, XComponent.Authentication.UserObject.InitializationError evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(stdEnum, evt, privateTopic);
        }

		public void SendEvent(StdEnum stdEnum, XComponent.Authentication.UserObject.CheckLogin evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(stdEnum, evt, privateTopic);
        }

		public void SendEvent(StdEnum stdEnum, XComponent.Authentication.UserObject.CreateHeartBeat evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(stdEnum, evt, privateTopic);
        }

		public void SendEvent(StdEnum stdEnum, XComponent.Authentication.UserObject.LoginSuccess evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(stdEnum, evt, privateTopic);
        }

		public void SendEvent(StdEnum stdEnum, XComponent.Authentication.UserObject.LoginError evt, string privateTopic = null)
        {
            _internalCommunicationLayer.SendEvent(stdEnum, evt, privateTopic);
        }

    }
}