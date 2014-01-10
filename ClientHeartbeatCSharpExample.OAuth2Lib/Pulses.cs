namespace OAuth2Lib.ClientHeartbeat {
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;

    public class QuestionResult
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("change")]
        public double Change { get; set; }
        [JsonProperty("score")]
        public double Score { get; set; }
        [JsonProperty("name")]
        public double Name { get; set; }
    }

    public class ChangeResult
    {
        [JsonProperty("change")]
        public double Change { get; set; }
        [JsonProperty("count")]
        public int Count { get; set; }
    }

    public class HeartbeatResult
    {
        [JsonProperty("received")]
        public int Received { get; set; }
        [JsonProperty("opted_out")]
        public int OptedOut { get; set; }
        [JsonProperty("total")]
        public int Total { get; set; }
    }

	public class PulseResult {

		[JsonProperty("id")]
		public long Id { get; set; }

        [JsonProperty("account_id")]
        public long AccountId { get; set; }

        [JsonProperty("code")]
        public string Code { get; set; }

		[JsonProperty("created_at")]
		public DateTime CreatedAt { get; set; }

		[JsonProperty("closed_at")]
        public DateTime ClosedAt { get; set; }

		[JsonProperty("question_1")]
		public double Question1 { get; set; }

		[JsonProperty("question_2")]
        public long Question2 { get; set; }

        [JsonProperty("question_3")]
        public long Question3 { get; set; }

        [JsonProperty("question_4")]
        public long Question4 { get; set; }

		[JsonProperty("overall")]
        public double Overall { get; set; }

        public static List<PulseResult> Deserialize(Stream jsonStream)
        {
			if (jsonStream == null) {
				throw new ArgumentNullException("jsonStream");
			}

            using (StreamReader reader = new StreamReader(jsonStream))
            {
                var things = reader.ReadToEnd();
                return JsonConvert.DeserializeObject<List<PulseResult>>(things);
            }

            
		}
	}
}
