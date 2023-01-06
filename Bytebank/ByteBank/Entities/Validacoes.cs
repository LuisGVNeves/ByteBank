using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

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
                Console.ResetColor();
                nomeUsuario = Console.ReadLine();
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                      Idade inválida, digite sem letras: ");
                Console.ResetColor();

                idadeUsuario = Console.ReadLine();

                if (inputUsuario == true)
                {
                    break;
                }

                inputUsuario = int.TryParse(idadeUsuario, out int outroNumero);
            }
            idade.Add(int.Parse(idadeUsuario));

        }
        public static void ValidarSaldo(List<double> saldo)
        {
            Console.Write("\n                      Digite o saldo do usuário: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            string saldoUsuario = Console.ReadLine();
            Console.ResetColor();


            // Se houve numero na tentativa de casting, vai ser true, se houver string, vai retornar false
            var inputUsuario = double.TryParse(saldoUsuario, out double numero);

            while (inputUsuario == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                      Saldo inválido, digite sem letras: ");
                Console.ResetColor();

                saldoUsuario = Console.ReadLine();

                if (inputUsuario == true)
                {
                    break;
                }

                inputUsuario = double.TryParse(saldoUsuario, out double outroNumero);

            }
            saldo.Add(double.Parse(saldoUsuario));

        }
        public static void ValidarCPF(List<string> cpf)
        {
            string cpfUsuario = "";

            Console.Write("\n                      Digite o cpf do usuário: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            cpfUsuario = Console.ReadLine();
            Console.ResetColor();


            IsCpf(cpfUsuario);

            if(IsCpf(cpfUsuario) == true)
            {
                cpf.Add(cpfUsuario);
            }
            else
            {
                while(IsCpf(cpfUsuario) == false)
                {
                    Console.Write("\n                      Digite um CPF válido: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    cpfUsuario = Console.ReadLine();
                    Console.ResetColor();

                    IsCpf(cpfUsuario);

                    if(IsCpf(cpfUsuario) == true)
                    {
                        break;
                    }
                }
            }


        }
        public static void ValidarSenha(List<string> senha)
        {
            string senhaUsuario = "";

            Console.Write("\n                      Digite a senha do usuário: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            senhaUsuario = Console.ReadLine();
            Console.ResetColor();


            while(senhaUsuario.Length < 8)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                      Senha muito curta, senha no minímo 8 caracteres: ");
                senhaUsuario = Console.ReadLine();
                Console.ResetColor();

                if(senhaUsuario.Length >= 8)
                {
                    break;
                }
            }
            senha.Add(senhaUsuario);
        }

        // Referência https://www.macoratti.net/11/09/c_val1.htm
        public static bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }
    }
}
