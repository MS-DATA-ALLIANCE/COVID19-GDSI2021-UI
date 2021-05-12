using Federated.Models;
using Federated.Models.Patients;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace Federated.Areas.EndUser.Controllers
{
    [Area("EndUser")]
    public class PatientsController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Run()
        {
            string filePathExecute = "wwwroot/Scripts/Bash/RunP.sh";
            FileInfo fileInfo = new FileInfo(filePathExecute);
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = true;
            startInfo.FileName = "/bin/bash";
            startInfo.Arguments = $"\"{fileInfo.FullName}\"";
            Process process = Process.Start(startInfo);
            string DoneP = @"/app/wwwroot/Scripts/Python/MSDA_Querry3/DoneP.txt";
            var CheckDoneP = (System.IO.File.Exists(DoneP));
            if (CheckDoneP == false)
            {
                int delayForComupte = 0;
                Thread.Sleep(delayForComupte);
                while (CheckDoneP == false)
                {

                    Thread.Sleep(delayForComupte);
                    delayForComupte++;
                    CheckDoneP = (System.IO.File.Exists(DoneP));

                }
            }
            while (CheckDoneP == true)
            {


                var webClient = new WebClient();
                var jsoncAge = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-age_in_cat.json");
                var jsoncAH = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-covid19_admission_hospital.json");
                var jsoncDIAG = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-covid19_diagnosis.json");
                var jsoncICU = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-covid19_icu_stay.json");
                var jsoncOUTDTH = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-covid19_outcome_death.json");
                var jsoncOUTL1 = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-covid19_outcome_levels_1.json");
                var jsoncOUTL2 = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-covid19_outcome_levels_2.json");
                var jsoncOUTVENT = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-covid19_outcome_ventilation_or_ICU.json");
                var jsoncVENT = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-covid19_ventilation.json");
                var jsoncDMT = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-dmt_type_overall.json");
                var jsoncEDSS = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-edss_in_cat2.json");
                var jsoncMST = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-ms_type2.json");
                var jsoncSEX = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/patients-sex_binary.json");

                var cAGE = JsonConvert.DeserializeObject<patients_age_in_cat>(jsoncAge);
                var cAH = JsonConvert.DeserializeObject<patients_covid19_admission_hospital>(jsoncAH);
                var cDIAG = JsonConvert.DeserializeObject<patients_covid19_diagnosis>(jsoncDIAG);
                var cICU = JsonConvert.DeserializeObject<patients_covid19_icu_stay>(jsoncICU);
                var cOUTDTH = JsonConvert.DeserializeObject<patients_covid19_outcome_death>(jsoncOUTDTH);
                var cOUTL1 = JsonConvert.DeserializeObject<patients_covid19_outcome_levels_1>(jsoncOUTL1);
                var cOUTL2 = JsonConvert.DeserializeObject<patients_covid19_outcome_levels_2>(jsoncOUTL2);
                var cOUTVENT = JsonConvert.DeserializeObject<patients_covid19_outcome_ventilation_or_ICU>(jsoncOUTVENT);
                var cVENT = JsonConvert.DeserializeObject<patients_covid19_ventilation>(jsoncVENT);
                var cDMT = JsonConvert.DeserializeObject<patients_dmt_type_overall>(jsoncDMT);
                var cEDSS = JsonConvert.DeserializeObject<patients_edss_in_cat2>(jsoncEDSS);
                var cMST = JsonConvert.DeserializeObject<patients_ms_type2>(jsoncMST);
                var cSEX = JsonConvert.DeserializeObject<patients_sex_binary>(jsoncSEX);

                Outcomes outcomes = new Outcomes
                {
                    patients_Age_in_Cats = new List<patients_age_in_cat> { cAGE },
                    patients_Covid19_Admission_Hospitals = new List<patients_covid19_admission_hospital> { cAH },
                    patients_Covid19_Diagnoses = new List<patients_covid19_diagnosis> { cDIAG },
                    patients_Covid19_Icu_Stays = new List<patients_covid19_icu_stay> { cICU },
                    patients_Covid19_Outcome_Deaths = new List<patients_covid19_outcome_death> { cOUTDTH },
                    patients_Covid19_Outcome_Levels_1s = new List<patients_covid19_outcome_levels_1> { cOUTL1 },
                    patients_Covid19_Outcome_Levels_2s = new List<patients_covid19_outcome_levels_2> { cOUTL2 },
                    patients_Covid19_Outcome_Ventilation_Or_ICUs = new List<patients_covid19_outcome_ventilation_or_ICU> { cOUTVENT },
                    patients_Covid19_Ventilations = new List<patients_covid19_ventilation> { cVENT },
                    patients_Dmt_Type_Overalls = new List<patients_dmt_type_overall> { cDMT },
                    patients_Edss_In_Cat2s = new List<patients_edss_in_cat2> { cEDSS },
                    patients_Ms_Type2s = new List<patients_ms_type2> { cMST },
                    patients_Sex_Binaries = new List<patients_sex_binary> { cSEX }
                };

                string filePathExecute1 = "wwwroot/Scripts/Bash/Zip.sh";
                FileInfo fileInfo1 = new FileInfo(filePathExecute1);
                ProcessStartInfo startInfo1 = new ProcessStartInfo();
                startInfo1.CreateNoWindow = false;
                startInfo1.UseShellExecute = true;
                startInfo1.FileName = "/bin/bash";
                startInfo1.Arguments = $"\"{fileInfo1.FullName}\"";
                Process process1 = Process.Start(startInfo1);

                string DoneZ = @"/app/wwwroot/Scripts/Python/MSDA_Querry3/DoneZ.txt";
                var CheckDoneZ = (System.IO.File.Exists(DoneZ));
                if (CheckDoneZ == false)
                {
                    int delayForComupte = 0;
                    Thread.Sleep(delayForComupte);
                    while (CheckDoneZ == false)
                    {

                        Thread.Sleep(delayForComupte);
                        delayForComupte++;
                        CheckDoneZ = (System.IO.File.Exists(DoneZ));

                    }
                }
                while (CheckDoneZ == true)
                {

                    return View(outcomes);
                }
            }


            return Redirect("~/EndUser/Home/Index");

        }
    }
}
