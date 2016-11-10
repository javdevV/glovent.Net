using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class choiceMap : EntityTypeConfiguration<choice>
    {
        public choiceMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.Description)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("choice");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.MyPoll_id).HasColumnName("MyPoll_id");

            // Relationships
            this.HasOptional(t => t.poll)
                .WithMany(t => t.choices)
                .HasForeignKey(d => d.MyPoll_id);

        }
    }
}
