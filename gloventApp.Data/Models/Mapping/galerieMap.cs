using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class galerieMap : EntityTypeConfiguration<galerie>
    {
        public galerieMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("galerie");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.event_idEvent).HasColumnName("event_idEvent");

            // Relationships
            this.HasOptional(t => t.evente)
                .WithMany(t => t.galeries)
                .HasForeignKey(d => d.event_idEvent);

        }
    }
}
