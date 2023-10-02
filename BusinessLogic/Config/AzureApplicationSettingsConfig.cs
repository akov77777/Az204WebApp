namespace BusinessLogic.Config
{
    public class AzureApplicationSettingsConfig
    {
        public const string ConfigSectionName = "AzureApplicationSettings";

        public bool UseMediatR { get; set; }

        public bool UseAzureLogging { get; set; }

        public bool UseSimpleAuthentication { get; set; }

        public string ShortDescription { get; set; }
    }
}
