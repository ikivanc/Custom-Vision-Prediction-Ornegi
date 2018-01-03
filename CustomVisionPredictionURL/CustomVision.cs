using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomVisionPrectionURL
{

    public class CustomVision
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Project")]
        public string Project { get; set; }

        [JsonProperty(PropertyName = "Iteration")]
        public string Iteration { get; set; }

        [JsonProperty(PropertyName = "Created")]
        public DateTime Created { get; set; }

        [JsonProperty(PropertyName = "Predictions")]
        public Prediction[] Predictions { get; set; }
    }

    public class Prediction
    {
        [JsonProperty(PropertyName = "TagId")]
        public string TagId { get; set; }

        [JsonProperty(PropertyName = "Tag")]
        public string Tag { get; set; }

        [JsonProperty(PropertyName = "Probability")]
        public float Probability { get; set; }
    }

}
