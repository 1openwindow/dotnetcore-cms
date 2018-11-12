using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sky.SelfServe.Models;
using Sky.SelfServe.Services;
using Microsoft.Extensions.Logging;

namespace Sky.SelfServe.Controllers
{
	[Route("api/[controller]")]
	public class TemplateController : BaseController
	{

		private readonly TemplateService _templateService; 
		private readonly ILogger _logger;

		public TemplateController(TemplateService templateService,
			ILogger<TemplateController> logger)
		{
			_templateService = templateService;
			_logger = logger;
		}

		[HttpGet("[action]")]
		public JsonResult ListTemplateData()
		{
			// return Enumerable.Range(1,5).Select(index => new TemplateModel
			// {
			// 	Id = new Random().Next(0, 10000),
			// 	Url = "https://www.azure.cn/zh-cn/partnerancasestudy/partner/",
			// 	TileName = "Partner A",
			// 	TileImageUrl = "https://resource.cdn.azure.cn/marketing-resource/media/images/partner/itongze@2x.png",
			// 	TileLink = "http://www.itongze.com/",
			// 	TileDescription = "解决方案：公有云、私有云、混合云解决方案，云平台迁移、实施、运维",
			// 	CreateTime = DateTime.Now,
			// 	UpdateTime = DateTime.Now
			// });
			_logger.LogInformation("Listing all items");
			return Json(_templateService.GetTemplate());
		}

		[HttpPost("[action]")]
		public JsonResult CreateTemplate()
		{
			
			return Json("");
		}
	}
}