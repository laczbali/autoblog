namespace OpenAI.API.Models
{
	public class ChatRequest
	{
		public string Model { get; set; }
		public Message[] Messages { get; set; }
		public float Temperature { get; set; }
	}
}
