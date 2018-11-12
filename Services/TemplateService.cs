using System.Collections.Generic;
using Sky.SelfServe.Models;
using Sky.SelfServe.Repositories;

namespace Sky.SelfServe.Services
{
	public class TemplateService
	{
		private readonly TemplateRepository _templateRepository;

		public TemplateService(TemplateRepository templateRepository)
		{
			_templateRepository = templateRepository;
		}

		public List<Partner> GetTemplate()
		{
			return _templateRepository.GetTemplate();
		}
	}
}