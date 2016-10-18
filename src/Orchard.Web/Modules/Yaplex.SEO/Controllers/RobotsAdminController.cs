using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.UI.Admin;
using Orchard.UI.Notify;
using Yaplex.SEO.Models;
using Yaplex.SEO.ViewModels;

namespace Yaplex.SEO.Controllers
{
    [OrchardFeature("Yaplex.SEO.Robots")]
    [Admin]
    public class RobotsAdminController : Controller
    {
        private readonly IOrchardServices _orchardServices;

        public RobotsAdminController(IOrchardServices orchardServices)
        {
            _orchardServices = orchardServices;
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        public ActionResult Index()
        {
            var robotsSettingsPart = _orchardServices.WorkContext.CurrentSite.As<RobotsSettingsPart>();
            return View(new RobotsViewModel
            {
                RobotsTxt = robotsSettingsPart.RobotsTxt
            });
        }

        [HttpPost]
        public ActionResult Index(RobotsViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);
            _orchardServices.WorkContext.CurrentSite.As<RobotsSettingsPart>().RobotsTxt = viewModel.RobotsTxt;
            _orchardServices.Notifier.Information(T("Your Robots information has been saved."));
            return RedirectToAction("Index");
        }
    }
}