using NUnit.Framework;

namespace Sibala_Taichung
{
    [TestFixture]
    public class SibalaComparerTests
    {
        private ISibala _firstRoll;

        private ISibala _secondRoll;

        [TestCase(new int[] { 1, 2, 3, 4 }, new int[] { 2, 2, 2, 2 })]
        [TestCase(new int[] { 1, 2, 1, 4 }, new int[] { 2, 2, 2, 2 })]
        [TestCase(new int[] { 1, 2, 4, 4 }, new int[] { 2, 2, 4, 1 })]
        [TestCase(new int[] { 4, 4, 3, 2 }, new int[] { 6, 6, 4, 1 })]
        public void Compare_ByType_SecondRoll_Win(int[] dice1, int[] dice2)
        {
            _firstRoll = new Sibala(dice1[0], dice1[1], dice1[2], dice1[3]);
            _secondRoll = new Sibala(dice2[0], dice2[1], dice2[2], dice2[3]);
            Assert.IsTrue(new SibalaComparer().Compare(_firstRoll, _secondRoll) < 0);
        }

        [TestCase(new int[] { 1, 2, 3, 2 }, new int[] { 1, 2, 3, 5 })]
        [TestCase(new int[] { 2, 2, 2, 2 }, new int[] { 3, 2, 4, 6 })]
        [TestCase(new int[] { 1, 1, 1, 1 }, new int[] { 4, 4, 4, 4 })]
        [TestCase(new int[] { 4, 4, 4, 4 }, new int[] { 6, 6, 6, 6 })]
        public void Compare_ByType_FirstRoll_Win(int[] dice1, int[] dice2)
        {
            _firstRoll = new Sibala(dice1[0], dice1[1], dice1[2], dice1[3]);
            _secondRoll = new Sibala(dice2[0], dice2[1], dice2[2], dice2[3]);
            Assert.IsTrue(new SibalaComparer().Compare(_firstRoll, _secondRoll) > 0);
        }

        [TestCase(new int[] { 4, 4, 3, 2 }, new int[] { 2, 6, 6, 3 })]
        public void First_Equal_Second(int[] dice1, int[] dice2)
        {
            _firstRoll = new Sibala(dice1[0], dice1[1], dice1[2], dice1[3]);
            _secondRoll = new Sibala(dice2[0], dice2[1], dice2[2], dice2[3]);
            Assert.IsTrue(new SibalaComparer().Compare(_firstRoll, _secondRoll) == 0);
        }
    }
}