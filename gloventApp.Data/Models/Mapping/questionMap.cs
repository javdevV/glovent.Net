using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class questionMap : EntityTypeConfiguration<question>
    {
        public questionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.statement)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("question");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.statement).HasColumnName("statement");
            this.Property(t => t.survey_id).HasColumnName("survey_id");

            // Relationships
            this.HasOptional(t => t.survey)
                .WithMany(t => t.questions)
                .HasForeignKey(d => d.survey_id);

        }
    }
}
