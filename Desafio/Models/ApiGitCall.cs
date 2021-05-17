using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using Newtonsoft.Json.Linq;

namespace Desafio.Models
{
    public class ApiGitCall
    {
           public static async Task<dynamic> makeRequest(string ApiUrl)
        {
            using (var client = new HttpClient())
            {   
                client.DefaultRequestHeaders.Add("User-Agent", "Desafio");
                var result = await client.GetStringAsync(ApiUrl);
                dynamic json = JsonConvert.DeserializeObject(result);


                var initialJson = "[]";
                var array = JArray.Parse(initialJson);

                foreach (var item in json)
                    if (item["language"] == "C#")
                    {
                        var itemToAdd = new JObject();
                        itemToAdd["id"] = item["id"];
                        itemToAdd["name"] = item["name"];
                        itemToAdd["avatar"] = item["owner"]["avatar_url"];
                        itemToAdd["description"] = item["description"];
                        itemToAdd["created"] = item["created_at"];
                        array.Add(itemToAdd);
                    }
                var newArray = (array[0],array[1], array[2], array[3], array[4]);

                return newArray;
             }

        }
    }
}