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
        public bool xeque {  get; private set; }

        public PartidaDeXadrez()
        {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            xeque = false;
            colocarPecas();

        }

        private Cor Adversaria(Cor cor)
        {
            if(cor == Cor.Branca)
            {
                return Cor.Amarela;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca rei(Cor cor)
        {
            foreach(Peca x in pecasEmJogo(cor))
            {
                if(x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool EstaEmXete(Cor cor)
        {
            Peca R = rei(cor);

            if (R == null)
            {
                throw new TabuleiroException("Não tem rei na cor do tabulueiro");
            }

            foreach (Peca x in pecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.movimentosPossiveis();

                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = Tabuleiro.retirarPeca(origem);
            p.incrementarQntdMovimentos();
            Peca pecaCapturada = Tabuleiro.retirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);
            if(pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            //jogadaespecial roque pequeno
            if(p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tabuleiro.retirarPeca(origemT);
                T.incrementarQntdMovimentos();
                Tabuleiro.ColocarPeca(T, destinoT);
            }
            
            //jogadaespecial roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tabuleiro.retirarPeca(origemT);
                T.incrementarQntdMovimentos();
                Tabuleiro.ColocarPeca(T, destinoT);
            }

            return pecaCapturada;
        }

        public void desfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tabuleiro.retirarPeca(destino);
            p.decrementarQntdMovimentos();

            if(pecaCapturada != null)
            {
                Tabuleiro.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            Tabuleiro.ColocarPeca(p, origem);

            //jogadaespecial roque pequeno
            if (p is Rei && destino.Coluna == origem.Coluna + 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna + 3);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna + 1);
                Peca T = Tabuleiro.retirarPeca(destinoT);
                T.decrementarQntdMovimentos();
                Tabuleiro.ColocarPeca(T, origemT);
            }

            //jogadaespecial roque grande
            if (p is Rei && destino.Coluna == origem.Coluna - 2)
            {
                Posicao origemT = new Posicao(origem.Linha, origem.Coluna - 4);
                Posicao destinoT = new Posicao(origem.Linha, origem.Coluna - 1);
                Peca T = Tabuleiro.retirarPeca(destinoT);
                T.decrementarQntdMovimentos();
                Tabuleiro.ColocarPeca(T, origemT);
            }

        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecasCapturadas = ExecutaMovimento(origem, destino);

            if (EstaEmXete(JogadorAtual))
            {
                desfazMovimento(origem, destino, pecasCapturadas);
                throw new TabuleiroException("Voce não pode se colocar em xeque!");
            }
            

            if (EstaEmXete(Adversaria(JogadorAtual)))
            {
                xeque = true;
            }
            else
            {
                xeque = false;
            }

            if (testeXequemate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }

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
            if (!Tabuleiro.Peca(origem).movimentoPossivel(destino))
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

        public bool testeXequemate(Cor cor)
        {
            if (!EstaEmXete(cor))
            {
                return false;
            }
            foreach (Peca x in pecasEmJogo(cor))
            {
                bool[,] mat = x.movimentosPossiveis();
                for(int i = 0; i < Tabuleiro.Linha; i++)
                {
                    for(int j = 0; j < Tabuleiro.Coluna; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXete(cor);
                            desfazMovimento(origem, destino, pecaCapturada);

                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }

        public void colocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            pecas.Add(peca); // Adiciona a peça ao conjunto

        }

        private void colocarPecas()
        {
            // Peças brancas
            colocarNovaPeca('a', 1, new Torre(Tabuleiro, Cor.Branca));
            colocarNovaPeca('b', 1, new Cavalo(Tabuleiro, Cor.Branca));
            colocarNovaPeca('c', 1, new Bispo(Tabuleiro, Cor.Branca));
            colocarNovaPeca('d', 1, new Rainha(Tabuleiro, Cor.Branca));
            colocarNovaPeca('e', 1, new Rei(Tabuleiro, Cor.Branca, this));
            colocarNovaPeca('f', 1, new Bispo(Tabuleiro, Cor.Branca));
            colocarNovaPeca('g', 1, new Cavalo(Tabuleiro, Cor.Branca));
            colocarNovaPeca('h', 1, new Torre(Tabuleiro, Cor.Branca));
            for (char coluna = 'a'; coluna <= 'h'; coluna++)
            {
                colocarNovaPeca(coluna, 2, new Peao(Tabuleiro, Cor.Branca));
            }

            // Peças amarelas
            colocarNovaPeca('a', 8, new Torre(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('b', 8, new Cavalo(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('c', 8, new Bispo(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('d', 8, new Rainha(Tabuleiro, Cor.Amarela));
            colocarNovaPeca('e', 8, new Rei(Tabuleiro, Cor.Amarela, this));
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
