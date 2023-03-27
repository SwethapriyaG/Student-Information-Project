using System;
using System.Collections.Generic;
using System.Linq;

namespace Programmering_2_projekt
{
    class ProgramManager
    {
        private bool programQuit = false;
        private Input input = new Input(); // instansierar ett objekt
        private Menu menu = new Menu();
        public void Start()
        {
            UserChoice userChoice = new UserChoice(input);
            
            while (programQuit == false)
            {
                menu.MainMenuText();
                programQuit=userChoice.UserChoiceCase();
            }
        }

    }
}
