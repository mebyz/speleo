using Spello.Models.Source;
using Newtonsoft.Json;

namespace Spello.Models
{

    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>
    public class MainResult
    {
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>        
        public Result result { get; set; }
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>        
        public MainResult(dynamic gitHub, dynamic gitHubPartners)
        {
            if (gitHub == null)
                return;
            this.result = new Result
            {
                Config = gitHub,
                ConfigPartners = gitHubPartners
            };
        }

        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>        
        public MainResult(dynamic gitHub)
        {
            if (gitHub == null)
                return;
            this.result = new Result
            {
                Config = null,
                ConfigPartners = gitHub
            };
        }

    }

    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>        
    public class Result
    {
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Compatibility compatibility { get; set; }
        //public Config config { get; set; }
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public dynamic Config { get; set; }
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public dynamic ConfigPartners { get; set; }

    }

    /// <summary>
    /// todo
    /// </summary>
    /// <remarks>todo</remarks>     
    public class Compatibility
    {
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        public string upgrade { get; set; }
        /// <summary>
        /// todo
        /// </summary>
        /// <remarks>todo</remarks>     
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string version { get; set; }
    }
    
}
