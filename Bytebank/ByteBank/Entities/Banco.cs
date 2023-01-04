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
        // Variavel global para manipular os métodos de saque e deposito
        public static double saldoUsuario = 0.0;

        // # Lista para guardar usuarios
        public static List<Usuario> usuarios = new List<Usuario>();

        // # Usuarios do banco
        public static Usuario usuario1 = new Usuario("", "", 0, 0, "");
        public static Usuario usuario2 = new Usuario("", "", 0, 0, "");
        public static Usuario usuario3 = new Usuario("", "", 0, 0, "");

        public static void CriarPrimeiroUsuario()
        {
            Console.Write("\nDigite o nome completo do usuário: ");
            usuario1.Nome = Console.ReadLine();

            Console.Write("Digite a idade do usuario: ");
            usuario1.Idade = int.Parse(Console.ReadLine());

            Console.Write("Digite o CPF do usuario: ");
            usuario1.Cpf = Console.ReadLine();

            Console.Write("Digite o saldo do usuario: ");
            usuario1.Saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("\n");

            Console.Write("Digite a senha do usuario: ");
            usuario1.Senha = Console.ReadLine();
            Console.WriteLine("\n");

            // Adicionando usuário a lista
            usuarios.Add(usuario1);

            // # Mensagem de sucesso
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuário criado com sucesso !");
            Console.ResetColor();

            System.Threading.Thread.Sleep(700);
            Console.Clear();
            Program.MostrarMenuPrincipal();
        }
        public static void CriarSegundoUsuario()
        {
            // Primeiro Usuario
            Console.Write("\nDigite o nome completo do usuário: ");
            usuario2.Nome = Console.ReadLine();

            Console.Write("Digite a idade do usuario: ");
            usuario2.Idade = int.Parse(Console.ReadLine());

            Console.Write("Digite o CPF do usuario: ");
            usuario2.Cpf = Console.ReadLine();

            Console.Write("Digite o saldo do usuario: ");
            usuario2.Saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("\n");

            Console.Write("Digite a senha do usuario: ");
            usuario2.Senha = Console.ReadLine();
            Console.WriteLine("\n");

            // Adicionando usuário a lista
            usuarios.Add(usuario2);

            // # Mensagem de sucesso
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuário criado com sucesso !");
            Console.ResetColor();

            System.Threading.Thread.Sleep(700);
            Console.Clear();
            Program.MostrarMenuPrincipal();
        }
        public static void CriarTerceiroUsuario()
        {
            // Primeiro Usuario
            Console.Write("\nDigite o nome completo do usuário: ");
            usuario3.Nome = Console.ReadLine();

            Console.Write("Digite a idade do usuario: ");
            usuario3.Idade = int.Parse(Console.ReadLine());

            Console.Write("Digite o CPF do usuario: ");
            usuario3.Cpf = Console.ReadLine();

            Console.Write("Digite o saldo do usuario: ");
            usuario3.Saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("\n");

            Console.Write("Digite a senha do usuario: ");
            usuario3.Senha = Console.ReadLine();
            Console.WriteLine("\n");

            // Adicionando usuário a lista
            usuarios.Add(usuario3);

            // # Mensagem de sucesso
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuário criado com sucesso !");
            Console.ResetColor();

            System.Threading.Thread.Sleep(700);
            Console.Clear();
            Program.MostrarMenuPrincipal();
        }


        // # Case 2 Método para deletar usuario no banco
        public static void DeletarUsuario()
        {
            Console.Write("\nDigite o nome completo do usuário que quer deletar: ");
            string nome = Console.ReadLine();

            if (nome == usuario1.Nome)
            {
                Console.Write($"\n" +
                    $"O usuário: {usuario1.Nome} irá ser deletado, deseja realmente excluir a conta? SIM ou NÃO: ");
                string perguntaConfirmacao = Console.ReadLine().ToUpper();

                if (perguntaConfirmacao == "SIM")
                {
                    usuarios.Remove(usuario1);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nUsuário {usuario1.Nome} deletado com sucesso !\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();

                    Program.MostrarMenuPrincipal();
                }
                else if (perguntaConfirmacao == "NAO" || perguntaConfirmacao == "NÃO")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nOperação cancelada com sucesso !\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();

                    Program.MostrarMenuPrincipal();
                }
            }
            else if(nome == usuario2.Nome)
            {
                Console.Write($"\n" +
                    $"O usuário: {usuario2.Nome} irá ser deletado, deseja realmente excluir a conta? SIM ou NÃO: ");
                string perguntaConfirmacao = Console.ReadLine().ToUpper();

                if (perguntaConfirmacao == "SIM")
                {
                    usuarios.Remove(usuario2);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nUsuário {usuario2.Nome} deletado com sucesso !\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();

                    Program.MostrarMenuPrincipal();
                }
                else if (perguntaConfirmacao == "NAO" || perguntaConfirmacao == "NÃO")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nOperação cancelada com sucesso !\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();

                    Program.MostrarMenuPrincipal();
                }
            }
            else if(nome == usuario3.Nome)
            {
                Console.Write($"\n" +
                    $"O usuário: {usuario3.Nome} irá ser deletado, deseja realmente excluir a conta? SIM ou NÃO: ");
                string perguntaConfirmacao = Console.ReadLine().ToUpper();

                if (perguntaConfirmacao == "SIM")
                {
                    usuarios.Remove(usuario3);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\nUsuário {usuario3.Nome} deletado com sucesso !\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();

                    Program.MostrarMenuPrincipal();
                }
                else if (perguntaConfirmacao == "NAO" || perguntaConfirmacao == "NÃO")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nOperação cancelada com sucesso !\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();

                    Program.MostrarMenuPrincipal();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nUSUARIO NÃO ENCONTRADO");
                Console.ResetColor();

                System.Threading.Thread.Sleep(700);
                Console.Clear();
                Program.MostrarMenuPrincipal();
            }

        }

        // # Case 3 Método que lista todos os usuarios do banco
        public static void ListarTodosUsuariosDoBanco()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n***LISTA DE USUÁRIOS BYTEBANK***");
            Console.ResetColor();

            for (int i = 0; i < usuarios.Count(); i++)
            {
                Console.Write($"\n\n" +
                    $"Nome: {usuarios[i].Nome}" +
                    $"\nIdade: {usuarios[i].Idade}" +
                    $"\nSaldo: R${usuarios[i].Saldo.ToString("F2", CultureInfo.InvariantCulture)}" +
                    $"\nCPF:{usuarios[i].Cpf}\n");
            }
            Console.WriteLine("\n\n\n");

            Usuario.LimparTerminal();
        }

        // # Case 4 Método que mostra o saldo total no banco
        public static void MostrarSaldoTotalBanco()
        {
            Console.Write("\nDigite o nome completo do usuário para checar saldo total da conta: ");
            string nome = Console.ReadLine();

            Console.Write("\nDigite a senha do do usuário para checar saldo total da conta: ");
            string senha = Console.ReadLine();

            // Percorrer a lista dos usuários aqui tava gerando um bug de pular o usuário e cair direto no else, então resolvi colocar só no if e separar os usuários.
            if (usuario1.Nome == nome && usuario1.Senha == senha)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSaldo total no banco: R$ {usuario1.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.ResetColor();

                Usuario.LimparTerminal();
            }
            else if(usuario2.Nome == nome && usuario2.Senha == senha)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSaldo total no banco: R$ {usuario2.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.ResetColor();

                Usuario.LimparTerminal();
            }
            else if (usuario3.Nome == nome && usuario3.Senha == senha)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nSaldo total no banco: R$ {usuario3.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                Console.ResetColor();

                Usuario.LimparTerminal();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("USUÁRIO NÃO ENCONTRADO\n");
                Console.ResetColor();

                Usuario.LimparTerminal();
            }

        }

        // # Case 5 Método que mostra detalhes de usuário
        public static void DetalhesUsuario()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n***DETALHES DO USUÁRIO***");
            Console.ResetColor();

            Console.Write("\nDigite o nome do usuário para checar as informações: ");
            string nome = Console.ReadLine();

            if (usuario1.Nome == nome)
            {
                Console.Write($"\nNome: {usuario1.Nome}\nIdade: {usuario1.Idade}\nSaldo: {usuario1.Saldo}\nCPF:{usuario1.Cpf}");
            }
            else if (usuario2.Nome == nome)
            {
                Console.Write($"\nNome: {usuario2.Nome}\nIdade: {usuario2.Idade}\nSaldo: {usuario2.Saldo}\nCPF:{usuario2.Cpf}");
            }
            else if (usuario3.Nome == nome)
            {
                Console.Write($"\nNome: {usuario3.Nome}\nIdade: {usuario3.Idade}\nSaldo: {usuario3.Saldo}\nCPF:{usuario3.Cpf}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("USUÁRIO NÃO ENCONTRADO\n");
                Console.ResetColor();
            }
            Console.WriteLine("\n\n");
            Usuario.LimparTerminal();
        }

        // # Case 6 Método para manipular a conta do usuário
        public static void ManipularConta()
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
                    RealizarSaque(valorSaque);
                    break;
                case 2:
                    Console.Write("\nDigite o valor a depositar: ");
                    double valorDepositado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    RealizarDeposito(valorDepositado);
                    break;

                case 3:
                    Console.Write("\nDigite o valor a transferir: ");
                    double valorTransferido = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    RealizarTransferencia(valorTransferido);
                    break;
            }


            static void RealizarSaque(double qtdSacar)
            {
                Console.Write("\nDigite o nome do usuário que deseja realizar Saque: ");
                string nome = Console.ReadLine();

                if (usuario1.Nome == nome)
                {
                    // Variavel global saldoUsuario vai receber o valor atual da conta do usuário
                    saldoUsuario = usuario1.Saldo;

                    if (qtdSacar > saldoUsuario)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não é possivel sacar, pois você não tem esse valor em conta");
                        Console.ResetColor();
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }
                    else if (saldoUsuario > 0)
                    {
                        saldoUsuario -= qtdSacar;

                        Console.WriteLine($"\nValor sacado: {qtdSacar.ToString("F2", CultureInfo.InvariantCulture)}\n");
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não é possível sacar, pois o saldo da conta é R$ 0.00");
                        Console.ResetColor();
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }

                    // Depois que usuário sacou, vou atualizar novamente o saldo do usuário
                    usuario1.Saldo = saldoUsuario;
                }
                else if (usuario2.Nome == nome)
                {
                    // Variavel global saldoUsuario vai receber o valor atual da conta do usuário
                    saldoUsuario = usuario2.Saldo;

                    if (qtdSacar > saldoUsuario)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não é possivel sacar, pois você não tem esse valor em conta");
                        Console.ResetColor();
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }
                    else if (saldoUsuario > 0)
                    {
                        saldoUsuario -= qtdSacar;

                        Console.WriteLine($"\nValor sacado: {qtdSacar.ToString("F2", CultureInfo.InvariantCulture)}\n");
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não é possível sacar, pois o saldo da conta é R$ 0.00");
                        Console.ResetColor();
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }

                    // Depois que usuário sacou, vou atualizar novamente o saldo do usuário
                    usuario2.Saldo = saldoUsuario;
                }
                else if (usuario3.Nome == nome)
                {
                    // Variavel global saldoUsuario vai receber o valor atual da conta do usuário
                    saldoUsuario = usuario3.Saldo;

                    if (qtdSacar > saldoUsuario)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não é possivel sacar, pois você não tem esse valor em conta");
                        Console.ResetColor();
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }
                    else if (saldoUsuario > 0)
                    {
                        saldoUsuario -= qtdSacar;

                        Console.WriteLine($"\nValor sacado: {qtdSacar.ToString("F2", CultureInfo.InvariantCulture)}\n");
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Não é possível sacar, pois o saldo da conta é R$ 0.00");
                        Console.ResetColor();
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }

                    // Depois que usuário sacou, vou atualizar novamente o saldo do usuário
                    usuario3.Saldo = saldoUsuario;
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

            static void RealizarDeposito(double qtdDeposito)
            {
                Console.Write("\nDigite o nome do usuário que deseja realizar o deposito: ");
                string nome = Console.ReadLine();

                if (usuario1.Nome == nome)
                {
                    // Variavel global saldoUsuario vai receber o valor atual da conta do usuário
                    saldoUsuario = usuario1.Saldo;

                    if (qtdDeposito > 0)
                    {
                        saldoUsuario += qtdDeposito;

                        Console.WriteLine($"\nValor depositado: {qtdDeposito.ToString("F2", CultureInfo.InvariantCulture)}\n");
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNão é possível depositar, pois o valor do deposito é R$ 0.00");
                        Console.ResetColor();
                        Console.WriteLine($"\nValor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }

                    // Depois que usuário sacou, vou atualizar novamente o saldo do usuário
                    usuario1.Saldo = saldoUsuario;
                }
                else if (usuario2.Nome == nome)
                {
                    // Variavel global saldoUsuario vai receber o valor atual da conta do usuário
                    saldoUsuario = usuario2.Saldo;

                    if (qtdDeposito > 0)
                    {
                        saldoUsuario += qtdDeposito;

                        Console.WriteLine($"\nValor depositado: {qtdDeposito.ToString("F2", CultureInfo.InvariantCulture)}\n");
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNão é possível depositar, pois o valor do deposito é R$ 0.00");
                        Console.ResetColor();
                        Console.WriteLine($"\nValor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }

                    // Depois que usuário sacou, vou atualizar novamente o saldo do usuário
                    usuario2.Saldo = saldoUsuario;
                }
                else if (usuario3.Nome == nome)
                {
                    // Variavel global saldoUsuario vai receber o valor atual da conta do usuário
                    saldoUsuario = usuario3.Saldo;

                    if (qtdDeposito > 0)
                    {
                        saldoUsuario += qtdDeposito;

                        Console.WriteLine($"\nValor depositado: {qtdDeposito.ToString("F2", CultureInfo.InvariantCulture)}\n");
                        Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNão é possível depositar, pois o valor do deposito é R$ 0.00");
                        Console.ResetColor();
                        Console.WriteLine($"\nValor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                        Usuario.LimparTerminal();
                    }

                    // Depois que usuário sacou, vou atualizar novamente o saldo do usuário
                    usuario3.Saldo = saldoUsuario;
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
           
            static void RealizarTransferencia(double qtdTransferencia)
            {
                // Variaveis temporárias pra alocar o saldo da propriedade do usuário e atualizar depois
                double saldoUsuario1 = 0.0;
                double saldoUsuario2 = 0.0;
                double saldoUsuario3 = 0.0;

                Console.Write("\nNome do usuário que vai enviar a transferência: ");
                string nome = Console.ReadLine();

                if (usuario1.Nome == nome)
                {
                    // Variavel saldoUsuario1,2,3 vai receber o valor atual da conta do usuário
                    saldoUsuario1 = usuario1.Saldo;
                    saldoUsuario2 = usuario2.Saldo;
                    saldoUsuario3 = usuario3.Saldo;

                    // Processamento de dados - Variavel saldo vai alocar temporariamente os novos valores e depois vai reatribuir para o atributo saldo do objeto usuario
                    if (qtdTransferencia > 0 && qtdTransferencia <= saldoUsuario1)
                    {
                        Console.Write("\nDigite o nome do usuário que vai receber a transferência: ");
                        string usuarioReceberTransferencia = Console.ReadLine();

                        if (usuarioReceberTransferencia == usuario2.Nome)
                        {
                            saldoUsuario1 -= qtdTransferencia;
                            saldoUsuario2 += qtdTransferencia;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nTransferência realizada com sucesso !");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(1000);
                            Usuario.LimparTerminal();
                        }
                        else if (usuarioReceberTransferencia == usuario3.Nome)
                        {
                            saldoUsuario1 -= qtdTransferencia;
                            saldoUsuario3 += qtdTransferencia;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nTransferência realizada com sucesso !");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(1000);
                            Usuario.LimparTerminal();
                        }
                        else if (usuarioReceberTransferencia == usuario1.Nome)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNão é possível transferir pro mesmo usuário !");
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
                    else if (qtdTransferencia <= 0)
                    {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNão é possível enviar zero reais ou menos !");
                            Console.ResetColor();

                            System.Threading.Thread.Sleep(1000);
                            Usuario.LimparTerminal();
                    }
                    else if(qtdTransferencia > saldoUsuario1)
                    {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNão é possível enviar um valor maior do que há na sua conta!");
                            Console.ResetColor();

                            System.Threading.Thread.Sleep(1000);
                            Usuario.LimparTerminal();
                    }

                    // Depois que usuário fez transferencia, vou atualizar novamente o saldo do usuário
                    usuario1.Saldo = saldoUsuario1;
                    usuario2.Saldo = saldoUsuario2;
                    usuario3.Saldo = saldoUsuario3;
                }
                else if (usuario2.Nome == nome)
                {
                    saldoUsuario1 = usuario1.Saldo;
                    saldoUsuario2 = usuario2.Saldo;
                    saldoUsuario3 = usuario3.Saldo;

                    if (qtdTransferencia > 0 && qtdTransferencia <= saldoUsuario2)
                    {
                        Console.Write("\nDigite o nome do usuário que vai receber a transferência: ");
                        string usuarioReceberTransferencia = Console.ReadLine();

                        if (usuarioReceberTransferencia == usuario1.Nome)
                        {
                            saldoUsuario2 -= qtdTransferencia;
                            saldoUsuario1 += qtdTransferencia;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nTransferência realizada com sucesso !");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(1000);
                            Usuario.LimparTerminal(); ;
                        }
                        else if (usuarioReceberTransferencia == usuario3.Nome)
                        {
                            saldoUsuario2 -= qtdTransferencia;
                            saldoUsuario3 += qtdTransferencia;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nTransferência realizada com sucesso !");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(1000);
                            Usuario.LimparTerminal();
                        }
                        else if (usuarioReceberTransferencia == usuario2.Nome)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNão é possível transferir pro mesmo usuário !");
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
                    else if(qtdTransferencia <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNão é possível enviar zero reais ou menos !");
                        Console.ResetColor();

                        System.Threading.Thread.Sleep(1000);
                        Usuario.LimparTerminal();
                    }
                    else if(qtdTransferencia > usuario2.Saldo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNão é possível enviar um valor maior do que há na sua conta!");
                        Console.ResetColor();

                        System.Threading.Thread.Sleep(1000);
                        Usuario.LimparTerminal();
                    }

                    usuario1.Saldo = saldoUsuario1;
                    usuario2.Saldo = saldoUsuario2;
                    usuario3.Saldo = saldoUsuario3;
                }
                else if (nome == usuario3.Nome)
                {
                    saldoUsuario1 = usuario1.Saldo;
                    saldoUsuario2 = usuario2.Saldo;
                    saldoUsuario3 = usuario3.Saldo;

                    if (qtdTransferencia > 0 && qtdTransferencia <= usuario3.Saldo)
                    {
                        Console.Write("\nDigite o nome do usuário que vai receber a transferência: ");
                        string usuarioReceberTransferencia = Console.ReadLine();

                        if (usuarioReceberTransferencia == usuario1.Nome)
                        {
                            saldoUsuario3 -= qtdTransferencia;
                            saldoUsuario1 += qtdTransferencia;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nTransferência realizada com sucesso !");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(1000);
                            Usuario.LimparTerminal();
                        }
                        else if (usuarioReceberTransferencia == usuario2.Nome)
                        {
                            saldoUsuario3 -= qtdTransferencia;
                            saldoUsuario2 += qtdTransferencia;

                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nTransferência realizada com sucesso !");
                            Console.ResetColor();
                            System.Threading.Thread.Sleep(1000);
                            Usuario.LimparTerminal();
                        }
                        else if (usuarioReceberTransferencia == usuario3.Nome)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nNão é possível transferir pro mesmo usuário !");
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
                    else if (qtdTransferencia <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNão é possível enviar zero reais ou menos !");
                        Console.ResetColor();

                        System.Threading.Thread.Sleep(1000);
                        Usuario.LimparTerminal();
                    }
                    else if(qtdTransferencia > usuario3.Saldo)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNão é possível enviar um valor maior do que há na sua conta!");
                        Console.ResetColor();

                        System.Threading.Thread.Sleep(1000);
                        Usuario.LimparTerminal();
                    }

                    usuario1.Saldo = saldoUsuario1;
                    usuario2.Saldo = saldoUsuario2;
                    usuario3.Saldo = saldoUsuario3;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n USUÁRIO NÃO ENCONTRADO !");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1000);
                    Usuario.LimparTerminal();
                }

            }


        }



    }
}
