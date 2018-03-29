#region Using
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using Orchard.Environment.Extensions;
using Orchard.Mvc.Routes;
#endregion

namespace Yaplex.SEO {
    [OrchardFeature("Yaplex.SEO.Robots")]
    public class RobotsRoutes : IRouteProvider {
        #region IRouteProvider Members
        public IEnumerable<RouteDescriptor> GetRoutes() {
            return new[] {
                new RouteDescriptor {
                    Priority = 10,
                    Route = new Route("robots.txt", // this is the name of the page url
                        new RouteValueDictionary {
                            {"area", "Yaplex.SEO"}, // this is the name of your module
                            {"controller", "RobotsTxt"},
                            {"action", "Index"}
                        },
                        new RouteValueDictionary(),
                        new RouteValueDictionary {
                            {"area", "Yaplex.SEO"} // this is the name of your module
                        },
                        new MvcRouteHandler())
                }
            };
        }

        public void GetRoutes(ICollection<RouteDescriptor> routes) {
            foreach (var routeDescriptor in GetRoutes()) {
                routes.Add(routeDescriptor);
            }
        }
        #endregion
    }
}
