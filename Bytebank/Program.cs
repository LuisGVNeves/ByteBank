using byteBank; 
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
            Usuario novoUsuario = new Usuario("", "", 0, 0,"");

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
                        Usuario.CriarUsuario(escolhaUsuario);
                        break;
                    case 2:
                        string cpf = "";
                        Usuario.DeletarUsuario(cpf);
                        break;
                    case 3:
                        Usuario.ListarTodosUsuariosDoBanco();
                        break;
                    case 4:
                        Usuario.MostrarSaldoTotalBanco();
                        break;
                    case 5:
                        Usuario.DetalhesUsuario();
                        break;
                    case 6:
                        Usuario.ManipularConta();
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