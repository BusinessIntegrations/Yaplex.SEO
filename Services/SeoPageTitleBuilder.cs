using System;
using System.Collections.Generic;
using System.Linq;
using Orchard;
using Orchard.Settings;
using Orchard.UI.PageTitle;

namespace Yaplex.SEO.Services
{
    public class SeoPageTitleBuilder : IPageTitleBuilder
    {
        private readonly ISiteService _siteService;
        private readonly IOrchardServices _orchardServices;
        private readonly List<string> _titleParts;
        private string _titleSeparator;

        public SeoPageTitleBuilder(ISiteService siteService, IOrchardServices orchardServices)
        {
            _siteService = siteService;
            _orchardServices = orchardServices;
            _titleParts = new List<string>(5);
        }

        protected string Title { get; set; }

        public void AddTitleParts(params string[] titleParts)
        {
            if (!string.IsNullOrWhiteSpace(Title))
            {
                _titleParts.Add(Title);

                string siteName = _orchardServices.WorkContext.CurrentSite.SiteName;
                if (!string.IsNullOrWhiteSpace(siteName))
                    _titleParts.Add(siteName);
            }
            else
            {
                if (titleParts.Length > 0)
                    foreach (string titlePart in titleParts)
                        if (!string.IsNullOrEmpty(titlePart))
                            _titleParts.Add(titlePart);
            }
        }

        public void AppendTitleParts(params string[] titleParts)
        {
            if (titleParts.Length > 0)
                foreach (var titlePart in titleParts)
                    if (!string.IsNullOrEmpty(titlePart))
                        _titleParts.Insert(0, titlePart);
        }

        public string GenerateTitle()
        {
            if (_titleSeparator == null)
                _titleSeparator = _siteService.GetSiteSettings().PageTitleSeparator;

            return _titleParts.Count == 0
                ? string.Empty
                : string.Join(_titleSeparator, _titleParts.AsEnumerable().ToArray());
        }

        public void SetTitle(string title)
        {
            Title = title;
        }
    }
}