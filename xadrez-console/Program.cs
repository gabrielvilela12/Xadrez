using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Tabuleiro obj_Tabuleiro = new Tabuleiro(8, 8);

            obj_Tabuleiro.ColocarPeca(new Torre(obj_Tabuleiro, Cor.Preto), new Posicao(0,0));
            obj_Tabuleiro.ColocarPeca(new Cavalo(obj_Tabuleiro, Cor.Preto), new Posicao(0,5));
            obj_Tabuleiro.ColocarPeca(new Rei(obj_Tabuleiro, Cor.Preto), new Posicao(0,4));

            Tela.ImprimirTabuleiro(obj_Tabuleiro);
            Console.ReadLine();
        }
    }
}
