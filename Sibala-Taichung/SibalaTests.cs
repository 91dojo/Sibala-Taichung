using NUnit.Framework;

namespace Sibala_Taichung
{
    [TestFixture()]
    class SibalaTests
    {
        [TestCase(1, 2, 3, 4, "No Points", EnumOutputType.NoPoint, 0, 0, TestName = "Sibala_When_Input_is_1_2_3_4_Should_return_NoPoints")]
        [TestCase(1, 1, 1, 1, "Same Color", EnumOutputType.SameColor, 1, 1, TestName = "Sibala_When_Input_is_1_1_1_1_Should_return_Same")]
        [TestCase(1, 3, 2, 1, "5 Points", EnumOutputType.NPoints, 5, 3, TestName = "Sibala_When_Input_is_1_3_2_1_Should_return_5 Points")]
        [TestCase(3, 4, 4, 3, "8 Points", EnumOutputType.NPoints, 8, 4, TestName = "Sibala_When_Input_is_3_4_4_3_Should_return_8 Points")]
        [TestCase(4, 1, 2, 4, "BG", EnumOutputType.NPoints, 3, 2, TestName = "Sibala_When_Input_is_4_1_2_4")]
        [TestCase(2, 2, 6, 6, "Sibala", EnumOutputType.NPoints, 12, 6, TestName = "Sibala_When_Input_is_2_2_6_6")]
        [TestCase(3, 1, 3, 3, "No Points", EnumOutputType.NoPoint, 0, 0, TestName = "Sibala_When_Input_is_3_1_3_3")]
        public void Sibala_Test(int dice1, int dice2, int dice3, int dice4, string expectedOutput, EnumOutputType ExpectedOutputType, int expectedPoint, int expectedMaxPoint)
        {
            var sibala = new Sibala(dice1,dice2,dice3,dice4);
            Assert.AreEqual(expectedOutput, sibala.Output); 
            Assert.AreEqual(ExpectedOutputType, sibala.OutputType); 
            Assert.AreEqual(expectedPoint, sibala.Point); 
        }
    }

    internal class Sibala
    {
        public string Output { get; set; }

        public EnumOutputType OutputType { get; set; }

        public int Point { get; set; }
        
        private List<int> Dice = new List<int>();

        public Sibala(int dice1, int dice2, int dice3, int dice4)
        {
            Dice.Add(dice1);
            Dice.Add(dice2);
            Dice.Add(dice3);
            Dice.Add(dice4);
            GetResult();

        }

        private void GetResult()
        {
            if (IsNoPoint())
            {
                OutputType = EnumOutputType.NoPoint;
                Output = "No Points";
            }
            else if(IsSameColor())
            {
                OutputType = EnumOutputType.SameColor;
                Point = Dice.First();
                Output = "Same Color";
            }
            else if (IsNormalPoint())
            {
                Point = Dice.GroupBy(x => x).Where(x => x.Count() == 1).Sum(x => x.Key);
                Output = Point + " Points";
                OutputType = EnumOutputType.NPoints;
            }
        }

        private bool IsNoPoint()
        {
            return Dice.GroupBy(x => x).Count() == Dice.Count;
        }

        private bool IsNormalPoint()
        {
            return Dice.Distinct().Count() == 3;
        }

        private bool IsSameColor()
        {
            return Dice.Distinct().Count() == 1;
        }
    }
}
