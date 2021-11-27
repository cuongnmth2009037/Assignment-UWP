using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using T2009M1HelloUWP.Entities;

namespace T2009M1HelloUWP.Service
{
    public class SongService
    {       
        private FileService fileService;
        private AccountService accountService;
        private string _accessToken;
        private const string ApiBaseUrl = "https://music-i-like.herokuapp.com";
        private const string ApiSongPath = "/api/v1/songs";
        private const string ApiGetMySongPath = "/api/v1/songs/mine";
        public async Task<List<Song>> GetLatestSongAsync()
        {
            List<Song> result = new List<Song>();
            try
            {
                HttpClient httpClient = new HttpClient();
                /*httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {credential.access_token}");*/
                var requestConnection = await httpClient.GetAsync(ApiBaseUrl + ApiSongPath);
                if (requestConnection.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await requestConnection.Content.ReadAsStringAsync();
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Song>>(content);
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

        public async Task<List<Song>> GetMySongAsync()
        {
            accountService = new AccountService();
            var credential = await accountService.LoadAccessTokenFromFile();
            List<Song> result = new List<Song>();          
            try
            {
                HttpClient httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {credential.access_token}");
                var requestConnection = await httpClient.GetAsync(ApiBaseUrl + ApiGetMySongPath);
                if (requestConnection.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var content = await requestConnection.Content.ReadAsStringAsync();
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Song>>(content);
                    Debug.WriteLine(content);
                    return result;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return result;
        }



        public async Task<Song> CreateSongAsync(Song song)
        {
            accountService = new AccountService();
            var credential = await accountService.LoadAccessTokenFromFile();
            _accessToken = credential.access_token;
            try
            {
                var songJson = Newtonsoft.Json.JsonConvert.SerializeObject(song);
                HttpClient httpClient = new HttpClient();
                Debug.WriteLine(songJson);
                httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_accessToken}");
                var httpContent = new StringContent(songJson, Encoding.UTF8, "application/json");
                var requestConnection = await httpClient.PostAsync("https://music-i-like.herokuapp.com/api/v1/songs/mine", httpContent);
                Debug.WriteLine(requestConnection.StatusCode);
                if (requestConnection.StatusCode == System.Net.HttpStatusCode.Created)
                {
                    return song;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }
    }
}
