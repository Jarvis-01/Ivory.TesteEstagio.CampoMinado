using System;

namespace Ivory.TesteEstagio.CampoMinado
{
    class Program
    {
        static void Main(string[] args)
        {
            var campoMinado = new CampoMinado();
            Console.WriteLine("Início do jogo\n=========");
            Console.WriteLine(campoMinado.Tabuleiro);

            // Realize sua codificação a partir deste ponto, boa sorte!

            //tamanho da matriz
            int linhas = 9;
            int colunas = 9;            
            
            HashSet<int> possivelBomba = new HashSet<int>();
            string tabuleiroSemQuebraLinha = campoMinado.Tabuleiro.Replace("\r", "").Replace("\n", "");

            // Enquanto o jogo não terminar em vitória ou derrota
            while (campoMinado.JogoStatus == 0)
            {

                for (int l = 0; l < linhas; l++){
                    for (int c = 0; c < colunas; c++){
                        char posicao = tabuleiroSemQuebraLinha[l * colunas + c];
                        char cima='0', cimaDireita='0', direita='0', baixoDireita='0', baixo='0', baixoEsquerda='0', esquerda='0', cimaEsquerda='0';
                        
                            //verificar vizinhos
                            if (l == 0){
                                if (c == 0){
                                    direita = tabuleiroSemQuebraLinha[l * colunas + (c+1)];
                                    baixoDireita = tabuleiroSemQuebraLinha[(l+1) * colunas + (c+1)];
                                    baixo = tabuleiroSemQuebraLinha[(l+1) * colunas + c];
                                }else if (c == colunas-1){
                                    baixo = tabuleiroSemQuebraLinha[(l+1) * colunas + c];
                                    baixoEsquerda = tabuleiroSemQuebraLinha[(l+1) * colunas + (c-1)];
                                    esquerda = tabuleiroSemQuebraLinha[(l) * colunas + (c-1)];
                                }else{
                                    direita = tabuleiroSemQuebraLinha[l * colunas + (c+1)];
                                    baixoDireita = tabuleiroSemQuebraLinha[(l+1) * colunas + (c+1)];
                                    baixo = tabuleiroSemQuebraLinha[(l+1) * colunas + c];
                                    baixoEsquerda = tabuleiroSemQuebraLinha[(l+1) * colunas + (c-1)];
                                    esquerda = tabuleiroSemQuebraLinha[(l) * colunas + (c-1)];
                                }
                            }else if (l == linhas-1){
                                if (c == 0){
                                    cima = tabuleiroSemQuebraLinha[(l-1) * colunas + c];
                                    cimaDireita = tabuleiroSemQuebraLinha[(l-1) * colunas + (c+1)];
                                    direita = tabuleiroSemQuebraLinha[l * colunas + (c+1)];
                                }else if (c == colunas-1){
                                    cima = tabuleiroSemQuebraLinha[(l-1) * colunas + c];
                                    esquerda = tabuleiroSemQuebraLinha[(l) * colunas + (c-1)];
                                    cimaEsquerda = tabuleiroSemQuebraLinha[(l-1) * colunas + (c-1)];
                                }else{
                                    cima = tabuleiroSemQuebraLinha[(l-1) * colunas + c];
                                    cimaDireita = tabuleiroSemQuebraLinha[(l-1) * colunas + (c+1)];
                                    direita = tabuleiroSemQuebraLinha[l * colunas + (c+1)];
                                    esquerda = tabuleiroSemQuebraLinha[(l) * colunas + (c-1)];
                                    cimaEsquerda = tabuleiroSemQuebraLinha[(l-1) * colunas + (c-1)];
                                    cima = tabuleiroSemQuebraLinha[(l-1) * colunas + c];
                                }
                            }else if (l > 0 && l < (linhas-2)){
                                if (c == 0){
                                    cima = tabuleiroSemQuebraLinha[(l-1) * colunas + c];
                                    cimaDireita = tabuleiroSemQuebraLinha[(l-1) * colunas + (c+1)];
                                    direita = tabuleiroSemQuebraLinha[l * colunas + (c+1)];
                                    baixoDireita = tabuleiroSemQuebraLinha[(l+1) * colunas + (c+1)];
                                    baixo = tabuleiroSemQuebraLinha[(l+1) * colunas + c];
                                }else if (c == colunas-1){
                                    cima = tabuleiroSemQuebraLinha[(l-1) * colunas + c];
                                    baixo = tabuleiroSemQuebraLinha[(l+1) * colunas + c];
                                    baixoEsquerda = tabuleiroSemQuebraLinha[(l+1) * colunas + (c-1)];
                                    esquerda = tabuleiroSemQuebraLinha[(l) * colunas + (c-1)];
                                }else{
                                    cima = tabuleiroSemQuebraLinha[(l-1) * colunas + c];
                                    cimaDireita = tabuleiroSemQuebraLinha[(l-1) * colunas + (c+1)];
                                    direita = tabuleiroSemQuebraLinha[l * colunas + (c+1)];
                                    baixoDireita = tabuleiroSemQuebraLinha[(l+1) * colunas + (c+1)];
                                    baixo = tabuleiroSemQuebraLinha[(l+1) * colunas + c];
                                    baixoEsquerda = tabuleiroSemQuebraLinha[(l+1) * colunas + (c-1)];
                                    esquerda = tabuleiroSemQuebraLinha[(l) * colunas + (c-1)];
                                    cimaEsquerda = tabuleiroSemQuebraLinha[(l-1) * colunas + (c-1)];
                                }
                            }

                            //ver quantidade de vizinhos fechados
                            int vizinhos=0;
                            if(cima == '-'){
                                vizinhos++;
                            }
                            if(cimaDireita == '-'){
                                vizinhos++;
                            }
                            if(direita == '-'){
                                vizinhos++;
                            }
                            if (baixoDireita == '-'){
                                vizinhos++;
                            }
                            if (baixo == '-'){
                                vizinhos++;
                            }
                            if (baixoEsquerda == '-'){
                                vizinhos++;
                            }
                            if (esquerda == '-'){
                                vizinhos++;
                            }
                            if (cimaEsquerda == '-'){
                                vizinhos++;
                            }


                            //procurar bomba
                            if (posicao != '-' && posicao != '0'){
                                if (vizinhos == (posicao - '0')){
                                    if(cima == '-'){
                                        possivelBomba.Add((l-1) * colunas + c);
                                    }if(cimaDireita == '-'){
                                        possivelBomba.Add((l-1) * colunas + (c+1));
                                    }if (direita == '-'){
                                        possivelBomba.Add(l * colunas + (c+1));
                                    }if (baixoDireita == '-'){
                                        possivelBomba.Add((l+1) * colunas + (c+1));
                                    }if (baixo == '-'){
                                        possivelBomba.Add((l+1) * colunas + c);
                                    }if (baixoEsquerda == '-'){
                                        possivelBomba.Add((l+1) * colunas + (c-1));
                                    }if (esquerda == '-'){
                                        possivelBomba.Add((l) * colunas + (c-1));
                                    }
                                }
                            }

                            
                        }
                    
                }
                //abrir casa
                bool achou = false;
                for (int l = 0; l < linhas; l++){
                    for (int c = 0; c < colunas; c++){
                        char posicao = tabuleiroSemQuebraLinha[l * colunas + c];

                        if (posicao == '-' && !(possivelBomba.Contains(l * colunas + c))){
                            campoMinado.Abrir(l+1, c+1);
                            tabuleiroSemQuebraLinha = campoMinado.Tabuleiro.Replace("\r", "").Replace("\n", "");
                            Console.WriteLine("============");
                            Console.WriteLine(campoMinado.Tabuleiro);
                            achou = true;
                            break;
                        }
                    }
                    if (achou){
                        break;
                    }
                }
                

            }
            if (campoMinado.JogoStatus == 1){
                Console.Write("Parebens voce ganhou!!");
            }else{
                Console.Write("Poxa voce perdeu");
            }

        }
    }
}
        
    

