using System.Collections;
using System.Collections.Generic;
using System;

namespace $safeprojectname$
{
    /*
     * Spring 2023
     */
    public class Parser
    {
        private CommandWords _commands;

        public Parser() : this(new CommandWords()) { }

        // Designated Constructor
        public Parser(CommandWords newCommands)
        {
            _commands = newCommands;
        }

        public Command ParseCommand(string commandString)
        {
            Command command = null;
            string[] words = commandString.Split(' ');
            if (words.Length > 0)
            {
                command = _commands.Get(words[0]);
                if (command != null)
                {
                    if (words.Length > 1)
                    {
                        command.SecondWord = words[1];
                        command.ThirdWord = words[2];
                        command.FourthWord = words[3];
                        command.FifthWord = words[4];
                    }
                    else
                    {
                        command.SecondWord = null;
                        command.ThirdWord = null;
                        command.FourthWord = null;
                        command.FifthWord = null;
                    }
                }
                else
                {
                    
                }
            }
            else
            {
                
            }
            return command;
        }

        public string Description()
        {
            return _commands.Description();
        }
    }
}
