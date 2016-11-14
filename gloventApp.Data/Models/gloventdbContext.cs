using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using gloventApp.Data.Models.Mapping;


namespace gloventApp.Data.Models
{
    public partial class gloventdbContext : DbContext
    {
        static gloventdbContext()
        {
            Database.SetInitializer<gloventdbContext>(null);
        }

        public gloventdbContext()
            : base("Name=gloventdbContext")
        {
        }

        public DbSet<answer> answer { get; set; }
        
        public DbSet<category> category { get; set; }
        public DbSet<choice> choice { get; set; }
        public DbSet<complaint> complaint { get; set; }
        public DbSet<evente> events { get; set; }
        public DbSet<field> field { get; set; }
        public DbSet<forum> forum { get; set; }
        public DbSet<galerie> galerie { get; set; }
        public DbSet<image> image { get; set; }
        public DbSet<likeimage> likeimage { get; set; }
        public DbSet<likevideo> likevideo { get; set; }
        public DbSet<organization> organization { get; set; }
        public DbSet<poll> poll { get; set; }
        public DbSet<question> question { get; set; }
        public DbSet<registrationform> registrationform { get; set; }
        public DbSet<survey> survey { get; set; }
        public DbSet<task> task { get; set; }
        public DbSet<thread> thread { get; set; }
        public DbSet<ticket> ticket { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<video> video { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new answerMap());
            modelBuilder.Configurations.Add(new categoryMap());
            modelBuilder.Configurations.Add(new choiceMap());
            modelBuilder.Configurations.Add(new complaintMap());
            modelBuilder.Configurations.Add(new eventMap());
            modelBuilder.Configurations.Add(new fieldMap());
            modelBuilder.Configurations.Add(new forumMap());
            modelBuilder.Configurations.Add(new galerieMap());
            modelBuilder.Configurations.Add(new imageMap());
            modelBuilder.Configurations.Add(new likeimageMap());
            modelBuilder.Configurations.Add(new likevideoMap());
            modelBuilder.Configurations.Add(new organizationMap());
            modelBuilder.Configurations.Add(new pollMap());
            modelBuilder.Configurations.Add(new questionMap());
            modelBuilder.Configurations.Add(new registrationformMap());
            modelBuilder.Configurations.Add(new surveyMap());
            modelBuilder.Configurations.Add(new taskMap());
            modelBuilder.Configurations.Add(new threadMap());
            modelBuilder.Configurations.Add(new ticketMap());
            modelBuilder.Configurations.Add(new userMap());
            modelBuilder.Configurations.Add(new videoMap());
        }
    }
}
