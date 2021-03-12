using System;
using System.Globalization;
namespace Bank
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
        {
            this.TipoConta = tipoConta;
            this.Saldo = saldo;
            this.Credito = credito;
            this.Nome = nome;
        }

        public bool Sacar(double valorSaque){

            if(Saldo - valorSaque < (Credito *-1))
            {
                Console.WriteLine("Saldo Insuficiente!");
                Console.ReadLine();
                return false;
            }
            Saldo -= valorSaque;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
            Console.ReadLine();
            return true;
        }

        public void Depositar(double valorDeposito)
        {
            Saldo += valorDeposito;
            Console.WriteLine("Saldo atual da conta de {0} é {1}", Nome, Saldo);
            Console.ReadLine();
        }

        public void Transferir(double valorTransferencia, Conta contaDestino)
        {
            if(Sacar(valorTransferencia))
            {
                contaDestino.Depositar(valorTransferencia);
            }
        }

        public override string ToString()
        {
            return "Conta: " + TipoConta +
                " | Titular: " + Nome +
                " | Saldo Atual R$: " + Saldo.ToString("F2", CultureInfo.InvariantCulture)+
                " | Credito R$: " + Credito.ToString("F2", CultureInfo.InvariantCulture);
            
        }
    }
    
    
    

    
}