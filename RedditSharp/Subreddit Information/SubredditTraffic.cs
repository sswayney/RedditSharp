using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RedditSharp.Things;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedditSharp
{
    public class SubredditTraffic 
    {
        private Reddit Reddit { get; set; }
        private IWebAgent WebAgent { get; set; }

        /// <summary>
        /// Subreddit.
        /// </summary>
        public Subreddit Subreddit { get; set; }

        public SubredditTraffic(Reddit reddit, Subreddit subreddit, IWebAgent webAgent)
        {
            Reddit = reddit;
            Subreddit = subreddit;
            WebAgent = webAgent;
        }

        public SubredditTraffic(Reddit reddit, Subreddit subreddit, JToken json, IWebAgent webAgent) : this(reddit, subreddit, webAgent)
        {
            JsonConvert.PopulateObject(json.ToString(), this, reddit.JsonSerializerSettings);
        }

        [JsonProperty("day")]
        public List<List<string>> Days { get; set; }

        [JsonProperty("hour")]
        public List<List<string>> Hours { get; set; }

        [JsonProperty("month")]
        public List<List<string>> Months { get; set; }
    }
}
