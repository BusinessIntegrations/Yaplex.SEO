#region Using
using Orchard;
using Yaplex.SEO.Models;
#endregion

namespace Yaplex.SEO.Services {
    public interface ICacheService : IDependency {
        #region Methods
        ICacheModel GetData();
        IRobotsSettingsPart GetSettings();
        void ReleaseCache();
        void UpdateSettings(IRobotsSettingsPart settings);
        #endregion
    }
}
