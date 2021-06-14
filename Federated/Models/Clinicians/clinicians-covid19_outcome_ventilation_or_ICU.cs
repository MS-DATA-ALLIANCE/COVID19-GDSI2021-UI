using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Federated.Models.Clinicians
{
    public class clinicians_covid19_outcome_ventilation_or_ICU
    {
        [JsonProperty("missing")]
        public int missing { get; set; }
        [JsonProperty("no")]
        public int no { get; set; }
        [JsonProperty("yes")]
        public int yes { get; set; }
    }
}
