#region Using
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
#endregion

namespace Yaplex.SEO.Models {
    public class SeoOverride : ContentPart<SeoOverrideRecord> {
        #region Properties
        [MaxLength(500)]
        [Display(Name = "Meta Description")]
        public string MetaDescription { get { return Retrieve(x => x.MetaDescription); } set { Store(x => x.MetaDescription, value); } }

        [MaxLength(255)]
        [Display(Name = "Meta Keywords (add comma separated meta keywords)")]
        public string MetaKeywords { get { return Retrieve(x => x.MetaKeywords); } set { Store(x => x.MetaKeywords, value); } }

        [MaxLength(255)]
        [Display(Name = "Page Title (overrides <title> tag of the page, keep it empty if no override required)")]
        public string PageTitle { get { return Retrieve(x => x.PageTitle); } set { Store(x => x.PageTitle, value); } }
        #endregion
    }
}
