using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateurDonnee
{
    class CommandController : IAction
    {

        public projetbiContext Context { get; set; }
        private CommandRandomiser randomiser;
        private int timer = 0;
        public CommandController(projetbiContext Context)
        {
            this.Context = Context;
            randomiser = new CommandRandomiser() { Context = Context };
            randomiser.Date = DateTime.Now;
        }
        public void Execute()
        {
            randomiser.Date=randomiser.Date.AddSeconds(1);
            if (timer == 0)
            {
                var Commande = randomiser.GetCommande();
                Context.Add(Commande);
                Context.SaveChanges();
                var random = new Random();
                timer = random.Next(300, 900);
                //timer = random.Next(30, 120);
                Console.WriteLine("Commande Effectué à " + Commande.Date + ", " + Commande.LignesCommandes.Count + " lignes, prochaine commande dans " + timer +"s");
            }
            timer--;

        }
    }
}
