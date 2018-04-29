using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SeagullWeb.Properties;

namespace SeagullWeb.Controllers
{
    public class PhotoController : ApiController
    {
        [HttpGet]
        public IEnumerable<string> Exterior()
        {
            var list = Directory.EnumerateFiles(Settings.Default.BasePath + "/images/Exterior").OrderBy(p => p);

            foreach (string fullPath in list)
            {
                yield return fullPath.Substring(Settings.Default.BasePath.Length + 1).Replace("\\", "/");
            }
        }

        [HttpGet]
        public IEnumerable<string> Interior()
        {
            var list = Directory.EnumerateFiles(Settings.Default.BasePath + "/images/Interior").OrderBy(p => p);

            foreach (string fullPath in list)
            {
                yield return fullPath.Substring(Settings.Default.BasePath.Length + 1).Replace("\\", "/");
            }
        }
    }
}
