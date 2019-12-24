namespace HouYou
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Sufferble
    {
        [JsonProperty("suffer")] public List<Suffer> Suffer { get; set; }
    }
}