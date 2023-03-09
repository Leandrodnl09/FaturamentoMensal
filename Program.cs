 
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
class Program
{
    static void Main(string[] args)
    {
        // Ler o arquivo JSON com os valores de faturamento diário
        var json = File.ReadAllText("faturamento.json");
        var faturamentoMensal = JsonSerializer.Deserialize<decimal[]>(json);

        // Calcular o menor valor de faturamento diário
        var menorFaturamento = faturamentoMensal.Min();

        // Calcular o maior valor de faturamento diário
        var maiorFaturamento = faturamentoMensal.Max();

        // Calcular a média de faturamento diário (ignorando dias sem faturamento)
        var diasComFaturamento = faturamentoMensal.Count(f => f > 0);
        var mediaMensal = faturamentoMensal.Sum() / diasComFaturamento;

        // Calcular o número de dias em que o faturamento diário foi superior à média mensal
        var diasAcimaDaMedia = faturamentoMensal.Count(f => f > mediaMensal);

        // Exibir os resultados
        Console.WriteLine($"Menor faturamento diário: {menorFaturamento:C}");
        Console.WriteLine($"Maior faturamento diário: {maiorFaturamento:C}");
        Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");
    }
}