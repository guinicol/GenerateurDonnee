using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateurDonnee
{
    class CommandController : IAction
    {

        public projetbiContext Context { get; set; }
        private CommandRandomiser randomiser;
        public CommandController(projetbiContext Context)
        {
            this.Context = Context;
            randomiser = new CommandRandomiser() { Context=Context };
        }
        public void Execute()
        {
            var Commande = randomiser.getCommande();

        }
    }
}
