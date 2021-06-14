using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Federated.Models.Patients
{
    public class patients_covid19_admission_hospital
    {
        [JsonProperty("missing")]
        public int missing { get; set; }
        [JsonProperty("no")]
        public int no { get; set; }
        [JsonProperty("yes")]
        public int yes { get; set; }
    }
}
