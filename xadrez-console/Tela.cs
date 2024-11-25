using System;
using tabuleiro;

namespace xadrez_console
{
    internal class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        {
            Console.WriteLine("  " + "0 1 2 3 4 5 6 7 "); //Numeração da casa da coluna
            for (int i = 0;i<tabuleiro.Linha;i++)
            {
                
                Console.Write(i + " "); //Numeração da casa da linha
                for (int j = 0; j < tabuleiro.Coluna; j++)
                {
                    

                    if (tabuleiro.Peca(i,j) == null) //Caso não exista peça na posição
                    {
                        Console.Write("- ");
                    }
                    else
                    {
                        Console.Write(tabuleiro.Peca(i, j) + " "); //Coloca a peça na posição
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
