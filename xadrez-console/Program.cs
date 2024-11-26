using System;
using tabuleiro;
using xadrez;

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
                    Console.Clear();
                    Tela.ImprimirTabuleiro(obj_PartidaDeXadrez.Tabuleiro);

                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().toPosicao();

                    obj_PartidaDeXadrez.ExecutaMovimento(origem, destino);
                

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            

            Console.ReadLine();
        }
    }
}
