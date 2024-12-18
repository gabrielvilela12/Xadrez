using tabuleiro;

namespace xadrez
{
    class Rei : Peca
    {

        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor)
        {
            this.partida = partida;
        }

        private bool podeMover(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p == null || p.Cor != this.Cor;
        }

        private bool testeTorreParaRoque(Posicao pos)
        {
            Peca p = Tabuleiro.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QntdMovimento == 0;
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
            pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            if (Tabuleiro.PosicaoValida(pos) && podeMover(pos))
            {
                matrix[pos.Linha, pos.Coluna] = true;

            }


            // #jogadaespecial roque

            if (QntdMovimento == 0 && !partida.xeque)
            {

                // #roque pequeno
                Posicao postT1 = new Posicao(Posicao.Linha,Posicao.Coluna + 3);


                if (testeTorreParaRoque(postT1))
                {
                    Posicao p1 = new Posicao(Posicao.Linha,Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha,Posicao.Coluna + 2);

                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null)
                    {
                        matrix[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // #roque grande
                Posicao postT2 = new Posicao(   Posicao.Linha, Posicao.Coluna - 4);


                if (testeTorreParaRoque(postT2))
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tabuleiro.Peca(p1) == null && Tabuleiro.Peca(p2) == null && Tabuleiro.Peca(p3) == null)
                    {
                        {
                            matrix[Posicao.Linha, Posicao.Coluna - 2] = true;
                        }
                    }

                }

            }
            return matrix;
        }
        
        public override string ToString()
        {
            return "R";
        }
    }
}
