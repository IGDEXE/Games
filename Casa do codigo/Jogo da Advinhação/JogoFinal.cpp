// Configura as bibliotecas
# include <stdio.h>
# include <stdlib.h>
# include <time.h>

// Configura a função princial
int main()
{
    printf("-- Welcome to: \n");
	printf("              A \n");
	printf("              H    \n");        
	printf("         A    H       \n");   
	printf("         H MM HA       \n");  
	printf("        AH^HH^HH         \n");                
	printf("        HH_HH_HHA \n");
	printf("      AAxHHHHxAxH        \n");
	printf("     HHHH/^\\HHHHA      \n"); 
	printf("    _HHHH___HHHHH_   \n\n");
	printf(" Royal Divination Game      \n\n"); 
    
    // Configura as variaveis
    int segundos = time(0);
    srand(segundos);
	int chute;
    int numerosecreto = rand() % 100;
	int ganhou = 0;
	int tentativas = 1;
	double pontos = 1000;
	int nivel;
	int totaltentativas;
	int acertou;
    int maior;
    int menor;
	
	// Valida a dificuldade
	printf("Qual o nivel de dificuldade? \n");
	printf("(1) Facil (2) Medio (3) Dificil \n \n");
	printf("Escolha: ");
	scanf("%d", &nivel);
	
	switch(nivel)
	{
		case 1:
			totaltentativas = 20;
			break;
		case 2:
			totaltentativas = 15;
			break;
		case 3:
			totaltentativas = 6;
			break;
		default:
			totaltentativas = 3;
			break;
	}
    
    // Cria o loop do jogo
    for(int i = 1; i <= totaltentativas; i++)
    {
    	// Mostra as tentativas
    	printf("Tentativa %d de %d \n", i, totaltentativas);
    	
    	// Recebe o chute do jogador
    	printf ("Qual eh o seu chute? ");
    	scanf("%d", &chute);
    	
    	// Salva os resultados
    	acertou = chute == numerosecreto;
    	maior = chute > numerosecreto;
    	menor = chute < numerosecreto;
    	
    	// Verifica se o numero é natural
    	if (chute < 0)
    	{
    		printf("Utilize apenas numeros maiores que 0 \n");
    		i--;
    		continue; // Reinicia o bloco de codigo, sem fazer a sequencia abaixo
		}
    
    	// Verifica se o jogador acertou
    	if (acertou)
    	{
    		break; // Para o loop no caso de acerto
		}
		else
		{
			printf("Erroooou!! \n");
			if (maior)
			{
				printf("O seu chute foi maior que o numero secreto... \n");
			}
			if (menor)
			{
				printf("O seu chute foi menor que o numero secreto... \n");
			}
		}
		
		// Calcula os pontos
		double pontosperdidos = abs(chute - numerosecreto) / 2.0; // Se o numero for negativo, ele é invertido para não somar pontos
		pontos = pontos - pontosperdidos;
	}
	
	// Encerra o jogo
	if (!acertou)
	{
		printf("                    /     \\\n");
		printf("                   ((     ))\n");
		printf("               ===  \\\\_v_//  ===\n");
		printf("                 ====)_^_(====\n");
		printf("                 ===/ O O \\===\n");
		printf("                 = | /_ _\\ | =\n");
		printf("                =   \\/_ _\\/   =\n");
		printf("                     \\_ _/\n");
		printf("                     (o_o)\n");
		printf("                      VwV\n");
		printf("\nVoce perdeu! Tente novamente!\n\n");
	}
	if (acertou)
	{
		printf("   . \n");
		printf("  / \\ \n");
		printf("  | | \n");
		printf("  |.| \n");
		printf("  |.| \n");
		printf("  |:|      __ \n");
		printf(",_|:|_,   /  ) \n");
		printf("  (Oo    / _I_ \n");
		printf("   +\\ \\  || __| \n");
		printf("      \\ \\||___| \n");
		printf("        \\ /.:.\\-\\ \n");
		printf("         |.:. /-----\\ \n");
		printf("         |___|::oOo::| \n");
		printf("         /   |:<_T_>:| \n");
		printf("        |_____\\ ::: / \n");
		printf("         | |  \\ \\:/ \n");
		printf("         | |   | | \n");
		printf("         \\ /   | \\___ \n");
		printf("         / |   \\_____\\ \n");
		printf("         `-' \n");
		printf("\nParabens! Voce acertou!\n");
		printf("Voce fez %.2f pontos \n", pontos);
	}
	printf("Obrigado por jogar! \n");
}
