using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    public partial class PopularRelacaoMusicaArtista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 2002 WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 2003 WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = 2004 WHERE Id = 3");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = NULL WHERE Id = 1");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = NULL WHERE Id = 2");
            migrationBuilder.Sql("UPDATE Musicas SET ArtistaId = NULL WHERE Id = 3");
        }
    }
}
