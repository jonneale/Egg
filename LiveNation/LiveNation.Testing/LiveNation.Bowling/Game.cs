using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveNation.Bowling
{
    public class Game
    {
        private bool _secondRoll;
        private int _firstRollScore;
        private bool _lastFrameWasSpare;
        private bool _lastFrameWasStrike;

        public int TotalPoints
        {
            get; protected set;
        }

        public void Roll(int points)
        {
            points = CalculateTotalPointsBasedOnLastFrame(points);

            SetStateOfGameBasedOnPinsKnockOver(points);

            _firstRollScore = _secondRoll ? 0 : points;

            TotalPoints += points;

            if (!_lastFrameWasStrike)
            {
                _secondRoll = !_secondRoll;
            }
        }

        private void SetStateOfGameBasedOnPinsKnockOver(int points)
        {
            if (points == 10)
            {
                _lastFrameWasStrike = true;
                _lastFrameWasSpare = false;
            }

            if (_secondRoll && (_firstRollScore + points) == 10)
            {
                _lastFrameWasSpare = true;
            }
        }

        private int CalculateTotalPointsBasedOnLastFrame(int points)
        {
            if ((!_secondRoll && _lastFrameWasSpare) || _lastFrameWasStrike)
            {
                points = points * 2;
            } 
            return points;
        }
    }
}
