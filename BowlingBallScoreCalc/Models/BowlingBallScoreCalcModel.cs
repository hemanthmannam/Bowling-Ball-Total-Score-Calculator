using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBallScoreCalc.Models
{
    public class BowlingBallScoreCalcModel
    {
        public int TotalNoOfRounds { get; set; }
        public List<int> Scores { get; set; }
        public List<ExceptionalRoundModel> LstExceptionalRounds { get; set; }
    }
    public class ExceptionalRoundModel
    {
        public int ExceptionalRound { get; set; }
        public int NoOfSlots { get; set; }
    }
    public class BowlingBallScoreCalcOutputModel
    {
        public bool IsValid { get; set; }
        public List<int> Scores { get; set; }
        public int TotalScore { get; set; }
    }
}
