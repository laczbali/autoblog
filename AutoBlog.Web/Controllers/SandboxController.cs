using Blaczko.Core.Extensions;
using Blaczko.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using OpenAI.API;
using OpenAI.API.Models;

namespace AutoBlog.Web.Controllers
{
#if DEBUG

	[ApiController]
	[Route("[controller]")]
	public class SandboxController : ControllerBase
	{
		private readonly ILogger<SandboxController> _logger;
		private readonly IOpenAiApi openAi;

		public SandboxController(
			ILogger<SandboxController> logger,
			IOpenAiApi openAi)
		{
			_logger = logger;
			this.openAi = openAi;
		}

		public async Task<IActionResult> IndexAsync()
		{
			var chatContext = new List<Message>
			{
				new Message
				{
					Content = "You are General Grievous, talking to General Kenobi",
					Role = Role.system
				},

				new Message
				{
					Content = "Hello There!",
					Role = Role.user
				}
			};
			var chatResponse = await this.openAi.Chat(chatContext, 1.2f);

			var imageResponse = await this.openAi.CreateImage("General Kenobi (the Jedi) and General Grievous (the four armed robot) talking", ImageSize.Small);

			return this.Content($"<div>{chatResponse}<div/><img src=\"{imageResponse}\"/>", "text/html");
		}
	}

#endif
}