using System;
using System.Collections.Generic;
using System.Linq;

namespace kolokwium
{
    class Program
    {

        public class Post 
        {
            public int BookId { get; set; }
            public string Tytul { get; set; }
            public string Autor { get; set; }
            public string Tresc { get; set; }
            public DateTime DataDodania { get; set; }

            public Post(int fakeId, string title, string author, string context, DateTime date)
            {
                BookId = fakeId;
                Tytul = title;
                Autor = author;
                Tresc = context;
                DataDodania = date;
            }
        }

        public static Random gen = new Random();

        public static DateTime RandomDay()
        {
            DateTime start = new DateTime(1995, 1, 1, 10, 15, 13);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[gen.Next(s.Length)]).ToArray());
        }

        public static void ReturnSortedList(int start, int amount)
        {
            List<Post> list = new List<Post>();


            for (int i = 0; i < 100; i++)
            {
                Post post1 = new Post(i,RandomString(15), "aaa", "ghi", RandomDay());
                list.Add(post1);
            }

            var sortedList = list.Where(x => x.BookId >= start && x.BookId <= (start + amount)).OrderBy(x => x.Tytul).OrderBy(x => x.DataDodania);

            foreach (var item in sortedList)
            {
                Console.WriteLine($"Tytuł: {item.Tytul} DataDodania: {item.DataDodania}");
            }
        }

        public static string JoinStrings<T>(ref T first, ref T second)
        {
            string a = first.ToString();
            string b = second.ToString();

            return a + b;
        }

        void HandleSomethingHappened(string foo)
        {

        }


        static void Main(string[] args)
        {
            //Bank bank = new Bank();
            Klient klient = new Klient();

            //zad1
            Console.WriteLine("Podaj startowy indeks: (0 - 100) ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Podaj ilość obiektów do pokazania: ");

            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Zadanie 1:");
            ReturnSortedList(a,b);
            Console.WriteLine();
            Console.WriteLine("Zadanie 2:");
            Console.WriteLine("Imie:");
            string imie = Console.ReadLine();
            Console.WriteLine("Nazwisko:");
            string nazwisko = Console.ReadLine();
            Console.WriteLine(ExtensionMethods.Rodo(imie) + " " + ExtensionMethods.Rodo(nazwisko));

            string joinLeft = "aaa";
            string joinRight = "bbb";
            Console.WriteLine("Zadanie 5:");
            Console.WriteLine(JoinStrings<string>(ref joinLeft, ref joinRight));
            Console.WriteLine("Zadanie 4:");
            klient.NoweZgloszenie += Klient_NoweZgloszenie;

        }

        private static void Klient_NoweZgloszenie(object sender, EventArgs e)
        {
            Bank bank = new Bank();
            bank.OtrzymanoZgloszenie += Bank_OtrzymanoZgloszenie1;
        }

        private static void Bank_OtrzymanoZgloszenie1(object sender, EventArgs e)
        {
            Console.WriteLine("Otrzymano zgłoszenie");
        }
    }
}
