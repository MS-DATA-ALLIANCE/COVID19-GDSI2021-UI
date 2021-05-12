using Federated.Models.Clinicians;
using Federated.Models.Patients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Federated.Models
{
    public class Outcomes
    {
       
       public IList<clinicians_covid19_admission_hospital> clinicians_Covid19_Admission_Hospitals { get; set; }
       public IList<patients_covid19_admission_hospital> patients_Covid19_Admission_Hospitals { get; set; }

       public IList<clinicians_covid19_diagnosis> clinicians_Covid19_Diagnoses { get; set; }
       public IList<patients_covid19_diagnosis> patients_Covid19_Diagnoses { get; set; }


       public IList<clinicians_covid19_icu_stay> clinicians_Covid19_Icu_Stays { get; set; }
       public IList<patients_covid19_icu_stay> patients_Covid19_Icu_Stays { get; set; }


        public IList<clinicians_covid19_outcome_death> clinicians_Covid19_Outcome_Deaths { get; set; }
        public IList<patients_covid19_outcome_death> patients_Covid19_Outcome_Deaths { get; set; }


        public IList<clinicians_covid19_outcome_ventilation_or_ICU> clinicians_Covid19_Outcome_Ventilation_Or_ICUs { get; set; }
        public IList<patients_covid19_outcome_ventilation_or_ICU> patients_Covid19_Outcome_Ventilation_Or_ICUs { get; set; }


        public IList<clinicians_covid19_ventilation> clinicians_Covid19_Ventilations { get; set; }
        public IList<patients_covid19_ventilation> patients_Covid19_Ventilations { get; set; }

        public IList<clinicians_disease_duration_in_cat2> clinicians_Disease_Duration_In_Cat2s { get; set; }
        public IList<patients_disease_duration_in_cat2> patients_Disease_Duration_In_Cat2s { get; set; }

        public IList<clinicians_edss_in_cat2> clinicians_Edss_In_Cat2s { get; set; }
        public IList<patients_edss_in_cat2> patients_Edss_In_Cat2s { get; set; }

        public IList<clinicians_has_comorbidities> clinicians_Has_Comorbidities { get; set; }
        public IList<patients_has_comorbidities> patients_Has_Comorbidities { get; set; }

        public IList<clinicians_ms_type2> clinicians_Ms_Type2s { get; set; }
        public IList<patients_ms_type2> patients_Ms_Type2s { get; set; }

        public IList <clinicians_sex_binary> clinicians_Sex_Binaries { get; set; }
        public IList <patients_sex_binary> patients_Sex_Binaries { get; set; }

        public IList<clinicians_age_in_cat> clinicians_Age_in_Cats { get; set; }
        public IList<patients_age_in_cat> patients_Age_in_Cats { get; set; }

        public IList<clinicians_covid19_outcome_levels_1> clinicians_Covid19_Outcome_Levels_1s { get; set; }
        public IList<patients_covid19_outcome_levels_1> patients_Covid19_Outcome_Levels_1s { get; set; }

        public IList<clinicians_covid19_outcome_levels_2> clinicians_Covid19_Outcome_Levels_2s { get; set; }
        public IList<patients_covid19_outcome_levels_2> patients_Covid19_Outcome_Levels_2s { get; set; }

        public IList<clinicians_dmt_type_overall> clinicians_Dmt_Type_Overalls { get; set; }
        public IList<patients_dmt_type_overall> patients_Dmt_Type_Overalls { get; set; }


    }
}
