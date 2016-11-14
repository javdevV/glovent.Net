using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class videoMap : EntityTypeConfiguration<video>
    {
        public videoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.name)
                .HasMaxLength(255);

            this.Property(t => t.url)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("video");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.aime).HasColumnName("aime");
            this.Property(t => t.danger).HasColumnName("danger");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.url).HasColumnName("url");
            this.Property(t => t.MyPatricipant_idUser).HasColumnName("MyPatricipant_idUser");
            this.Property(t => t.galerie_id).HasColumnName("galerie_id");

            // Relationships
            this.HasOptional(t => t.galerie)
                .WithMany(t => t.videos)
                .HasForeignKey(d => d.galerie_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.videos)
                .HasForeignKey(d => d.MyPatricipant_idUser);

        }
    }
}
