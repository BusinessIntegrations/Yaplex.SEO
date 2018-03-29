#region Using
using System;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Environment.Extensions;
using Orchard.UI.PageTitle;
using Orchard.UI.Resources;
using Yaplex.SEO.Models;
using Yaplex.SEO.Services;
#endregion

namespace Yaplex.SEO.Drivers {
    [OrchardFeature("Yaplex.SEO")]
    public class SeoOverrideDriver : ContentPartDriver<SeoOverride> {
        private readonly SeoPageTitleBuilder _pageTitleBuilder;
        private readonly IResourceManager _resourceManager;

        public SeoOverrideDriver(IResourceManager resourceManager, IPageTitleBuilder pageTitleBuilder) {
            _resourceManager = resourceManager;
            _pageTitleBuilder = pageTitleBuilder as SeoPageTitleBuilder;
        }

        #region Properties
        protected override string Prefix => "seopart";
        #endregion

        #region Methods
        protected override DriverResult Display(SeoOverride seoOverride, string displayType, dynamic shapeHelper) {
            // Do not amend meta-data if item is being rendered in a list, for example.
            if (displayType.Equals("Detail", StringComparison.OrdinalIgnoreCase)) {
                if (!string.IsNullOrWhiteSpace(seoOverride.PageTitle)) {
                    _pageTitleBuilder?.SetTitle(seoOverride.PageTitle);
                }
                if (!string.IsNullOrWhiteSpace(seoOverride.MetaKeywords)) {
                    _resourceManager.SetMeta(new MetaEntry {
                        Name = "keywords",
                        Content = seoOverride.MetaKeywords
                    });
                }
                if (!string.IsNullOrWhiteSpace(seoOverride.MetaDescription)) {
                    _resourceManager.SetMeta(new MetaEntry {
                        Name = "description",
                        Content = seoOverride.MetaDescription
                    });
                }
            }
            return null;
        }

        protected override DriverResult Editor(SeoOverride @override, dynamic shapeHelper) {
            return ContentShape("Parts_Meta_Edit",
                () => shapeHelper.EditorTemplate(TemplateName: "Parts/YaplexSeoPart", Model: @override, Prefix: Prefix));
        }

        protected override DriverResult Editor(SeoOverride @override, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(@override, Prefix, null, null);
            return Editor(@override, shapeHelper);
        }

        protected override void Exporting(SeoOverride part, ExportContentContext context) {
            context.Element(part.PartDefinition.Name)
                .SetAttributeValue("MetaDescription", part.MetaDescription);
            context.Element(part.PartDefinition.Name)
                .SetAttributeValue("MetaKeywords", part.MetaKeywords);
            context.Element(part.PartDefinition.Name)
                .SetAttributeValue("PageTitle", part.PageTitle);
        }

        protected override void Importing(SeoOverride part, ImportContentContext context) {
            var partDefinitionName = part.PartDefinition.Name;
            if (context.Data.Element(partDefinitionName) == null) {
                return;
            }
            part.MetaKeywords = context.Attribute(part.PartDefinition.Name, "MetaKeywords");
            part.MetaDescription = context.Attribute(part.PartDefinition.Name, "MetaDescription");
            part.PageTitle = context.Attribute(part.PartDefinition.Name, "PageTitle");
        }
        #endregion
    }
}
