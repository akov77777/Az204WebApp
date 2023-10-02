namespace BusinessLogic.CQRS.GetConfigItem
{
    public sealed class GetConfigItemQuery : IQuery<string>
    {
        public string ConfigItemName { get; init; }

        public bool IsSection { get; init; }

        public GetConfigItemQuery(string configItemName, bool isSection)
        {
            ConfigItemName = configItemName;
            IsSection = isSection;
        }
    }
}