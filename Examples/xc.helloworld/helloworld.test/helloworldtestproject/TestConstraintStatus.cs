namespace XComponent.HelloWorld.IntegrationTests
{
    internal class TestConstraintStatus
    {
        public TestConstraintStatus(string description, object actualValue, bool isSatisfied)
        {
            Description = description;
            ActualValue = actualValue;
            IsSatisfied = isSatisfied;
        }

        public string Description { get; private set; }

        public object ActualValue { get; private set; }

        public bool IsSatisfied { get; private set; }
    }
}
