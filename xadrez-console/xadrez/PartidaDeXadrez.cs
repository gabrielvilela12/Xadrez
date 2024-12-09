using tabuleiro;
using xadrez_console.tabuleiro;
using System.Collections.Generic;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro Tabuleiro { get; private set; }
        public int Turno;
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            colocarPecas();

        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.retirarPeca(origem);
            p.incrementarQntdMovimentos();
            Peca pecaCapturada = Tabuleiro.retirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            mudaJogador();
        }

        public void validarPosicaoDeOrigem(Posicao pos)
        {
            if(Tabuleiro.Peca(pos) == null)
            {
                throw new TabuleiroException("Não existe peça na posição de origem");
            }
            if(JogadorAtual != Tabuleiro.Peca(pos).Cor)
            {
                throw new TabuleiroException("A peça de origem não é sua");
            }
            if (!Tabuleiro.Peca(pos).existeMovimentosPossiveis())
            {
                throw new TabuleiroException("Não há movimentos possiveis para a peça");
            }
        }

        public void validarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tabuleiro.Peca(origem).podeMoverPara(destino))
            {
                throw new TabuleiroException("Posição de destino inválida");
            }
        }

        public void mudaJogador()
        {
            if(JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Amarela;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach(Peca x in capturadas) 
            {
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> pecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
        }

        private void colocarPecas()
        {
            // Peças Brancas
            colocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Rainha(Tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branca));
            colocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branca));

            for (char coluna = 'a'; coluna <= 'h'; coluna++)
            {
                colocarNovaPeca(coluna, 2, new Peao(Tabuleiro, Cor.Branca));
            }

            // Peças Amarelas (ou Pretas)
            colocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('d', 8, new Rainha(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('f', 8, new Bispo(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('g', 8, new Cavalo(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('h', 8, new Torre(Tabuleiro, Cor.Amarela));

            for (char coluna = 'a'; coluna <= 'h'; coluna++)
            {
                colocarNovaPeca(coluna, 7, new Peao(Tabuleiro, Cor.Amarela));
            }
        }

    }
}
