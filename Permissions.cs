#region Using
using System.Collections.Generic;
using Orchard.Environment.Extensions.Models;
using Orchard.Security.Permissions;
#endregion

namespace Yaplex.SEO {
    public class Permissions : IPermissionProvider {
        public static readonly Permission ManageRobots = new Permission {
            Description = "Manage robots.txt",
            Name = nameof(ManageRobots)
        };

        private static readonly Permission[] permissions = {ManageRobots};

        #region IPermissionProvider Members
        public IEnumerable<PermissionStereotype> GetDefaultStereotypes() {
            return new[] {
                new PermissionStereotype {
                    Name = "Administrator",
                    Permissions = permissions
                }
            };
        }

        public IEnumerable<Permission> GetPermissions() {
            return permissions;
        }

        public virtual Feature Feature { get; set; }
        #endregion
    }
}
