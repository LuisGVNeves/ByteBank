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
        public static void DeletarUsuario(string cpf)
        {
            Console.Write("\nDigite o nome completo do usuário que quer deletar: ");
            string nome = Console.ReadLine();

            Console.Write("\nConfirme o CPF do usuário: ");
            cpf = Console.ReadLine();

            foreach (Usuario p in usuarios)
            {
                if (nome == p.Nome && cpf == p.Cpf)
                {
                    string perguntaConfirmacao = "";
                    Console.WriteLine($"\nO usuário: {p.Nome} irá ser deletado, deseja realmente excluir a conta? SIM ou NÃO:");

                    perguntaConfirmacao = Console.ReadLine().ToUpper();

                    while (perguntaConfirmacao != "SIM" || perguntaConfirmacao != "NÃO" || perguntaConfirmacao != "NAO")
                    {
                        if (perguntaConfirmacao == "SIM")
                        {
                            usuarios.Remove(p);

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nUsuário deletado com sucesso !\n");
                            Console.ResetColor();

                            System.Threading.Thread.Sleep(1500);
                            Console.Clear();

                            break;
                        }
                        if (perguntaConfirmacao == "NAO" || perguntaConfirmacao == "NÃO")
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("\nOperação cancelada com sucesso !\n");
                            Console.ResetColor();

                            System.Threading.Thread.Sleep(1500);
                            Console.Clear();
                            break;

                        }

                        Console.WriteLine("\nDigite SIM ou NÃO !\n");

                        System.Threading.Thread.Sleep(1000);

                        Console.WriteLine($"\nO usuário: {p.Nome} irá ser deletado, deseja realmente excluir a conta? SIM ou NÃO:");
                        perguntaConfirmacao = Console.ReadLine().ToUpper();

                    }
                    break;
                }
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
        #region Comentário explicando a função ManipularConta
        /*
        - Vai percorrer a lista de usuários e se achar o nome, vai pegar a variavel global saldoUsuario e
        essa vai receber o valor do saldo atual do usuário
        - Depois vai chamar o MENU para manusear a conta, então usuario pode depositar ou sacar, 
        depois que o usuário fazer um desses dois, eu atualizo a propriedade saldo.
        - Oara quando for checado o saldo total do banco, esteja com os valores atualizados.
        */
        #endregion
        public static void ManipularConta()
        {
            Console.Write("\nDigite o nome do usuário que deseja manipular a conta: ");
            string nome = Console.ReadLine();
            if (usuario1.Nome == nome)
            {
                // Variavel global saldoUsuario vai receber o valor atual da conta do usuário
                saldoUsuario = usuario1.Saldo;

                // Sub menu para usuário sacar o dinheiro ou depositar
                MenuManusearConta();

                // Depois que usuário depositou ou sacou, vou atualizar novamente o saldo do usuário
                usuario1.Saldo = saldoUsuario;
            }
            else if (usuario2.Nome == nome)
            {
                // Variavel global saldoUsuario vai receber o valor atual da conta do usuário
                saldoUsuario = usuario2.Saldo;

                // Sub menu para usuário sacar o dinheiro ou depositar
                MenuManusearConta();

                // Depois que usuário depositou ou sacou, vou atualizar novamente o saldo do usuário
                usuario2.Saldo = saldoUsuario;
            }
            else if (usuario3.Nome == nome)
            {
                // Variavel global saldoUsuario vai receber o valor atual da conta do usuário
                saldoUsuario = usuario3.Saldo;

                // Sub menu para usuário sacar o dinheiro ou depositar
                MenuManusearConta();

                // Depois que usuário depositou ou sacou, vou atualizar novamente o saldo do usuário
                usuario3.Saldo = saldoUsuario;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("USUÁRIO NÃO ENCONTRADO\n");
                Console.ResetColor();

                System.Threading.Thread.Sleep(1000);
                Usuario.LimparTerminal();
            }
        }

        // # Case 6 - SubMenu para manipular a conta
        public static void MenuManusearConta()
        {
            Console.WriteLine("\n1 - Fazer Saque");
            Console.WriteLine("2 - Depositar");
            Console.Write("\nDigite a opção desejada: ");

            int respostaUsuario = int.Parse(Console.ReadLine());

            if (respostaUsuario == 1)
            {
                Console.Write("\nDigite o valor a sacar: ");
                double valorSaque = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                RealizarSaque(valorSaque);
            }
            if (respostaUsuario == 2)
            {
                Console.Write("\nDigite o valor a depositar: ");
                double valorDepositado = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                RealizarDeposito(valorDepositado);
            }


        }

        // # Case 6 - Realizar Saque
        public static void RealizarSaque(double qtdSacar)
        {
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

        }

        // # Case 6 - Realizar Deposito
        public static void RealizarDeposito(double qtdDeposito)
        {
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

        }


        /* # Case 7 - Realizar Transferencia
        public static void RealizarTransferencia(double qtdTransferencia)
        {
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

        }
        */
    }
}
