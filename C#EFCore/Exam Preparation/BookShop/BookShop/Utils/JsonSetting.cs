using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace BookShop.Utils
{
    public static class JsonSetting
    {
        public  static JsonSerializerSettings DefaultSettingJSON()
        {
            DefaultContractResolver contractor = new DefaultContractResolver
            {
                //NamingStrategy = new CamelCaseNamingStrategy()
            };

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = contractor,
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore
            };
            return settings;
        }
    }
}
