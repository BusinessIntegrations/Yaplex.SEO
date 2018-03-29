#region Using
using System.Data;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Yaplex.SEO.Models;
#endregion

namespace Yaplex.SEO {
    public class Migrations : DataMigrationImpl {
        private const string SeoOverride = "SeoOverride";

        #region Methods
        public int Create() {
            // Creating table SeoOverrideRecord
            SchemaBuilder.CreateTable(nameof(SeoOverrideRecord),
                table => table.ContentPartRecord()
                    .Column(nameof(SeoOverrideRecord.MetaKeywords), DbType.String)
                    .Column(nameof(SeoOverrideRecord.MetaDescription), DbType.String)
                    .Column(nameof(SeoOverrideRecord.PageTitle), DbType.String));
            return 1;
        }

        public int UpdateFrom1() {
            ContentDefinitionManager.AlterPartDefinition(SeoOverride, cfg => cfg.Attachable());
            return 2;
        }

        public int UpdateFrom2() {
            ContentDefinitionManager.AlterPartDefinition(SeoOverride,
                cfg => cfg.Attachable()
                    .WithDescription("Adds additional fields to a content type to maintain better SEO results for a content type."));
            return 3;
        }

        public int UpdateFrom3() {
            SchemaBuilder.AlterTable(nameof(SeoOverrideRecord),
                table => {
                    table.AlterColumn(nameof(SeoOverrideRecord.MetaDescription),
                        column => column.WithType(DbType.String)
                            .WithLength(500));
                });
            return 4;
        }

        public int UpdateFrom4() {
            ContentDefinitionManager.AlterTypeDefinition("Page", x => x.WithPart("SeoOverride"));
            return 5;
        }
        #endregion
    }
}
