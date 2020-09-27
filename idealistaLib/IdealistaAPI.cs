using IdealistaLib.Filters;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;

namespace IdealistaLib
{


    public class IdealistaAPI
    {
        public HttpClient Client { get; }
        private string APIKey { get; set; }
        private string APISecret { get; set; }
        private string KEYSECRET { get; set; }

        private string BearerToken { get; set; }

        public IdealistaAPI(string key, string secret)
        {
            APIKey = key; // setting up APIKey
            APISecret = secret;  // setting up APISecret
            string encodedkey = HttpUtility.UrlEncode(APIKey);
            string encodedsecret = HttpUtility.UrlEncode(APISecret);
            byte[] data = System.Text.ASCIIEncoding.ASCII.GetBytes(encodedkey + ":" + encodedsecret);
            KEYSECRET = System.Convert.ToBase64String(data);
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://api.idealista.com/");
        }

        public IdealistaAPI(string bearerToken)
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("https://api.idealista.com/");
            this.BearerToken = bearerToken;
        }

        public async Task<AuthResponse> Authenticate()
        {
            /*
             * 
             * curl -X POST -H "Authorization: Basic YWJjOjEyMw==" -H "Content-Type:
             * application/x-www-form-urlencoded" -d 'grant_type=client_credentials&scope=read'
             * "https://api.idealista.com/oauth/token" -k
             */
            try
            {
                Client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Basic " + KEYSECRET);
                var response = await Client.PostAsync("/oauth/token", new StringContent("grant_type=client_credentials&scope=read", Encoding.UTF8, "application/x-www-form-urlencoded"));
                if (response.IsSuccessStatusCode)
                {
                    string jsonresponse = await response.Content.ReadAsStringAsync();
                    var json = JsonSerializer.Deserialize<AuthResponse>(jsonresponse);
                    this.BearerToken = json.access_token;
                    return json;
                }
                else return null;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public async Task<SearchResponse> SearchRequest(SearchFilter filter, string country)
        {
            try
            {
                if (string.IsNullOrEmpty(BearerToken))
            {

                throw new Exception("No Token here.");

            }
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", "Bearer " + this.BearerToken);
            var method = new MultipartFormDataContent();
            var requestContent = new MultipartFormDataContent();

            var response = await Client.PostAsync("/3.5/" + country + "/search", new StringContent(filter.ToString(), Encoding.UTF8, "application/x-www-form-urlencoded"));
            string jsonresponse = await response.Content.ReadAsStringAsync();
            var json = JsonSerializer.Deserialize<SearchResponse>(jsonresponse);
            return json;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
