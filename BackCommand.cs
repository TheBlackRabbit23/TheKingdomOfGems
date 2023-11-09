using System.Collections;
using System.Collections.Generic;

namespace $safeprojectname$
{
    /*
     * Spring 2023
     */
    public class BackCommand : Command
    {

        public BackCommand() : base()
        {
            this.Name = "back";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.WaltTo(this.SecondWord);
            }
            else
            {
                player.WarningMessage("\nBack Where?");
            }
            return false;
        }
    }
}
