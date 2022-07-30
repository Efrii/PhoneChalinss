using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PhoneChalin.Models;
using PhoneChalin.Repositories.Interfaces;

namespace PhoneChalin.Repositories.Data
{
    public class SmartphoneRepository : GenericRepository<Smartphone, int>
    {
        public SmartphoneRepository() : base("smartphone/")
        {

        }

        public async Task<List<Smartphone>> getall()
        {
            List<Smartphone> smartphones = new List<Smartphone>();

            var responseTask = await client.GetAsync("https://localhost:42573/api/smartphone/getall");

            if (responseTask.IsSuccessStatusCode)
            {
                var readTask = await responseTask.Content.ReadAsStringAsync();
                var parsedObject = JObject.Parse(readTask);
                var dataOnly = parsedObject["data"].ToString();

                smartphones = JsonConvert.DeserializeObject<List<Smartphone>>(dataOnly);
            }

            return smartphones;
        }
    }
}
