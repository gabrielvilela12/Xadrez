using System;
using tabuleiro;
using xadrez;
using System.Collections.Generic;

namespace xadrez_console
{
    internal class Tela
    {
        public static void imprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tabuleiro);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);

            if (!partida.Terminada)
            {
                Console.WriteLine("Aguardando jogador: " + partida.JogadorAtual + "\n");
                if (partida.xeque)
                {
                    Console.WriteLine("Voce está em xeque");
                }
            }
            else
            {
                Console.WriteLine("\nXEQUEMATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }

        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Peças capturadas:");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.pecasCapturadas(Cor.Branca));
            Console.Write("Amarela: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            ImprimirConjunto(partida.pecasCapturadas(Cor.Amarela));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca p in conjunto)
            {
                Console.Write(p + ", ");
            }
            Console.Write("]\n");
        }


        //Carrega o tabuleiro na tela
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro)
        { 
            for (int i = 0;i<tabuleiro.Linha;i++)
            {
                Console.Write(8 - i + " "); //Monta o tabuleiro com numeração da linha
                for (int j = 0; j < tabuleiro.Coluna; j++)
                {
                    imprimirPeca(tabuleiro.Peca(i,j));
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirTabuleiro(Tabuleiro tabuleiro, bool[,] posicoesPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor;
            ConsoleColor fundoAlterado = ConsoleColor.DarkGray;

            for (int i = 0; i < tabuleiro.Linha; i++)
            {
                Console.Write(8 - i + " ");
                for (int j = 0; j < tabuleiro.Coluna; j++)
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor= fundoOriginal;
                    }

                    imprimirPeca(tabuleiro.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;

                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h");
            Console.BackgroundColor = fundoOriginal;

        }

        public static PosicaoXadrez lerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        //Exibe as peças na tela
        public static void imprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
            {
                if (peca.Cor == Cor.Branca)
                {
                    Console.Write(peca);
                }
                else
                {
                    ConsoleColor aux = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(peca);
                    Console.ForegroundColor = aux;
                }
                Console.Write(" ");
            }
        }
    }
}
