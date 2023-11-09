using System.Collections;
using System.Collections.Generic;
using System;

namespace $safeprojectname$
{
    /*
     * Spring 2023
     */
    public class Game
    {
        private Player _player;
        private Parser _parser;
        private bool _playing;

        public Game()
        {
            _playing = false;
            _parser = new Parser(new CommandWords());
            _player = new Player(GemsWorld.Instance.Entrance);
        }

        /**
     *  Main play routine.  Loops until end of play.
     */
        public void Play()
        {

            // Enter the main command loop.  Here we repeatedly read commands and
            // execute them until the game is over.

            bool finished = false;
            while (!finished)
            {
                Console.Write("\n>");
                Command command = _parser.ParseCommand(Console.ReadLine());
                if (command == null)
                {
                    _player.ErrorMessage("I don't understand...");
                }
                else
                {
                    finished = command.Execute(_player);
                }
            }
        }


        public void Start()
        {
            _playing = true;
            _player.InfoMessage(Welcome());
        }

        public void End()
        {
            _playing = false;
            _player.InfoMessage(Goodbye());
        }

        public void Win()
        {
            _playing = true;
            _player.InfoMessage(Winner());
            Start();
        }

        public void Lose()
        {
            _playing = false;
            _player.InfoMessage(Loser());
            Start();
        }


        public string Welcome()
        {

            return "Welcome to The Kingdom Of Gems. " +
            "\nFour friends were walking in a park having a wonderful time, forgetting all the worries of the world. " +
            "\nSuddenly, they stumbled upon a peculiar looking door that they had never seen before. Curiosity got " +
            "\nthe best of them and they opened the door one by one, only to be taken aback by the scenery inside. " +
            "\nThe sun was shining brighter then they had ever seen and the sky was a deep blue. Excited by what " +
            "\nthey found, the four girls decided to explore the new realm. They soon realised that it was called " +
            "\nGems World and that it was a strange place. The air was filled with the sweet smell of flowers and there " +
            "\nwere sights to behold everywhere. But before they could explore further, they were told by a wise old " +
            "\nlady that the only way to leave Gems World was to find the four boxes with the keys needed to return back " +
            "\nto the earth. She told them that the boxes were hidden somewhere in the realm and that the only way to " +
            "\nfind them was to search for clues. The girls did as told and set off on their adventure. " +

            "\n\nType 'help' if you need help." + _player.CurrentRoom.Description();
        }

        public string Winner()
        {
            return
            "\nAfter days of searching, they finally found the four boxes and keys inside. " +
            "\nWhen they tried to open them with the keys, they realised that the boxes were " +
            "\nonly able to open when they were all used together. The friends celebrated in " +
            "\njoy as they opened the boxes and used the keys to return to the earth. As they " +
            "\nclosed the mysterious portal door, they vowed to never forget their special " +
            "\njourney in the Kingdom Of Gems. " + _player.CurrentRoom.Description();



        }

        public string Loser()
        {
            return
            "\nAfter days of searching, they couldn't found all the four boxes or the keys inside. " +
            "\nThe friends vowed to never forget their special journey in the Kingdom Of Gems, but " +
            "\nwere downhearted because they all long to return back to earth. Do you want to " +
            "\ncontinue or restart the game. " +_player.CurrentRoom.Description();
        }
           

        public string Goodbye()
        {
            return "\nThank you for playing, Goodbye. \n";
        }

    }
}
