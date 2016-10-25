using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.Environment.Extensions;
using Orchard.UI.PageTitle;
using Orchard.UI.Resources;
using Yaplex.SEO.Models;
using Yaplex.SEO.Services;

namespace Yaplex.SEO.Drivers {
    [OrchardFeature("Yaplex.SEO")]
    public class SeoOverrideDriver : ContentPartDriver<SeoOverride> {
        private readonly IResourceManager _resourceManager;
        private readonly IPageTitleBuilder _pageTitleBuilder;

        public SeoOverrideDriver(IResourceManager resourceManager, IPageTitleBuilder pageTitleBuilder)
        {
            _resourceManager = resourceManager;
            _pageTitleBuilder = pageTitleBuilder;
        }

        protected override string Prefix
        {
            get
            {
                return "seopart";
            }
        }
        protected override DriverResult Display(SeoOverride @override, string displayType, dynamic shapeHelper) {
            if (!string.IsNullOrWhiteSpace(@override.PageTitle))
            {
                SeoPageTitleBuilder pageTitleBuilder = this._pageTitleBuilder as SeoPageTitleBuilder;
                if (pageTitleBuilder != null)
                {
                    string pageTitle = @override.PageTitle;
                    pageTitleBuilder.SetTitle(pageTitle);
                }
            }
            if (!string.IsNullOrWhiteSpace(@override.MetaKeywords)) {
                _resourceManager.SetMeta(new MetaEntry {
                    Name = "keywords",
                    Content = @override.MetaKeywords
                });
            }
            if (!string.IsNullOrWhiteSpace(@override.MetaDescription)) {
                _resourceManager.SetMeta(new MetaEntry {
                    Name = "description",
                    Content = @override.MetaDescription
                });
            }

            return null;
        }

        protected override DriverResult Editor(SeoOverride @override, dynamic shapeHelper) {
            return ContentShape("Parts_Meta_Edit", () => 
            shapeHelper.EditorTemplate(
                TemplateName: "Parts/YaplexSeoPart",
                Model: @override,
                Prefix: Prefix));
        }

        protected override DriverResult Editor(SeoOverride @override, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(@override, Prefix, null, null);
            return Editor(@override, updater, shapeHelper);
        }
    }
}