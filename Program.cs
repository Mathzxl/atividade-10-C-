using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        string caminhoArquivo = "estudantes.txt";
        StreamReader leitor = new StreamReader(caminhoArquivo);

        int quantidadeLinhas = ContabilizarLinhas(leitor);
        leitor.BaseStream.Seek(0, SeekOrigin.Begin); // Resetar a posição do leitor
        leitor.DiscardBufferedData();

        string[] nomes = ObterNomes(leitor, quantidadeLinhas);
        leitor.BaseStream.Seek(0, SeekOrigin.Begin);
        leitor.DiscardBufferedData();

        double[] medias = CalcularMedias(leitor, quantidadeLinhas);

        EscreverEstudantesAprovados(nomes, medias, "aprovados.txt");
        EscreverEstudantesReprovados(nomes, medias, "reprovados.txt");
        EscreverEstudantesOrdenadosPorMedia(nomes, medias, "ordenados_por_media.txt");

        double maiorNota = ObterMaiorNota(leitor);
        Console.WriteLine("A maior nota geral é: " + maiorNota);

        ImprimirDadosEstudantes(nomes, medias);

        leitor.Close();
    }

    static int ContabilizarLinhas(StreamReader leitor)
    {
        int quantidadeLinhas = 0;
        while (leitor.ReadLine() != null)
        {
            quantidadeLinhas++;
        }
        return quantidadeLinhas;
    }

    static string[] ObterNomes(StreamReader leitor, int quantidadeLinhas)
    {
        string[] nomes = new string[quantidadeLinhas];
        for (int i = 0; i < quantidadeLinhas; i++)
        {
            string linha = leitor.ReadLine();
            string[] dados = linha.Split(' ');
            nomes[i] = dados[0];
        }
        return nomes;
    }

    static double[] CalcularMedias(StreamReader leitor, int quantidadeLinhas)
    {
        double[] medias = new double[quantidadeLinhas];
        for (int i = 0; i < quantidadeLinhas; i++)
        {
            string linha = leitor.ReadLine();
            string[] dados = linha.Split(' ');
            double nota1 = Convert.ToDouble(dados[1]);
            double nota2 = Convert.ToDouble(dados[2]);
            double nota3 = Convert.ToDouble(dados[3]);
            medias[i] = (nota1 + nota2 + nota3) / 3;
        }
        return medias;
    }

    static void EscreverEstudantesAprovados(string[] nomes, double[] medias, string caminhoArquivo)
    {
        using (StreamWriter escritor = new StreamWriter(caminhoArquivo))
        {
            for (int i = 0; i < nomes.Length; i++)
            {
                if (medias[i] >= 6.0)
                {
                    escritor.WriteLine(nomes[i] + " " + medias[i].ToString("F2"));
                }
            }
        }
    }

    static void EscreverEstudantesReprovados(string[] nomes, double[] medias, string caminhoArquivo)
    {
        using (StreamWriter escritor = new StreamWriter(caminhoArquivo))
        {
            for (int i = 0; i < nomes.Length; i++)
            {
                if (medias[i] < 6.0)
                {
                    escritor.WriteLine(nomes[i] + " " + medias[i].ToString("F2"));
                }
            }
        }
    }

    static void EscreverEstudantesOrdenadosPorMedia(string[] nomes, double[] medias, string caminhoArquivo)
    {
        var estudantes = nomes.Zip(medias, (nome, media) => new { Nome = nome, Media = media })
                              .OrderByDescending(estudante => estudante.Media)
                              .ToList();

        using (StreamWriter escritor = new StreamWriter(caminhoArquivo))
        {
            foreach (var estudante in estudantes)
            {
                escritor.WriteLine(estudante.Nome + " " + estudante.Media.ToString("F2"));
            }
        }
    }

    static double ObterMaiorNota(StreamReader leitor)
    {
        double maiorNota = 0;
        string linha;
        while ((linha = leitor.ReadLine()) != null)
        {
            Console.WriteLine($"Linha lida: {linha}"); // Mensagem de depuração
            string[] dados = linha.Split(' ');
            for (int i = 1; i < dados.Length; i++)
            {
                Console.WriteLine($"Nota atual: {dados[i]}"); // Mensagem de depuração
                double nota = Convert.ToDouble(dados[i]);
                maiorNota = Math.Max(maiorNota, nota);
            }
        }
        return maiorNota;
    }


    static void ImprimirDadosEstudantes(string[] nomes, double[] medias)
    {
        for (int i = 0; i < nomes.Length; i++)
        {
            Console.WriteLine(nomes[i] + ": " + medias[i].ToString("F2"));
        }
        Console.ReadLine();
    }
}
