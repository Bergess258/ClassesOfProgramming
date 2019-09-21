
namespace Parser.Core.Habra
{
    class CSWeapSettings : IParserSettings
    {

        public string BaseUrl { get; set; } = "https://csgohub.ru";

        public string Prefix { get; set; } = "weapons.html";
    }
}
