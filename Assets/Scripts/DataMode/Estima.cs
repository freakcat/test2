namespace HouYou
{
    using System.Collections;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using UnityEngine;

    public partial class Estima
    {
        [JsonProperty("sufferid")] public int SufferId { get; set; }
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("estimaname")] public string EstimaName { get; set; }
    }
}