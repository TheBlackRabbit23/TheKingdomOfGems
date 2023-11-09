using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class SearchCommand : Command
    {

        public SearchCommand() : base()
        {
            this.Name = "search";
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
                player.WarningMessage("\nSearch What?");
            }
            return false;
        }

    }

}
