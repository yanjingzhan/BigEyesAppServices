namespace BigEyesAppServices.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelContext")
        {
        }

        private static ModelContext _modelContext = null;

        public static ModelContext DatabaseContext
        {
            get
            {
                if (_modelContext == null)
                {
                    _modelContext = new ModelContext();
                    _modelContext.Database.Initialize(false);
                }

                return _modelContext;
            }
        }


        public virtual DbSet<Advertising> Advertising { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<VersionUpdate> VersionUpdate { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advertising>()
                .Property(e => e.SourceUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Advertising>()
                .Property(e => e.DirectUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PasswordSalt)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PhoneNum)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.RealName)
                .IsUnicode(false);

            modelBuilder.Entity<VersionUpdate>()
                .Property(e => e.Version)
                .IsUnicode(false);

            modelBuilder.Entity<VersionUpdate>()
                .Property(e => e.DownloadUrl)
                .IsUnicode(false);

            modelBuilder.Entity<VersionUpdate>()
                .Property(e => e.VersionUpdatecol)
                .IsUnicode(false);
        }
    }
}
