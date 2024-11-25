namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        private Peca[,] Pecas; // Alterado para 'object' por enquanto, já que 'Peca' não está definido

        public Tabuleiro(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
            Pecas = new Peca[linha, coluna];
        }

        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public void ColocarPeca(Peca p, Posicao posicao)
        {
            Pecas[posicao.Linha, posicao.Coluna] = p;
            p.Posicao = posicao;
        }
    }
}