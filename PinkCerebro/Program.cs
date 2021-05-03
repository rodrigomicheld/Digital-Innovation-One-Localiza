using System;

namespace PinkCerebro
{
    class Program
    {
        static void Main(string[] args)
        {
            int tamanhoLista= int.Parse(Console.ReadLine());
            int multi2 = 0, multi3 = 0, multi4 = 0, multi5 = 0;

       //declare suas variaveis aqui   

            string[] entrada = Console.ReadLine().Split();

      //continue a solução
            for (int i=0; i<entrada.Length; i++)
            {
                int valor = int.Parse(entrada[i]);

                if (valor%2==0)
                   multi2++;
                
                if (valor%3==0)
                   multi3++;
                
                if (valor%4==0)
                   multi4++;

                if (valor%5==0)
                   multi5++;
            }

            Console.WriteLine("{0} Multiplo(s) de 2",multi2);
            Console.WriteLine("{0} Multiplo(s) de 3",multi3);
            Console.WriteLine("{0} Multiplo(s) de 4",multi4);
            Console.WriteLine("{0} Multiplo(s) de 5",multi5);
        }
    }
}
