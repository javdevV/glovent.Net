using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class forumMap : EntityTypeConfiguration<forum>
    {
        public forumMap()
        {
            // Primary Key
            this.HasKey(t => t.name);

            // Properties
            this.Property(t => t.name)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("forum", "glovent");
            this.Property(t => t.name).HasColumnName("name");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.threads).HasColumnName("threads");
            this.Property(t => t.initiator_idUser).HasColumnName("initiator_idUser");

            // Relationships
            this.HasOptional(t => t.user);

        }
    }
}
