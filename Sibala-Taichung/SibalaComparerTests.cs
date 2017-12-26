using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace Sibala_Taichung
{
    [TestFixture]
    public class SibalaComparerTests
    {
        private SibalaComparer.ISibala _firstRoll;

        private SibalaComparer.ISibala _secondRoll;

        [SetUp]
        public void Setup()
        {
            _firstRoll = Substitute.For<SibalaComparer.ISibala>();
            _secondRoll = Substitute.For<SibalaComparer.ISibala>();
        }

        [TestCase(EnumOutputType.NoPoint, EnumOutputType.NoPoint, 0)]
        [TestCase(EnumOutputType.NPoints, EnumOutputType.NoPoint, 1)]
        [TestCase(EnumOutputType.NoPoint, EnumOutputType.NPoints, -1)]
        [TestCase(EnumOutputType.SameColor, EnumOutputType.NoPoint, 1)]
        [TestCase(EnumOutputType.NoPoint, EnumOutputType.SameColor, -1)]
        public void Compare_ByType(EnumOutputType xOutputType, EnumOutputType yOutputType, int expected)
        {
            _firstRoll.OutputType.Returns(xOutputType);
            _secondRoll.OutputType.Returns(yOutputType);
            Assert.AreEqual(expected, SibalaComparer.Compare(_firstRoll, _secondRoll));
        }

        [Test]
        public void Compare_SameColor_1biggerThan4()
        {
            _firstRoll.OutputType.Returns(EnumOutputType.SameColor);
            _secondRoll.OutputType.Returns(EnumOutputType.SameColor);
            _firstRoll.Point.Returns(1);
            _secondRoll.Point.Returns(4);
            Assert.IsTrue(SibalaComparer.Compare(_firstRoll, _secondRoll) >  0);
        }

        [Test]
        public void Compare_SameColor_4BiggerThan6()
        {
            _firstRoll.OutputType.Returns(EnumOutputType.SameColor);
            _secondRoll.OutputType.Returns(EnumOutputType.SameColor);
            _firstRoll.Point.Returns(4);
            _secondRoll.Point.Returns(6);
            Assert.IsTrue(SibalaComparer.Compare(_firstRoll, _secondRoll) > 0);

        }

    }

    public class SibalaComparer
    {
        
        public static int Compare(ISibala x, ISibala y)
        {
            var samecolorlookup = new Dictionary<int, int>
            {
                {1,6},
                {4,5},
                {6,4},
                {5,3},
                {3,2},
                {2,1}
            };
            if (x.OutputType == y.OutputType)
            {
                if (x.OutputType == EnumOutputType.NoPoint)
                {
                    return 0;
                }

                if (x.OutputType == EnumOutputType.SameColor)
                {
                    if (samecolorlookup[x.Point] > samecolorlookup[y.Point])
                    {
                        return 1;
                    }

                    return 0;

                }
            }
            if (x.OutputType > y.OutputType)
                return 1;
            return -1;
        }

        public interface ISibala
        {
            EnumOutputType OutputType { get; }
            int Point { get; set; }
        }
    }
}