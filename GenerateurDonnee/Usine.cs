using System;
using System.Collections.Generic;
using System.Text;

namespace GenerateurDonnee
{
    class Usine : IAction
    {
        private MachineControllerFab controllerFab;
        private MachineControllerCond controllerCond;
        public projetbiContext Context { get; set; }
        public Usine(projetbiContext context)
        {
            Context = context;
            controllerFab = new MachineControllerFab(context);
            controllerCond = new MachineControllerCond(context);

        }
        public void Execute()
        {
            controllerFab.Execute();
            controllerCond.Execute();
        }
    }
}
