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

        public static async Task<List<JobListData>> GetJobList() {

            string response = await System.Services.ApiInterfacer.GetJob("all");

            Console.WriteLine(response);

            return JsonConvert.DeserializeObject<List<JobListData>>(response);
        }

        public static async Task<List<Category>> GetCategoryList() {

            List<Category> categoryList = new List<Category>() {
                new Category() { id = "1", name = "งานวิศวกรรม"},
                new Category() { id = "2", name = "งานคอมพิวเตอร์"},
                new Category() { id = "8", name = "งานบัญชี"},
            };

            string response = await System.Services.ApiInterfacer.GetCategory("all");

            return JsonConvert.DeserializeObject<List<Category>>(response);
        }
    }
}
