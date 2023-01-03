using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios
{
    internal class Usuario
    {
        // # Atributos Usuario
        public string Nome;
        public int Idade;
        public double Saldo;
        public string Cpf;
        public string Senha;
        public int Id;

        // # Lista para guardar usuarios
        public static ArrayList usuarios = new ArrayList();

        // # Constructor
        public Usuario(string nome, string cpf, int idade, double saldo, string senha)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Saldo = saldo;
            this.Cpf = cpf;
            this.Senha = senha;
        }

        // # Método para limpar o terminal
        public static void LimparTerminal()
        {
            // # Tratamento pra ver se o usuário deseja limpar a tela

            Console.Write("Deseja limpar a tela? SIM ou NÃO: ");
            string perguntaUsuario = Console.ReadLine().ToUpper();

            while (perguntaUsuario != "SIM")
            {
                System.Threading.Thread.Sleep(2000);
                Console.Write("Deseja limpar a tela? SIM ou NÃO: ");
                perguntaUsuario = Console.ReadLine().ToUpper();
            }

            if (perguntaUsuario == "SIM")
            {
                // # Pausa antes do clear
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- Limpando ---");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }

        // # Método para mostrar o menu inicial
        public static void MenuInicial()
        {
            // # Boas vindas do banco
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("-------------------------- BEM-VINDO AO BYTEBANK --------------------------");
            Console.ResetColor();
            Console.WriteLine("ByteBank é um banco terminal feito em C#, com conhecimentos aprendidos");
            Console.WriteLine("na escola Imã Learning Place.");
            Console.WriteLine("\n\nPor favor, preencha seu cadastro antes de continuar:");
            Console.WriteLine("\n");
        }

        // # Método para preencher as informações do primeiro usuário criado - class Program Line 17
        public static void PreencherInformacoesUsuario(Usuario novoUsuario)
        {
            Console.Write("Digite o nome completo do usuário: ");
            novoUsuario.Nome = Console.ReadLine();

            Console.Write("Digite a idade do usuario: ");
            novoUsuario.Idade = int.Parse(Console.ReadLine());

            Console.Write("Digite o CPF do usuario: ");
            novoUsuario.Cpf = Console.ReadLine();

            Console.Write("Digite o saldo do usuario: ");
            novoUsuario.Saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("\n");

            Console.Write("Digite a senha do usuario: ");
            novoUsuario.Senha = Console.ReadLine();
            Console.WriteLine("\n");

            // # Adicionando novo usuário na lista
            usuarios.Add(novoUsuario);

            // # Mensagem de sucesso
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuário criado com sucesso !");

            System.Threading.Thread.Sleep(1500);
            Console.Clear();
        }

        // # Método para mostrar o menu principal ao usuario
        public static void ShowMenuPrincipal()
        {
            // # Boas vindas do banco
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("-------------------------- INTERFACE BYTEBANK --------------------------");
            Console.ResetColor();

            Console.WriteLine("\n                        1 - Inserir novo usuário");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                        2 - Deletar um usuário");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("                        3 - Listar todas as contas registradas");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("                        4 - Total armazenado no banco");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("                        5 - Detalhes de um usuário");
            Console.ResetColor();

            Console.WriteLine("                        6 - Manipular a conta");
            Console.WriteLine("                        0 - Para sair do programa");
            Console.Write("\n                        Digite a opção desejada: ");
        }
    }
}
