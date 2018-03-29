#region Using
using Orchard;
using Orchard.Caching;
using Orchard.ContentManagement;
using Yaplex.SEO.Models;
#endregion

namespace Yaplex.SEO.Services {
    public class RobotCacheService : IRobotCacheService {
        private readonly ICacheManager _cacheManager;
        private readonly IOrchardServices _orchardServices;
        private readonly ISignals _signals;

        public RobotCacheService(ICacheManager cacheManager, IOrchardServices orchardServices, ISignals signals) {
            _cacheManager = cacheManager;
            _orchardServices = orchardServices;
            _signals = signals;
        }

        #region IRobotCacheService Members
        public string GetRobotsTxt() {
            return _cacheManager.Get(Constants.CacheKey,
                context => {
                    context.Monitor(_signals.When(Constants.CacheChanged));
                    return _orchardServices.WorkContext.CurrentSite.As<RobotsSettingsPart>()
                        .RobotsTxt;
                });
        }
        #endregion
    }
}
