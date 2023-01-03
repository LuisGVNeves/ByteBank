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
        // # Lista para guardar usuarios
        public static ArrayList usuarios = new ArrayList();

        // Variavel global para manipular os métodos de saque e deposito
        public static double saldoUsuario = 0.0;

        // # Case 1 Método criar usuario no banco
        public static void CriarUsuario()
        {
            // # Instanciando objeto novoUsuario da classe Usuario
            Usuario novoUsuario = new Usuario("", "", 0, 0, "");

            while (true)
            {
                Console.Write("\nDigite o nome completo do usuário: ");
                novoUsuario.Nome = Console.ReadLine();
                
                Console.Write("Digite a idade do usuario: ");
                novoUsuario.Idade = int.Parse(Console.ReadLine());

                Console.Write("Digite o CPF do usuario: ");
                novoUsuario.Cpf = Console.ReadLine();

                Console.Write("Digite o saldo do usuario: ");
                novoUsuario.Saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.WriteLine("\n");

                Console.Write("Digite a senha do usuario: ");
                novoUsuario.Senha = Console.ReadLine();
                Console.WriteLine("\n");

                usuarios.Add(novoUsuario);

                // # Mensagem de sucesso
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Usuário criado com sucesso !");
                Console.ResetColor();

                // # Se na contagem do array já tiver pelo menos 1 usuário, eu posso mostrar a msg de criar um novo usuario
                if(usuarios.Count > 1)
                {
                     Console.Write("\n\nDeseja criar um novo usuário? Sim ou NÃO: ");
                    
                    string novaEscolhaUsuario = Console.ReadLine().ToUpper();
                    if (novaEscolhaUsuario == "NÃO" || novaEscolhaUsuario == "NAO")
                    {
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        break;
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    break;
                }


            }

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

            foreach (Usuario p in usuarios)
            {
                Console.Write($"\n\nNome: {p.Nome}\nIdade: {p.Idade}\nSaldo: R${p.Saldo.ToString("F2", CultureInfo.InvariantCulture)}\nCPF:{p.Cpf}\n");
            }
            Console.WriteLine("\n\n\n");

            Usuario.LimparTerminal();
        }

        // # Case 4 Método que mostra o saldo total no banco
        public static void MostrarSaldoTotalBanco()
        {
            string nome = "";
            Console.Write("\nDigite o nome completo do usuário para checar saldo total da conta: ");
            nome = Console.ReadLine();

            foreach (Usuario usuario in usuarios)
            {
                try
                {
                    if(nome == usuario.Nome)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nSaldo total no banco: R$ {usuario.Saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                        Console.ResetColor();

                        Usuario.LimparTerminal();
                        break;
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                        
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("Procurando usuário.. \n");
                        Console.ResetColor();

                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                catch
                {
                    if (nome != usuario.Nome)
                    {
                        Usuario.LimparTerminal();
                        break;
                    }
                }
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

            foreach (Usuario p in usuarios)
            {
                if (p.Nome == nome)
                {
                    Console.Write($"\nNome: {p.Nome}\nIdade: {p.Idade}\nSaldo: {p.Saldo}\nCPF:{p.Cpf}");
                }
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

            foreach (Usuario p in usuarios)
            {
                if (p.Nome == nome)
                {
                    // Variavel global saldoUsuario vai receber o valor atual da conta do usuário
                    saldoUsuario = p.Saldo;

                    // Sub menu para usuário sacar o dinheiro ou depositar
                    MenuManusearConta();

                    // Depois que usuário depositou ou sacou, vou atualizar novamente o saldo do usuário
                    p.Saldo = saldoUsuario;
                }
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

    }
}
