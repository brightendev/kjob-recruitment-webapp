using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KJobRecruitmentWebApp.Data
{
    public class Job
    {
        public class Category
        {
            public string id { get; set; }
            public string name { get; set; }
        }

        public class JobListData
        {
            public string id { get; set; }
            public string title { get; set; }
            public string min_salary { get; set; }
            public string max_salary { get; set; }
            public int category { get; set; }
            public string created_date { get; set; }
            public string modified_date { get; set; }
            public string detail_1 { get; set; }
        }

        public class JobAllData
        {
            public string id { get; set; }
            public string title { get; set; }
            public string min_salary { get; set; }
            public string max_salary { get; set; }
            public string category { get; set; }
            public string created_date { get; set; }
            public string modified_date { get; set; }
            public string detail_1 { get; set; }
            public string detail_2 { get; set; }
            public string detail_3 { get; set; }
            public string detail_4 { get; set; }
            public string detail_5 { get; set; }
        }

        public class JobDetailData
        {
            public string title { get; set; }
            public string l1 { get; set; }
            public string l2 { get; set; }
            public string l3 { get; set; }
            public string l4 { get; set; }
            public string l5 { get; set; }
            public string l6 { get; set; }
        }

        public static async Task<List<JobListData>> GetJobList() {

            string response = await System.Services.ApiInterfacer.GetJob("all");

            Console.WriteLine(response);

            return JsonConvert.DeserializeObject<List<JobListData>>(response);
        }

        public static async Task<List<Category>> GetCategoryList() {

            string response = await System.Services.ApiInterfacer.GetCategory("all");

            return JsonConvert.DeserializeObject<List<Category>>(response);
        }

        public static async Task<JobAllData> GetJobDetail(string jobId)
        {

            string response = await System.Services.ApiInterfacer.GetJob(jobId);

      //      Console.WriteLine(response);

            return JsonConvert.DeserializeObject<JobAllData>(response);
        }
    }
}
