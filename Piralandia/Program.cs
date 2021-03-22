using System;

namespace Piralandia
{
    class Program
    {
        static void Main(string[] args)
        {
            string n = Console.ReadLine();
            long entrada = Int64.Parse(n);
            char [] arr = new char[n.Length];
            int j = 0;
            System.Console.WriteLine(n.Length);

            for (int i = n.Length; i > 0 ; i--){
                
                arr[j] = n[i-1];
                j++;
            }
            string v = new string(arr);
            Console.WriteLine(v);


            
           // string v = new string(arr);
           // Console.WriteLine(v);
        }
    }
}
