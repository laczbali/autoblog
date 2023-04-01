using Blaczko.Core.Extensions;
using Microsoft.AspNetCore.Mvc;
using OpenAI.API;

namespace AutoBlog.Web.Controllers
{
#if DEBUG

	[ApiController]
	[Route("[controller]")]
	public class SandboxController : ControllerBase
	{
		private readonly ILogger<SandboxController> _logger;

		public SandboxController(
			ILogger<SandboxController> logger,
			OpenAiApiConfig config)
		{
			_logger = logger;
		}

		public IActionResult Index()
		{
			return this.Ok("ok");
		}
	}

#endif
}