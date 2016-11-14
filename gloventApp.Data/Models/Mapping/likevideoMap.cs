using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class likevideoMap : EntityTypeConfiguration<likevideo>
    {
        public likevideoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("likevideo");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.userr_idUser).HasColumnName("userr_idUser");
            this.Property(t => t.vid_id).HasColumnName("vid_id");

            // Relationships
            this.HasOptional(t => t.video)
                .WithMany(t => t.likevideos)
                .HasForeignKey(d => d.vid_id);
            this.HasOptional(t => t.user)
                .WithMany(t => t.likevideos)
                .HasForeignKey(d => d.userr_idUser);

        }
    }
}
