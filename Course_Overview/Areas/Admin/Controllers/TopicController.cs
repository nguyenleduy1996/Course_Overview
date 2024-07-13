using Course_Overview.Areas.Admin.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Course_Overview.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TopicController : Controller
	{
		private readonly ITopicRepository _topicRepository;
		public TopicController(ITopicRepository topicRepository)
		{
			_topicRepository = topicRepository;
		}

		public async Task<IActionResult> Index()
		{
			var topic = await _topicRepository.GetAllTopic();
			return View(topic);
		}

		public IActionResult Create()
		{
			return View();
		}
	}
}
