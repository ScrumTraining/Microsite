using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using SeagullWeb.Properties;

namespace SeagullWeb.Controllers
{
    public class CustomerController : ApiController
    {
        [DataContract]
        public class MoreInfoRequest
        {
            [DataMember(Name = "firstName")]
            public string FirstName { get; set; }
            [DataMember(Name = "lastName")]
            public string LastName { get; set; }
            [DataMember(Name = "email")]
            public string Email { get; set; }
        }

        [HttpPost]
        public Boolean MoreInfo([FromBody]MoreInfoRequest request)
        {
            if (!Directory.Exists(Settings.Default.BasePath + "/customer"))
            {
                Directory.CreateDirectory(Settings.Default.BasePath + "/customer");
            }
            var filepath = Settings.Default.BasePath + "/customer/moreinfo.csv";
            if (!File.Exists(filepath))
            {
                File.Create(filepath);
            }
            File.AppendAllText(filepath, $"{request.FirstName},{request.LastName},{request.Email}\n");
            return true;
        }
    }
}
