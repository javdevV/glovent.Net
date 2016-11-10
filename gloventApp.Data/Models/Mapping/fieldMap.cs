using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class fieldMap : EntityTypeConfiguration<field>
    {
        public fieldMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.label)
                .HasMaxLength(255);

            this.Property(t => t.type)
                .HasMaxLength(255);

            this.Property(t => t.category)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("field");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.label).HasColumnName("label");
            this.Property(t => t.type).HasColumnName("type");
            this.Property(t => t.MyRF_id).HasColumnName("MyRF_id");
            this.Property(t => t.category).HasColumnName("category");

            // Relationships
            this.HasOptional(t => t.registrationform)
                .WithMany(t => t.fields)
                .HasForeignKey(d => d.MyRF_id);

        }
    }
}
