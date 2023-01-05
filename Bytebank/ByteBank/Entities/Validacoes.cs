﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace validacoes
{
    internal class Validacoes
    {
        public static void ValidarNome(List<string> nome)
        {
            Console.Write("\n                      Digite o nome do usuário: ");
            Console.ForegroundColor = ConsoleColor.Blue;

            string nomeUsuario = Console.ReadLine();
            Console.ResetColor();

            while (
                nomeUsuario.Contains("1") ||
                nomeUsuario.Contains("2") ||
                nomeUsuario.Contains("3") ||
                nomeUsuario.Contains("4") ||
                nomeUsuario.Contains("5") ||
                nomeUsuario.Contains("6") ||
                nomeUsuario.Contains("7") ||
                nomeUsuario.Contains("8") ||
                nomeUsuario.Contains("9")
                )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("\n                      Digite o nome do usuário sem números: ");
                nomeUsuario = Console.ReadLine();
                Console.ResetColor();
            }
            nome.Add(nomeUsuario);
        }
        public static void ValidarIdade(List<int> idade)
        {
            Console.Write("\n                      Digite a idade do usuário: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            string idadeUsuario = Console.ReadLine();
            Console.ResetColor();

            // Se houve numero na tentativa de casting, vai ser true, se houver string, vai retornar false

            var inputUsuario = int.TryParse(idadeUsuario, out int numero);

            while (inputUsuario == false)
            {
                Console.Write("\n                      Digite a idade do usuário: ");

                Console.ForegroundColor = ConsoleColor.Red;
                idadeUsuario = Console.ReadLine();
                Console.ResetColor();

                if (inputUsuario == true)
                {
                    break;
                }

                inputUsuario = int.TryParse(idadeUsuario, out int outroNumero);
            }
            idade.Add(int.Parse(idadeUsuario));

        }
        public static void ValidarSaldo(List<double> saldo)
        {
            Console.Write("\n                      Digite o saldo do usuário: ");

            Console.ForegroundColor = ConsoleColor.Blue;
            string saldoUsuario = Console.ReadLine();
            Console.ResetColor();


            // Se houve numero na tentativa de casting, vai ser true, se houver string, vai retornar false
            var inputUsuario = decimal.TryParse(saldoUsuario, out decimal numero);

            while (inputUsuario == false)
            {
                Console.Write("\n                      Digite o saldo do usuário: ");

                Console.ForegroundColor = ConsoleColor.Red;
                saldoUsuario = Console.ReadLine();
                Console.ResetColor();

                if (inputUsuario == true)
                {
                    break;
                }

                inputUsuario = decimal.TryParse(saldoUsuario, out decimal outroNumero);

            }
            saldo.Add(double.Parse(saldoUsuario));

        }
        public static void ValidarCPF(List<string> cpf)
        {
            string cpfUsuario = "";
            string cpfAtualizado = "";
            
            Console.Write("\n                      Digite o cpf do usuário: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            cpfUsuario = Console.ReadLine();
            Console.ResetColor();

            bool ehNumero = int.TryParse(cpfUsuario, out int n);

            while (ehNumero == false)
            {

                Console.Write("\n                      CPF inválido digite novamente: ");
                Console.ForegroundColor = ConsoleColor.Blue;
                cpfUsuario = Console.ReadLine();
                Console.ResetColor();

                ehNumero = int.TryParse(cpfUsuario, out int x);
            }
            while (ehNumero == true)
            {
                if (cpfUsuario.Length < 11)
                {
                    Console.Write("\n                      CPF inválido digite novamente: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    cpfUsuario = Console.ReadLine();

                    Console.ResetColor();
                }
                else
                {
                    cpfAtualizado += cpfUsuario.Substring(0, 3);
                    cpfAtualizado += ".";
                    cpfAtualizado += cpfUsuario.Substring(3, 3);
                    cpfAtualizado += ".";
                    cpfAtualizado += cpfUsuario.Substring(6, 3);
                    cpfAtualizado += "-";
                    cpfAtualizado += cpfUsuario[cpfUsuario.Length - 2];
                    cpfAtualizado += cpfUsuario[cpfUsuario.Length - 1];
                    break;
                }

            }
            cpf.Add(cpfAtualizado);

        }
    }
}