using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class likeimageMap : EntityTypeConfiguration<likeimage>
    {
        public likeimageMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("likeimage");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.img_id).HasColumnName("img_id");
            this.Property(t => t.participant_idUser).HasColumnName("participant_idUser");

            // Relationships
            this.HasOptional(t => t.image)
                .WithMany(t => t.likeimages)
                .HasForeignKey(d => d.img_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.likeimages)
                .HasForeignKey(d => d.participant_idUser);

        }
    }
}
