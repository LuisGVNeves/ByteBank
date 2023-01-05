using byteBank;
using validacoes;
using ClasseBanco;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Usuarios
{
    internal class Usuario
    {
        // Lista Usuário
        public static List<string> nome = new List<string>();
        public static List<int> idade = new List<int>();
        public static List<double> saldo = new List<double>();
        public static List<string> cpf = new List<string>();
        public static List<string> senha = new List<string>();


        // # Método para CriarUsuario
        public static void CriarUsuario(List<string> nome, List<int> idade, List<double> saldo, List<string> cpf, List<string> senha)
        {
            // Input dos usuários com validação
            Validacoes.ValidarNome(nome);
            Validacoes.ValidarIdade(idade);
            Validacoes.ValidarSaldo(saldo);



            Console.Write("                      Digite o cpf do usuário: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            cpf.Add(Console.ReadLine());
            Console.ResetColor();

            Console.Write("                      Digite a senha do usuário: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            senha.Add(Console.ReadLine());
            Console.ResetColor();

            // # Mensagem de sucesso
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\n                      Usuário criado com sucesso !\n\n");
            Console.ResetColor();

            System.Threading.Thread.Sleep(1200);
            Console.Clear();
            Program.MostrarMenuPrincipal();
        }



        // # Método para deletar o usuário
        public static void DeletarUsuario(List<string> nome, List<int> idade, List<double> saldo, List<string> cpf, List<string> senha)
        {
            Console.Write("\nDigite o nome do usuário: ");
            string nomeDeletar = Console.ReadLine();

            for (int i = 0; i < nome.Count(); i++)
            {
                if (nomeDeletar == nome[i])
                {
                    Console.Write($"\n" +
                    $"O usuário: {nome[i]} irá ser deletado, deseja realmente excluir a conta? SIM ou NÃO: ");
                    string perguntaConfirmacao = Console.ReadLine().ToUpper();

                    if (perguntaConfirmacao == "SIM")
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\nUsuário {nome[i]} deletado com sucesso !\n");
                        Console.ResetColor();

                        nome.Remove(nome[i]);
                        idade.Remove(idade[i]);
                        saldo.Remove(saldo[i]);
                        cpf.Remove(cpf[i]);
                        senha.Remove(senha[i]);

                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();

                        Program.MostrarMenuPrincipal();
                    }
                    else if (perguntaConfirmacao == "NAO" || perguntaConfirmacao == "NÃO")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("\nOperação cancelada com sucesso !\n");
                        Console.ResetColor();

                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();

                        Program.MostrarMenuPrincipal();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUSUÁRIO NÃO ACHADO\n");
                    Console.ResetColor();
                }
            }

            Console.WriteLine("\nConta deletada com sucesso");
            Console.Clear();
            Program.MostrarMenuPrincipal();
        }

        // # Método para listar todos os usuários no banco
        public static void ListarTodosUsuariosDoBanco(List<string> nome, List<string> cpf, List<double> saldo, List<int> idade)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n***LISTA DE USUÁRIOS BYTEBANK***");
            Console.ResetColor();

            for (int i = 0; i < nome.Count; i++)
            {
                Console.WriteLine($"\n Nome: {nome[i]} \nIdade: {idade[i]} \nSaldo: R${saldo[i]}\n CPF:{cpf[i]}");
            }

            Console.WriteLine("\n\n\n");
            Usuario.LimparTerminal();
        }

        // # Método para mostrar o saldo do usuario
        public static void MostrarSaldoTotalBanco(List<string> nome, List<double> saldo, List<string> senha)
        {
            // Limite de tentativas pra achar o nome no banco
            int tentativas = 0;

            Console.Write("\nDigite o nome completo do usuário para checar saldo total da conta: ");
            string nomeUsuario = Console.ReadLine();

            // Validação para ver se usuário quer checar algum nome antes mesmo de preencher um cadastro
            if (nome.Count() == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNenhum usuário cadastrado");
                Console.ResetColor();

                System.Threading.Thread.Sleep(1500);
                Console.Clear();
                Program.MostrarMenuPrincipal();

                return;
            }

            for (int i = 0; i < nome.Count(); i++)
            {
                // Enquanto não achar o nome preenchido no cadastro
                while (nome[i] != nomeUsuario)
                {
                    tentativas++;

                    if (tentativas <= 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($"\n          Número de tentativas: {tentativas}\n");
                        Console.ResetColor();

                        Console.Write("\n          Digite um nome válido: ");
                        nomeUsuario = Console.ReadLine();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("\nNúmero máximo de tentativas atingidas !\n");
                        Console.ResetColor();

                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        Program.MostrarMenuPrincipal();
                        break;
                    }

                    // Se usuario cadastrou nome e for igual aos objetos usuario já cadastrados, então dá pra ver o valor
                    if (nome[i] == nomeUsuario)
                    {

                        Console.Write("\nDigite a senha do usuário para checar saldo total da conta: ");
                        string senhaUsuario = Console.ReadLine();

                        while (senhaUsuario != senha[i])
                        {
                            Console.WriteLine("\nSenha inválida\n");
                            Console.Write("Digite Novamente: ");
                            senhaUsuario = Console.ReadLine();
                        }

                        if (nome[i] == nomeUsuario && senha[i] == senhaUsuario)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\nSaldo total no banco: R$ {saldo.Sum()}");
                            Console.ResetColor();

                            Usuario.LimparTerminal();
                            break;
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("USUÁRIO NÃO ENCONTRADO\n");
                            Console.ResetColor();

                            System.Threading.Thread.Sleep(1500);
                            Console.Clear();

                            Usuario.LimparTerminal();
                            break;
                        }

                    }

                }

            }
        }


        // # Método para apresentar usuário unico
        public static void DetalhesUsuario(List<string> nome, List<double> saldo, List<int> idade)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n***DETALHES DO USUÁRIO***");
            Console.ResetColor();

            Console.Write("Digite o nome do usuario: ");
            string nomeUsuario = Console.ReadLine();

            for (int i = 0; i < nome.Count; i++)
            {
                if (nomeUsuario == nome[i])
                {
                    Console.WriteLine($"Nome usuário: {nome[i]}");
                    Console.WriteLine($"Saldo usuário: {saldo[i]}");
                    Console.WriteLine($"Idade usuário: {idade[i]}");
                }
            }

            Console.WriteLine("\n\n");
            Usuario.LimparTerminal();
        }

        // # Método para limpar o terminal
        public static void LimparTerminal()
        {
            // # Tratamento pra ver se o usuário deseja limpar a tela

            Console.Write("\nDeseja voltar ao Menu? SIM ou NÃO: ");
            string perguntaUsuario = Console.ReadLine().ToUpper();

            if (perguntaUsuario == "SIM")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- Limpando ---");
                Console.ResetColor();
                System.Threading.Thread.Sleep(500);
                Console.Clear();

                Program.MostrarMenuPrincipal();
            }
            if (perguntaUsuario == "NÃO" || perguntaUsuario == "NAO")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nRedirecionando para o inicío.. ");
                Console.ResetColor();

                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                Program.MenuInicial();
            }
        }

    }
}
