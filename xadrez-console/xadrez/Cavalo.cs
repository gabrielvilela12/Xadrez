using tabuleiro;

namespace xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matrix = new bool[Tabuleiro.Linha, Tabuleiro.Coluna];
            Posicao pos = new Posicao(0, 0);

            // Movimento 1
            pos.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
            }

            // Movimento 2
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
            }

            // Movimento 3
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 2);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
            }

            // Movimento 4
            pos.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
            }

            // Movimento 5
            pos.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
            }

            // Movimento 6
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
            }

            // Movimento 7
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 2);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
            }

            // Movimento 8
            pos.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
            }

            return matrix;
        }

        public override string ToString()
        {
            return "C";
        }
    }
}
