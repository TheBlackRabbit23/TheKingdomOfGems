using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class InventoryCommand : Command
    {
        public InventoryCommand()
        {

            this.Name = "inventory";
        }


        public override bool Execute(Player player)
        {
            player.Inventory();
            return false;
        }
    }
}
