using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bankamat
{
    abstract class DocumentProgram
    {
        protected DocumentProgram(string name)
        {
            Name = name;

        }

        public string Name { get; set; }
        public int Budjet { get; set; } = 20;


        public void OpenDock()
        {
            Console.WriteLine("Document openned succesufuly");
        }
        public virtual void EditDock()
        {
            Console.WriteLine("Document edited succesufuly");
        }
        public virtual void SaveDock()
        {
            Console.WriteLine("Document saved succesufuly");
        }

        public virtual void ShowCharacter()
        {
            Console.WriteLine($"Name - {Name}\nBudjet - {Budjet}");

        }

    }


    class ProDockProgram : DocumentProgram
    {


        public ProDockProgram(string name) : base(name)
        {
            base.Budjet -= 3;

        }
        public sealed override void EditDock()
        {
            Console.WriteLine("Edited with pro version.");
        }
        public override void SaveDock()
        {
            Console.WriteLine("Document Saved in doc format, for pdf format buy Expert packet");
        }
        public override void ShowCharacter()
        {
            base.ShowCharacter();
        }



    }
    class ExpertDock : DocumentProgram
    {
        public ExpertDock(string name) : base(name)
        {
            base.Budjet -= 5;

        }
        public sealed override void EditDock()
        {

            Console.WriteLine("Edited with expert version.");
        }
        public override void SaveDock()
        {
            Console.WriteLine("Document Saved in pdf format");
        }
        public override void ShowCharacter()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            base.ShowCharacter();
        }

    }

    static class Dock
    {
        public static string Basic { get; set; } = "Basic";
        public static string Pro { get; set; } = "Pro";
        public static string Expert { get; set; } = "Expert";

    }



    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\tHello and welcome!");
            Console.WriteLine($"Whichone do you want?\n1)pro version \nPRICE ; 3$\n\n2)Expert version  \nPRICE : 5$ ");
            string name;

            string e = Dock.Basic;
            Console.WriteLine(Dock.Basic);
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("For Basic write basic\nFor Pro write pro");
                string text;
                Console.WriteLine("Write hire : ");
                text = Console.ReadLine();
                if (text == "basic")
                {
                    Console.WriteLine($"You choose {Dock.Basic}");
                    Console.WriteLine("Enter your name : ");
                    name = Console.ReadLine();

                    DocumentProgram s = new ProDockProgram(name);
                    s.ShowCharacter();
                    s.EditDock();
                    s.SaveDock();
                    s.OpenDock();
                    Thread.Sleep(2000);
                    Console.Clear();
                }

                else if (text == "pro")
                {
                    Console.WriteLine($"You choose {Dock.Pro}");
                    Console.WriteLine("Enter your name : ");
                    name = Console.ReadLine();

                    DocumentProgram s = new ExpertDock(name);
                    s.ShowCharacter();
                    s.EditDock();
                    s.SaveDock();
                    s.OpenDock();
                    Thread.Sleep(2000);
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("False!");
                    Thread.Sleep(2000);
                    Console.Clear();
                    continue;

                }
            }
        }

    }
}
