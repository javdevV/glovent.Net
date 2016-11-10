using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class surveyMap : EntityTypeConfiguration<survey>
    {
        public surveyMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.description)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("survey");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.description).HasColumnName("description");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.MyEvent_idEvent).HasColumnName("MyEvent_idEvent");

            // Relationships
            this.HasOptional(t => t.evente)
                .WithMany(t => t.surveys)
                .HasForeignKey(d => d.MyEvent_idEvent);

        }
    }
}
