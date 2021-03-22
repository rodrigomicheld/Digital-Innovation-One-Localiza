using System;

namespace TempoEvento
{
    class Program
    {
        static void Main(string[] args)
        {
            int diaInicio, diaTermino, horaMomentoInicio, minutoMomentoInicio, segundoMomentoInicio;
            int horaMomentoTermino, minutoMomentoTermino, segundoMomentoTerminio;
            //continue escrevendo a solucao
            System.Console.WriteLine("informa x pra encerrar");
            string op ="";

            while (! op.Equals("x")){
            string[] dadosInicio = Console.ReadLine().Split();
            diaInicio = Convert.ToInt32(dadosInicio[1]);

            string[] dadosMomentoInicio = Console.ReadLine().Split();
            horaMomentoInicio = Convert.ToInt32(dadosMomentoInicio[0]);
            minutoMomentoInicio = Convert.ToInt32(dadosMomentoInicio[2]);
            segundoMomentoInicio = Convert.ToInt32(dadosMomentoInicio[4]);
            
            string[] dadosTermino = Console.ReadLine().Split();
            diaTermino = Convert.ToInt32(dadosTermino[1]);
            
            string[] dadosMomentoTermino = Console.ReadLine().Split();
            horaMomentoTermino = Convert.ToInt32(dadosMomentoTermino[0]);
            minutoMomentoTermino = Convert.ToInt32(dadosMomentoTermino[2]);
            segundoMomentoTerminio = Convert.ToInt32(dadosMomentoTermino[4]);
               
            
            int dias = ((diaTermino - diaInicio)*86400);
            int segundosHoras = ((horaMomentoTermino - horaMomentoInicio)*3600);
            int transformaSegundosInicio = ((horaMomentoInicio*3600)+(minutoMomentoInicio*60)+segundoMomentoInicio);
            int transformaSegundosTermino = ((horaMomentoTermino*3600)+(minutoMomentoTermino*60)+segundoMomentoTerminio);

            
            int somaTotalSegundos = (dias + (transformaSegundosTermino - transformaSegundosInicio));
            int W = somaTotalSegundos/86400;
            int X = (somaTotalSegundos % 86400)/3600;
            int Y = ((somaTotalSegundos % 86400) % 3600)/60;
            int Z = (((somaTotalSegundos % 86400) % 3600)%60)%60;
            
            
                        
            Console.WriteLine("{0} dia(s)", W);
            Console.WriteLine("{0} horas(s)", X);
            Console.WriteLine("{0} minutos(s)", Y);
            Console.WriteLine("{0} segundos(s)", Z);

            System.Console.WriteLine( "continuar");
            op = Console.ReadLine();
        }
        }
    }
}
