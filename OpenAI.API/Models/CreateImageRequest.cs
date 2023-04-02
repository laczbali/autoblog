using System.Text.Json.Serialization;

namespace OpenAI.API.Models
{
	public class CreateImageRequest
	{
		public string Prompt { get; set; }

		public string Size { get; private set; }

		public int N { get; set; }

		[JsonIgnore]
		public ImageSize ImageSize {
			get => _imageSize;
			set
			{
				_imageSize = value;
				Size = ImageSizeMap[value];
			}
		}

		private ImageSize _imageSize;

		private readonly Dictionary<ImageSize, string> ImageSizeMap = new Dictionary<ImageSize, string>
		{
			{ ImageSize.Small, "256x256" },
			{ ImageSize.Medium, "512x512" },
			{ ImageSize.Large, "1024x1024" }
		};
	}

	public enum ImageSize
	{
		Small,
		Medium,
		Large
	}
}
