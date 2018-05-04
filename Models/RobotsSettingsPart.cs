#region Using
using Orchard.ContentManagement;
using Orchard.ContentManagement.Utilities;
using Orchard.Environment.Extensions;
#endregion

namespace Yaplex.SEO.Models {
    [OrchardFeature("Yaplex.SEO.Robots")]
    public class RobotsSettingsPart : ContentPart, IRobotsSettingsPart {
        public RobotsSettingsPart() {
            DefaultRobotsContent = new LazyField<string>();
        }

        #region IRobotsSettingsPart Members
        public string RobotsTxt
        {
            get { return this.Retrieve(x => x.RobotsTxt, DefaultRobotsContent.Value); }
            set { this.Store(x => x.RobotsTxt, value); }
        }
        #endregion

        #region Properties
        public LazyField<string> DefaultRobotsContent { get; }
        #endregion
    }
}
