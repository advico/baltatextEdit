using System;
using System.IO;

namespace textEdit
{
    class Program 
    {
        static void Main(string[]args)
        {
            Menu();
        }
        static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Escolha uma opção: ");
            Console.WriteLine("Abrir arquivo (opção 1)");
            Console.WriteLine("Criar novo arquivo (opção 2)");
            Console.WriteLine("Sair (opção 0)");
            short option = short.Parse(Console.ReadLine());
            switch (option)
            {
                case 0: System.Environment.Exit(0); break;
                case 1: Abrir(); break;
                case 2: Editar(); break;
                default: Menu(); break;
            }
        }
        static void Abrir()
        {
            Console.Clear();
            Console.WriteLine(" Qual caminho do arquivo ? ");
            string path = Console.ReadLine();

            using (var file = new StreamReader(path))
            {
                string text = file.ReadToEnd();
                Console.WriteLine(text);
            }
            Console.WriteLine("");
            Console.ReadLine();
            Menu();

        }
        static void Editar()
        {
            Console.Clear();
            Console.WriteLine("Escreva seu texto (ESC para sair)");
            Console.WriteLine("----------");
            string text ="";
            
            do 
            {
                text += Console.ReadLine();
                text += Environment.NewLine;
            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            Console.Write(text);
        }
        static void Salvar(string text)
        {
            Console.Clear();
            Console.WriteLine("Onde deseja salvar o arquivo ?");
            var path = Console.ReadLine();

            using (var file = new StreamWriter(path))
            {
                file.Write(text);
            }
            
            Console.WriteLine($"Arquivo {path} salvo! ");
            Console.ReadLine();
            Menu();
        }
    }
    
}