#region Using
using Orchard.ContentManagement;
using Orchard.ContentManagement.Utilities;
#endregion

namespace Yaplex.SEO.Models {
    public class RobotsSettingsPart : ContentPart {
        public RobotsSettingsPart() {
            DefaultRobotsContent = new LazyField<string>();
        }

        #region Properties
        public LazyField<string> DefaultRobotsContent { get; }

        public string RobotsTxt
        {
            get { return this.Retrieve(x => x.RobotsTxt, DefaultRobotsContent.Value); }
            set { this.Store(x => x.RobotsTxt, value); }
        }
        #endregion
    }
}
