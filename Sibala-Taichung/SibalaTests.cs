using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Sibala_Taichung
{
    [TestFixture()]
    class SibalaTests
    {
        [TestCase(1,2,3,4, "No Points", EnumOutputType.NoPoint, 0,TestName = "Sibala_When_Input_is_1_2_3_4_Should_return_NoPoints")]
        [TestCase(1,1,1,1, "Same Color", EnumOutputType.SameColor, 1,TestName = "Sibala_When_Input_is_1_1_1_1_Should_return_Same")]
        [TestCase(1,3,2,1, "5 Points", EnumOutputType.NPoints, 5,TestName = "Sibala_When_Input_is_1_3_2_1_Should_return_5 Points")]
        public void Sibala_Test(int dice1, int dice2, int dice3, int dice4, string expectedOutput, EnumOutputType ExpectedOutputType, int expectedPoint)
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
