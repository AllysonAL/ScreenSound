using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ScreenSound.Banco;
using ScreenSound.Menus;
using ScreenSound.Modelos;

string? connectionString;
ScreenSoundContext context;
DAL<Artista> artistaDAL;
Dictionary<int, Menu> opcoes;

void TentarExecutar()
{
    try
    {
        Executar();
    }
    catch (Exception erro)
    {
        Console.WriteLine(erro);
    }
}

void Executar()
{
    Inicializar();

    if (EhProgramaConfigurado())
    {
        DefinirContext();
        DefinirArtista();
        DefinirOpcoes();
        ExibirOpcoesDoMenu();
    }
    else
    {
        Console.WriteLine("O programa não conseguiu encontrar ConnectionString");
    }
}

void Inicializar()
{
    IConfigurationRoot config = new ConfigurationBuilder()
          .AddUserSecrets<Program>()
          .Build();

    connectionString = config.GetConnectionString("DefaultConnection");
}

bool EhProgramaConfigurado()
{
    return connectionString != null;
}

void DefinirContext()
{
    context = new ScreenSoundContext(connectionString!);
}

void DefinirArtista()
{
    artistaDAL = new DAL<Artista>(context);
}

void DefinirOpcoes()
{
    opcoes = new()
    {
        { 1, new MenuRegistrarArtista() },
        { 2, new MenuRegistrarMusica() },
        { 3, new MenuMostrarArtistas() },
        { 4, new MenuMostrarMusicas() },
        { 5, new MenuMostrarMusicasPorAno(new DAL<Musica>(context)) },
        { -1, new MenuSair() }
    };
}

void ExibirOpcoesDoMenu()
{
    ExibirLogo();

    Console.WriteLine("\nDigite 1 para registrar um artista");
    Console.WriteLine("Digite 2 para registrar a música de um artista");
    Console.WriteLine("Digite 3 para mostrar todos os artistas");
    Console.WriteLine("Digite 4 para exibir todas as músicas de um artista");
    Console.WriteLine("Digite 5 para exibir todas as músicas de um ano de lançamento");
    Console.WriteLine("Digite -1 para sair");

    Console.Write("\nDigite a sua opção: ");
    string opcaoEscolhida = Console.ReadLine()!;
    int opcaoEscolhidaNumerica = int.Parse(opcaoEscolhida);

    if (opcoes.ContainsKey(opcaoEscolhidaNumerica))
    {
        Menu menuASerExibido = opcoes[opcaoEscolhidaNumerica];
        menuASerExibido.Executar(artistaDAL);
        if (opcaoEscolhidaNumerica > 0) ExibirOpcoesDoMenu();
    } 
    else
    {
        Console.WriteLine("Opção inválida");
    }
}

void ExibirLogo()
{
    Console.WriteLine(@"

    ░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
    ██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
    ╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
    ░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
    ██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
    ╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
    ");

    Console.WriteLine("Boas vindas ao Screen Sound 3.0!");
}

TentarExecutar();