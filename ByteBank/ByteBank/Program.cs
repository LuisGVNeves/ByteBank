using ByteBank;
using System.Collections;
using System.Drawing;

namespace byteBank
{
    class Program
    {

        // # Lista para guardar usuarios
        static ArrayList usuarios = new ArrayList();

        // # Método para mostrar o menu ao usuario
        static void ShowMenu()
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("                       -------------------------- BEM-VINDO AO BYTEBANK --------------------------          ");
            Console.ResetColor();
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Listar todas as contas registradas");
            Console.WriteLine("4 - Total armazenado no banco");
            Console.WriteLine("5 - Detalhes de um usuário");
            Console.WriteLine("6 - Manipular a conta");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("\nDigite a opção desejada: ");
        }

        // # Case 1 Método criar usuario
        static void CriarUsuario()
        {
            // # Instanciando objeto novoUsuario da classe Usuario
            Usuario novoUsuario = new Usuario("", 0, 0);

            Console.WriteLine("Digite o nome do usuário: ");
            novoUsuario.nome = Console.ReadLine();

            Console.WriteLine("Digite a idade do usuario: ");
            novoUsuario.idade = int.Parse(Console.ReadLine());


            Console.WriteLine("Digite o saldo do usuario: ");
            novoUsuario.saldo = double.Parse(Console.ReadLine());

            // # Adicionando novo usuário na lista
            usuarios.Add(novoUsuario);
        }

        // # Case 2 Método para deletar usuario
        static void DeletarUsuario(string nomeDeletar)
        {

            foreach (Usuario p in usuarios )
            {
                if(p.nome == nomeDeletar) 
                {
                    usuarios.Remove(p);
                    break;
                }
            }
        }

        // # Case 3 Método que mostra detalhes do usuário
        static void DetalhesUsuario() 
        {
            foreach (Usuario p in usuarios)
            {
                Console.Write($"\nNome: {p.nome}" +
                    $"\nIdade usuário: {p.idade}" +
                    $"\nSaldo usuário: {p.saldo}"
                    );
                Console.WriteLine("\n\n");
            }
        }

        // # Case 4 Método que mostra o saldo total no banco
        static void MostrarSaldoTotalBanco(string nome)
        {
            foreach (Usuario p in usuarios)
            {
                if (p.nome == nome)
                {
                    Console.WriteLine($"Usuário: {p.nome} Total no banco: {p.saldo}");
                }
            }
        }

        public static void Main(string[] args) 
        {
            int option;
            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("                       -------------------------- Encerrando programa --------------------------          ");
                        Console.ResetColor();
                        break;
                    case 1:
                        CriarUsuario();
                        break;
                    case 2:
                        
                        string nomeDeletar = "";
                        
                        Console.WriteLine("Digite o nome do usuário que quer deletar: ");
                        nomeDeletar = Console.ReadLine();

                        DeletarUsuario(nomeDeletar);
                        break;
                    case 3:
                        DetalhesUsuario();
                        break;
                    case 4:
                        string nome = "";

                        Console.WriteLine("Digite o nome do usuário que você quer checar o valor total: ");
                        nome = Console.ReadLine();

                        MostrarSaldoTotalBanco(nome);
                        break;
                }

            } while (option != 0);

        }

    }
}