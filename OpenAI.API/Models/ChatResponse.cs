using System.Text.Json.Serialization;

namespace OpenAI.API.Models
{
	public class ChatResponse
	{
		public Choice[] Choices { get; set; }
	}

	public class Choice
	{
		public Message Message { get; set; }
	}
}
