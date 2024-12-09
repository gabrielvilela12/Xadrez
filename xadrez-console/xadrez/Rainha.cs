using tabuleiro;

namespace xadrez
{
    class Rainha : Peca
    {
        public Rainha(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
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

            // Movimentos da Torre (linhas e colunas)

            // Acima
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha--;
            }

            // Abaixo
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Linha++;
            }

            // Direita
            pos.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna++;
            }

            // Esquerda
            pos.DefinirValores(this.Posicao.Linha, this.Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.Coluna--;
            }

            // Movimentos do Bispo (diagonais)

            // Diagonal superior esquerda
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            // Diagonal superior direita
            pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            // Diagonal inferior esquerda
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            // Diagonal inferior direita
            pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
            while (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;
                if (Tabuleiro.Peca(pos) != null && Tabuleiro.Peca(pos).Cor != Cor)
                {
                    break;
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            return matrix;
        }

        public override string ToString()
        {
            return "Q";
        }
    }
}
