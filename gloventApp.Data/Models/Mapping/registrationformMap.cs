using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class registrationformMap : EntityTypeConfiguration<registrationform>
    {
        public registrationformMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("registrationform");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.title).HasColumnName("title");
        }
    }
}
