using System.Collections;
using System.Collections.Generic;
using System;

namespace $safeprojectname$
{

    /*
     * Spring 2023
     */
    public abstract class Command
    {
        private string _name;
        public string Name { get { return _name; } set { _name = value; } }
        private string _secondWord;
        public string SecondWord { get { return _secondWord; } set { _secondWord = value; } }
        private string _thirdWord;
        public string ThirdWord { get { return _thirdWord; } set { _thirdWord = value; } }
        private string _fourthWord;
        public string FourthWord { get { return _fourthWord; } set { _fourthWord = value; } }
        private string _fifthWord;
        public string FifthWord { get { return _fifthWord; } set { _fifthWord = value; } }
        public Command()
        {
            this.Name = "";
            this.SecondWord = null;
            this.ThirdWord = null;
            this.FourthWord = null;
            this.FifthWord = null;
        }

        public bool HasSecondWord()
        {
            return this.SecondWord != null;
        }
        public bool HasThirdWord()
        {
            return this.ThirdWord != null;
        }
        public bool HasFourthWord()
        {
            return this.FourthWord != null;
        }
        public bool HasFifthWord()
        {
            return this.FifthWord != null;
        }


        public abstract bool Execute(Player player);
    }
}
