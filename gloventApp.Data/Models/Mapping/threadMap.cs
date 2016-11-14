using System.ComponentModel.DataAnnotations.Schema;
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

            // Table & Column Mappings
            this.ToTable("thread");
            this.Property(t => t.threadId).HasColumnName("threadId");
            this.Property(t => t.CommentingUser).HasColumnName("CommentingUser");
            this.Property(t => t.ParentForum).HasColumnName("ParentForum");
            this.Property(t => t.threadContent).HasColumnName("threadContent");
            this.Property(t => t.title).HasColumnName("title");
        }
    }
}
