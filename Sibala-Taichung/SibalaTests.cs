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
        [Test]
        public void Sibala_When_Input_is_1_2_3_4_Should_return_NoPoints()
        {
            var sibala = new Sibala(1,2,3,4);
            Assert.AreEqual("No Points", sibala.Output); 
            Assert.AreEqual(EnumOutputType.NoPoint, sibala.OutputType); 
            Assert.AreEqual(0, sibala.Point); 
        }

        [Test]
        public void Sibala_When_Input_is_1_1_1_1_Should_return_Same()
        {
            var sibala = new Sibala(1, 1, 1, 1);
            Assert.AreEqual("Same Color", sibala.Output);
            Assert.AreEqual(EnumOutputType.SameColor, sibala.OutputType);
            Assert.AreEqual(1, sibala.Point);
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

        }

        private void SetResult(int dice1, int dice2, int dice3, int dice4)
        {
            throw new NotImplementedException();
        }

        public string Output { get; set; }
        public EnumOutputType OutputType { get; set; }
        public int Point { get; set; }

    }
}
