using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RocheTechnicalTask.UIWPF.ViewModel.Helpers
{
    public class TextFileHelper
    {
        //public const string BASE_URL = "http://localhost:80";
        public const string FILES_ENDPOINT = "/api/Files?sText={0}";

        public static async Task<List<Model.TextFile>> GetTextFiles(string text)
        {
            string base_url = ConfigurationManager.AppSettings["urlBase"];
            string url = base_url + string.Format(FILES_ENDPOINT, text);

            List<Model.TextFile> Files = new List<Model.TextFile>();

            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                var responseString = await response.Content.ReadAsStringAsync();
                responseString = responseString.Trim();

                Files = JsonConvert.DeserializeObject<List<Model.TextFile>>(responseString);

            }

            return Files;
        }

    }
}
