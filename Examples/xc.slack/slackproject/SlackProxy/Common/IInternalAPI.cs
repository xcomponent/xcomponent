//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by XCTools.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace XComponent.SlackProxy.Common
{
    using System;
    using XComponent.Common.ApiContext;
    using Microsoft.FSharp.Collections;
    using Microsoft.FSharp.Core;
    
    
    public interface IInternalAPI
    {
		void Init(Context context);
			
		void SendMessage(Context context);
			
		void Success(Context context);
			
		void Error(Context context);
			
		
		
		void Init(Context context, XComponent.Common.Event.DefaultEvent transitionEvent);
			
		void SendMessage(Context context, XComponent.SlackProxy.UserObject.SendMessage transitionEvent);
			
		void Success(Context context, XComponent.SlackProxy.UserObject.Success transitionEvent);
			
		void Error(Context context, XComponent.SlackProxy.UserObject.Error transitionEvent);
			
		
		
		void SendEvent(XComponent.SlackProxy.UserObject.SendMessage evt);
			
			void SendEvent(StdEnum stdEnum, XComponent.SlackProxy.UserObject.SendMessage evt);
			
		void SendEvent(XComponent.SlackProxy.UserObject.Success evt);
			
			void SendEvent(StdEnum stdEnum, XComponent.SlackProxy.UserObject.Success evt);
			
		void SendEvent(XComponent.SlackProxy.UserObject.Error evt);
			
			void SendEvent(StdEnum stdEnum, XComponent.SlackProxy.UserObject.Error evt);
			
		
    }
}