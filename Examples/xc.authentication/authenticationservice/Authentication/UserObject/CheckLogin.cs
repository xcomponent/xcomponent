namespace XComponent.Authentication.UserObject
{
    
    
    [System.Serializable()]
    public class CheckLogin
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string RequestId { get; set; }
    }
}
