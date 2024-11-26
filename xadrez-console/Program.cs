using System;
using tabuleiro;
using xadrez;

namespace xadrez_console
{
    internal class Program
    {

        static void Main(string[] args)
        {
            PosicaoXadrez posicaoXadrez = new PosicaoXadrez('c', 7);

            Console.WriteLine(posicaoXadrez);
            Console.WriteLine(posicaoXadrez.toPosicao());
            Console.ReadLine();
        }
    }
}
