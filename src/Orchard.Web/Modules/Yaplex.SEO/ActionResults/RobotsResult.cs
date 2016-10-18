using System.Web.Mvc;
using Orchard;
using Orchard.ContentManagement;
using Yaplex.SEO.Models;

namespace Yaplex.SEO.ActionResults
{
    public class RobotsResult : ActionResult
    {
        private readonly IOrchardServices _orchardServices;

        public RobotsResult(IOrchardServices orchardServices)
        {
            _orchardServices = orchardServices;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var robotsTxt = _orchardServices.WorkContext.CurrentSite.As<RobotsSettingsPart>().RobotsTxt;
            context.HttpContext.Response.ContentType = "text/plain";
            context.HttpContext.Response.Output.Write(robotsTxt);
        }
    }
}