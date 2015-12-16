using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace XComponent.Authentication.TriggeredMethod
{
    using System;
    using XComponent.Authentication.Common;
    using XComponent.Authentication.Common.Senders;
    using XComponent.Common.TriggeredMethod;
    using XComponent.Common.Manager;
    using XComponent.Common.Logger;
    
    
    public partial class TriggeredMethodContext : ICustomTriggeredMethodContext
    {

        public void OnComponentInitialized()
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(componentManager.Resources.GetResourceAllText("users.xml"));

            XmlNodeList usersList = xmlDocument.SelectNodes("//user");
            List<User> users = new List<User>();
            foreach (XmlNode userNode in usersList)
            {
                User user = new User();
                user.Name = userNode.SelectSingleNode("name").InnerXml;
                user.Password = userNode.SelectSingleNode("password").InnerXml;
                users.Add(user);
            }

            Users = users;
        }

        public IEnumerable<User> Users { get; private set; }

        public void UnHanledException(TriggeredMethodException exception)
        {
        }
    }

    public partial interface ICustomTriggeredMethodContext : ITriggeredMethodContext
    {
        IEnumerable<User> Users { get; }
        
    }
}
