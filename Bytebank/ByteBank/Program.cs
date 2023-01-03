using byteBank;
using Usuarios;
using ClasseBanco;
using System.Collections;
using System.Drawing;
using System.Globalization;

namespace byteBank
{
    class Program
    {

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
            Console.Write("\n\nDeseja iniciar um cadastro? SIM ou NÃO: ");
            string respostaUsuario = Console.ReadLine().ToUpper();
            if (respostaUsuario == "SIM")
            {
                Banco.CriarUsuario();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("-------------------------- Encerrando programa --------------------------");
                Console.ResetColor();
                Environment.Exit(0);
            }
        }

        // # Método para mostrar o menu principal ao usuario
        public static void MostrarMenuPrincipal()
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


        public static void Main(string[] args)
        {
            // # Menu inicial pro usuário
            MenuInicial();

            int escolhaUsuario;
            do
            {
                // # Método que mostra o menu principal ao usuário
                MostrarMenuPrincipal();

                escolhaUsuario = int.Parse(Console.ReadLine());

                switch (escolhaUsuario)
                {
                    case 1:
                        Banco.CriarUsuario();
                        break;
                    case 2:
                        string cpf = "";
                        Banco.DeletarUsuario(cpf);
                        break;
                    case 3:
                        Banco.ListarTodosUsuariosDoBanco();
                        break;
                    case 4:
                        Banco.MostrarSaldoTotalBanco();
                        break;
                    case 5:
                        Banco.DetalhesUsuario();
                        break;
                    case 6:
                        Banco.ManipularConta();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-------------------------- Encerrando programa --------------------------");
                        Console.ResetColor();
                        break;
                }

            } while (escolhaUsuario != 0);

        }

    }
}