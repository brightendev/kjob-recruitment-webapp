using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KJobRecruitmentWebApp.Data
{
    public static class ExternalDatabase
    {

        public class ProvinceData
        {
            public string province_id { get; set; }
            public string province_name { get; set; }
        }

        public class BloodTypeData
        {
            public string blood_id { get; set; }
            public string blood_name { get; set; }
        }

        public static async Task<List<ProvinceData>> GetProvinceData() {

            List<ProvinceData> provinceDataList = JsonConvert.DeserializeObject<List<ProvinceData>>(await System.Services.ApiInterfacer.GetAllProvince());

            return provinceDataList;
        }

        public static async Task<List<BloodTypeData>> GetAllBloodTypeData() {

            return JsonConvert.DeserializeObject<List<BloodTypeData>>(await System.Services.ApiInterfacer.GettAllBloodType());
        }
    }
}
