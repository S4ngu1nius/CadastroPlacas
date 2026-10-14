/*
 Programa de cadastro de placas de veículos em C#.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CadastroPlacas
{
    class Program
    {
        static void Main(string[] args)
        {
            // Cria uma lista para armazenar as placas cadastradas
            List<string> placas = new List<string>();
            // Loop principal do programa
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Cadastro de Placas de Veículos ===");
                Console.WriteLine("1. Cadastrar placa");
                Console.WriteLine("2. Listar placas cadastradas");
                Console.WriteLine("3. Sair");
                Console.Write("Escolha uma opção: ");
                string opcao = Console.ReadLine();
                switch (opcao)
                {
                    case "1":
                        CadastrarPlaca(placas);
                        break;
                    case "2":
                        ListarPlacas(placas);
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opção inválida! Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }
        static void CadastrarPlaca(List<string> placas)
        {
            Console.Clear();
            Console.WriteLine("=== Cadastro de Placa ===");
            Console.Write("Digite a placa do veículo (ex: ABC-1234): ");
            string placa = Console.ReadLine();
            // Valida a placa
            if (ValidarPlaca(placa))
            {
                placas.Add(placa.ToUpper());
                Console.WriteLine("Placa cadastrada com sucesso!");
            }
            else
            {
                Console.WriteLine("Placa inválida! Pressione qualquer tecla para continuar...");
            }
            Console.ReadKey();
        }
        static void ListarPlacas(List<string> placas)
        {
            Console.Clear();
            Console.WriteLine("=== Placas Cadastradas ===");
            if (placas.Count == 0)
            {
                Console.WriteLine("Nenhuma placa cadastrada.");
            }
            else
            {
                foreach (var placa in placas)
                {
                    Console.WriteLine(placa);
                }
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        }
        static bool ValidarPlaca(string placa)
        {
            // Valida o formato da placa (ex: ABC-1234)
            if (string.IsNullOrWhiteSpace(placa) || placa.Length != 8)
                return false;

            placa = placa.ToUpper();

            // ABC-1234
            for (int i = 0; i < 3; i++)
            {
                if (!char.IsLetter(placa[i]))
                    return false;
            }
            if (placa[3] != '-')
                return false;
            for (int i = 4; i < 8; i++)
            {
                if (!char.IsDigit(placa[i]))
                    return false;
            }
            return true;
        }
    }
}