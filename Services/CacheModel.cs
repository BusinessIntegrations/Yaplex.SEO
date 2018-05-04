#region Using
#endregion

namespace Yaplex.SEO.Services {
    public class CacheModel : ICacheModel {
        public CacheModel(string robotsTxt) {
            RobotsTxt = robotsTxt;
        }

        #region ICacheModel Members
        public string RobotsTxt { get; }
        #endregion
    }
}
