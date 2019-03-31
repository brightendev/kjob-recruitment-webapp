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


        public class ReligionData
        {
            public string religion_id { get; set; }
            public string religion_name { get; set; }
        }

        public class RelationshipData
        {
            public string relationship_id { get; set; }
            public string relationship_name { get; set; }
        }

        public class MilitaryCriterionData
        {
            public string military_criterion_id { get; set; }
            public string military_criterion_name { get; set; }
        }

        public class GenderData
        {
            public string gender_id { get; set; }
            public string gender_name { get; set; }
        }

        public class PublicData
        {
            public List<BloodTypeData> Blood { get; set; }
            public List<ProvinceData> Province { get; set; }
            public List<ReligionData> Religion { get; set; }
            public List<RelationshipData> Relationship { get; set; }
            public List<MilitaryCriterionData> MilitaryCriterion { get; set; }
            public List<GenderData> Gender { get; set; }
        }
        public static async Task<PublicData> GetPublicData() {

            return JsonConvert.DeserializeObject<PublicData>(await System.Services.ApiInterfacer.GetPublicData());
        }
    }
}
