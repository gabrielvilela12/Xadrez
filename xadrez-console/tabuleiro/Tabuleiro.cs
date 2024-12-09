using xadrez_console.tabuleiro;

namespace tabuleiro
{
    class Tabuleiro
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }
        private Peca[,] Pecas; //Matrix de peças

        public Tabuleiro(int linha, int coluna)
        {
            this.Linha = linha;
            this.Coluna = coluna;
            Pecas = new Peca[linha, coluna];
        }

        //Posições das peças
        public Peca Peca(Posicao pos) 
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        //Verifica se já existe uma peça na posição
        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos);
            return Peca(pos) != null;
        }

        //Coloca a peça em uma posição
        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Posição já ocupada!");
            }

            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca retirarPeca(Posicao posicao)
        {
            if (!ExistePeca(posicao))
            {
                return null;
            }
            Peca aux = Peca(posicao);
            aux.Posicao = null;
            Pecas[posicao.Linha, posicao.Coluna] = null;
            return aux; 
        }

        //Verifica se a posição é válida no tamanho do tabuleiro
        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linha || pos.Coluna < 0 || pos.Coluna >= Coluna)
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        //Exceção caso de algum erro
        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posição inválida!");
            }
        }
    }
}