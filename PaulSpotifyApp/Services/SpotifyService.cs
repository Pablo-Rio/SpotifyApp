using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpotifyAPI.Web;

namespace PaulSpotifyApp.Service
{
    public class SpotifyService
    {
        private SpotifyClient _spotifyClient;
        // Check this link to get your access token :
        // https://developer.spotify.com/documentation/web-api
        private const string ClientId = "YOUR_CLIENT_ID_HERE";
        private const string ClientSecret = "YOUR_CLIENT_SECRET_HERE";

        #region Instance

        public static SpotifyService Instance { get; } = new SpotifyService();

        #endregion

        public async Task<bool> ConnectSpotify()
        {
            try
            {
                string token = await GetAccessToken();
                _spotifyClient = new SpotifyClient(token);
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return false;
            }
        }

        public SpotifyClient GetSpotifyClient()
        {
            return _spotifyClient;
        }

        private async Task<string> GetAccessToken()
        {
            string baseUrl = "https://accounts.spotify.com/api/token";
            string authHeader = Convert.ToBase64String(
                System.Text.Encoding.UTF8.GetBytes($"{ClientId}:{ClientSecret}"));
            var formContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "client_credentials")
            });

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", authHeader);
                HttpResponseMessage response = await client.PostAsync(baseUrl, formContent);
                if (response.IsSuccessStatusCode)
                {
                    string jsonContent = await response.Content.ReadAsStringAsync();
                    dynamic tokenObject = JsonConvert.DeserializeObject(jsonContent);
                    return tokenObject.access_token;
                }
                else
                {
                    throw new Exception("Unable to get access token");
                }
            }
        }
    }
}