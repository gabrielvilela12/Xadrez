namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QntdMovimento { get; protected set; }
        public Tabuleiro Tabuleiro { get; protected set; }


        //Contrutor da Peça
        public Peca(Cor cor, Tabuleiro tabuleiro)
        {
            this.Posicao = null; 
            this.Cor = cor;
            this.QntdMovimento = 0;
            this.Tabuleiro = tabuleiro;
        }

        public Peca(Tabuleiro tabuleiro, Cor cor)
        {
            Tabuleiro = tabuleiro;
            Cor = cor;
        }

        public void incrementarQntdMovimentos()
        {
            QntdMovimento++;
        }

        public bool existeMovimentosPossiveis()
        {
            bool[,] mat = movimentosPossiveis();
            for(int i = 0;i < Tabuleiro.Linha; i++)
            {
                for(int j = 0;j < Tabuleiro.Coluna; j++)
                {
                    if (mat[i,j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool podeMoverPara(Posicao pos)
        {
            return movimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] movimentosPossiveis();
    }
}
