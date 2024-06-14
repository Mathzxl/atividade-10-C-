using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _1
{
    class Program
    {
        static int L(StreamReader leitor)
        {
            string linhas;
            linhas = leitor.ReadLine();
            int quantidadeLinhas = 0;
            while (linhas != null)
            {
                quantidadeLinhas++;
                linhas = leitor.ReadLine();
            }
            return quantidadeLinhas;
        }
        static string[] ON(StreamReader leitor, int ql)
        {
            string linhas;
            linhas = leitor.ReadLine();
            string[] nomes = new string[ql];
            string[] dados;
            int i = 0;
            while (linhas != null)
            {
                dados = linhas.Split(' ');
                nomes[i] = dados[1];
                i++;
                linhas = leitor.ReadLine();
            }
            return nomes;
        }
        static double[] CM(StreamReader leitor, int ql)
        {
            string linhas;
            linhas = leitor.ReadLine();
            double[] medias = new double[ql];
            string[] dados;
            int i = 0;
            while (linhas != null)
            {
                dados = linhas.Split(' ');
                double nota1 = double.Parse(dados[2]);
                double nota2 = double.Parse(dados[3]);
                double nota3 = double.Parse(dados[4]);
                medias[i] = (nota1 + nota2 + nota3) / 30.00;
                i++;
                linhas = leitor.ReadLine();
            }
            return medias;
        }
        static void Ebarq(string[] nomes, double[] cm)
        {
            StreamWriter MédiaSuperior = new StreamWriter("C:\\Users\\Mathzz\\source\\repos\\atividade10\\atividade10\\bin\\Debug\\MediaSuperior6.txt");
            for (int i = 0; i < nomes.Length; i++)
            {
                if (cm[i] > 6.0)
                {
                    MédiaSuperior.WriteLine(nomes[i] + $"\t Média: {cm[i]}");   
                }
            }
            MédiaSuperior.Close();
        }
        static void Eaarq(string[] nomes, double[] cm)
        {
            StreamWriter MédiaInferior = new StreamWriter("C:\\Users\\Mathzz\\source\\repos\\atividade10\\atividade10\\bin\\Debug\\MédiaInferior6.txt");
            for (int i = 0; i < nomes.Length; i++)
            {
                if (cm[i] < 6)
                {
                    MédiaInferior.WriteLine(nomes[i] + $"\t Média: {cm[i]}");
                }
            }
            MédiaInferior.Close();
        }
        static void DadosEstudantes(string[] nomes, double[] cm)
        {
            StreamWriter sorted = new StreamWriter("C:\\Users\\Mathzz\\source\\repos\\atividade10\\atividade10\\bin\\Debug\\DadosEstudantes.txt");
            double[] sortr = cm;
            Array.Sort(sortr, nomes);
            Array.Reverse(sortr);
            Array.Reverse(nomes);
            for (int i = 0; i < cm.Length; i++)
            {
                {
                    sorted.WriteLine(nomes[i] + $"\t Média: {sortr[i]}");
                }
            }
            sorted.Close();
        }
        static double MaioresNotas(StreamReader leitor)
        {
            string linhas;
            linhas = leitor.ReadLine();
            string[] dados;
            int i = 0;
            double Maior = double.MinValue;
            while (linhas != null)
            {
                dados = linhas.Split(' ');
                double nota1 = double.Parse(dados[2]);
                double nota2 = double.Parse(dados[3]);
                double nota3 = double.Parse(dados[4]);
                i++;
                if ((double.Parse(dados[2])) > Maior)
                {
                    Maior = double.Parse(dados[2]);
                }
                else if ((double.Parse(dados[3])) > Maior)
                {
                    Maior = double.Parse(dados[3]);
                }
                else if ((double.Parse(dados[4])) > Maior)
                {
                    Maior = double.Parse(dados[4]);
                }
                linhas = leitor.ReadLine();
            }
            return Maior / 10;
        }

        static void DadosEstudanteConsole(string[] names, double[] cm)
        {
            for (int i = 0; i < names.Length; i++)
            {
                Console.WriteLine(names[i] + $"\t Média: {cm[i]}");
            }
        }
        static void Main(string[] args)
        {
            int linha;
            StreamReader arq = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
            linha = L(arq);
            Console.WriteLine("Quantidade de Linhas do Arquivo: " + linha);
            arq.Close();
            arq = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
            string[] nomes;
            nomes = ON(arq, linha);
            arq.Close();
            arq = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
            double[] ma;
            ma = CM(arq, linha);
            arq.Close();
            Ebarq(nomes, ma);
            Eaarq(nomes, ma);
            DadosEstudantes(nomes, ma);
            arq = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
            Console.WriteLine("\nMaior Nota Geral: " + MaioresNotas(arq) + "\n");
            arq.Close();
            DadosEstudanteConsole(nomes, ma);
            Console.ReadLine();
        }
    }
}
