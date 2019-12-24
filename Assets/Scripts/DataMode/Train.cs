namespace HouYou
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using Newtonsoft.Json;

    public partial class Train
    {
        [JsonProperty("sufferid")] public int SufferId { get; set; }
        [JsonProperty("id")] public int Id { get; set; }
        [JsonProperty("trainname")] public string TrainName { get; set; }
    }
}