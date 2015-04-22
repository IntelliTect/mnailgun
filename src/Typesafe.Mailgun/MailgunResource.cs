using Newtonsoft.Json;

namespace Typesafe.Mailgun
{
	public class MailgunResource
	{
        [JsonProperty("id")]
		public string Id { get; set; } 
	}
}