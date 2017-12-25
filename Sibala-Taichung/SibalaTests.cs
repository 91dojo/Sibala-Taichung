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
        private List<int> diceList = new List<int>();
        public Sibala(int dice1, int dice2, int dice3, int dice4)
        {
            diceList.Add(dice1);
            diceList.Add(dice2);
            diceList.Add(dice3);
            diceList.Add(dice4);
            GetResult();

        }

        private void GetResult()
        {
            if (diceList.GroupBy(x => x).Count() == diceList.Count)
            {
                Output = "No Points";
                OutputType = EnumOutputType.NoPoint;
            }
            else if(diceList.Distinct().Count() == 1)
            {
                Output = "Same Color";
                OutputType = EnumOutputType.SameColor;
                Point = diceList.First();
            }
            else if (diceList.Distinct().Count() == 3)
            {
                Point = diceList.GroupBy(x => x).Where(x => x.Count() == 1).Sum(x => x.Key);
                Output = Point + " Points";
                OutputType = EnumOutputType.NPoints;
            }
        }

        public string Output { get; set; }
        public EnumOutputType OutputType { get; set; }
        public int Point { get; set; }

    }
}
