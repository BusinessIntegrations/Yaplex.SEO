#region Using
using System.Web.Mvc;
using Orchard;
using Orchard.Environment.Extensions;
using Orchard.Localization;
using Orchard.Themes;
using Orchard.UI.Admin;
using Orchard.UI.Notify;
using Yaplex.SEO.Models;
using Yaplex.SEO.Services;
using Yaplex.SEO.ViewModels;
#endregion

namespace Yaplex.SEO.Controllers {
    [Themed]
    [Admin]
    [OrchardFeature("Yaplex.SEO.Robots")]
    public class AdminController : Controller {
        private readonly ICacheService _cacheService;
        private readonly IOrchardServices _orchardServices;

        public AdminController(IOrchardServices orchardServices, ICacheService cacheService) {
            _orchardServices = orchardServices;
            _cacheService = cacheService;
            T = NullLocalizer.Instance;
        }

        #region Properties
        public Localizer T { get; set; }
        #endregion

        #region Methods
        public ActionResult Index() {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageRobots, T(Constants.CannotManageText))) {
                return new HttpUnauthorizedResult();
            }

            var prettifySettingsViewModel = GetViewModel();
            return View(prettifySettingsViewModel);
        }

        [HttpPost]
        [ActionName("Index")]
        public ActionResult IndexPost(RobotsViewModel model) {
            if (!_orchardServices.Authorizer.Authorize(Permissions.ManageRobots, T(Constants.CannotManageText))) {
                return new HttpUnauthorizedResult();
            }

            if (ModelState.IsValid) {
                if (TryUpdateModel(model)) {
                    UpdatePart(model);
                    _orchardServices.Notifier.Information(T("Yaplex Robots.txt settings saved successfully."));
                }
                else {
                    _orchardServices.Notifier.Information(T("Could not save Yaplex Robots.txt settings."));
                }
            }
            else {
                _orchardServices.Notifier.Error(T(Constants.ValidationErrorText));
                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        private RobotsViewModel GetViewModel() {
            var settingsPart = _cacheService.GetSettings();
            return new RobotsViewModel {
                RobotsTxt = settingsPart.RobotsTxt
            };
        }

        private void UpdatePart(IRobotsSettingsPart model) {
            _cacheService.UpdateSettings(model);
        }
        #endregion
    }
}
