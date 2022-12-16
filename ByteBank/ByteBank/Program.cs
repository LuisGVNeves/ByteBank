using ByteBank;
using System.Collections;
using System.Drawing;
using System.Globalization;

namespace byteBank
{
    class Program
    {

        // # Lista para guardar usuarios
        static ArrayList usuarios = new ArrayList();

        // Variavel global para manipular os métodos de saque e deposito
        public static double saldoUsuario = 0.0;

        // # Método para mostrar o menu ao usuario
        static void ShowMenu()
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
        static void CriarUsuario()
        {

            // # Instanciando objeto novoUsuario da classe Usuario
            Usuario novoUsuario = new Usuario("", 0, 0);

            Console.WriteLine("\n");
            Console.Write("Digite o nome do usuário: ");
            novoUsuario.nome = Console.ReadLine();

            
            Console.Write("Digite a idade do usuario: ");
            novoUsuario.idade = int.Parse(Console.ReadLine());


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
        static void DeletarUsuario(string nomeDeletar)
        {

            foreach (Usuario p in usuarios )
            {
                if(p.nome == nomeDeletar) 
                {
                    usuarios.Remove(p);

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\nUsuário deletado com sucesso !\n");
                    Console.ResetColor();

                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();

                    break;
                }
            }
        }

        // # Case 3 Método que lista todos os usuarios do banco
        static void ListarTodosUsuariosDoBanco() 
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n***LISTA DE USUÁRIOS BYTEBANK***");
            Console.ResetColor();


            foreach (Usuario p in usuarios)
            {
                Console.Write($"\n\nNome: {p.nome}\nIdade: {p.idade}\nSaldo: R${p.saldo.ToString("F2", CultureInfo.InvariantCulture)}\n");
            }
            Console.WriteLine("\n\n\n");

            // # Pausa antes do clear
            System.Threading.Thread.Sleep(2500);
            Console.Clear();
        }

        // # Case 4 Método que mostra o saldo total no banco
        static void MostrarSaldoTotalBanco(string nome)
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
        static void DetalhesUsuario(string nome) 
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
        static void ManipularConta(string nome)
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
        static void MenuManusearConta()
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
            if (saldoUsuario > 0)
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


        public static void Main(string[] args) 
        {
            int option;
            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                // # Variável para manipular os parâmetros das funções, para deletar nome, procurar nome etc..
                string nome = "";

                /*
                    # A cada opção escolhida é chamada uma função referente a escolha do usuário
                na escolha de alguns cases, eu mudou a cor que vai ser o input do usuário com o 
                Console.ForegroundColor, e depois que o usuário digita, eu reseto a cor do console

                    - Se tirar o reset, todo o terminal fica com a cor referente ao foreground 
                */
                switch (option)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("-------------------------- Encerrando programa --------------------------");
                        Console.ResetColor();
                        break;
                    case 1:
                        CriarUsuario();
                        break;
                    case 2:
                        
                        Console.Write("\nDigite o nome do usuário que quer deletar: ");
                        nome = Console.ReadLine();

                        DeletarUsuario(nome);
                        break;
                    case 3:
                        ListarTodosUsuariosDoBanco();
                        break;
                    case 4:
                        Console.Write("\nDigite o nome do usuário para checar saldo total da conta: ");
                        nome = Console.ReadLine();

                        MostrarSaldoTotalBanco(nome);
                        break;
                    case 5:

                        Console.Write("\nDigite o nome do usuário para checar as informações: ");
                        nome = Console.ReadLine();

                        DetalhesUsuario(nome);
                        break;
                    case 6:
                        Console.Write("\nDigite o nome do usuário que deseja manipular a conta: ");
                        nome = Console.ReadLine();

                        ManipularConta(nome);
                        break;
                }

            } while (option != 0);

        }

    }
}