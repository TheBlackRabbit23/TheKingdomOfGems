using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    public class CharacterCommand : Command
    {

        public CharacterCommand() : base()
        {
            this.Name = "character";
        }

        override
        public bool Execute(Player player)
        {
            if (this.HasSecondWord())
            {
                player.Examine(this.SecondWord);
            }
            else
            {
                player.WarningMessage("\nCharacter Who?");
            }
            return false;
        }
    }
}
