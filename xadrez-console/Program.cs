using System;
using tabuleiro;

namespace xadrez_console
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Tabuleiro obj_Tabuleiro = new Tabuleiro(8, 8);

            Tela.ImprimirTabuleiro(obj_Tabuleiro);
            Console.ReadLine();
        }
    }
}
