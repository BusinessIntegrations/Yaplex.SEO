using System.Web.Mvc;
using Orchard;
using Orchard.Environment.Extensions;
using Yaplex.SEO.ActionResults;

namespace Yaplex.SEO.Controllers
{
    [OrchardFeature("Yaplex.SEO.Robots")]
    public class RobotsTxtController : Controller
    {
        private readonly IOrchardServices _orchardServices;

        public RobotsTxtController(IOrchardServices orchardServices)
        {
            _orchardServices = orchardServices;
        }

        // GET: RobotsTxt
        public ActionResult Index()
        {
            return new RobotsResult(_orchardServices);
        }
    }
}