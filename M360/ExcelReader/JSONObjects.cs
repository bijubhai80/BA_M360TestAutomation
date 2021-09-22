using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;

namespace M360TestAutomation.ExcelReader
{
    public static class JSONData
    {
        public static Dictionary<String, JObject> ReadAllJSONFiles()
        {
            Dictionary<String, JObject> JSONObjects = new Dictionary<String, JObject>();
            string filepath = "";
            if (TestContext.Parameters.Count > 0)
            {
                filepath = TestContext.Parameters.Get("JSONTestData");
            }
            else
            {
                filepath = ConfigurationManager.AppSettings.Get("JSONTestData");
            }
            DirectoryInfo d = new DirectoryInfo(filepath);
            var files = d.GetFiles("*.json");

            foreach (var file in files)
            {
                JObject jsonData = JObject.Parse(File.ReadAllText(file.FullName));
                JSONObjects.Add(file.Name.Replace(".json", ""), jsonData);
            }
            return JSONObjects;
        }
    }
}
