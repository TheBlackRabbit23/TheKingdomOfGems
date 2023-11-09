using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class ReadCommand : Command
    {

        public ReadCommand() : base()
        {
            this.Name = "read";
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
                player.WarningMessage("\nRead What?");
            }
            return false;
        }

    }

}
