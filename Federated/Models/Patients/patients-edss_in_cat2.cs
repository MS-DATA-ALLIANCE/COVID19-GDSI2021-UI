using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Federated.Models.Patients
{
    public class patients_edss_in_cat2
    {
        [JsonProperty("0")]
        public int zero { get; set; }
        [JsonProperty("1")]
        public int one { get; set; }

        public int missing { get; set; }
        [JsonProperty("2")]
        public int two { get; set; }


    }
}
