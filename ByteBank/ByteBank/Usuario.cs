using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    internal class Usuario
    {
        // # Variaveis publicas internas da classe Usuario
        public string nome;
        public int idade;
        public double saldo;

        public Usuario(string nome, int idade, double saldo) 
        {
            this.nome = nome;
            this.idade = idade;
            this.saldo = saldo;
        }    
    }
}
