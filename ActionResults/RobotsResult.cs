#region Using
using System.Web.Mvc;
#endregion

namespace Yaplex.SEO.ActionResults {
    public class RobotsResult : ActionResult {
        private readonly string _robotTxt;

        public RobotsResult(string robotTxt) {
            _robotTxt = robotTxt;
        }

        #region Methods
        public override void ExecuteResult(ControllerContext context) {
            var robotsTxt = _robotTxt;
            context.HttpContext.Response.ContentType = "text/plain";
            context.HttpContext.Response.Output.Write(robotsTxt);
        }
        #endregion
    }
}
