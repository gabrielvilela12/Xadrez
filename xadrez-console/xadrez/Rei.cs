using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {
        public Rei(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
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

            // Acima
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
            }
                

            // Nordeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;

            }

            // Direita
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;

            }

            // Sudeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;

            }

            // Abaixo
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;

            }

            // Sudoeste
            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;

            }

            // Esquerda
            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;

            }

            // Noroeste
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;

            }

            return matrix;
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
