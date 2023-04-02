using OpenAI.API.Models;

namespace OpenAI.API
{
	public interface IOpenAiApi
	{
		/// <summary>
		/// Send a chat request
		/// </summary>
		/// <param name="messages">Context to the conversation, at elast one item is required</param>
		/// <param name="temperature">Value between 0-2 signifying response creativity</param>
		/// <returns></returns>
		Task<string> Chat(IEnumerable<Message> messages, float temperature = 1);

		/// <inheritdoc cref="Chat(IEnumerable{Message}, float)"/>
		/// <param name="resultChoices">How many alternative results should be returned</param>
		Task<List<Message>> Chat(IEnumerable<Message> messages, float temperature = 1, int resultChoices = 1);

		/// <summary>
		/// Create an image from a prompt.
		/// </summary>
		/// <param name="prompt"></param>
		/// <param name="size"></param>
		/// <returns>An image url</returns>
		Task<string> CreateImage(string prompt, ImageSize size = ImageSize.Small);

		/// <param name="imageCount">How many images should be returned</param>
		/// <returns>A list of image URLs</returns>
		/// <inheritdoc cref="CreateImage(string, ImageSize)"/>
		Task<List<string>> CreateImage(string prompt, ImageSize size = ImageSize.Small, int imageCount = 1);
	}
}
