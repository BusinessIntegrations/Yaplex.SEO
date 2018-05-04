#region Using
using Orchard;
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using Yaplex.SEO.Models;
#endregion

namespace Yaplex.SEO.Services {
    [OrchardFeature("Yaplex.SEO.Robots")]
    public class CacheService : ICacheService {
        private readonly ICacheManager _cacheManager;
        private readonly IOrchardServices _orchardServices;
        private readonly ISignals _signals;

        public CacheService(ICacheManager cacheManager, IOrchardServices orchardServices, ISignals signals) {
            _cacheManager = cacheManager;
            _orchardServices = orchardServices;
            _signals = signals;
        }

        #region ICacheService Members
        public ICacheModel GetData() {
            return _cacheManager.Get(Constants.CacheKey,
                context => {
                    context.Monitor(_signals.When(Constants.CacheTrigger));
                    var settingsPart = GetSettingsPart();
                    return new CacheModel(Substitute(settingsPart.RobotsTxt));
                });
        }

        public IRobotsSettingsPart GetSettings() {
            return GetSettingsPart();
        }

        public void ReleaseCache() {
            _signals.Trigger(Constants.CacheTrigger);
        }

        public void UpdateSettings(IRobotsSettingsPart settings) {
            var part = GetSettingsPart();
            part.RobotsTxt = settings.RobotsTxt;
            ReleaseCache();
        }
        #endregion

        #region Methods
        private RobotsSettingsPart GetSettingsPart() {
            return _orchardServices.WorkContext.CurrentSite.As<RobotsSettingsPart>();
        }

        private string Substitute(string robotsTxt) {
            return robotsTxt.Replace(Constants.DomainMarker, _orchardServices.WorkContext.CurrentSite.BaseUrl);
        }
        #endregion
    }
}
