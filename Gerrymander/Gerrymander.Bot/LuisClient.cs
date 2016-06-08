using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace Gerrymander.Bot
{
    public class LuisClient
    {
        private readonly string id;
        private readonly string key;

        public LuisClient(string id, string key)
        {
            this.id = id;
            this.key = key;
        }

        public async Task<LuisMessage> ParseMessage(string message)
        {
            using (var client = new HttpClient())
            {
                var uri = $"https://api.projectoxford.ai/luis/v1/application?id={id}&subscription-key={key}&q={Uri.EscapeDataString(message)}";
                var luisMessage = await client.GetAsync(uri);
                if (luisMessage.IsSuccessStatusCode)
                {
                    var jsonResponse = await luisMessage.Content.ReadAsStringAsync();
                    var responseMessage = JsonConvert.DeserializeObject<LuisMessage>(jsonResponse);
                    return responseMessage;
                }
            }
            return null;
        }
    }

    public class LuisMessage
    {
        public string query { get; set; }
        public Intent[] intents { get; set; }
        public Entity[] entities { get; set; }
    }

    public class Intent
    {
        public string intent { get; set; }
        public float score { get; set; }
    }

    public class Entity
    {
        public string entity { get; set; }
        public string type { get; set; }
        public int startIndex { get; set; }
        public int endIndex { get; set; }
        public float score { get; set; }
    }
}