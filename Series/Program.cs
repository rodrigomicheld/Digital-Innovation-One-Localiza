using System;

namespace Series
{
    class Program
    {
        static SeriesRepositorio repository = new SeriesRepositorio();
        static void Main(string[] args)
        {
            string op = Menu().ToUpper();

            while (op != "X"){

                switch (op){
                    case "1":
                       ListSeries();
                       break;
                    case "2":
                       InsertSeries();
                       break;
                    case "3":
                       UpdateSeries();
                       break;
                    case "4":
                       DeleteSeries();
                       break;
                    case "5":
                       ViewSeries();
                       break;
                    case "C":
                       Console.Clear();
                       break;
                    default:
                       throw new ArgumentOutOfRangeException();                                                                       
                }
                op = Menu().ToUpper();
            }
            Console.WriteLine("Thank You!");
        }

         public static void ViewSeries(){
            Console.WriteLine("----- View Series ------");

            Console.WriteLine("Enter with id Serie");
            int id = int.Parse(Console.ReadLine());
            
            var serie = repository.ReturnPerId(id);

            Console.WriteLine(serie);
        }

        public static void DeleteSeries(){
            Console.WriteLine("----- Remove Series ------");

            Console.WriteLine("Enter with id Serie");
            int id = int.Parse(Console.ReadLine());

            repository.Delete(id);
        }


        public static void UpdateSeries(){
            Console.WriteLine("----- Update Series ------");

            Console.WriteLine("Enter with id Serie");
            int id = int.Parse(Console.ReadLine());

            // varre todos generos no enum e lista
            foreach( int i in Enum. GetValues(typeof(Genre))){
                Console.WriteLine("{0} - {1} ", i, Enum.GetName(typeof(Genre),i));
            }
            Console.WriteLine( "Choice an option above ");
            int codGenre = int.Parse(Console.ReadLine());
            
            

            Console.WriteLine("Enter a Titlle the Series");
            string titlle = Console.ReadLine();

            Console.WriteLine("Enter a Descripton the Series");
            string descripton = Console.ReadLine();

            Console.WriteLine("Enter an Year the Series");
            int year = int.Parse(Console.ReadLine());
            
            Series series = new Series(id, (Genre)codGenre, titlle,descripton, year);
            repository.Update(id,series);
        }

         public static void InsertSeries(){
            Console.WriteLine("----- Insert New Series ------");
            
            // varre todos generos no enum e lista
            foreach(int i in Enum.GetValues(typeof(Genre))){
                Console.WriteLine("{0} - {1}", i, Enum.GetName(typeof(Genre),i));
            }
            Console.WriteLine( "Choice an option above ");
            int codGenre = int.Parse(Console.ReadLine());
            
            int id = repository.NextId();

            Console.WriteLine("Enter a Titlle the Series");
            string titlle = Console.ReadLine();

            Console.WriteLine("Enter a Descripton the Series");
            string descripton = Console.ReadLine();

            Console.WriteLine("Enter an Year the Series");
            int year = int.Parse(Console.ReadLine());
            
            Series series = new Series(id, (Genre)codGenre, titlle,descripton, year);
            repository.Insert(series);
        }

        public static void ListSeries(){
            Console.WriteLine("----- List Series ------");

            var List = repository.List();

            if (List.Count == 0){
                Console.WriteLine("List is empty!!");
                return;
            }

            foreach (var list in List){
                Console.WriteLine("ID: {0} - {1} {2}", list.returnId(), list.returnTitle(),(list.returnStatusExcluted() ? " Excluted" :""));
            }
        }

        public static string Menu(){
            Console.WriteLine();
            Console.WriteLine("Choice a option");
            Console.WriteLine();
            Console.WriteLine("1- List Series");
            Console.WriteLine("2- Insert a new Serie");
            Console.WriteLine("3- Update Serie");
            Console.WriteLine("4- Delete Series");
            Console.WriteLine("5- View Series");
            Console.WriteLine("C- Clean Screen");
            Console.WriteLine("X- Exit");
            Console.WriteLine();

            string op = Console.ReadLine();
            return op;
        }
    }
}
