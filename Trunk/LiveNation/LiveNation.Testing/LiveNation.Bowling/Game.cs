using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveNation.Bowling
{
    public class Game
    {
        public int Points
        {
            get; protected set;
        }

        public void Roll(int points)
        {
            Points += points;
        }
    }
}
