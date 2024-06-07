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
                Console.WriteLine(nomes[i]);
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
                medias[i] = (nota1 + nota2 + nota3) / 3;
                Console.WriteLine(medias[i]);
                i++;
                linhas = leitor.ReadLine();
            }
            return medias;
        }
        static void Main(string[] args)
        {
            int linha;
            StreamReader arq = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
            linha = L(arq);
            Console.WriteLine(linha);
            arq.Close();
            arq = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
            string[] nomes;
            nomes = ON(arq, linha);
            arq.Close();
            arq = new StreamReader("lista_atp_10_arquivos.txt", Encoding.UTF8);
            double[] ma;
            ma = CM(arq, linha);
            Console.ReadLine();
        }
    }
}
