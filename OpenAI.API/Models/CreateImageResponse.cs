namespace OpenAI.API.Models
{
	public class CreateImageResponse
	{
		public Image[] Data { get; set; }
	}

	public class Image
	{
		public string Url { get; set; }
	}
}
