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
                                Console.WriteLine(@"╔═════════════════════════ COMPROVANTE DE SAQUE ════════════════════════╗");

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

            // Procurar nome do usuário na lista de nomes
            int nomePercorrido = nome.FindIndex(nome => nome == nomeUsuario);

            // Enquanto não achar o usuário, perguntar de novo se deseja tentar novamente
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
                    Console.Write("\n\nDigite o nome do usuário que deseja realizar o deposito: ");
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
            if (nomePercorrido > -1)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.WriteLine(@"╔═════════════════════════ AREA DEPOSITO ════════════════════════╗");
                Console.ResetColor();

                // Mostrar dados do usuario escolhido
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


                // # Confirmação se usuário quer mesmo depositar o money
                Console.Write($"\nO usuário {nomeUsuario} receber um depósito de {qtdDeposito} R$, confirma? SIM ou NÃO: ");
                string perguntaConfirmacao = Console.ReadLine().ToUpper();

                if (perguntaConfirmacao == "SIM")
                {
                    Random comprovante = new Random();

                    for (int i = 0; i < nome.Count(); i++)
                    {
                        if (nomeUsuario == nome[i])
                        {
                            // valor do deposito baixo
                            if (qtdDeposito < 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\nNão é possivel depositar 0 ou menos reais na conta");
                                Console.ResetColor();
                                Console.WriteLine($"\nUsuário: {nomeUsuario} ");
                                Console.WriteLine($"\nValor atual da conta: {saldo[i]} R$");

                                Usuario.LimparTerminal();
                                return;
                            }
                            // Saque realizado
                            else if (qtdDeposito > 0)
                            {
                                //  Saldo vai ser descontado no mento o valor do saque
                                double saldoAtual = saldo[i] += qtdDeposito;

                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine("\n\n  Depósito realizado com sucesso !\n\n");
                                Console.ResetColor();

                                Console.ResetColor();
                                System.Threading.Thread.Sleep(1100);
                                Console.Clear();

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine(@"╔═════════════════════════ COMPROVANTE DE DEPÓSITO ════════════════════════╗");

                                Console.WriteLine(@"                 ════════════════════════════════════════════");
                                Console.WriteLine($"            Comprovante: {comprovante.Next(50)}");
                                Console.ResetColor();
                                Console.WriteLine($"\n                          Usuário: {nomeUsuario} ");
                                Console.WriteLine($"\n                          Saldo: {saldo[i] - qtdDeposito} ");

                                Console.WriteLine($"\n                          Solicitação de depósito: {qtdDeposito.ToString("F2", CultureInfo.InvariantCulture)} R$");
                                Console.WriteLine($"\n                          Saldo atual: {saldoAtual} R$\n");

                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.WriteLine(@"                 ════════════════════════════════════════════");
                                Console.ResetColor();

                                Usuario.LimparTerminal();
                                return;
                            }
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\nSaque de {qtdDeposito} R$ realizado com sucesso !\n");
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

        // Variaveis temporárias pra alocar o saldo da propriedade do usuário e atualizar depois
        public static double saldoUsuario1 = 0.0;
        public static double saldoUsuario2 = 0.0;
        public static string usuarioEnviarTransferencia;
        public static string usuarioReceberTransferencia;
        public static void RealizarTransferencia(double qtdTransferencia, List<string> nome, List<double> saldo)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Clear();
            Console.WriteLine(@"╔═════════════════════════ AREA TRANSFERENCIA ════════════════════════╗");
            Console.ResetColor();


            Console.Write("\nNome do usuário que vai enviar a transferência: ");
            usuarioEnviarTransferencia = Console.ReadLine();

            // Procurar nome do usuário que vai enviar a transferencia na lista de nomes
            int nomePercorrido = nome.FindIndex(nome => nome == usuarioEnviarTransferencia);
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
                    Console.Write("\n\nDigite o nome do usuário que vai enviar a transferência: ");
                    usuarioEnviarTransferencia = Console.ReadLine();

                    nomePercorrido = nome.FindIndex(nome => nome == usuarioEnviarTransferencia);
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


            Console.Write("\nDigite o nome do usuário que vai receber a transferência: ");
            usuarioReceberTransferencia = Console.ReadLine();

            // Procurar nome do usuário que vai receber a transferencia na lista de nomes
            nomePercorrido = nome.FindIndex(nome => nome == usuarioReceberTransferencia);
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
                    Console.Write("\n\nDigite o nome do usuário que vai receber a transferência: ");
                    usuarioReceberTransferencia = Console.ReadLine();

                    nomePercorrido = nome.FindIndex(nome => nome == usuarioReceberTransferencia);
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


            // O saldo dos usuario que transfere e do usuário que recebe serão colocados nas variaveis saldoUsuario1 e saldoUsuario2 momentaneamente 
            for (int i = 0; i < nome.Count(); i++)
            {
                if (nome[i] == usuarioEnviarTransferencia)
                {
                    saldoUsuario1 = saldo[i];
                }
                if (nome[i] == usuarioReceberTransferencia)
                {
                    saldoUsuario2 = saldo[i];
                }
            }


            // Transferencia do usuário pra quem recebe
            if (qtdTransferencia > 0 && qtdTransferencia <= saldoUsuario1)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Console.WriteLine(@"╔═════════════════════════ AREA TRANSFERENCIA ════════════════════════╗");
                Console.ResetColor();

                // Usuarios para melhorar visibilidade no terminal
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

                // # Confirmação se usuário quer mesmo fazer a transferencia
                Console.Write($"\nO usuário {usuarioEnviarTransferencia} irá fazer uma tranferência de {qtdTransferencia} R$ para {usuarioReceberTransferencia}, confirmar transferência? SIM ou NÃO: ");
                string perguntaConfirmacao = Console.ReadLine().ToUpper();

                if (perguntaConfirmacao == "SIM")
                {
                    Random comprovante = new Random();

                    // Valor do usuário que vai transferir antes de ocorrer a transferencia
                    double saldoUsuarioUmAntigo = saldoUsuario1;
                    saldoUsuario1 -= qtdTransferencia;
                    saldoUsuario2 += qtdTransferencia;

                    // Variaveis saldoUsuario já estão atualizadas com o valor da transferencia e deposito, agora vou pegar o saldo[i] de acordo com o nome de quem transferiu e quem recebeu
                    for (int i = 0; i < nome.Count(); i++)
                    {
                        // # Atualizando o valor
                        if (nome[i] == usuarioEnviarTransferencia)
                        {
                            saldo[i] = saldoUsuario1;
                        }
                        if (nome[i] == usuarioReceberTransferencia)
                        {
                            saldo[i] = saldoUsuario2;
                        }
                    }

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\n  Transferência realizada com sucesso !\n\n");
                    Console.ResetColor();


                    Console.ResetColor();
                    System.Threading.Thread.Sleep(1100);
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(@"╔═════════════════════════ COMPROVANTE DE TRANSFERÊNCIA ════════════════════════╗");

                    Console.WriteLine(@"                 ════════════════════════════════════════════");
                    Console.WriteLine($"            Comprovante: {comprovante.Next(50)}");
                    Console.ResetColor();
                    Console.WriteLine($"\n                          Usuário: {usuarioEnviarTransferencia} ");
                    Console.WriteLine($"\n                          Saldo: {saldoUsuarioUmAntigo}");
                    Console.WriteLine("                     ----------------------------");
                    Console.WriteLine($"\n                          Solicitação de transferência: - {qtdTransferencia.ToString("F2", CultureInfo.InvariantCulture)} R$\n");
                    Console.WriteLine("                     ----------------------------");

                    Console.WriteLine($"\n                          Saldo atual: {saldoUsuario1} R$\n");

                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    Console.WriteLine(@"                 ════════════════════════════════════════════");
                    Console.ResetColor();

                    Usuario.LimparTerminal();
                    return;
                }
                else if (perguntaConfirmacao == "NAO" || perguntaConfirmacao == "NÃO")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n   Transferência cancelada com sucesso !\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();

                    Program.MostrarMenuPrincipal();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n   Transferência cancelada\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(100);
                    Console.Clear();
                    Program.MostrarMenuPrincipal();
                }
            }
            // Se o valor da transferencia for menor que 0
            else if (qtdTransferencia <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão é possível enviar zero reais ou menos !");
                Console.ResetColor();

                System.Threading.Thread.Sleep(1000);
                Usuario.LimparTerminal();
            }
            // Se o usuario que vai transferir tentar transferir um saldo maior que há na conta dele
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



        }

    }
}
