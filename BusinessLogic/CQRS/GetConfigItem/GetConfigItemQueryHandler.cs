using BusinessLogic.Config;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace BusinessLogic.CQRS.GetConfigItem
{
    public sealed class GetConfigItemQueryHandler : IQueryHandler<GetConfigItemQuery, string>
    {
        private readonly IConfiguration _configuration;

        public GetConfigItemQueryHandler(IConfiguration configuration) 
        {
            _configuration = configuration;
        }

        public Task<string> Handle(GetConfigItemQuery request, CancellationToken cancellationToken)
        {
            string response;

            //AzureApplicationSettings
            if (request.IsSection)
            {
                //Microsoft.Extensions.Configuration
                //"AzureApplicationSettings"
                var section = _configuration.GetSection(request.ConfigItemName);
                var azureApplicationSettingsConfig = _configuration.GetSection(request.ConfigItemName).Get<AzureApplicationSettingsConfig>();
                response = $"{JsonConvert.SerializeObject(section)} --- {JsonConvert.SerializeObject(azureApplicationSettingsConfig)}";
            }
            else
            {
                //Microsoft.Extensions.Configuration.Binder
                //"AzureApplicationSettings:ShortDescription"
                response = _configuration.GetValue<string>(request.ConfigItemName);
            }
            
            return Task.FromResult(response);
        }
    }
}
