using Orchard.ContentManagement;
using Orchard.ContentManagement.Utilities;

namespace Yaplex.SEO.Models
{
    public class RobotsSettingsPart : ContentPart
    {
        internal readonly LazyField<string> DefaultRobotsContent = new LazyField<string>();

        public string RobotsTxt
        {
            get { return this.Retrieve(x => x.RobotsTxt, DefaultRobotsContent.Value); }
            set { this.Store(x => x.RobotsTxt, value); }
        }
    }
}