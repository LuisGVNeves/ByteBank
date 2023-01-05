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

        // Variável para fazer contagem de quantas contas possuem no banco, se atingir limite, usuário não consegue criar mais conta
        public static int contadorUsuarios = 0;

        // # Método para mostrar interface de cadastro
        public static void InterfaceCadastro()
        {
            if(contadorUsuarios == 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nLimite de conta para um usuário atingido !");
                Console.ResetColor();
                Usuario.LimparTerminal();
            }
            else
            {
                // # Boas vindas do banco
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(@"╔═════════════════════════ CADASTRO DE CONTA ════════════════════════╗");
                Console.ResetColor();


                Usuario.CriarUsuario(Usuario.nome, Usuario.idade, Usuario.saldo, Usuario.cpf, Usuario.senha);

                contadorUsuarios++;
            }
        }


        // # Método para mostrar o menu inicial
        public static void MenuInicial()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(@"╔═════════════════════════                          ═════════════════════════╗");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"            ════════════════ BOAS VINDAS BYTEBANK ════════════════    ");
            Console.ResetColor();
            Console.WriteLine(@"╚═════════════════════════                          ═════════════════════════╝");

            Console.ResetColor();
            Console.WriteLine("\n\n     ByteBank é um banco terminal feito em C#, com conhecimentos aprendidos");
            Console.WriteLine("     na escola Imã Learning Place.");
            Console.Write("\n\n     Deseja iniciar um cadastro no banco BYTEBANK? Sim ou Não: ");

            string respostaUsuario = Console.ReadLine().ToUpper();

            if (respostaUsuario == "SIM")
            {
                Console.Clear();
                
                // Iniciar Cadastro 
                InterfaceCadastro();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n     Deseja realmente sair? SIM ou NÃO: ");
                Console.ResetColor();

                string novaResposta = Console.ReadLine().ToUpper();
                if (novaResposta != "SIM")
                {
                    Console.Clear();
                    MostrarMenuPrincipal();
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n-------------------------- Encerrando ByteBank --------------------------");
                    Console.ResetColor();
                    Environment.Exit(0);
                }
            }
        }

        // # Método para mostrar o menu principal ao usuario
        public static void MostrarMenuPrincipal()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("╔═════════════════════════    INTERFACE BYTEBANK   ════════════════════════╗");
            Console.ResetColor();

            Console.WriteLine("\n                        1  -  Cadastrar novo usuário");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                        2  -  Deletar um usuário");
            Console.ResetColor();

            Console.WriteLine("                        3  -  Listar todas as contas registradas");

            Console.WriteLine("                        4  -  Total armazenado no banco");

            Console.WriteLine("                        5  -  Detalhes de um usuário");


            Console.WriteLine("                        6  -  Manipular a conta");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("                        0  -  Para sair do programa");
            Console.ResetColor();

            Console.Write("\n                           Digite a opção desejada: ");
        }

        public static void Main(string[] args)
        {
            // # Menu inicial pro usuário
            MenuInicial();

            int escolhaUsuario; 
            do
            {
                escolhaUsuario = int.Parse(Console.ReadLine());

                switch (escolhaUsuario)
                {
                    case 1:
                        Console.Clear();
                        InterfaceCadastro();
                        break;
                    case 2:
                        Usuario.DeletarUsuario(Usuario.nome, Usuario.idade, Usuario.saldo, Usuario.cpf, Usuario.senha);
                        break;
                    case 3:
                        Usuario.ListarTodosUsuariosDoBanco(Usuario.nome, Usuario.cpf, Usuario.saldo, Usuario.idade);
                        break;
                    case 4:
                        Usuario.MostrarSaldoTotalBanco(Usuario.nome, Usuario.saldo, Usuario.senha);
                        break;
                    case 5:
                        Usuario.DetalhesUsuario(Usuario.nome, Usuario.saldo, Usuario.idade);
                        break;
                    case 6:
                        Banco.ManipularConta(Usuario.nome, Usuario.idade, Usuario.saldo, Usuario.cpf, Usuario.senha);
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-------------------------- Encerrando BYTEBANK --------------------------");
                        Console.ResetColor();
                        break;
                }

            } while (escolhaUsuario != 0);

        }

    }
}