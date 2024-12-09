using tabuleiro;

namespace xadrez
{
    class Peao : Peca
    {
        public Peao(Tabuleiro tabuleiro, Cor cor) : base(tabuleiro, cor)
        {
        }

        private bool existeInimigo(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p.Cor != this.Cor;
        }

        private bool livre(Posicao pos)
        {
            return Tabuleiro.Peca(pos) == null;
        }

        public override bool[,] movimentosPossiveis()
        {
            bool[,] matrix = new bool[Tabuleiro.Linha, Tabuleiro.Coluna];
            Posicao pos = new Posicao(0, 0);

            if (this.Cor == Cor.Branca)
            {
                // Movimento simples para frente
                pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && livre(pos))
                {
                    matrix[pos.Linha, pos.Coluna] = true;
                }

                // Movimento inicial de dois passos
                pos.DefinirValores(this.Posicao.Linha - 2, this.Posicao.Coluna);
                Posicao pos2 = new Posicao(this.Posicao.Linha - 1, this.Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && livre(pos) && Tabuleiro.PosicaoValida(pos2) && livre(pos2))
                {
                    matrix[pos.Linha, pos.Coluna] = true;
                }

                // Captura diagonal esquerda
                pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && existeInimigo(pos))
                {
                    matrix[pos.Linha, pos.Coluna] = true;
                }

                // Captura diagonal direita
                pos.DefinirValores(this.Posicao.Linha - 1, this.Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && existeInimigo(pos))
                {
                    matrix[pos.Linha, pos.Coluna] = true;
                }
            }
            else
            {
                // Movimento simples para frente
                pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && livre(pos))
                {
                    matrix[pos.Linha, pos.Coluna] = true;
                }

                // Movimento inicial de dois passos
                pos.DefinirValores(this.Posicao.Linha + 2, this.Posicao.Coluna);
                Posicao pos2 = new Posicao(this.Posicao.Linha + 1, this.Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && livre(pos) && Tabuleiro.PosicaoValida(pos2) && livre(pos2))
                {
                    matrix[pos.Linha, pos.Coluna] = true;
                }

                // Captura diagonal esquerda
                pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && existeInimigo(pos))
                {
                    matrix[pos.Linha, pos.Coluna] = true;
                }

                // Captura diagonal direita
                pos.DefinirValores(this.Posicao.Linha + 1, this.Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && existeInimigo(pos))
                {
                    matrix[pos.Linha, pos.Coluna] = true;
                }
            }

            return matrix;
        }

        public override string ToString()
        {
            return "P";
        }
    }
}
