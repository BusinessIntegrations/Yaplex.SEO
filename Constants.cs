#region Using
using Yaplex.SEO.Controllers;
#endregion

namespace Yaplex.SEO {
    public static class Constants {
        public const string AdminControllerName = "Admin";
        public const string AdminMenuName = "BI Robots.txt";
        public const string AreaName = "Yaplex.SEO";
        public const string BiMenuSection = "bi-menu-section";
        public const string CacheKey = "Yaplex.SEO.Services.RobotCacheService";
        public const string CacheTrigger = "Yaplex.SEO.Services.RobotCacheServiceChanged";
        public const string CannotManageText = "Can't manage Yaplex Robots.txt Settings";
        public const string DomainMarker = "{DOMAIN}";
        public const string IndexActionName = nameof(AdminController.Index);
        public const string SiteContentTypeName = "Site";
        public const string ValidationErrorText = "Validation error";
    }
}
