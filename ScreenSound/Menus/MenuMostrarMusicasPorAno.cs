using System;
using ScreenSound.Banco;
using ScreenSound.Modelos;

namespace ScreenSound.Menus
{
    internal class MenuMostrarMusicasPorAno : Menu
    {
        private DAL<Musica> MusicaDAL { get; set; }
        public MenuMostrarMusicasPorAno(DAL<Musica> musicaDAL)
        {
            MusicaDAL = musicaDAL;
        }

        public override void Executar(DAL<Artista> artistaDAL)
        {
            base.Executar(artistaDAL);
            ExibirTituloDaOpcao("Conhecer as melhores lançadas de um ano");
            Console.Write("Digite o ano que você deseja conhecer as melhores: ");
            var anoLancamento = int.Parse(Console.ReadLine()!);
            var musicas = MusicaDAL.ListarPor(x => x.AnoLancamento == anoLancamento);

            Console.WriteLine($"\nMúsicas do ano {anoLancamento}");

            foreach (var musica in musicas)
            {
                musica.ExibirFichaTecnica();
            }

            Console.WriteLine("Digite uma tecla para voltar ao menu principal");
            Console.ReadKey();
            Console.Clear();
        }
    }
}