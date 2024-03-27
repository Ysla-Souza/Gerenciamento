using System;
using System.Collections.Generic;
using Model;

namespace Principal
{
    public static class Menu
    {
        private static readonly List<Equipamento> equipamentos = new List<Equipamento>();

        public static void Iniciar()
        {
            while (true)
            {
                MostrarMenu();
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        CadastrarEquipamento();
                        break;
                    case "2":
                        VisualizarInsumos();
                        break;
                    case "3":
                        RealizarCheckin();
                        break;
                    case "4":
                        RealizarCheckout();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }

        private static void MostrarMenu()
        {
            Console.WriteLine("Selecione uma opção:");
            Console.WriteLine("1 - Cadastrar equipamento");
            Console.WriteLine("2 - Visualizar todos os insumos inseridos nos equipamentos");
            Console.WriteLine("3 - Realizar Checkin do insumo");
            Console.WriteLine("4 - Realizar Checkout do insumo");
            Console.WriteLine("5 - Sair");
        }

        private static void CadastrarEquipamento()
        {
            Console.WriteLine("Digite o ID do equipamento:");
            string id = Console.ReadLine();

            if (string.IsNullOrEmpty(id))
            {
                Console.WriteLine("ID do equipamento não pode ser nulo ou vazio.");
                return;
            }

            Console.WriteLine("Digite o nome do equipamento:");
            string nome = Console.ReadLine();

            if (string.IsNullOrEmpty(nome))
            {
                Console.WriteLine("Nome do equipamento não pode ser nulo ou vazio.");
                return;
            }

            Equipamento equipamento = new Equipamento(id, nome);
            equipamentos.Add(equipamento);
            Console.WriteLine("Equipamento cadastrado com sucesso!");
        }

        private static void VisualizarInsumos()
        {
            Console.WriteLine("Insumos cadastrados nos equipamentos:");

            foreach (Equipamento equipamento in equipamentos)
            {
                Console.WriteLine($"Equipamento: {equipamento.Nome}");

                if (equipamento.Insumos.Count > 0)
                {
                    Console.WriteLine("Insumos:");

                    foreach (Insumo insumo in equipamento.Insumos)
                    {
                        Console.WriteLine($"- ID: {insumo.Id}, Tipo: {insumo.Tipo}, Data de Validade: {insumo.DataValidade.ToString("dd/MM/yyyy")}");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum insumo cadastrado neste equipamento.");
                }

                Console.WriteLine();
            }
        }

        private static void RealizarCheckin()
        {
            Console.WriteLine("Digite o ID do insumo:");
            string id = Console.ReadLine();

            Console.WriteLine("Digite o tipo do insumo:");
            string tipo = Console.ReadLine();

            Console.WriteLine("Digite a data de validade (dd/mm/aaaa):");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataValidade))
            {
                Console.WriteLine("Data de validade inválida.");
                return;
            }

            Console.WriteLine("Digite o ID do equipamento onde deseja adicionar o insumo:");
            string idEquipamento = Console.ReadLine();
            Equipamento equipamento = equipamentos.Find(e => e.Id == idEquipamento);

            if (equipamento == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            Insumo insumo = new Insumo(id, tipo, dataValidade);
            equipamento.AdicionarInsumo(insumo);
            Console.WriteLine($"Insumo cadastrado com sucesso no equipamento: {equipamento.Nome} com data de validade: {dataValidade.ToString("dd/MM/yyyy")}");
        }

        private static void RealizarCheckout()
        {
            Console.WriteLine("Digite o ID do insumo:");
            string idInsumo = Console.ReadLine();

            Insumo insumo = null;
            Equipamento equipamentoDoInsumo = null;

            foreach (Equipamento equip in equipamentos)
            {
                insumo = equip.Insumos.Find(i => i.Id == idInsumo);
                if (insumo != null)
                {
                    equipamentoDoInsumo = equip;
                    break;
                }
            }

            if (insumo == null)
            {
                Console.WriteLine("Insumo não encontrado.");
                return;
            }

            Console.WriteLine("Digite o ID do equipamento para realizar o Checkout:");
            string idEquipamento = Console.ReadLine();
            Equipamento equipamento = equipamentos.Find(e => e.Id == idEquipamento);

            if (equipamento == null)
            {
                Console.WriteLine("Equipamento não encontrado.");
                return;
            }

            if (equipamentoDoInsumo != equipamento)
            {
                Console.WriteLine("Este insumo não está neste equipamento.");
                return;
            }

            equipamento.RemoverInsumo(insumo);
            Console.WriteLine("Check-out realizado com sucesso!");
        }
    }
}
