using Blaczko.Core.Configuration;

namespace OpenAI.API
{
	public class OpenAiApiConfig : ConfigModel
	{
		public string BaseUrl { get; set; }

		public string AuthToken { get; set; }

		// rate limit settings
	}
}
