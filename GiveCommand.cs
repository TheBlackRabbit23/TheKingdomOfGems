using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class GiveCommand : Command
    {

        public GiveCommand() : base()
        {
            this.Name = "give";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.PickUp(this.SecondWord);
            }
            else
            {
                player.WarningMessage("\nGive What?");
            }
            return false;
        }

    }

}
