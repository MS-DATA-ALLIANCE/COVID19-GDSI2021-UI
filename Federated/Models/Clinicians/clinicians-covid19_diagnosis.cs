using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Federated.Models.Clinicians
{
    public class clinicians_covid19_diagnosis
    {
        public int confirmed { get; set; }
        public int not_suspected { get; set; }
        public int suspected { get; set; }
    }
}
