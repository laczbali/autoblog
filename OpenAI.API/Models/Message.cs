using System.Text.Json.Serialization;

namespace OpenAI.API.Models
{
	public class Message
	{
		[JsonConverter(typeof(JsonStringEnumConverter))]
		public Role Role { get; set; }

		public string Content { get; set; }
	}

	public enum Role
	{
		/// <summary>
		/// Use to provide rules and context for the conversation (ie "You are an IT helpdesk assistant")
		/// </summary>
		system,

		/// <summary>
		/// Your generic inputs
		/// </summary>
		user,

		/// <summary>
		/// The responses of OpenAI
		/// </summary>
		assistant
	}
}
