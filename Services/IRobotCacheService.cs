#region Using
using Orchard;
#endregion

namespace Yaplex.SEO.Services {
    public interface IRobotCacheService : IDependency {
        #region Methods
        string GetRobotsTxt();
        #endregion
    }
}
