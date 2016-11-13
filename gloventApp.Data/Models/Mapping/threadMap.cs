using System.ComponentModel.DataAnnotations;
using System.Data.Entity.ModelConfiguration;

namespace gloventApp.Data.Models.Mapping
{
    public class threadMap : EntityTypeConfiguration<thread>
    {
        public threadMap()
        {
            // Primary Key
            this.HasKey(t => t.threadId);

            // Properties
            this.Property(t => t.threadContent)
                .HasMaxLength(255);

            this.Property(t => t.title)
                .HasMaxLength(255);

            this.Property(t => t.ParentForum_name)
                .HasMaxLength(255);

            // Table & Column Mappings
            this.ToTable("thread", "glovent");
            this.Property(t => t.threadId).HasColumnName("threadId");
            this.Property(t => t.threadContent).HasColumnName("threadContent");
            this.Property(t => t.title).HasColumnName("title");
            this.Property(t => t.CommentingUser_idUser).HasColumnName("CommentingUser_idUser");
            this.Property(t => t.ParentForum_name).HasColumnName("ParentForum_name");

            // Relationships
            this.HasOptional(t => t.forum)
                .WithMany(t => t.threads1)
                .HasForeignKey(d => d.ParentForum_name);
            this.HasOptional(t => t.user);

        }
    }
}
