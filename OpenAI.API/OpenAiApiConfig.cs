using Blaczko.Core.Configuration;

namespace OpenAI.API
{
	public class OpenAiApiConfig : ConfigModel
	{
		[RequiredKey]
		public string AuthToken { get; set; }

		public string BaseUrl { get; set; } = "https://api.openai.com/v1/";

		public string Model { get; set; } = "gpt-3.5-turbo";

		// RATE LIMITING
	}
}
