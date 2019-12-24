namespace HouYou
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Estimable
    {
        [JsonProperty("estima")] public List<Estima> Estima { get; set; }
    }
}