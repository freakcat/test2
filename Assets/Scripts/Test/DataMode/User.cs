namespace HouYou
{
    using Newtonsoft.Json;

    public partial class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("pw")]
        public string Pw { get; set; }
    }
}