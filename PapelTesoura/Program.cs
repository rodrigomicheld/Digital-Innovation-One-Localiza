using System;

namespace PapelTesoura
{
    class Program
    {
        static void Main(string[] args)
        {
            int qtdTeste = int.Parse(Console.ReadLine());
            string v1, v2;
            for (int i = 1; i <= qtdTeste; i++) //insira a variavel correta
            {
                string[] valores = Console.ReadLine().Split();
                v1 = valores[0].ToLower();
                v2 = valores[1].ToLower();
                System.Console.WriteLine(v1);
                if((v1 =="tesoura" && v2 =="papel") || (v1 =="papel" && v2 =="pedra") //complete a solução
                    || (v1 =="pedra" && v2 =="largato") || (v1 =="largato" && v2 =="spock")
                    || (v1 =="spock" && v2 =="tesoura") || (v1 =="tesoura" && v2 =="largato")
                    || (v1 =="largato" && v2 =="papel") || (v1 =="papel" && v2 =="spock")
                    || (v1 =="spock" && v2 =="pedra") || (v1 =="pedra" && v2 =="tesoura"))
                    Console.WriteLine("Caso #{0}: Bazinga!", i);                
                else if (v1==v2)   //complete a solucao
                    Console.WriteLine("Caso #{0}: De novo!", i);
                else
                    Console.WriteLine("Caso #{0}: Raj trapaceou!", i);
            }
        }
    }
}
