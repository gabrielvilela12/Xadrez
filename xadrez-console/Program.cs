using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Tabuleiro obj_Tabuleiro = new Tabuleiro(8,8);

            obj_Tabuleiro.ColocarPeca(new Torre(obj_Tabuleiro, Cor.Preto), new Posicao(4,7));
          


            Tela.ImprimirTabuleiro(obj_Tabuleiro);
            

            Console.ReadLine();
        }
    }
}
