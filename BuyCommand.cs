using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class BuyCommand : Command
    {

        public BuyCommand() : base()
        {
            this.Name = "buy";
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
                player.WarningMessage("\nBuy What?");
            }
            return false;
        }

    }

}
