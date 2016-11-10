using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class answerMap : EntityTypeConfiguration<answer>
    {
        public answerMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id_question, t.id_user });

            // Properties
            this.Property(t => t.id_question)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.id_user)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.reply)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("answer");
            this.Property(t => t.id_question).HasColumnName("id_question");
            this.Property(t => t.id_user).HasColumnName("id_user");
            this.Property(t => t.reply).HasColumnName("reply");

            // Relationships
            this.HasRequired(t => t.user)
                .WithMany(t => t.answers)
                .HasForeignKey(d => d.id_user);
            this.HasRequired(t => t.question)
                .WithMany(t => t.answers)
                .HasForeignKey(d => d.id_question);

        }
    }
}
