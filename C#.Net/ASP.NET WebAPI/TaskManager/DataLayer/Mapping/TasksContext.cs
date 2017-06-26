namespace DataLayer.Mapping
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class TasksContext : DbContext
    {
        public TasksContext()
            : base("name=TasksContext")
        {
        }

        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Tasks> Tasks { get; set; }
        public virtual DbSet<TasksAndTag> TasksAndTags { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tag>()
                .HasMany(e => e.TasksAndTags)
                .WithRequired(e => e.Tag)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Pass)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tasks)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
