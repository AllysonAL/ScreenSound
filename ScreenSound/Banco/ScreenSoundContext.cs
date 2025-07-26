using System;
using ScreenSound.Modelos;
using Microsoft.EntityFrameworkCore;

namespace ScreenSound.Banco
{
    internal class ScreenSoundContext : DbContext
    {
        public DbSet<Artista> Artistas { get; set; } = null!;
        public DbSet<Musica> Musicas { get; set; } = null!;

        public ScreenSoundContext(DbContextOptions<ScreenSoundContext> options) : base(options) { }
    }
}