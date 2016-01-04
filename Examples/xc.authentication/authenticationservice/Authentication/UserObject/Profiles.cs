using System.Collections.Generic;

namespace XComponent.Authentication.UserObject
{
    
    
    [System.Serializable()]
    public class Profiles
    {
        public Profiles()
        {
            ProfileList = new List<string>();
        }

        public List<string> ProfileList { get; set; }
    }
}
