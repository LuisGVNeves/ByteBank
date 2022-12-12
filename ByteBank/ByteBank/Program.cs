﻿using ByteBank;
using System.Collections;

namespace byteBank
{
    class Program
    {
        // # Método para mostrar o menu ao usuario
        static void ShowMenu()
        {
            Console.WriteLine("1 - Inserir novo usuário");
            Console.WriteLine("2 - Deletar um usuário");
            Console.WriteLine("3 - Detalhes de um usuário");
            Console.WriteLine("4 - Total armazenado no banco");
            Console.WriteLine("0 - Para sair do programa");
            Console.Write("\nDigite a opção desejada: ");
        }

        // # Lista para guardar usuarios
        static ArrayList usuarios = new ArrayList();

        // # Método criar usuario
        static void CriarUsuario()
        {
            Usuario novoUsuario = new Usuario("", 0, 0);

            Console.WriteLine("Digite o nome do usuário: ");
            novoUsuario.nome = Console.ReadLine();

            Console.WriteLine("Digite a idade do usuario: ");
            novoUsuario.idade = int.Parse(Console.ReadLine());


            Console.WriteLine("Digite o salário do usuario: ");
            novoUsuario.salario = double.Parse(Console.ReadLine());

            // # Adicionando novo usuário na lista
            usuarios.Add(novoUsuario);
        }



        // # Método que mostra detalhes do usuário
        static void DetalhesUsuario() 
        {
            foreach (Usuario p in usuarios)
            {
                Console.Write($"Nome usuário: {p.nome} | Idade usuário: {p.idade} | Salário usuário: {p.salario}");
                Console.WriteLine("\n\n");
            }
        }


        public static void Main(string[] args) 
        {
            Console.WriteLine("Antes de começar a usar, vamos configurar alguns valores: ");

            Console.WriteLine("Digite a quantidade de usuários: ");
            int quantidadeDeUsuarios = int.Parse(Console.ReadLine());


            int option;
            do
            {
                ShowMenu();
                option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 0:
                        Console.WriteLine("-------- Encerrando programa --------");
                        break;
                    case 1:
                        CriarUsuario();
                        break;
                    case 3:
                        DetalhesUsuario();
                        break;
                }

            } while (option != 0);



  
        }
    }
}