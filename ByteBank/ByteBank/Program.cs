﻿using ByteBank;
using System.Collections;
using System.Drawing;
using System.Globalization;

namespace byteBank
{
    class Program
    {

        // # Lista para guardar usuarios
        static ArrayList usuarios = new ArrayList();

        
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

        // # Case 3 Método que lista todos os usuarios do banco
        static void ListarTodosUsuariosDoBanco() 
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n\n***LISTA DE USUÁRIOS BYTEBANK***");
            Console.ResetColor();


            foreach (Usuario p in usuarios)
            {
                Console.Write($"\n\nNome: {p.nome}\nIdade: {p.idade}\nSaldo: R${p.saldo}\n");
            }
            Console.WriteLine("\n\n\n");
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
        }

        public static void Main(string[] args) 
        {


            int option;
            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

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
                        Console.Clear();
                        break;
                    case 2:
                        string nomeDeletar = "";
                        
                        Console.Write("\nDigite o nome do usuário que quer deletar: ");
                        nomeDeletar = Console.ReadLine();

                        DeletarUsuario(nomeDeletar);
                        break;
                    case 3:
                        ListarTodosUsuariosDoBanco();
                        break;
                    case 4:
                        string nome = "";

                        Console.Write("\nDigite o nome do usuário para checar saldo total da conta: ");
                        nome = Console.ReadLine();

                        MostrarSaldoTotalBanco(nome);
                        break;
                    case 5:
                        string nomeUsuario = "";

                        Console.Write("\nDigite o nome do usuário para checar as informações: ");
                        nomeUsuario = Console.ReadLine();

                        DetalhesUsuario(nomeUsuario);
                        break;
                }

            } while (option != 0);

        }

    }
}