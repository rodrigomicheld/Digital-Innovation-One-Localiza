using System;
using System.Collections.Generic;
using System.Globalization;

namespace Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcao = Menu();

            while (opcao.ToUpper() != "X")
            {
                switch(opcao)
                {
                    case "1":
                        ListarConta();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        RealizarTransferencia();
                        break;
                    case "4":
                        RealizarSaque();
                        break;
                    case "5":
                        RealizarDeposito();
                        break;
                    case "C":
                        Console.Clear();
                        break; 
                    default:
                        throw new ArgumentOutOfRangeException("Informe uma opção válida");
                                
                }
                opcao = Menu();

            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!");
        }
        private static void RealizarSaque()
        {
            Console.WriteLine("Informe em qual conta será realizado o saque");
            int numeroConta = int.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            
            Console.WriteLine("Informe o valor que será sacado");
            double valor = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            if (listContas.Count == 0)
            {
                Console.WriteLine("Não temos nenhuma conta cadastrada no momento!");
                Console.ReadLine();
            }else{
                listContas[numeroConta].Sacar(valor);
            }

        }
        private static void RealizarDeposito()
        {
            Console.WriteLine("Informe em qual conta será realizado o depósito");
            int numeroConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Informe o valor que será depositado");
            double valor = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            if (listContas.Count == 0)
            {
                Console.WriteLine("Não temos nenhuma conta cadastrada no momento!");
                Console.ReadLine();
            }else{
                listContas[numeroConta].Depositar(valor);
            }

        }
        private static void RealizarTransferencia()
        {
            Console.WriteLine("Informe em qual conta será realizado o transferência");
            int numeroConta = int.Parse(Console.ReadLine());
            
            Console.WriteLine("Informe o valor que será transferido");
            double valor = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Console.WriteLine("Informe em qual conta será creditado");
            int contaDestino = int.Parse(Console.ReadLine());

            if (listContas.Count == 0)
            {
                Console.WriteLine("Não temos nenhuma conta cadastrada no momento!");
                Console.ReadLine();
            }else{
                listContas[numeroConta].Transferir(valor,listContas[contaDestino]);
            }

        }
        private static void ListarConta()
        {
            int cont = 0;
            if (listContas.Count == 0)
            {
                Console.WriteLine("Não temos nenhuma conta cadastrada no momento!");
                Console.ReadLine();
                return;    
            }
            foreach(Conta obj in listContas)
            {   
                Console.WriteLine("#"+ cont++ +" | "+ obj);                   
            }
            Console.ReadLine();
        }
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            
            Console.Write(" Digite 1- Conta Fisica ou 2- Conta Juridica: ");
            int tipoConta = int.Parse(Console.ReadLine());

            Console.Write(" Digite o Nome do Titular: ");
            string nome = Console.ReadLine();

            Console.Write(" Digite o saldo inicial: R$ ");
            double saldo = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Console.Write(" Digite o credito: R$ ");
            double credito = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            listContas.Add(new Conta((TipoConta)tipoConta,saldo,credito,nome));
        
        }
        private static string Menu()
        {
            Console.WriteLine();
            Console.WriteLine("Bem-vindo ao Bank");
            Console.WriteLine();
            Console.WriteLine("Informe a opção desejada");
            Console.WriteLine();
            Console.WriteLine("1- Listar contas");
            Console.WriteLine("2- Inserir nova conta");
            Console.WriteLine("3- Transferir");
            Console.WriteLine("4- Sacar");
            Console.WriteLine("5- Depositar");
            Console.WriteLine("C - Limpar tela");
            Console.WriteLine("X - Sair");
            Console.WriteLine();

            string opcao = Console.ReadLine();
            Console.WriteLine();
            return opcao;
        }
    }
}
