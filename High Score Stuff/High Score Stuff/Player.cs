using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Dynamic;
using System.Numerics;

namespace High_Score_Stuff
{
    public class HighScores
    {
        private int score;
        private string initials;


        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public string Initials
        {
            get { return initials; }
            set { initials = value; }
        }


        /*public Fart(int score, string initials)
        {
            Score = score;
            Initials = initials;
        }
        */

        public HighScores(int score, string initials)
        {
            Initials = initials;
            Score = score;
        }

        public void PlayerInfo()
        {
            Console.WriteLine($"Score is: {Score}, Initials are: {Initials}");
        }

        //  4. Create a constructor that takes two parameters, initials, and score, and initializes the corresponding properties.

        //Differentiating between private and public stuff is the biggest issue here.
        //Not crazy hard just step. 3 that seems confusing.
    }
}

