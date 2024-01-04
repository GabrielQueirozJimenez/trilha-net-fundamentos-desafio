using Microsoft.VisualBasic;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
//--------------------------------------------------------------------------------------------------------VARIÁVEIS
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

//--------------------------------------------------------------------------------------------------------CLIENTE
        public void AdicionarVeiculo_Ciente()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(Console.ReadLine());
            Console.WriteLine($"Veículo adicionado com sucesso");
            Thread.Sleep(2500);
        }

        public void RemoverVeiculo_Cliente(DateTime começo)
        {
            Console.WriteLine("Digite a placa do seu veículo para remover:");


            string placa = Console.ReadLine();

            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                DateTime fim = DateTime.Now;
                

                TimeSpan horas = fim - começo;
                decimal taxa = 1.50m;
                decimal valorTotal = 5m + (decimal)horas.TotalHours*taxa;

                veiculos.Remove(placa);


                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal:F2}");
                Thread.Sleep(3000);
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
                Thread.Sleep(2500);
            }
        }


//--------------------------------------------------------------------------------------------------------FUNCIONÁRIO

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para estacionar:");
            veiculos.Add(Console.ReadLine());
        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");

            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = int.Parse(Console.ReadLine());
                decimal valorTotal = precoInicial + (precoPorHora*horas);

                veiculos.Remove(placa);

                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
                foreach(string automovel in veiculos)
                {
                    Console.WriteLine(automovel);
                }
            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}