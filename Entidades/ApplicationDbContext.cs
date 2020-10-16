using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Entidades;

namespace Convidarte.Entidades
{
    public class ApplicationDbContext : IdentityDbContext
        <ApplicationUser, // TUser
            ApplicationRole, // TRole
            string, // TKey
            IdentityUserClaim<string>, // TUserClaim
            ApplicationUserRole, // TUserRole,
            IdentityUserLogin<string>, // TUserLogin
            IdentityRoleClaim<string>, // TRoleClaim
            IdentityUserToken<string> // TUserToken
        >
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artista> Artistas { get; set; }

        //public DbSet<Votacion> Votacion { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Custom Identity Tables
            modelBuilder.Entity<ApplicationUser>().ToTable("Usuarios");
            modelBuilder.Entity<ApplicationRole>().ToTable("Roles");
            modelBuilder.Entity<ApplicationUserRole>().ToTable("RolUsuarios");
        }
    }
}
