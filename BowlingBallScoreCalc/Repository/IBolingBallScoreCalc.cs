using BowlingBallScoreCalc.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBallScoreCalc.Repository
{
    public interface IBolingBallScoreCalc
    {
        BowlingBallScoreCalcOutputModel CalculateBowlingBallScore(BowlingBallScoreCalcModel inputModel);
    }
}
