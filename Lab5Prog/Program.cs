using System;
using System.Text.RegularExpressions;

namespace Lab5Prog
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к файлу: ");
            string path = Console.ReadLine();
            Console.WriteLine("Выберите:");
            ReturnProg:
                Console.WriteLine("1) Замена слов\n2) Замена номеров");
                string change = Console.ReadLine();
                switch (change)
                {
                    case "1":
                        Dictionary dictionary = new Dictionary(path);
                        dictionary.GetInfo();
                        break;
                    case "2":

                        Regexes regexes = new Regexes(path);
                        regexes.GetNumbers();
                        break;
                }
            Console.WriteLine("Повторить?(Да или нет)");
            string returnProg = Console.ReadLine();
            if (returnProg == "Да" || returnProg == "да")
            {
                goto ReturnProg;
            }
            else Console.ReadKey();


        }
    }
}
