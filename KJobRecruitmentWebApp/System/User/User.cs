using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KJobRecruitmentWebApp.System.User
{
    public static class User
    {
        public class Account {
            public string email { get; set; }
            public string create_date { get; set; }
            public string last_login { get; set; }

        }
        public class Profile {
            public string personal_id { get; set; }
            public string thai_name { get; set; }
            public string eng_name { get; set; }
            public string date_of_birth { get; set; }
            public string nationality { get; set; }
            public string race { get; set; }
            public string religion { get; set; }
            public string blood { get; set; }
            public string relationship { get; set; }
            public string child { get; set; }
            public string military_criterion { get; set; }
            public string address { get; set; }
            public string province { get; set; }
            public string telephone { get; set; }
            public string email { get; set; }
            public string gender { get; set; }
        }
        public class UserDetail {
            public Account account { get; set; }
            public Profile profile { get; set; }
        }
        public static  UserDetail GetUserDetail(string email)
        {
            var data = new
            {
                Account = new
                {
                    email = "jjj@gmail.com",
                    create_date = "10/10/2016",
                    last_login = "11/11/2016"
                },
                Profile = new
                {
                    personal_id = "11121248",
                    thai_name = "ฟิวส์",
                    eng_name = "kuyfuse",
                    date_of_birth = "10/11/2013",
                    nationality = "thai",
                    race = "thai",
                    religion = "christian",
                    blood = "A",
                    relationship = "single",
                    child = "2",
                    military_criterion = "run away",
                    address = "45/78 m.7",
                    province = "bangkok",
                    telephone = "054896321",
                    email = "kuyfuse@gmail.com",
                    gender = "male"
                }
            };

            string data2 = JsonConvert.SerializeObject(data);
            Console.WriteLine(data2);
            return JsonConvert.DeserializeObject<UserDetail>(data2);
            
            
        }
    }
}
