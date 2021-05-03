using System;
using System.Globalization;

namespace Quadrante
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] entrada = Console.ReadLine().Split(" ");
            double x = double.Parse(entrada[0]);
            double y = double.Parse(entrada[1]);
            string resultado;
          
            if ((x<0) && (y>0))
                resultado = "Q2";
            else if ((x>0) && (y>0))
                resultado = "Q1";
            else if ((x<0) && (y<0))
                resultado = "Q3";
            else if ((x>0) && (y<0))
                resultado = "Q4";  
            else if (((x>0) && (y==0))||((x<0) && (y==0)))
                resultado = "Eixo X";
            else if (((x==0) && (y>0))||((x==0) && (y<0)))
                resultado = "Eixo Y";  
            else 
                resultado = "Origem";
            
          Console.WriteLine(resultado);
         
    }
        }
    
}

