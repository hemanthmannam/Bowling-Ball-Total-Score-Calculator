using BowlingBallScoreCalc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBallScoreCalc.ScoreCalcService
{
    public interface IScoreCalculator
    {
        int GetCurrentScore(BowlingBallScoreCalcModel inputModel, int roundNumber);
    }
}
