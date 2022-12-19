using System;
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

        public Usuario(string nome, string sobrenome, int idade, double saldo) 
        {
            this.nome = nome;
            this.idade = idade;
            this.saldo = saldo;
            this.sobrenome = sobrenome;


        }    



    }
}
