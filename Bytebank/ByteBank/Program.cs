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
        public static void Main(string[] args)
        {
            // # Menu inicial pro usuário
            Usuario.MenuInicial();

            // # Instanciando objeto novoUsuario da classe Usuario
            Usuario novoUsuario = new Usuario("", "", 0, 0, "");

            Usuario.PreencherInformacoesUsuario(novoUsuario);

            int escolhaUsuario;
            do
            {
                // # Método que mostra o menu principal ao usuário
                Usuario.ShowMenuPrincipal();

                escolhaUsuario = int.Parse(Console.ReadLine());

                switch (escolhaUsuario)
                {
                    case 1:
                        Banco.CriarUsuario(escolhaUsuario);
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