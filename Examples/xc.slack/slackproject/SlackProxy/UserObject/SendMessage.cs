namespace XComponent.SlackProxy.UserObject
{
    
    
    // ICloneable interface can be implemented to override clone behaviour of XComponent
    // IDisposable interface can be implemented to dispose public/internal members when the state machine is in a final state
    // ToString() can be overridden. XCSpy uses it to display state machine instances
    [System.Serializable()]
    public class SendMessage
    {
        public string SlackChannel { get; set; }
        public string SlackUrlWithToken { get; set; }
        public string SlackUser { get; set; }
        public string MessageImage { get; set; }
        public string MessageTitle { get; set; }
        public string Text { get; set; }
        public string IconEmoji { get; set; }
        public string Color { get; set; }

    }
}
