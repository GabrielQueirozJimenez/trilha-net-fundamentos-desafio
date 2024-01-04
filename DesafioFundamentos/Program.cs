using System.Collections;
using System.Threading;
using DesafioFundamentos.Models;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

decimal precoInicial = 0;
decimal precoPorHora = 0;
Estacionamento intro = new Estacionamento(0,0);

string apresentaçao = "   BEM-VINDO AO ESTACIONAMENTO AUTÔNOMO";
int linha_lenght = apresentaçao.Length+4;

//-----------------------------------------------------------------------------------------------APRESENTAÇÃO
Console.WriteLine($"{new string('-',linha_lenght)}\n{apresentaçao}\n{new string('-',linha_lenght)}{new string('\n',2)}");
Console.WriteLine("Como gostaria de prosseguir?\n");
Console.WriteLine("1 - Cliente");
Console.WriteLine("2 - Funcionário");
string escolha = Console.ReadLine();

switch(escolha)
{
    case "1":
    {
        Console.Clear();
        Console.WriteLine("Qual o seu nome: ");
        string nome = Console.ReadLine();
        DateTime começo_cliente = DateTime.Now;

        while(true)
        {
            Console.Clear();
            Console.WriteLine($"Olá {nome}.\nO preço padrão no estacionamento é de R$5,00 + R$1,50 por hora.");
            Console.WriteLine($"O que você deseja fazer?{new string ('\n',2)}1 - Buscar vaga\n2 - Remover seu veículo\n3 - Cancelar");
            string escolha_cliente = Console.ReadLine();
            switch(escolha_cliente)
            {
                case "1":
                {
                    Console.WriteLine("Iremos agora verificar se há vagas disponiveis.");

                    Thread.Sleep(3500);
                    Console.Clear();
                    Console.WriteLine("Verificando...");  

                    Thread.Sleep(4000);
                    Random random = new Random();
                    int prob_vaga = random.Next(1,11);

                    if(prob_vaga<=3)
                    {
                        Console.WriteLine("Infelizmente, não há mais vagas disponiveis. =(");
                        Thread.Sleep(2000);
                        break;
                    } else
                    {
                        Console.WriteLine("Vaga encontrada!!!");
                        Thread.Sleep(3000);
                        Console.Clear();
                        Console.WriteLine("Vamos agora, iniciar o cadastro do seu veículo");
                        Thread.Sleep(2000);
                        intro.AdicionarVeiculo_Ciente();
                    }
                    break;
                }
                case "2":
                {
                    Console.WriteLine("Preparando o processo de remoção do veículo...");
                    Thread.Sleep(3000);
                    Console.Clear();
                    intro.RemoverVeiculo_Cliente(começo_cliente);
                    break;
                }
                case "3":
                {
                    Console.WriteLine("Encerrando processo...");
                    Thread.Sleep(2500);
                    Console.WriteLine("Tenha um bom dia");
                    Thread.Sleep(2000);
                    Console.Clear();
                    return;
                }
            }
        }
    }
//-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=------------------------------------------------------------
    case "2":
    {
        Console.Clear();
        Console.WriteLine("Seja bem vindo ao sistema de estacionamento!\n" +
                  "Digite o preço inicial:");
        precoInicial = Convert.ToDecimal(Console.ReadLine());

        Console.WriteLine("Agora digite o preço por hora:");
        precoPorHora = Convert.ToDecimal(Console.ReadLine());

        // Instancia a classe Estacionamento, já com os valores obtidos anteriormente
        Estacionamento es = new Estacionamento(precoInicial, precoPorHora);

        string opcao = string.Empty;
        bool exibirMenu = true;

        // Realiza o loop do menu
        while (exibirMenu)
        {
            Console.Clear();
            Console.WriteLine("Digite a sua opção:");
            Console.WriteLine("1 - Cadastrar veículo");
            Console.WriteLine("2 - Remover veículo");
            Console.WriteLine("3 - Listar veículos");
            Console.WriteLine("4 - Encerrar");

            switch (Console.ReadLine())
            {
                case "1":
                    es.AdicionarVeiculo();
                    break;

                case "2":
                    es.RemoverVeiculo();
                    break;

                case "3":
                    es.ListarVeiculos();
                    break;

                case "4":
                    exibirMenu = false;
                    break;

                default:
                    Console.WriteLine("Opção inválida");
                    break;
            }

            Console.WriteLine("Pressione uma tecla para continuar");
            Console.ReadLine();
        }

        Console.WriteLine("O programa se encerrou");
        break;
    }
    
    default:
    {
        Console.WriteLine("Opção invalida, tente outra vez");
        break;
    }
}
Console.WriteLine("Até Logo!!");