using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class PickUpCommand : Command
    {

        public PickUpCommand() : base()
        {
            this.Name = "take";
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
                player.WarningMessage("\nTake What?");
            }
            return false;
        }

    }

}

