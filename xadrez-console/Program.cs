using System;
using tabuleiro;
using xadrez;
using xadrez_console.tabuleiro;

namespace xadrez_console
{
    internal class Program
    {

        static void Main(string[] args)
        {
            try
            {
               PartidaDeXadrez obj_PartidaDeXadrez = new PartidaDeXadrez();


                while (!obj_PartidaDeXadrez.Terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirTabuleiro(obj_PartidaDeXadrez.Tabuleiro);
                        Console.WriteLine();
                        Console.WriteLine("Turno: " + obj_PartidaDeXadrez.Turno);
                        Console.WriteLine("Aguardando jogador: " + obj_PartidaDeXadrez.JogadorAtual + "\n");


                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        obj_PartidaDeXadrez.validarPosicaoDeOrigem(origem);


                        bool[,] posicoesPossiveis = obj_PartidaDeXadrez.Tabuleiro.Peca(origem).movimentosPossiveis();


                        Console.Clear();
                        Tela.ImprimirTabuleiro(obj_PartidaDeXadrez.Tabuleiro, posicoesPossiveis);



                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        obj_PartidaDeXadrez.validarPosicaoDeDestino(origem,destino);
                        obj_PartidaDeXadrez.RealizaJogada(origem, destino);

                    }
                    catch (TabuleiroException ex)
                    {
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }
            }
            catch (TabuleiroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
            
            

            Console.ReadLine();
        }
    }
}
