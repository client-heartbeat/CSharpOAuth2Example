namespace OAuth2Lib.ClientHeartbeat {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;


	public class PulseResult {

		[JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("account_id")]
        public int AccountId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("closed_at")]
        public DateTime ClosedAt { get; set; }

		[JsonProperty("question_1")]
		public double Question1 { get; set; }

		[JsonProperty("question_2")]
        public double Question2 { get; set; }

        [JsonProperty("question_3")]
        public double Question3 { get; set; }

        [JsonProperty("question_4")]
        public double Question4 { get; set; }

		[JsonProperty("overall")]
        public double Overall { get; set; }

        public static List<PulseResult> Deserialize(Stream jsonStream)
        {
			if (jsonStream == null) {
				throw new ArgumentNullException("jsonStream");
			}

            using (StreamReader reader = new StreamReader(jsonStream))
            {
                var jsonResult = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<PulseResult>>(jsonResult);
            }

            
		}
	}
}
