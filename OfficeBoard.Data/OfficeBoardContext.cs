namespace OfficeBoard.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;
    using System.Data.Entity;

    public class OfficeBoardContext : IdentityDbContext<User>
    {
        public OfficeBoardContext()
            : base("name=OfficeBoard")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<OfficeBoardContext, Configuration>());
        }

        public virtual DbSet<Note> Notes { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }

        public static OfficeBoardContext Create()
        {
            return new OfficeBoardContext();
        }
    }
}