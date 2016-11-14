using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class imageMap : EntityTypeConfiguration<image>
    {
        public imageMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("image");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.aime).HasColumnName("aime");
            this.Property(t => t.danger).HasColumnName("danger");
            this.Property(t => t.image1).HasColumnName("image");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.MyPatricipant_idUser).HasColumnName("MyPatricipant_idUser");
            this.Property(t => t.galerie_id).HasColumnName("galerie_id");

            // Relationships
            this.HasOptional(t => t.galerie)
                .WithMany(t => t.images)
                .HasForeignKey(d => d.galerie_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.images)
                .HasForeignKey(d => d.MyPatricipant_idUser);

        }
    }
}
