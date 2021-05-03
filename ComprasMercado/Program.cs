using System;

namespace ComprasMercado
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalDeCasosDeTeste = int.Parse(Console.ReadLine());
                string[] itens = new string[1000];
            for(int i=0; i<totalDeCasosDeTeste; i++){
                string[] lista = Console.ReadLine().ToLower().Split(" ");
                for(int j=0; ((j<lista.Length) && (j<1000)); j++){
                    itens[j] = lista[j].Substring(0,Math.Min(lista[j].Length,20));
                }
                ExibirListaFinal(itens);
                itens = new string[1000];
            }    
        }
        static void ExibirListaFinal (string[] lista){
            
            string atual,proxima ="";      
            StringComparer ordenar = StringComparer.InvariantCultureIgnoreCase;
            Array.Sort(lista, ordenar);

            for(int i=0;i<lista.Length;i++){
                atual = lista[i];
                if (atual != proxima){
                   proxima = atual;
                   System.Console.Write(lista[i]+" ");
               
                }
            }
            Console.WriteLine();
        }
    }
}
