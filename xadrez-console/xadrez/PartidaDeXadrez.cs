using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        private int Turno;
        private Cor JogadorAtual;
        public bool Terminada { get; private set; }


        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8,8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            colocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.retirarPeca(origem);
            p.incrementarQntdMovimentos();
            Peca pecaCapturada = Tabuleiro.retirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
        }

        private void colocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Amarela), new PosicaoXadrez('c',1).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Amarela), new PosicaoXadrez('c',2).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Amarela), new PosicaoXadrez('d',4).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('d',5).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('d',6).toPosicao());

        }
    }
}
