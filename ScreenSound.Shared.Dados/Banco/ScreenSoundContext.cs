using System;
using ScreenSound.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ScreenSound.Banco
{
    public class ScreenSoundContext : DbContext
    {
        private string ConnectionString { get ; set; }
        public DbSet<Artista> Artistas { get; set; } = null!;
        public DbSet<Musica> Musicas { get; set; } = null!;

        public ScreenSoundContext(string connectionString)
        {
            ConnectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(ConnectionString)
                .UseLazyLoadingProxies();
        }
    }
}