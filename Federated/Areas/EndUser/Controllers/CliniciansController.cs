using Federated.Models;
using Federated.Models.Clinicians;
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
    public class CliniciansController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Loading()
        {
            return View();

        }



        public IActionResult Run()
        {
            //string filePathExecute = "wwwroot/Scripts/Bash/RunC.sh";
            //FileInfo fileInfo = new FileInfo(filePathExecute);
            //ProcessStartInfo startInfo = new ProcessStartInfo();
            //startInfo.CreateNoWindow = false;
            //startInfo.UseShellExecute = true;
            //startInfo.FileName = "/bin/bash";
            //startInfo.Arguments = $"\"{fileInfo.FullName}\"";
            //Process process = Process.Start(startInfo);
            string DoneC = @"/app/wwwroot/Scripts/Python/MSDA_Querry3/DoneC.txt";
            var CheckDoneC = (System.IO.File.Exists(DoneC));
            if (CheckDoneC == false)
            {
                int delayForComupte = 0;
                Thread.Sleep(delayForComupte);
                while (CheckDoneC == false)
                {

                    Thread.Sleep(delayForComupte);
                    delayForComupte++;
                    CheckDoneC = (System.IO.File.Exists(DoneC));

                }
            }
            while (CheckDoneC == true)
            {


                //var webClient = new WebClient();
                //var jsoncAge = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-age_in_cat.json");
                //var jsoncAH = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_admission_hospital.json");
                //var jsoncDIAG = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_diagnosis.json");
                //var jsoncICU = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_icu_stay.json");
                //var jsoncOUTDTH = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_outcome_death.json");
                //var jsoncOUTL1 = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_outcome_levels_1.json");
                //var jsoncOUTL2 = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_outcome_levels_2.json");
                //var jsoncOUTVENT = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_outcome_ventilation_or_ICU.json");
                //var jsoncVENT = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_ventilation.json");
                //var jsoncDMT = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-dmt_type_overall.json");
                //var jsoncEDSS = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-edss_in_cat2.json");
                //var jsoncMST = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-ms_type2.json");
                //var jsoncSEX = webClient.DownloadString("C:/Users/ashka/OneDrive/Documents/Projects/Federated/Federated/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-sex_binary.json");




                var webClient = new WebClient();
                var jsoncAge = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-age_in_cat.json");
                var jsoncAH = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_admission_hospital.json");
                var jsoncDIAG = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_diagnosis.json");
                var jsoncICU = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_icu_stay.json");
                var jsoncOUTDTH = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_outcome_death.json");
                var jsoncOUTL1 = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_outcome_levels_1.json");
                var jsoncOUTL2 = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_outcome_levels_2.json");
                var jsoncOUTVENT = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_outcome_ventilation_or_ICU.json");
                var jsoncVENT = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-covid19_ventilation.json");
                var jsoncDMT = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-dmt_type_overall.json");
                var jsoncEDSS = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-edss_in_cat2.json");
                var jsoncMST = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-ms_type2.json");
                var jsoncSEX = webClient.DownloadString(@"/app/wwwroot/Scripts/Python/MSDA_Querry3/Outputs/clinicians-sex_binary.json");


                //string pattern0 = @"\b0\b";
                //string pattern1 = @"\b1\b";
                //string pattern2 = @"\b2\b";
                //string pattern3 = @"\b3\b";

                //jsoncAge = Regex.Replace(jsoncAge, pattern1, "one", RegexOptions.None);
                //jsoncAge = Regex.Replace(jsoncAge, pattern0, "zero", RegexOptions.None);
                //jsoncAge = Regex.Replace(jsoncAge, pattern2, "two", RegexOptions.None);
                //jsoncAge = Regex.Replace(jsoncAge, pattern3, "three", RegexOptions.None);





                var cAGE = JsonConvert.DeserializeObject<clinicians_age_in_cat>(jsoncAge);
                var cAH = JsonConvert.DeserializeObject<clinicians_covid19_admission_hospital>(jsoncAH);
                var cDIAG = JsonConvert.DeserializeObject<clinicians_covid19_diagnosis>(jsoncDIAG);
                var cICU = JsonConvert.DeserializeObject<clinicians_covid19_icu_stay>(jsoncICU);
                var cOUTDTH = JsonConvert.DeserializeObject<clinicians_covid19_outcome_death>(jsoncOUTDTH);
                var cOUTL1 = JsonConvert.DeserializeObject<clinicians_covid19_outcome_levels_1>(jsoncOUTL1);
                var cOUTL2 = JsonConvert.DeserializeObject<clinicians_covid19_outcome_levels_2>(jsoncOUTL2);
                var cOUTVENT = JsonConvert.DeserializeObject<clinicians_covid19_outcome_ventilation_or_ICU>(jsoncOUTVENT);
                var cVENT = JsonConvert.DeserializeObject<clinicians_covid19_ventilation>(jsoncVENT);
                var cDMT = JsonConvert.DeserializeObject<clinicians_dmt_type_overall>(jsoncDMT);
                var cEDSS = JsonConvert.DeserializeObject<clinicians_edss_in_cat2>(jsoncEDSS);
                var cMST = JsonConvert.DeserializeObject<clinicians_ms_type2>(jsoncMST);
                var cSEX = JsonConvert.DeserializeObject<clinicians_sex_binary>(jsoncSEX);




                Outcomes outcomes = new Outcomes
                {
                    clinicians_Age_in_Cats = new List<clinicians_age_in_cat> { cAGE },
                    clinicians_Covid19_Admission_Hospitals = new List<clinicians_covid19_admission_hospital> { cAH },
                    clinicians_Covid19_Diagnoses = new List<clinicians_covid19_diagnosis> { cDIAG },
                    clinicians_Covid19_Icu_Stays = new List<clinicians_covid19_icu_stay> { cICU },
                    clinicians_Covid19_Outcome_Deaths = new List<clinicians_covid19_outcome_death> { cOUTDTH },
                    clinicians_Covid19_Outcome_Levels_1s = new List<clinicians_covid19_outcome_levels_1> { cOUTL1 },
                    clinicians_Covid19_Outcome_Levels_2s = new List<clinicians_covid19_outcome_levels_2> { cOUTL2 },
                    clinicians_Covid19_Outcome_Ventilation_Or_ICUs = new List<clinicians_covid19_outcome_ventilation_or_ICU> { cOUTVENT },
                    clinicians_Covid19_Ventilations = new List<clinicians_covid19_ventilation> { cVENT },
                    clinicians_Dmt_Type_Overalls = new List<clinicians_dmt_type_overall> { cDMT },
                    clinicians_Edss_In_Cat2s = new List<clinicians_edss_in_cat2> { cEDSS },
                    clinicians_Ms_Type2s = new List<clinicians_ms_type2> { cMST },
                    clinicians_Sex_Binaries = new List<clinicians_sex_binary> { cSEX }
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
