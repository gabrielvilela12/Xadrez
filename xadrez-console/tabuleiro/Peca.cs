namespace tabuleiro
{
    class Peca
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
    }
}
