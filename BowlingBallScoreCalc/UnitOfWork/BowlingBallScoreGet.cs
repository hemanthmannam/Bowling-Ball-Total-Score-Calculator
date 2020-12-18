using BowlingBallScoreCalc.Models;
using BowlingBallScoreCalc.ScoreCalcService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BowlingBallScoreCalc.UnitOfWork
{
    public class BowlingBallScoreGet
    {
        private readonly IScoreCalculator _iScoreCalculator;
        private BowlingBallScoreCalcOutputModel response = new BowlingBallScoreCalcOutputModel();
        public BowlingBallScoreGet(IScoreCalculator scoreCalculator)
        {
            _iScoreCalculator = scoreCalculator;
        }
        public BowlingBallScoreGet()
        {
            _iScoreCalculator = new ScoreCalculator();
        }

        public BowlingBallScoreCalcOutputModel GetTotalBowlingBallScore(BowlingBallScoreCalcModel inputModel)
        {
            List<int> LstScores = new List<int>();
            int CurrentTotalScore = 0;
            response.IsValid = true;
            response.Scores = new List<int>();

            int ValidNumberOfSlots = ((inputModel.TotalNoOfRounds - inputModel.LstExceptionalRounds?.Count ?? 0) * 2) + inputModel.LstExceptionalRounds?.Sum(a => a.NoOfSlots) ?? 0;

            if (inputModel.Scores == null || inputModel.TotalNoOfRounds == 0)
                return new BowlingBallScoreCalcOutputModel
                {
                    IsValid = false
                };

            if (inputModel.Scores.Any(a => a > 10 || a < 0)
                || inputModel.Scores.Count != ValidNumberOfSlots
                || inputModel.LstExceptionalRounds?.GroupBy(a => a.ExceptionalRound)?.Count() < inputModel.LstExceptionalRounds?.Count())
                return new BowlingBallScoreCalcOutputModel
                {
                    IsValid = false
                };

            for (int i = 1; i <= inputModel.TotalNoOfRounds; i++)
            {
                int result = _iScoreCalculator.GetCurrentScore(inputModel, i);

                if (result != 0)
                    LstScores.Add(result);
                else
                    break;

                CurrentTotalScore = LstScores.Sum();

                response.Scores.Add(CurrentTotalScore);
            }

            if (LstScores.Count != inputModel.TotalNoOfRounds)
                return new BowlingBallScoreCalcOutputModel
                {
                    IsValid = false
                };
            else
            {
                response.TotalScore = LstScores.Sum();
                return response;
            }
        }
    }
}
