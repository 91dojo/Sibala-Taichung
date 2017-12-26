﻿using NUnit.Framework;

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
}
