using ByteBank;
using System.Collections;
using System.Drawing;
using System.Globalization;

namespace byteBank
{
    class Program
    {
        public static void Main(string[] args) 
        {
            int option;
            do
            {
                Usuario.ShowMenu();
                option = int.Parse(Console.ReadLine());

                // # Variável para manipular os parâmetros das funções, para deletar nome, procurar nome etc..
                string nome = "";

                /*
                    # A cada opção escolhida é chamada uma função referente a escolha do usuário
                na escolha de alguns cases, eu mudo a cor que vai ser o input do usuário com o 
                Console.ForegroundColor, e depois que o usuário digita, eu reseto a cor do console
                */
                switch (option)
                {
                    case 0:

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-------------------------- Encerrando programa --------------------------");
                        Console.ResetColor();

                        break;
                    case 1:

                        Usuario.CriarUsuario();

                        break;
                    case 2:
                        
                        Console.Write("\nDigite o nome do usuário que quer deletar: ");
                        nome = Console.ReadLine();

                        Usuario.DeletarUsuario(nome);

                        break;
                    case 3:

                        Usuario.ListarTodosUsuariosDoBanco();

                        break;
                    case 4:

                        Console.Write("\nDigite o nome do usuário para checar saldo total da conta: ");
                        nome = Console.ReadLine();

                        Usuario.MostrarSaldoTotalBanco(nome);

                        break;
                    case 5:

                        Console.Write("\nDigite o nome do usuário para checar as informações: ");
                        nome = Console.ReadLine();

                        Usuario.DetalhesUsuario(nome);

                        break;
                    case 6:

                        Console.Write("\nDigite o nome do usuário que deseja manipular a conta: ");
                        nome = Console.ReadLine();

                        Usuario.ManipularConta(nome);

                        break;
                }

            } while (option != 0);

        }

    }
}