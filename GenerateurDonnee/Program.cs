using System;
using System.Collections.Generic;
using System.Threading;

namespace GenerateurDonnee
{
    class Program
    {
        private List<IAction> Actions;
        private projetbiContext Context;
        private const int timer = 1000;
        static void Main(string[] args)
        {
            var program = new Program();

        }
        public Program()
        {
            Actions = new List<IAction>();
            Context = new projetbiContext();

            var CommandCtrl = new CommandController(Context);
            Actions.Add(CommandCtrl);

            while (true)
            {
                foreach (var item in Actions)
                {
                    item.Execute();
                }
                Thread.Sleep(timer);
            }
        }
    }
}