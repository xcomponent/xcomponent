namespace XComponent.Authentication.UserObject
{
    
    
    [System.Serializable()]
    public class ChangePassword
    {
        public string Login { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
