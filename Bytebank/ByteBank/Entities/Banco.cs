using byteBank;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Usuarios;

namespace ClasseBanco
{
    internal class Banco
    {
        // # Case 6 Método para manipular a conta do usuário
        public static void ManipularConta(List<string> nome, List<int> idade, List<double> saldo, List<string> cpf, List<string> senha)
        {
            Console.WriteLine("\n[ AREA TRANSFERENCIA ]\n");
            Console.WriteLine("\n1 - Fazer Saque");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Realizar Transferência");
            Console.Write("\nDigite a opção desejada: ");

            int respostaUsuario = int.Parse(Console.ReadLine());
            switch (respostaUsuario)
            {
                case 1:
                    Console.Write("\nDigite o valor a sacar: ");
                    double valorSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    RealizarSaque(valorSaque, Usuario.nome, Usuario.saldo);
                    break;
                case 2:
                    Console.Write("\nDigite o valor a depositar: ");
                    double valorDepositado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    RealizarDeposito(valorDepositado, Usuario.nome, Usuario.saldo);
                    break;

                case 3:
                    Console.Write("\nDigite o valor a transferir: ");
                    double valorTransferido = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    RealizarTransferencia(valorTransferido, Usuario.nome, Usuario.saldo);
                    break;
            }


        }

        public static void RealizarSaque(double qtdSacar, List<string> nome, List<double> saldo)
        {
            Console.Write("\nDigite o nome do usuário que deseja realizar Saque: ");
            string nomeUsuario = Console.ReadLine();

            for (int i = 0; i < nome.Count(); i++)
            {
                if (nome[i] == nomeUsuario)
                {
                    if (qtdSacar > saldo[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não é possivel sacar, pois você não tem esse valor em conta");
                        Console.ResetColor();
                        Console.WriteLine($"Valor atual da conta: {saldo[i]}");

                        Usuario.LimparTerminal();
                        break;
                    }
                    else if (saldo[i] > 0)
                    {
                        saldo[i] -= qtdSacar;

                        Console.WriteLine($"\nValor sacado: {qtdSacar.ToString("F2", CultureInfo.InvariantCulture)}\n");
                        Console.WriteLine($"Valor atual da conta: {saldo[i]}\n");

                        Usuario.LimparTerminal();
                        break;

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não é possível sacar, pois o saldo da conta é R$ 0.00");
                        Console.ResetColor();
                        Console.WriteLine($"Valor atual da conta: {saldo[i]}\n");

                        Usuario.LimparTerminal();
                        break;

                    }

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUSUÁRIO NÃO ENCONTRADO");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1000);
                    Usuario.LimparTerminal();
                    break;
                }
            }
        }

        public static void RealizarDeposito(double qtdDeposito, List<string> nome, List<double> saldo)
        {
            Console.Write("\nDigite o nome do usuário que deseja realizar o deposito: ");
            string nomeUsuario = Console.ReadLine();

            for (int i = 0; i < nome.Count(); i++)
            {
                if (nome[i] == nomeUsuario)
                {
                    if (qtdDeposito > 0)
                    {
                        saldo[i] += qtdDeposito;

                        Console.WriteLine($"\nValor depositado: {qtdDeposito.ToString("F2", CultureInfo.InvariantCulture)}\n");
                        Console.WriteLine($"Valor atual da conta: {saldo[i]}\n");

                        Usuario.LimparTerminal();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNão é possível depositar, pois o valor do deposito é R$ 0.00");
                        Console.ResetColor();
                        Console.WriteLine($"Valor atual da conta: {saldo[i]}\n");

                        Usuario.LimparTerminal();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUSUÁRIO NÃO ENCONTRADO");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1000);
                    Usuario.LimparTerminal();
                }
            }

        }

        public static void RealizarTransferencia(double qtdTransferencia, List<string> nome, List<double> saldo)
        {
            // Variaveis temporárias pra alocar o saldo da propriedade do usuário e atualizar depois
            double saldoUsuario1 = 0.0;
            double saldoUsuario2 = 0.0;

            Console.Write("\nNome do usuário que vai enviar a transferência: ");
            string nomeUsuario = Console.ReadLine();

            Console.Write("\nDigite o nome do usuário que vai receber a transferência: ");
            string usuarioReceberTransferencia = Console.ReadLine();

            for (int i = 0; i < nome.Count(); i++)
            {
                if (nome[i] == nomeUsuario)
                {
                    saldoUsuario1 = saldo[i];
                }
                if (nome[i] == usuarioReceberTransferencia)
                {
                    saldoUsuario2 = saldo[i];
                }
            }

            if (qtdTransferencia > 0 && qtdTransferencia <= saldoUsuario1)
            {
                saldoUsuario1 -= qtdTransferencia;
                saldoUsuario2 += qtdTransferencia;

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nTransferência realizada com sucesso !");
                Console.ResetColor();

                System.Threading.Thread.Sleep(1000);
                Usuario.LimparTerminal();
            }
            else if (qtdTransferencia <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão é possível enviar zero reais ou menos !");
                Console.ResetColor();

                System.Threading.Thread.Sleep(1000);
                Usuario.LimparTerminal();
            }
            else if (qtdTransferencia > saldoUsuario1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão é possível enviar um valor maior do que há na sua conta!");
                Console.ResetColor();

                System.Threading.Thread.Sleep(1000);
                Usuario.LimparTerminal();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nUSUÁRIO NÃO ENCONTRADO");
                Console.ResetColor();

                System.Threading.Thread.Sleep(1000);
                Usuario.LimparTerminal();
            }

            for (int i = 0; i < nome.Count(); i++)
            {
                // # Atualizando o valor
                if (nome[i] == nomeUsuario)
                {
                    saldo[i] = saldoUsuario1;
                }
                if (nome[i] == usuarioReceberTransferencia)
                {
                    saldo[i] = saldoUsuario2;
                }
            }


        }

    }
}
