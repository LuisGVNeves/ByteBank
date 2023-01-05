using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace validacoes
{
    internal class Validacoes
    {
        public static void ValidarNome(List<string> nome)
        {
            Console.Write("\n                      Digite o nome do usuário: ");
            Console.ForegroundColor = ConsoleColor.Blue;

            string nomeUsuario = Console.ReadLine();
            Console.ResetColor();

            while (
                nomeUsuario.Contains("1") ||
                nomeUsuario.Contains("2") ||
                nomeUsuario.Contains("3") ||
                nomeUsuario.Contains("4") ||
                nomeUsuario.Contains("5") ||
                nomeUsuario.Contains("6") ||
                nomeUsuario.Contains("7") ||
                nomeUsuario.Contains("8") ||
                nomeUsuario.Contains("9")
                )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                      Digite o nome do usuário sem números: ");
                nomeUsuario = Console.ReadLine();
                Console.ResetColor();
            }
            nome.Add(nomeUsuario);
        }
        public static void ValidarIdade(List<int> idade)
        {
            Console.Write("\n                      Digite a idade do usuário: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            string idadeUsuario = Console.ReadLine();
            Console.ResetColor();

            // Se houve numero na tentativa de casting, vai ser true, se houver string, vai retornar false

            var inputUsuario = int.TryParse(idadeUsuario, out int numero);

            while (inputUsuario == false)
            {
                Console.Write("\n                      Digite a idade do usuário: ");

                Console.ForegroundColor = ConsoleColor.Red;
                idadeUsuario = Console.ReadLine();
                Console.ResetColor();

                if (inputUsuario == true)
                {
                    idade.Add(int.Parse(idadeUsuario));
                    break;
                }

                inputUsuario = int.TryParse(idadeUsuario, out int outroNumero);
            }

        }
        public static void ValidarSaldo(List<double> saldo)
        {
            Console.Write("\n                      Digite o saldo do usuário: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            string saldoUsuario = Console.ReadLine();
            Console.ResetColor();


            // Se houve numero na tentativa de casting, vai ser true, se houver string, vai retornar false
            var inputUsuario = decimal.TryParse(saldoUsuario, out decimal numero);

            while (inputUsuario == false)
            {
                Console.Write("\n                      Digite o saldo do usuário: ");

                Console.ForegroundColor = ConsoleColor.Red;
                saldoUsuario = Console.ReadLine();
                Console.ResetColor();

                if (inputUsuario == true)
                {
                    saldo.Add(double.Parse(saldoUsuario));
                    break;
                }

                inputUsuario = decimal.TryParse(saldoUsuario, out decimal outroNumero);

            }

        }

    }
}
