#region Using
using System.Web.Mvc;
using Orchard.Environment.Extensions;
using Yaplex.SEO.ActionResults;
using Yaplex.SEO.Services;
#endregion

namespace Yaplex.SEO.Controllers {
    [OrchardFeature("Yaplex.SEO.Robots")]
    public class RobotsTxtController : Controller {
        private readonly IRobotCacheService _cacheService;

        public RobotsTxtController(IRobotCacheService cacheService) {
            _cacheService = cacheService;
        }

        #region Methods
        // GET: RobotsTxt
        public ActionResult Index() {
            return new RobotsResult(_cacheService.GetRobotsTxt());
        }
        #endregion
    }
}
