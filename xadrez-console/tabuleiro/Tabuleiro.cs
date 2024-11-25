namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        private object[,] Pecas; // Alterado para 'object' por enquanto, já que 'Peca' não está definido

        public Tabuleiro(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
            Pecas = new object[linha, coluna];
        }
    }
}