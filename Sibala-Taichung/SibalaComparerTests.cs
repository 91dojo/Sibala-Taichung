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
        
        [TestCase(EnumOutputType.NoPoint, EnumOutputType.NPoints)]
        [TestCase(EnumOutputType.NoPoint, EnumOutputType.SameColor)]
        public void Compare_ByType_SecondRoll_Wn(EnumOutputType xOutputType, EnumOutputType yOutputType)
        {
            _firstRoll.OutputType.Returns(xOutputType);
            _secondRoll.OutputType.Returns(yOutputType);
            Assert.IsTrue(SibalaComparer.Compare(_firstRoll, _secondRoll) < 0);
        }

        [TestCase(EnumOutputType.NPoints, EnumOutputType.NoPoint)]
        [TestCase(EnumOutputType.SameColor, EnumOutputType.NoPoint)]
        public void Compare_ByType_FirstRoll_Win(EnumOutputType xOutputType, EnumOutputType yOutputType)
        {
            _firstRoll.OutputType.Returns(xOutputType);
            _secondRoll.OutputType.Returns(yOutputType);
            Assert.IsTrue(SibalaComparer.Compare(_firstRoll, _secondRoll) > 0);
        }

        [Test]
        public void Compare_SameColor_1biggerThan4()
        {
            _firstRoll.OutputType.Returns(EnumOutputType.SameColor);
            _secondRoll.OutputType.Returns(EnumOutputType.SameColor);
            _firstRoll.Point.Returns(1);
            _secondRoll.Point.Returns(4);
            Assert.IsTrue(SibalaComparer.Compare(_firstRoll, _secondRoll) > 0);
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

        [Test]
        public void Compare_Diff_Point_5_Should_Bigger_than_3()
        {
            _firstRoll.OutputType.Returns(EnumOutputType.NPoints);
            _secondRoll.OutputType.Returns(EnumOutputType.NPoints);
            _firstRoll.Point.Returns(3);
            _secondRoll.Point.Returns(5);
            Assert.IsTrue(SibalaComparer.Compare(_firstRoll, _secondRoll) < 0);
        }
        [Test]
        public void Compare_Same_Point_Diff_Max_Point()
        {
            _firstRoll.OutputType.Returns(EnumOutputType.NPoints);
            _secondRoll.OutputType.Returns(EnumOutputType.NPoints);
            _firstRoll.Point.Returns(7);
            _secondRoll.Point.Returns(7);
            _firstRoll.MaxPoint.Returns(5);
            _secondRoll.MaxPoint.Returns(6);

            Assert.IsTrue(SibalaComparer.Compare(_firstRoll, _secondRoll) < 0);
        }

    }

    public class SibalaComparer
    {
        private static Dictionary<int, int> _samecolorlookup = new Dictionary<int, int>
        {
            {1, 6},
            {4, 5},
            {6, 4},
            {5, 3},
            {3, 2},
            {2, 1}
        };

        public static int Compare(ISibala firstRoll, ISibala secondRoll)
        {
            if (IsSameType(firstRoll, secondRoll))
            {
                if (IsSameColor(firstRoll))
                {
                    return _samecolorlookup[firstRoll.Point] - _samecolorlookup[secondRoll.Point];
                }
                if (firstRoll.OutputType == EnumOutputType.NPoints)
                {
                    return firstRoll.Point - secondRoll.Point;
                }

                return 0;
            }
            if (firstRoll.OutputType > secondRoll.OutputType)
            {
                return 1; 
            }
                
            return -1;
        }

        private static bool IsSameColor(ISibala x)
        {
            return x.OutputType == EnumOutputType.SameColor;
        }

        private static bool IsSameType(ISibala x, ISibala y)
        {
            return x.OutputType == y.OutputType;
        }

        public interface ISibala
        {
            EnumOutputType OutputType { get; }

            int Point { get; set; }
            int MaxPoint { get; set; }
        }
    }
}