using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace GenerateurDonnee
{
    class Program
    {
        private List<IAction> Actions;
        private projetbiContext Context;
        private const int timer = 5;

        /// <summary>
        /// Heure actuelle dans le Programme (à utiliser pour les enregistrements : Accélère le temps)
        /// </summary>
        static public DateTime Date { get; set; }
        static void Main(string[] args)
        {
            if (File.Exists("date.txt"))
            {
                var reader = new StreamReader(new FileStream("date.txt", FileMode.Open));
                Date = DateTime.Parse(reader.ReadLine());

            }
            else
            {
                Date = DateTime.Now;
            }
            var program = new Program();

        }
        public Program()
        {
            Actions = new List<IAction>();
            Context = new projetbiContext();

            var CommandCtrl = new CommandController(Context);
            Actions.Add(CommandCtrl);
            var UsineCtrl = new Usine(Context);
            Actions.Add(UsineCtrl);
            while (true)
            {
                Date = Date.AddSeconds(1);
                foreach (var item in Actions)
                {
                    item.Execute();
                }
                Thread.Sleep(timer);
            }
        }
    }
}