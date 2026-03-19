using Microsoft.EntityFrameworkCore;
using CRUDASP.Models;

namespace CRUDASP.Data
{
    public class AppDBContext : DbContext
    {

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(tb =>
            {
                tb.HasKey(col => col.Cedula);
                tb.Property(col => col.Cedula).HasMaxLength(50);

                tb.Property(col => col.Nombre).HasMaxLength(50);
                tb.Property(col => col.Apellido).HasMaxLength(50);
                tb.Property(col => col.correo).HasMaxLength(50);
                tb.Property(col => col.password).HasMaxLength(50);
            });

            modelBuilder.Entity<Usuario>().ToTable("usuario");
        }

    }
}
