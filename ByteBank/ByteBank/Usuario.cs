using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    internal class Usuario
    {
        // # Variaveis publicas internas da classe Usuario
        public string nome;
        public string sobrenome;
        public int idade;
        public double saldo;
        public string cpf;

        // Variavel global para manipular os métodos de saque e deposito
        public static double saldoUsuario = 0.0;

        // # Lista para guardar usuarios
        public static ArrayList usuarios = new ArrayList();


        public Usuario(string nome, string cpf, int idade, double saldo) 
        {
            this.nome = nome;
            this.idade = idade;
            this.saldo = saldo;
            this.cpf = cpf;
        }

        // # Método para mostrar o menu ao usuario
        public static void ShowMenu()
        {
            // # Boas vindas do banco
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("-------------------------- BEM-VINDO AO BYTEBANK --------------------------");
            Console.ResetColor();

            Console.WriteLine("1 - Inserir novo usuário");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2 - Deletar um usuário");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("4 - Total armazenado no banco");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("5 - Detalhes de um usuário");
            Console.ResetColor();

            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("\nDigite a opção desejada: ");
        }

        // # Case 1 Método criar usuario
        public static void CriarUsuario()
        {

            // # Instanciando objeto novoUsuario da classe Usuario
            Usuario novoUsuario = new Usuario("", "", 0, 0);


            Console.WriteLine("\n");
            Console.Write("Digite o nome completo do usuário: ");
            novoUsuario.nome = Console.ReadLine();


            Console.Write("Digite a idade do usuario: ");
            novoUsuario.idade = int.Parse(Console.ReadLine());


            Console.Write("Digite o CPF do usuario: ");
            novoUsuario.cpf = Console.ReadLine();


            Console.Write("Digite o saldo do usuario: ");
            novoUsuario.saldo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.WriteLine("\n");


            // # Adicionando novo usuário na lista
            usuarios.Add(novoUsuario);


            // # Mensagem de sucesso
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Usuário criado com sucesso !");

            System.Threading.Thread.Sleep(1500);
            Console.Clear();
        }

        // # Case 2 Método para deletar usuario
        public static void DeletarUsuario(string cpf)
        {
            string nome;

            Console.Write("\nDigite o nome completo do usuário que quer deletar: ");
            nome = Console.ReadLine();

            Console.Write("\nConfirme o CPF do usuário: ");
            cpf = Console.ReadLine();

            foreach (Usuario p in usuarios)
            {
                if (nome == p.nome && cpf == p.cpf)
                {
                    string perguntaConfirmacao = "";
                    Console.WriteLine($"\nO usuário: {p.nome} irá ser deletado, deseja realmente excluir a conta? SIM ou NÃO:");

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

                        Console.WriteLine($"\nO usuário: {p.nome} irá ser deletado, deseja realmente excluir a conta? SIM ou NÃO:");
                        perguntaConfirmacao = Console.ReadLine().ToUpper();

                    }
                    break;
                }
                else
                {
                    Console.WriteLine("\nUsuário não encontrado na base de dados !");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
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
                Console.Write($"\n\nNome: {p.nome}\nIdade: {p.idade}\nSaldo: R${p.saldo.ToString("F2", CultureInfo.InvariantCulture)}\nCPF:{p.cpf}\n");
            }
            Console.WriteLine("\n\n\n");

            // # Pausa antes do clear
            System.Threading.Thread.Sleep(2500);
            Console.Clear();
        }

        // # Case 4 Método que mostra o saldo total no banco
        public static void MostrarSaldoTotalBanco(string nome)
        {
            Console.WriteLine("\n");
            foreach (Usuario p in usuarios)
            {
                if (p.nome == nome)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Saldo total no banco: R$ {p.saldo.ToString("F2", CultureInfo.InvariantCulture)}");
                    Console.ResetColor();
                }
            }
            Console.WriteLine("\n\n");

            // # Pausa antes do clear
            System.Threading.Thread.Sleep(3000);
            Console.Clear();


        }

        // # Case 5 Método que mostra detalhes de usuário
        public static void DetalhesUsuario(string nome)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n\n***DETALHES DO USUÁRIO***");
            Console.ResetColor();

            foreach (Usuario p in usuarios)
            {
                if (p.nome == nome)
                {
                    Console.Write($"\nNome: {p.nome}\nIdade: {p.idade}\nSaldo: {p.saldo}");
                    break;
                }
            }
            Console.WriteLine("\n\n");


            // # Pausa antes do clear
            System.Threading.Thread.Sleep(2500);
            Console.Clear();
        }

        // # Case 6 Método para manipular a conta do usuário
        public static void ManipularConta(string nome)
        {
            #region Explicação da função ManipularConta
            /*
                  - Vai percorrer a lista de usuários e se achar o nome, vai pegar a variavel global saldoUsuario e
                essa vai receber o valor do saldo atual do usuário

                - Depois vai chamar o SubMenu

                - Depois que ocorre o subMenu o usuario deposita ou saca, entao eu atualizo a propriedade saldo de novo para quando for checado o saldo total do banco, esteja com os valores corretos.
            */
            #endregion

            foreach (Usuario p in usuarios)
            {
                if (p.nome == nome)
                {
                    saldoUsuario = p.saldo;
                    MenuManusearConta();

                    p.saldo = saldoUsuario;
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
            if(qtdSacar > saldoUsuario)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não é possivel sacar, pois você não tem esse valor em conta");
                Console.ResetColor();
                Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                // # Pausa antes do clear
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
            }
            else if (saldoUsuario > 0)
            {
                saldoUsuario -= qtdSacar;

                Console.WriteLine($"\nValor sacado: {qtdSacar.ToString("F2", CultureInfo.InvariantCulture)}\n");
                Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                // # Pausa antes do clear
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Não é possível sacar, pois o saldo da conta é R$ 0.00");
                Console.ResetColor();
                Console.WriteLine($"Valor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                // # Pausa antes do clear
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
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

                // # Pausa antes do clear
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nNão é possível depositar, pois o valor do deposito é R$ 0.00");
                Console.ResetColor();
                Console.WriteLine($"\nValor atual da conta: {saldoUsuario.ToString("F2", CultureInfo.InvariantCulture)}\n");

                // # Pausa antes do clear
                System.Threading.Thread.Sleep(3500);
                Console.Clear();
            }

        }
    }
}
