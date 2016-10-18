using Orchard;
using Orchard.UI.Navigation;

namespace Yaplex.SEO.Menus
{
    public class RobotsAdminMenu : Component, INavigationProvider, IDependency
    {
        public string MenuName
        {
            get { return "admin"; }
        }

        public void GetNavigation(NavigationBuilder builder)
        {
            builder.AddImageSet("seo").Add(T("Yaplex SEO"), "4.0", seo =>
            {
                var firstChild = seo.LinkToFirstChild(false);
                var localizedString = T("Robots.txt");
                firstChild.Add(localizedString, "2.0", sitemap => sitemap.Action("Index", "RobotsAdmin", new
                {
                    area = "Yaplex.SEO"
                }));
            });
        }
    }
}