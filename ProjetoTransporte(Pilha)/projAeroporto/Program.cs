using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjetoAeoroporto.Models;
using ProjetoAeoroporto.Controllers;

namespace ProjetoAeoroporto
{
    class Program
    {
        static Veiculos veiculos = new Veiculos();
        static Garagens garagens = new Garagens();
        static Viagens viagens = new Viagens();
        static List<Transporte> transportes = new List<Transporte>();
        static bool emJornada = false;

        static void Main(string[] args)
        {
            string op = "";

            do {
                Console.Clear();
                op = menu();
                switch (op) {
                    case "0": break;
                    case "1": cadastrarVeiculo(); break;
                    case "2": cadastrarGaragem(); break;
                    case "3": iniciarJornada(); break;
                    case "4": encerrarJornada(); break;
                    case "5": liberarViagem(); break;
                    case "6": listarVeiculosGaragem(); break;
                    case "7": qtdeViagensEfetuadas(); break;
                    case "8": listarViagensEfetuadas(); break;
                    case "9": informarPassageiro(); break;
                }
            } while (op != "0");
        }

        static string menu() {
            Console.WriteLine("0. Sair \n" +
                "1. Cadastrar veículo \n" +
                "2. Cadastrar garagem \n" +
                "3. Iniciar jornada \n" +
                "4. Encerrar jornada \n" +
                "5. Liberar viagem de uma determinada origem para um determinado destino \n" +
                "6. Listar veículos em determinada garagem (informando a qtde de veículos e seu potencial de transporte) \n" +
                "7. Informar qtde de viagens efetuadas de uma determinada origem para um determinado destino \n" +
                "8. Listar viagens efetuadas de uma determinada origem para um determinado destino \n" +
                "9. Informar qtde de passageiros transportados de uma determinada origem para um determinado destino ");
            Console.Write("Digite um opção: ");
            return Console.ReadLine();
        }

        static void cadastrarVeiculo() {
            if (!emJornada)
            {
                Console.Write("Digite o ID: ");
                int id = Int32.Parse(Console.ReadLine());

                Console.Write("Digite a placa: ");
                string placa = Console.ReadLine();

                Console.Write("Digite a lotação: ");
                int lotacao = Int32.Parse(Console.ReadLine());

                veiculos.incluir(new Veiculo(id, placa, lotacao));
            }
        }

        static void cadastrarGaragem()
        {
            if (!emJornada)
            {
                Console.Write("Digite o ID: ");
                int id = Int32.Parse(Console.ReadLine());

                Console.Write("Digite a local: ");
                string local = Console.ReadLine();

                garagens.incluir(new Garagem(id, local));
            }
        }

        static void iniciarJornada() {
            int i = 0;
            foreach (Veiculo veiculo in veiculos.ListVeiculos) {
                if(i < garagens.ListGaragens.Count) garagens.ListGaragens[i].adicionarVeiculo(veiculo);
                if (i == garagens.ListGaragens.Count) i = 0;
                else i++;
            }
            emJornada = true;
        }

        static void encerrarJornada() {
            for (int i = 0; i < viagens.QueueViagens.Count; i++) {
                Viagem viagem = viagens.QueueViagens.Dequeue();
                transportes.Add(new Transporte(viagem.Veiculo, viagem.Veiculo.Lotacao));
            }
        }

        static void liberarViagem() {
            Console.Write("Digite o ID: ");
            int id = Int32.Parse(Console.ReadLine());

            Console.Write("Digite o ID de origem: ");
            int idOrigem = Int32.Parse(Console.ReadLine());
            Garagem origem = garagens.pesquisar(idOrigem);

            Console.Write("Digite o ID de destino: ");
            int idDestino = Int32.Parse(Console.ReadLine());
            Garagem destino = garagens.pesquisar(idDestino);

            Veiculo veiculo = origem.Veiculos.Pop();
            destino.Veiculos.Push(veiculo);
            viagens.incluir(new Viagem(id, origem, destino, veiculo));
        }

        static void listarVeiculosGaragem() {
            Console.Write("Digite o ID da garagem: ");
            int id = Int32.Parse(Console.ReadLine());
            Garagem garagem = garagens.pesquisar(id);
            Console.WriteLine("Quantidade de veículos: " + garagem.Veiculos.Count);
            int potencial = 0;
            garagem.Veiculos.ToList().ForEach(v => potencial += v.Lotacao);
            Console.WriteLine("Potencial de transporte: " + potencial);
            Console.ReadKey();
        }

        static void qtdeViagensEfetuadas() {
            Console.WriteLine("Digite o ID de origem: ");
            int idOrigem = Int32.Parse(Console.ReadLine());
            Garagem origem = garagens.pesquisar(idOrigem);

            Console.Write("Digite o ID de destino: ");
            int idDestino = Int32.Parse(Console.ReadLine());
            Garagem destino = garagens.pesquisar(idDestino);

            int qtde = 0;
            viagens.QueueViagens.ToList().ForEach(v => {
                if (v.Origem.Equals(origem) && v.Destino.Equals(destino)) qtde++;
            });
            Console.WriteLine("Quantidade de viagens efetuadas de {0} para {1}: {2}", origem.Local, destino.Local, qtde);
            Console.ReadKey();
        }

        static void listarViagensEfetuadas()
        {
            Console.WriteLine("Digite o ID de origem: ");
            int idOrigem = Int32.Parse(Console.ReadLine());
            Garagem origem = garagens.pesquisar(idOrigem);

            Console.Write("Digite o ID de destino: ");
            int idDestino = Int32.Parse(Console.ReadLine());
            Garagem destino = garagens.pesquisar(idDestino);
            
            viagens.QueueViagens.ToList().ForEach(v => {
                if (v.Origem.Equals(origem) && v.Destino.Equals(destino)) {
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("Id: " + v.Id);
                    Console.WriteLine("Origem: {0} - {1}", v.Origem.Id, v.Origem.Local);
                    Console.WriteLine("Destino: {0} - {1}", v.Destino.Id, v.Destino.Local);
                    Console.WriteLine("Veículo: {0} - {1} - {2}", v.Veiculo.Id, v.Veiculo.Placa, v.Veiculo.Lotacao);
                }
            });
            Console.ReadKey();
        }

        static void informarPassageiro() {
            Console.WriteLine("Digite o ID de origem: ");
            int idOrigem = Int32.Parse(Console.ReadLine());
            Garagem origem = garagens.pesquisar(idOrigem);

            Console.Write("Digite o ID de destino: ");
            int idDestino = Int32.Parse(Console.ReadLine());
            Garagem destino = garagens.pesquisar(idDestino);

            int qtd = 0;
            viagens.QueueViagens.ToList().ForEach(v => {
                if (v.Origem.Equals(origem) && v.Destino.Equals(destino))
                {
                    qtd += v.Veiculo.Lotacao;                   
                }
            });
            Console.WriteLine("Quantidade: " + qtd);
            Console.ReadKey();
        }
    }
}
