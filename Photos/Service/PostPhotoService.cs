using Photos.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Photos.Service
{
    public class PostPhotoService
    {
        private const string ApiUrl = "https://jsonplaceholder.typicode.com/photos";
       /* private const string ApiPhoto = "/GET/posts";*/
        public async Task<List<Photo>> GetPhotoAsync()
        {
            List<Photo> result = new List<Photo>();
            try
            {
                HttpClient httpClient = new HttpClient();
                var requestConnection = await httpClient.GetAsync(ApiUrl);
                if (requestConnection.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await requestConnection.Content.ReadAsStringAsync();
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Photo>>(content);
                    Console.WriteLine(content);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }
    }
}
