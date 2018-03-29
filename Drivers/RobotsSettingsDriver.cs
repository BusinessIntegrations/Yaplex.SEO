#region Using
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Yaplex.SEO.Models;
using Yaplex.SEO.ViewModels;
#endregion

namespace Yaplex.SEO.Drivers {
    [OrchardFeature("Yaplex.SEO.Robots")]
    public class RobotsSettingsDriver : ContentPartDriver<RobotsSettingsPart> {
        private readonly ISignals _signals;

        public RobotsSettingsDriver(ISignals signals) {
            _signals = signals;
        }

        #region Methods
        protected override DriverResult Editor(RobotsSettingsPart part, dynamic shapeHelper) {
            return ContentShape("Parts_RobotSettings",
                    () => shapeHelper.EditorTemplate(TemplateName: "Parts/RobotSettings",
                        Model: new RobotsViewModel {
                            RobotsTxt = part.RobotsTxt
                        },
                        Prefix: Prefix))
                .OnGroup(Constants.AdminMenuName);
        }

        protected override DriverResult Editor(RobotsSettingsPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            _signals.Trigger(Constants.CacheChanged);
            return Editor(part, shapeHelper);
        }
        #endregion
    }
}
