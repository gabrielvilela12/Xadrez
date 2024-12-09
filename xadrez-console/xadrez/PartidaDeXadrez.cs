using tabuleiro;
using xadrez_console.tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno;
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
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
        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(Tabuleiro.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem");
            }
            if(JogadorAtual != Tabuleiro.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem não é sua");
            }
            if (!Tabuleiro.Peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para a peça");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        public void mudaJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Amarela;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        private void colocarPecas()
        {
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Amarela), new PosicaoXadrez('a',8).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Amarela), new PosicaoXadrez('c',2).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Amarela), new PosicaoXadrez('d',4).toPosicao());
            Tabuleiro.ColocarPeca(new Torre(Tabuleiro, Cor.Branca), new PosicaoXadrez('d',5).toPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez('d',6).toPosicao());
            Tabuleiro.ColocarPeca(new Rei(Tabuleiro, Cor.Branca), new PosicaoXadrez('d',7).toPosicao());

        }
    }
}
