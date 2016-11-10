using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class categoryMap : EntityTypeConfiguration<category>
    {
        public categoryMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Libelle)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("category");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Libelle).HasColumnName("Libelle");
        }
    }
}
