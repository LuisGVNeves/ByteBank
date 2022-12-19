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
            int escolhaUsuario;
            do
            {
                // # Método que mostra o menu ao usuário
                Usuario.ShowMenu();

                escolhaUsuario = int.Parse(Console.ReadLine());

                switch (escolhaUsuario)
                {
                    case 1:
                        Usuario.CriarUsuario();
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