using System.Collections;
using System.Collections.Generic;

namespace $safeprojectname$
{
    /*
     * Spring 2023
     */
    public class MeetCommand : Command
    {

        public MeetCommand() : base()
        {
            this.Name = "meet";
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
                player.WarningMessage("\nMeet Where?");
            }
            return false;
        }
    }
}
