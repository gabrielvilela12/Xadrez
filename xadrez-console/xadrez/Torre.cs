using tabuleiro;

namespace xadrez
{
    class Torre : Peca
    {
        public Torre(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
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
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);  // Corrigido
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha - 1;
            }

            // Abaixo
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);  // Corrigido
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha = pos.Linha + 1;
            }

            // Direita
            pos.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna + 1);  // Corrigido
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna + 1;
            }

            // Esquerda
            pos.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna - 1);  // Corrigido
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna = pos.Coluna - 1;
            }

            return matrix;
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
