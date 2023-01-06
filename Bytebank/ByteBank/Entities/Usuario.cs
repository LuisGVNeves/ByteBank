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
            Validacoes.ValidarSenha(senha);
            Validacoes.ValidarCPF(nome,idade,saldo,cpf,senha);

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
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Clear();
            Console.WriteLine(@"╔═════════════════════════ DELETAR CONTA ════════════════════════╗");
            Console.ResetColor();
            Console.WriteLine("\n\n Usuários cadastrados:");

            // Usuarios disponiveis
            for (int i = 0; i < nome.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                          Nome:");
                Console.ResetColor();
                Console.Write($"  {nome[i]}");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                          Idade:");
                Console.ResetColor();
                Console.Write($"  {idade[i]}");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                          Saldo:");
                Console.ResetColor();
                Console.Write($"  {saldo[i]} R$");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                          CPF:");
                Console.ResetColor();
                Console.Write($"  {cpf[i]}\n");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("            ════════════════════════════════════════════");
                Console.ResetColor();

            }

            // Verifica se não tem ninguém cadastrado então o menu não aparece para deletar
            if (Program.contadorUsuarios == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\n                     USUÁRIO NÃO ACHADO\n");
                Console.ResetColor();

                System.Threading.Thread.Sleep(1500);
                Console.Clear();

                Program.MostrarMenuPrincipal();
                return;
            }

            // Remover usuario
            Console.Write("\n\n\nDigite o nome a deletar: ");
            string nomeDeletar = Console.ReadLine();

            int nomePercorrido = nome.FindIndex(nome => nome == nomeDeletar);

            while(nomePercorrido == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNOME NÃO ACHADO");
                Console.ResetColor();

                Console.Write("\nDeseja tentar de novo? SIM ou NÃO: ");
                string respostaUsuario = Console.ReadLine().ToUpper();

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("════════════════════════════════════════════");
                Console.ResetColor();

                if (respostaUsuario == "SIM")
                {
                    Console.Write("\n\nDigite o nome a deletar: ");
                    nomeDeletar = Console.ReadLine();

                    nomePercorrido = nome.FindIndex(nome => nome == nomeDeletar);
                }

                if (respostaUsuario == "NÃO" || respostaUsuario == "NAO")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n                     Voltando ao menu principal\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                    Program.MostrarMenuPrincipal();
                    return;
                }
            }

            Console.Write($"\nO usuário: {nomeDeletar} irá ser deletado, deseja realmente excluir a conta? SIM ou NÃO: ");
            string perguntaConfirmacao = Console.ReadLine().ToUpper();

            if (perguntaConfirmacao == "SIM")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nUsuário {nomeDeletar} deletado com sucesso !\n");
                Console.ResetColor();

                cpf.Remove(nomeDeletar);
                nome.RemoveAt(nomePercorrido);
                senha.RemoveAt(nomePercorrido);
                saldo.RemoveAt(nomePercorrido);

                // Limite de usuarios criados vai diminuir quando excluir usuario
                Program.contadorUsuarios--;

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
            else
            {
                Console.Clear();
                Program.MostrarMenuPrincipal();
            }

            return;
        }

        // # Método para listar todos os usuários no banco
        public static void ListarTodosUsuariosDoBanco(List<string> nome, List<string> cpf, List<double> saldo, List<int> idade)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine(@"╔═════════════════════════ LISTA DE USUÁRIOS BYTEBANK ════════════════════════╗");
            Console.ResetColor();

            for (int i = 0; i < nome.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n\n                               Nome:");
                Console.ResetColor();
                Console.Write($"  {nome[i]}");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n                               Idade:");
                Console.ResetColor();
                Console.Write($"  {idade[i]}");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n                               Saldo:");
                Console.ResetColor();
                Console.Write($"  {saldo[i].ToString("F2", CultureInfo.InvariantCulture)} R$");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("\n                               CPF:");
                Console.ResetColor();
                Console.Write($"  {cpf[i]}\n");

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("                   ════════════════════════════════════════════");
                Console.ResetColor();

            }

            Console.WriteLine("\n\n\n");
            Usuario.LimparTerminal();
        }

        // # Método para mostrar o saldo do usuario
        public static void MostrarSaldoTotalBanco(List<string> nome, List<double> saldo, List<string> senha)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(@"╔═════════════════════════ SALDO USUÁRIOS BYTEBANK ════════════════════════╗");
            Console.ResetColor();
            Console.WriteLine("\n\nUsuários disponíveis: \n");

            // Mostrar quantos usuários tem no banco (facilitar o acesso)
            for (int i = 0; i < nome.Count(); i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("                               Nome:");
                Console.ResetColor();
                Console.Write($"  {nome[i]}\n");
            }
            Console.Write("\n                  ════════════════════════════════════════════\n\n");
            Console.ResetColor();

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

            Console.Write("\nDigite o nome completo do usuário para checar saldo total da conta: ");
            string nomeUsuario = Console.ReadLine();

            for (int i = 0; i < nome.Count; i++)
            {
                if (nomeUsuario == nome[i])
                {
                    if (nomeUsuario == Banco.usuarioEnviarTransferencia)
                    {
                        saldo[i] = Banco.saldoUsuario1;
                    }
                    if (nomeUsuario == Banco.usuarioReceberTransferencia)
                    {
                        saldo[i] = Banco.saldoUsuario2;
                    }
                    Console.WriteLine($"\nNome usuário: {nome[i]}");
                    Console.WriteLine($"Saldo total usuário: {(saldo[i].ToString("F2", CultureInfo.InvariantCulture))}");
                }

            }
            Usuario.LimparTerminal();

        }

        // # Método para apresentar usuário unico
        public static void DetalhesUsuario(List<string> nome, List<double> saldo, List<int> idade)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine(@"╔═════════════════════════ DETALHES USUÁRIO ════════════════════════╗");
            Console.ResetColor();


            Console.Write("                      Digite o nome do usuario: ");
            string nomeUsuario = Console.ReadLine();

            for (int i = 0; i < nome.Count; i++)
            {
                if (nomeUsuario == nome[i])
                {
                    Console.WriteLine("\n\n");
                    Console.WriteLine(@"            ╔═════════════════════════════════════════════════╗");
                    Console.WriteLine($"                        Nome usuário: {nome[i]}");
                    Console.WriteLine($"                        Saldo usuário: {saldo[i].ToString("F2", CultureInfo.InvariantCulture)}");
                    Console.WriteLine($"                        Idade usuário: {idade[i]}");
                    Console.WriteLine($"                        CPF usuário: {cpf[i]}");
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
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nRedirecionando para o inicío.. ");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
                Program.MostrarMenuPrincipal();
            }
        }


    }
    
}
