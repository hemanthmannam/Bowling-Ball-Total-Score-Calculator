using BowlingBallScoreCalc.Models;
using BowlingBallScoreCalc.UnitOfWork;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBallScoreCalc.Tests
{
    [TestClass]
    public class BowlingFixture
    {
        [TestMethod]
        public void Bowling_Ball_Score_Calc_Test()
        {
            BowlingBallScoreCalcModel inputModel = new BowlingBallScoreCalcModel
            {
                TotalNoOfRounds = 10,
                LstExceptionalRounds = new List<ExceptionalRoundModel>
                {
                    new ExceptionalRoundModel
                    {
                        ExceptionalRound=10,
                        NoOfSlots=3
                    }
                },
                Scores = new List<int> { 3, 7, 5, 0, 10, 0, 10, 0, 9, 1, 8, 1, 7, 1, 9, 1, 6, 1, 6, 4, 10 }
            };

            Assert.AreEqual(147, new BowlingBallScoreGet().GetTotalBowlingBallScore(inputModel)?.TotalScore);

        }

        [TestMethod]
        public void Bowling_Ball_Score_Calc_Is_Invalid__Test()
        {
            BowlingBallScoreCalcModel inputModel = new BowlingBallScoreCalcModel
            {
                TotalNoOfRounds = 10,
                LstExceptionalRounds = new List<ExceptionalRoundModel>
                {
                    new ExceptionalRoundModel
                    {
                        ExceptionalRound=10,
                        NoOfSlots=3
                    }
                },
                Scores = new List<int> { 3, 7, 5, 0, 10, 0, 10, 0, 9, 1, 8, 1, 7, 1, 9, 1, 6, 1, 6, 4, 10, 1 }
            };

            Assert.IsFalse(new BowlingBallScoreGet().GetTotalBowlingBallScore(inputModel).IsValid);

        }

        [TestMethod]
        public void Bowling_Ball_Score_Calc_Is_Invalid_Test_2()
        {
            BowlingBallScoreCalcModel inputModel = new BowlingBallScoreCalcModel
            {
                TotalNoOfRounds = 10,
                LstExceptionalRounds = new List<ExceptionalRoundModel>
                {
                    new ExceptionalRoundModel
                    {
                        ExceptionalRound=10,
                        NoOfSlots=3
                    }
                },
                Scores = new List<int> { 3, 7, 5, 0, 10, 0, 10, 0, 9, 1, 8, 1, 7, 1, 9, 1, 6, 1, 6, 5, 10 }
            };

            Assert.IsFalse(new BowlingBallScoreGet().GetTotalBowlingBallScore(inputModel).IsValid);

        }

        [TestMethod]
        public void Bowling_Ball_Score_Calc_Is_Invalid_Test_3()
        {
            BowlingBallScoreCalcModel inputModel = new BowlingBallScoreCalcModel
            {
                TotalNoOfRounds = 10,
                LstExceptionalRounds = new List<ExceptionalRoundModel>
                {
                    new ExceptionalRoundModel
                    {
                        ExceptionalRound=10,
                        NoOfSlots=3
                    }
                },
                Scores = null
            };

            Assert.IsFalse(new BowlingBallScoreGet().GetTotalBowlingBallScore(inputModel).IsValid);

        }
    }
}
