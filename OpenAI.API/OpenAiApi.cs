using Blaczko.Core.Extensions;
using Blaczko.Core.Wrappers;
using OpenAI.API.Models;

namespace OpenAI.API
{
	/// <inheritdoc cref="IOpenAiApi"/>
	public class OpenAiApi : IOpenAiApi
	{
		private readonly OpenAiApiConfig config;

		public OpenAiApi(OpenAiApiConfig config)
		{
			this.config = config;
		}

		public async Task<string> Chat(IEnumerable<Message> messages, float temperature)
		{
			var response = await Chat(messages, temperature, 1);
			return response.FirstOrDefault()?.Content;
		}

		public async Task<List<Message>> Chat(IEnumerable<Message> messages, float temperature, int resultChoices)
		{
			if (messages is null || messages?.Count() == 0) throw new ArgumentException("You must provide at least 1 message", nameof(messages));
			if (temperature < 0 || temperature > 2) throw new ArgumentException("Temperature must be between 0 and 2", nameof(temperature));

			var requestObject = new ChatRequest
			{
				Model = this.config.Model,
				Messages = messages.ToArray(),
				Temperature = temperature
			};

			var result = await HttpClientWrapper.MakeRequestAsync<ChatResponse>(
				config.BaseUrl.TidyUrl("chat", "completions"),
				HttpMethod.Post,
				requestObject.ToHttpJsonContent(),
				"Bearer",
				config.AuthToken);

			return result.Choices.Select(x => x.Message).ToList();
		}

		public async Task<string> CreateImage(string prompt, ImageSize size)
		{
			var response = await CreateImage(prompt, size, 1);
			return response.FirstOrDefault();
		}

		public async Task<List<string>> CreateImage(string prompt, ImageSize size, int imageCount)
		{
			if (prompt.NullIfEmpty() is null) throw new ArgumentNullException("Must provide prompt", nameof(prompt));
			if (imageCount < 0 || imageCount > 10) throw new ArgumentException("ImageCount must be between 1 and 10", nameof(imageCount));

			var requestObject = new CreateImageRequest
			{
				ImageSize = size,
				Prompt = prompt,
				N = imageCount
			};

			var result = await HttpClientWrapper.MakeRequestAsync<CreateImageResponse>(
				config.BaseUrl.TidyUrl("images", "generations"),
				HttpMethod.Post,
				requestObject.ToHttpJsonContent(),
				"Bearer",
				config.AuthToken);

			return result.Data.Select(x => x.Url).ToList();
		}
	}
}