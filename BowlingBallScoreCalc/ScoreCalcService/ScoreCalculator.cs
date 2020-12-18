using BowlingBallScoreCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BowlingBallScoreCalc.ScoreCalcService
{
    public class ScoreCalculator : IScoreCalculator
    {
        public int GetCurrentScore(BowlingBallScoreCalcModel inputModel, int roundNumber)
        {
            var ExceptionalRound = inputModel.LstExceptionalRounds.FirstOrDefault(a => a.ExceptionalRound == roundNumber);

            int NumberOfSlots = 2, ExtraSlots = 0;

            if (ExceptionalRound != null)
                NumberOfSlots = ExceptionalRound.NoOfSlots;

            if (ExceptionalRound?.NoOfSlots < NumberOfSlots)
                return 0;


            if (inputModel.LstExceptionalRounds.Any(a => a.ExceptionalRound < roundNumber))
            {
                var ExceptionalRounds = inputModel.LstExceptionalRounds.Where(a => a.ExceptionalRound < roundNumber);

                ExtraSlots = ExceptionalRounds.Sum(a => a.NoOfSlots) - (ExceptionalRounds.Count() * 2);
            }

            List<int> LstCurrentRoundScores = inputModel.Scores.Skip(ExtraSlots + ((roundNumber - 1) * 2)).Take(NumberOfSlots).ToList();



            if (LstCurrentRoundScores.Take(2).Sum() > 10 || LstCurrentRoundScores.First() == 0)
                return 0;

            //calculate spare
            if (LstCurrentRoundScores.Sum() == 10 && LstCurrentRoundScores.First() != 10 && ExceptionalRound == null)
            {
                if (ExceptionalRound == null)
                    LstCurrentRoundScores.Add(inputModel.Scores.Skip(roundNumber == 1 ? 2 : ExtraSlots + (NumberOfSlots + ((roundNumber - 1) * 2))).First());

                return LstCurrentRoundScores.Sum();
            }

            //when not all the pins are knocked or the round is exceptional(generally 10th round)
            if (LstCurrentRoundScores.Sum() < 10 || ExceptionalRound != null)
            {
                return LstCurrentRoundScores.Sum();
            }

            if (LstCurrentRoundScores.First() == 10 && ExceptionalRound == null)
            {
                List<int> nextSlots = inputModel.Scores.Skip(((roundNumber - 1) * 2) + NumberOfSlots).Take(4).ToList();

                List<int> FinalSlotresults = new List<int>();

                if (nextSlots.First() == 10)
                {
                    FinalSlotresults.Add(nextSlots.First());
                    FinalSlotresults.Add(nextSlots.Skip(2).First());
                }
                else
                {
                    FinalSlotresults.AddRange(nextSlots.Take(2));
                }

                LstCurrentRoundScores.AddRange(FinalSlotresults);

                return LstCurrentRoundScores.Sum();
            }


            return 0;
        }
    }
}
