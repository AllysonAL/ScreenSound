Console.WriteLine(DescricaoObjeto("a"));

object obj = 10;

var b = obj switch
{
    int a => $"Isso é um int: {a}",
    string i => $"Isso é uma string {i}",
    null => "Isso está nulo",
    _ => "Não sei o que é isso"
};

