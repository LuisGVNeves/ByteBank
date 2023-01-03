﻿using ClasseBanco;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Usuarios
{
    internal class Usuario
    {
        // # Atributos Usuario
        public string Nome;
        public int Idade;
        public double Saldo;
        public string Cpf;
        public string Senha;
        public int Id;

        // # Constructor
        public Usuario(string nome, string cpf, int idade, double saldo, string senha)
        {
            this.Nome = nome;
            this.Idade = idade;
            this.Saldo = saldo;
            this.Cpf = cpf;
            this.Senha = senha;
        }
        // # Método para limpar o terminal
        public static void LimparTerminal()
        {
            // # Tratamento pra ver se o usuário deseja limpar a tela

            Console.Write("\nDeseja limpar a tela? SIM ou NÃO: ");
            string perguntaUsuario = Console.ReadLine().ToUpper();

            while (perguntaUsuario != "SIM")
            {
                System.Threading.Thread.Sleep(2000);
                Console.Write("Deseja limpar a tela? SIM ou NÃO: ");
                perguntaUsuario = Console.ReadLine().ToUpper();
            }

            if (perguntaUsuario == "SIM")
            {
                // # Pausa antes do clear
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- Limpando ---");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }


    }
}