using Microsoft.AspNetCore.Mvc;
using Sky.SelfServe.Models;
using System;
using Microsoft.Azure.Sky.School.Common;
using Sky.SelfServe.Services;
using Microsoft.AspNetCore.Routing;
using System.Threading.Tasks;
using Sky.SelfServe.Pages;
using Sky.SelfServe.Common;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Sky.SelfServe.Controllers
{
	[Route("api/[controller]")]
	public class PublishController : Controller
	{
		private readonly StorageClient _storageClient;
		private readonly TemplateService _templateService;
		private readonly ViewRenderService  _viewRenderService;
		private readonly ILogger _logger;

		public PublishController(StorageClient storageClient,
				TemplateService templateService,
                ViewRenderService  viewRenderService,
				ILogger<PublishController> logger)
		{
			_storageClient = storageClient;
			_templateService = templateService;
			_viewRenderService = viewRenderService;
			_logger = logger;
		}

		[Route("render")]
		public async Task<IActionResult> RenderView()
		{
			var viewModel = new Partner
			{
				TileName = "hello world",
				TileImageUrl = "hello world",
				TileLink = "hello world",
				TileDescription = "hello world"
			};

			var result = await _viewRenderService.RenderToStringAsync("Partner", viewModel);

			return Content(result);
		}

		[HttpGet("[action]")]
		public async Task<JsonResult> Publish(PublishModel publishModel)
		{
			if (publishModel.Environment == "review")
			{

			}

			//1. read xml
			var template = GetDefaultTemplateByName(publishModel.TemplateName);
			var viewModel = new PartnerView
			{
				PartnerList = _templateService.GetTemplate()
			};

			var content = await _viewRenderService.RenderToStringAsync("Partner", viewModel);

			var result = template.Replace("<sky.template.b9fb8f26-8f08-4d73-8c84-2c7058b046d1.body/>", content);

			SaveToStorage("test", result);

			return Json(WebUtility.HtmlEncode(result));
		}

		private string GetDefaultTemplateByName(string templateName)
		{
			var test = "Content/default-template/parnter.default.template.xml";

			try
			{
				var result = _storageClient.GetContent(test).Result;
				return result;
				// return _storageClient.GetContent(test).Result;
			}
			catch (Exception e)
			{
				//throw new ArticleNotFoundException("not able to read article in blob");
				Console.WriteLine(e.Message.ToString());
			}

			return "";
		}

		private bool SaveToStorage(string blobName, string xmlString)
		{
			var test = "Content/partnerancasestudy/test.xml";
			//var test = "Content/default-template/parnter.output.template.xml";

			try
			{
				var result = _storageClient.UploadContent(test, xmlString);
				// return _storageClient.GetContent(test).Result;
			}
			catch (Exception e)
			{
				//throw new ArticleNotFoundException("not able to read article in blob");
				Console.WriteLine(e.Message.ToString());
			}

			return true;
		}
	}
}