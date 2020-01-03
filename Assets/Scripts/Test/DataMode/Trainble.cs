namespace HouYou
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Trainble
    {
        [JsonProperty("train")] public List<Train> Train { get; set; }
    }
}