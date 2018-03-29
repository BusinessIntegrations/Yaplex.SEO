#region Using
using System.Collections.Generic;
using System.Linq;
using Orchard;
using Orchard.Settings;
using Orchard.UI.PageTitle;
#endregion

namespace Yaplex.SEO.Services {
    public class SeoPageTitleBuilder : IPageTitleBuilder {
        private readonly IOrchardServices _orchardServices;
        private readonly ISiteService _siteService;
        private readonly List<string> _titleParts;
        private string _titleSeparator;

        public SeoPageTitleBuilder(ISiteService siteService, IOrchardServices orchardServices) {
            _siteService = siteService;
            _orchardServices = orchardServices;
            _titleParts = new List<string>(5);
        }

        #region IPageTitleBuilder Members
        public void AddTitleParts(params string[] titleParts) {
            if (!string.IsNullOrWhiteSpace(Title)) {
                _titleParts.Add(Title);
                var siteName = _orchardServices.WorkContext.CurrentSite.SiteName;
                if (!string.IsNullOrWhiteSpace(siteName)) {
                    _titleParts.Add(siteName);
                }
            }
            else {
                if (titleParts.Length > 0) {
                    foreach (var titlePart in titleParts) {
                        if (!string.IsNullOrEmpty(titlePart)) {
                            _titleParts.Add(titlePart);
                        }
                    }
                }
            }
        }

        public void AppendTitleParts(params string[] titleParts) {
            if (titleParts.Length > 0) {
                foreach (var titlePart in titleParts) {
                    if (!string.IsNullOrEmpty(titlePart)) {
                        _titleParts.Insert(0, titlePart);
                    }
                }
            }
        }

        public string GenerateTitle() {
            if (_titleSeparator == null) {
                _titleSeparator = _siteService.GetSiteSettings()
                    .PageTitleSeparator;
            }
            return _titleParts.Count == 0
                ? string.Empty
                : string.Join(_titleSeparator,
                    _titleParts.AsEnumerable()
                        .ToArray());
        }
        #endregion

        #region Properties
        protected string Title { get; set; }
        #endregion

        #region Methods
        public void SetTitle(string title) {
            Title = title;
        }
        #endregion
    }
}
