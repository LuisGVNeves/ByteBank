﻿using byteBank;
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
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Clear();
            Console.WriteLine(@"╔═════════════════════════ MANIPULAR CONTA ════════════════════════╗");
            Console.ResetColor();
            Console.WriteLine("\n                           1 - Fazer Saque");
            Console.WriteLine("                           2 - Depositar");
            Console.WriteLine("                           3 - Realizar Transferência");
            Console.Write("\n\n                         Digite a opção desejada: ");

            int respostaUsuario = int.Parse(Console.ReadLine());
            switch (respostaUsuario)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    Console.Clear();
                    Console.WriteLine(@"╔═════════════════════════ AREA SAQUE ════════════════════════╗");
                    Console.ResetColor();

                    Console.Write("\n                    Digite o valor a sacar: ");
                    double valorSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    RealizarSaque(valorSaque, Usuario.nome, Usuario.saldo);
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Clear();
                    Console.WriteLine(@"╔═════════════════════════ AREA DEPOSITO ════════════════════════╗");
                    Console.ResetColor();

                    Console.Write("\n                    Digite o valor a depositar: ");
                    double valorDepositado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    RealizarDeposito(valorDepositado, Usuario.nome, Usuario.saldo);
                    break;

                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.Clear();
                    Console.WriteLine(@"╔═════════════════════════ AREA TRANSFERENCIA ════════════════════════╗");
                    Console.ResetColor();

                    Console.Write("\n                      Digite o valor a transferir: ");
                    double valorTransferido = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    RealizarTransferencia(valorTransferido, Usuario.nome, Usuario.saldo);
                    break;
            }


        }

        public static void RealizarSaque(double qtdSacar, List<string> nome, List<double> saldo)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Clear();
            Console.WriteLine(@"╔═════════════════════════ AREA SAQUE ════════════════════════╗");
            Console.ResetColor();

            Console.Write("\nDigite o nome do usuário que deseja realizar Saque: ");
            string nomeUsuario = Console.ReadLine();

            // Procurar nome do usuário na lista de nomes
            int nomePercorrido = nome.FindIndex(nome => nome == nomeUsuario);

            // Verificação até achar o nome do usuário, e perguntar se o usuário deseja continuar buscando o nome do usuário
            while (nomePercorrido == -1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNOME NÃO ACHADO");
                Console.ResetColor();

                Console.Write("\nDeseja tentar de novo? SIM ou NÃO: ");
                string respostaUsuario = Console.ReadLine().ToUpper();
                

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write("════════════════════════════════════════════");
                Console.ResetColor();

                if (respostaUsuario == "SIM")
                {
                    Console.Write("\n\nDigite o nome do usuário que deseja realizar Saque: ");
                    nomeUsuario = Console.ReadLine();

                    nomePercorrido = nome.FindIndex(nome => nome == nomeUsuario);
                }

                if (respostaUsuario == "NÃO" || respostaUsuario == "NAO")
                {
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n                     Voltando ao menu principal\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();

                    Program.MostrarMenuPrincipal();
                    return;
                }
            }

            // Quando achar o nome do usuario
            if(nomePercorrido > -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine(@"╔═════════════════════════ AREA SAQUE ════════════════════════╗");
                Console.ResetColor();

                // Usuario
                for (int i = 0; i < nome.Count(); i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n                          Nome:");
                    Console.ResetColor();
                    Console.Write($"  {nome[i]}");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n                          Saldo:");
                    Console.ResetColor();
                    Console.Write($"  {saldo[i]} R$");

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\n\n            ════════════════════════════════════════════\n");
                    Console.ResetColor();

                }

                // # Confirmação se usuário quer mesmo sacar o money
                Console.Write($"\nO usuário {nomeUsuario} irá fazer um saque de {qtdSacar} R$, deseja realmente sacar este valor da conta? SIM ou NÃO: ");
                string perguntaConfirmacao = Console.ReadLine().ToUpper();

                if (perguntaConfirmacao == "SIM")
                {
                    /*
                        - Agora que usuário confirmou que realmente deseja sacar, vou fazer uma verificação no for pra saber se
                        o saldo que ele tem é compatível com o saque:
                            if Quantidade do saque é maior que saldo?
                            if Saldo na conta é maior que zero pra ocorrer o saque?
                            else Saldo zerado e não ocorre o saque

                    */
                    Random comprovante = new Random();

                    for (int i = 0; i < nome.Count(); i++)
                    {
                        if (nomeUsuario == nome[i])
                        {
                            // Não tem valor do saque disponivel
                            if (qtdSacar > saldo[i])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\nNão é possivel sacar, pois você não tem esse valor em conta");
                                Console.ResetColor();
                                Console.WriteLine($"\nUsuário: {nomeUsuario} ");
                                Console.WriteLine($"\nValor atual da conta: {saldo[i]} R$");

                                Usuario.LimparTerminal();
                                return;
                            }
                            // Saque realizado
                            else if (saldo[i] > 0)
                            {
                                //  Saldo vai ser descontado no mento o valor do saque
                                double saldoAtual = saldo[i] -= qtdSacar;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\n  Saque realizado com sucesso !\n\n");
                                Console.ResetColor();

                                Console.ResetColor();
                                System.Threading.Thread.Sleep(1100);
                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine(@"╔═════════════════════════ COMPROVANTE DE TRANSFERÊNCIA ════════════════════════╗");

                                Console.WriteLine(@"                 ════════════════════════════════════════════");
                                Console.WriteLine($"            Comprovante: {comprovante.Next(50)}");
                                Console.ResetColor();
                                Console.WriteLine($"\n                          Usuário: {nomeUsuario} ");
                                Console.WriteLine($"\n                          Saldo: {saldo[i] + qtdSacar} ");

                                Console.WriteLine($"\n                          Solicitação de saque: {qtdSacar.ToString("F2", CultureInfo.InvariantCulture)} R$");
                                Console.WriteLine($"\n                          Saldo atual: {saldoAtual} R$\n");

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine(@"                 ════════════════════════════════════════════");
                                Console.ResetColor();

                                Usuario.LimparTerminal();
                                return;
                            }
                            // conta zerada
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Não é possível sacar, pois o saldo da conta é R$ 0.00");
                                Console.ResetColor();
                                Console.WriteLine($"Valor atual da conta: {saldo[i]}\n");

                                Usuario.LimparTerminal();
                                return;
                            }
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nSaque de {qtdSacar} R$ realizado com sucesso !\n");
                    Console.ResetColor();

                }
                else if (perguntaConfirmacao == "NAO" || perguntaConfirmacao == "NÃO")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nSaque cancelado com sucesso !\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();

                    Program.MostrarMenuPrincipal();
                }
                else
                {
                    Console.Clear();
                    Program.MostrarMenuPrincipal();
                }
            }

        }

        public static void RealizarDeposito(double qtdDeposito, List<string> nome, List<double> saldo)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Clear();
            Console.WriteLine(@"╔═════════════════════════ AREA DEPOSITO ════════════════════════╗");
            Console.ResetColor();

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
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine(@"╔═════════════════════════ AREA TRANSFERENCIA ════════════════════════╗");
            Console.ResetColor();

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
