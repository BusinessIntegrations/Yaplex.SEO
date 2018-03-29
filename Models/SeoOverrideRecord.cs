#region Using
using Orchard.ContentManagement.Records;
#endregion

namespace Yaplex.SEO.Models {
    public class SeoOverrideRecord : ContentPartRecord {
        #region Properties
        public virtual string MetaDescription { get; set; }
        public virtual string MetaKeywords { get; set; }
        public virtual string PageTitle { get; set; }
        #endregion
    }
}
