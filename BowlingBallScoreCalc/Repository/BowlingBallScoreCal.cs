using BowlingBallScoreCalc.Models;
using BowlingBallScoreCalc.ScoreCalcService;
using BowlingBallScoreCalc.UnitOfWork;

namespace BowlingBallScoreCalc.Repository
{
    public class BowlingBallScoreCal : IBolingBallScoreCalc
    {
        private readonly IScoreCalculator _iScoreCalculator;
        public BowlingBallScoreCal(IScoreCalculator scoreCalculator)
        {
            _iScoreCalculator = scoreCalculator;
        }
        public BowlingBallScoreCalcOutputModel CalculateBowlingBallScore(BowlingBallScoreCalcModel inputModel)
        {
            return new BowlingBallScoreGet(_iScoreCalculator).GetTotalBowlingBallScore(inputModel);
        }
    }
}
