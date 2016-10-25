using System.Data;
using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Yaplex.SEO {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            // Creating table SeoOverrideRecord
            SchemaBuilder.CreateTable("SeoOverrideRecord", table => table
                .ContentPartRecord()
                .Column("MetaKeywords", DbType.String)
                .Column("MetaDescription", DbType.String)
                .Column("PageTitle", DbType.String)
                );

            return 1;
        }

        public int UpdateFrom1() {
            ContentDefinitionManager.AlterPartDefinition(
                "SeoOverride", cfg => cfg.Attachable());

            return 2;
        }
        public int UpdateFrom2() {
            ContentDefinitionManager.AlterPartDefinition(
                "SeoOverride", cfg => cfg.Attachable().WithDescription("Adds additional fields to a content type to maintain better SEO results for a content type."));

            return 3;
        }

        public int UpdateFrom3() {
            SchemaBuilder.AlterTable("SeoOverrideRecord", table => {
                table.AlterColumn("MetaDescription", column => column.WithType(DbType.String).WithLength(500));
            });

            return 4;
        }

        public int UpdateFrom4() {
            ContentDefinitionManager.AlterTypeDefinition("Page", x=>x.WithPart("SeoOverride"));
            return 5;
        }
    }
}